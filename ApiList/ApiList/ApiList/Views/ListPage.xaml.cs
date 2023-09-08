using ApiList.Models;
using ApiList.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel();
            LoadData();
        }

        private async void LoadData()
        {
            var viewModel = (ListPageViewModel)BindingContext;
            await viewModel.GetItems();
        }

        private void ApiList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
                return;

            var selectedApiItem = e.SelectedItem as ApiListModel;
      
            ApiList.SelectedItem = null;

            Navigation.PushAsync(new ItemDetailPage(selectedApiItem));
        }
    }


}
