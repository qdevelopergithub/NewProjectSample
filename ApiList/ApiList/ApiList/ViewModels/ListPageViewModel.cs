using ApiList.Api;
using ApiList.Constants;
using ApiList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ApiList.ViewModels
{
    public class ListPageViewModel
    {
        public ObservableCollection<ApiListModel> Items { get; set; }

        public ListPageViewModel()
        {
            Items = new ObservableCollection<ApiListModel>();
        }

        public async Task GetItems()
        {
            var apiClient = new ApiClient();
            var url = $"{ConstantStrings.BaseUrl}{ConstantStrings.Todos}";
            var response = await apiClient.Get<List<ApiListModel>>(url);
            if (response.IsSuccess)
            {
                foreach (var item in response.Data)
                {
                    Items.Add(item);
                }
            }
        }
    }
}
