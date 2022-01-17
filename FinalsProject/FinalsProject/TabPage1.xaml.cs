using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace FinalsProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage1 : ContentPage
    {
        private HttpClient httpClient = new HttpClient();
        private string endpoint = "https://api.frankfurter.app/";
        public TabPage1()
        {
            InitializeComponent();
            //TestConnection();
            GetCurrencies();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
        }



        private async void GetCurrencies()
        {
            string requestUri = endpoint + "currencies";
            // List of Dictionaries
            Dictionary<string, string> formattedResponse;
            string response = await httpClient.GetStringAsync(requestUri);
            formattedResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            List<string> keys = new List<string>(formattedResponse.Keys);

            ConvertCurrencyFrom.ItemsSource = keys;
            ConvertCurrencyTo.ItemsSource = keys;

        }
    }
}