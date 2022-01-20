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
            //ConvertCurrency(1.0, "USD", "PHP");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ConvertCurrency(double.Parse(ConvertAmountFrom.Text), ConvertCurrencyFrom.SelectedItem.ToString(), ConvertCurrencyTo.SelectedItem.ToString());
            // Task<double> convertedAmount = ConvertCurrency(double.Parse(ConvertAmountFrom.Text),
            //    ConvertCurrencyFrom.SelectedItem.ToString(),
            //    ConvertCurrencyTo.SelectedItem.ToString());
            //ConvertAmountTo.Text = convertedAmount.Result.ToString();
        }

        private async void ConvertCurrency(double AmountFrom, string CurrencyFrom, string CurrencyTo)
        {
            double amountTo = 0.0;

            // call the api
            // supply the parameters
            string requestUri = endpoint +
                "latest?amount=" + AmountFrom +
                "&from=" + CurrencyFrom +
                "&to=" + CurrencyTo;
            string response = await httpClient.GetStringAsync(requestUri);
            
            Currency formattedResponse;
            formattedResponse = JsonConvert.DeserializeObject<Currency>(response);
            //ConvertAmountTo.Text = formattedResponse.date;
            Dictionary<string, string> rates = formattedResponse.rates;
            string amountString;
            rates.TryGetValue(CurrencyTo, out amountString);
            //amountTo = double.Parse(amountString);


            ConvertAmountTo.Text = amountString;
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