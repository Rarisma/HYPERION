using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HYPERION_API
{
    public partial class MainPage : ContentPage
    {
        private string host = "http://192.168.0.170:5000/";
        public MainPage()
        {
            InitializeComponent();
        }

        async void SendRequest(StringContent content)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(host);

                    // method address would be like api/callUber:SomePort for example
                    var result = await client.PostAsync("Move", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                }
            }
            catch
            {

            }

        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            SendRequest(new StringContent("{\"Id\":9}", Encoding.UTF8, "application/json"));


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            SendRequest(new StringContent("{\"Id\":3}", Encoding.UTF8, "application/json"));
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            SendRequest(new StringContent("{\"Id\":1}", Encoding.UTF8, "application/json"));
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            SendRequest(new StringContent("{\"Id\":0}", Encoding.UTF8, "application/json"));
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            host = "http://" + e.NewTextValue + @"/";
        }
    }
}
