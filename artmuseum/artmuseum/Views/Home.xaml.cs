using System;
using System.Collections.Generic;

using artmuseum.Models;
using artmuseum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace artmuseum.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
	{
        VMHome vmHome;
        public Home (UserDetails userDetails)
		{
			InitializeComponent ();
            vmHome = new VMHome(userDetails);
            BindingContext = vmHome;

        }

    }
}

