using ApiList.ViewModels;
using ApiList.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ApiList
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
