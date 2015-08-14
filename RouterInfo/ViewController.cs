using System;

using UIKit;
using SystemConfiguration;
using Foundation;
using System.Threading.Tasks;

namespace RouterInfo
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			Task.Run (() => {
				string[] supportedInterfaces;
				if (CaptiveNetwork.TryGetSupportedInterfaces (out supportedInterfaces) == StatusCode.OK && supportedInterfaces != null && supportedInterfaces.Length > 0) {
					foreach (var si in supportedInterfaces) {
						NSDictionary networkInfo;
						if (CaptiveNetwork.TryCopyCurrentNetworkInfo(si, out networkInfo) == StatusCode.OK) {
							if (networkInfo.Count > 0) {
								NSObject value;
								if (networkInfo.TryGetValue(CaptiveNetwork.NetworkInfoKeySSID, out value)) {
									BeginInvokeOnMainThread (() => {
										lblSsid.Text = string.Format("SSID: {0}", value);
									});
								}
								if (networkInfo.TryGetValue(CaptiveNetwork.NetworkInfoKeyBSSID, out value)) {
									BeginInvokeOnMainThread (() => {
										lblBssid.Text = string.Format("BSSID: {0}", value);
									});
								}
								if (networkInfo.TryGetValue(CaptiveNetwork.NetworkInfoKeySSIDData, out value)) {
									BeginInvokeOnMainThread (() => {
										lblSsidData.Text = string.Format("SSID Data: {0}", value);
									});
								}
							}
						}
					}
				} else {
					BeginInvokeOnMainThread(() => {
						var alert = new UIAlertView("Error", "Cannot get network info!", null, "Ok");
						alert.Show();
					});
				}
			});
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}

