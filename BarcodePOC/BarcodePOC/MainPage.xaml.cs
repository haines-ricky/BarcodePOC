using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace BarcodePOC
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        async void OnScanRequest(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
            

            // Navigate to our scanner page
            try
            {
                await Navigation.PushAsync(scanPage);
            }
            catch (Exception ex){
                await this.DisplayAlert(
                    "Error",
                    "Exception: "+ex.Message,
                    "Ok!");
            }

        }

        async void TestButton(object sender, EventArgs e)
        {
            await this.DisplayAlert(
                    "OnScanRequest",
                    "Barcode scan requested!",
                    "Ok!");
        }
    }
}
