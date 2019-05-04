﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FluidApp.Annotations;
using GalaSoft.MvvmLight.Command;
using Models;

namespace FluidApp
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Propeties

        private bool _erGodkendt;
        public bool erGodkendt
        {
            get { return _erGodkendt; }
            set
            {
                if (value != _erGodkendt)
                {
                    _erGodkendt = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("erGodkendt"));
                }
            }
        }
        private string _brugernavn;
        public string Brugernavn
        {
            get { return _brugernavn; }
            set
            {
                _brugernavn = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Brugernavn"));
            }
        }
        private string _kodeord;

        public string Kodeord
        {
            get { return _kodeord; }
            set
            {
                _kodeord = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Kodeord"));
            }
        }

        #endregion


        public ICommand LoginCommand
        {
            get { return new RelayCommand(() => Login()); }
        }


        public void Login()
        {
            //TODO check username and password vs database here.

            Administrator admin = new Administrator();

            // Brugernavn == "Test" && Kodeord == "Test kodeord")

            foreach (var godkendt in admin.GetAll())
            {
                
                if (Brugernavn == godkendt.Brugernavn && Kodeord == godkendt.Kodeord)
                {

                    erGodkendt = true;
                    //var frame = new Frame();
                    //frame.Navigate(typeof(Kolonne), null);
                    //Window.Current.Content = frame;

                }
            }

            
            if (!String.IsNullOrEmpty(Brugernavn) && !String.IsNullOrEmpty(Kodeord))
                erGodkendt = true;
        }

        

        #region MyRegion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs propertyname,
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}
