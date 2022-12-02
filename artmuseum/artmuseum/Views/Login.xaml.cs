//using System;
//using System.Collections.Generic;
using artmuseum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace artmuseum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        VMLogin vmLogin;
        public Login()
        {
            InitializeComponent();
            vmLogin = new VMLogin();
            BindingContext = vmLogin;
        }

    }
}
