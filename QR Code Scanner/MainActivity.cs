using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using ZXing;

namespace QR_Code_Scanner
{
	[Activity(Label = "QR_Code_Scanner", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			ImageView view = FindViewById<ImageView> (Resource.Id.qrCodeView);
			Button scannerButton = FindViewById<Button> (Resource.Id.scannerButton);
			view.SetImageBitmap (GetQRCode ());

			scannerButton.Click += async (sender, e) => {
				var scanner = new ZXing.Mobile.MobileBarcodeScanner(this);
				var result = await scanner.Scan();

				//Console.WriteLine(result.Text);
				Toast.MakeText(this, result.Text, ToastLength.Long).Show();

			};
		}

		private Bitmap GetQRCode()
		{
			var writer = new BarcodeWriter 
			{
				Format = BarcodeFormat.QR_CODE,
				Options = new ZXing.Common.EncodingOptions 
				{
					Height = 600,
					Width = 600
				}
			};
			return  writer.Write ("Varun Rathore");
		}
	}
}

