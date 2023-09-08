using ApiList.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using ApiList.ViewModels;
using ApiList.Models;

namespace ApiList.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(ApiListModel Item)
        {
            InitializeComponent();
            BindingContext =Item;
        }
    }
}