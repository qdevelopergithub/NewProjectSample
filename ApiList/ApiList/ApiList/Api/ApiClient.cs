using ApiList.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ApiList.Api
{
    public class ApiClient
    {
        public async Task<Result<T>> Get<T>(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Check for internet connection
                    var current = Xamarin.Essentials.Connectivity.NetworkAccess;
                    if (current != Xamarin.Essentials.NetworkAccess.Internet)
                    {
                        var error = "No internet connection";
                        await Application.Current.MainPage.DisplayAlert("Error", error, "OK");
                        // No internet connection, return a failed result
                        return new Result<T>
                        {
                            IsSuccess = false,
                            ErrorMessage = error
                        };
                    }

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<T>(json);

                    return new Result<T>
                    {
                        IsSuccess = true,
                        Data = data
                    };
                }
                catch (Exception ex)
                {
                    // Show an alert with the error message
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

                    // Return a failed result
                    return new Result<T>
                    {
                        IsSuccess = false,
                        ErrorMessage = ex.Message
                    };
                }
            }
        }
    }
}
