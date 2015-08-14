// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RouterInfo
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblBssid { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSsid { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSsidData { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblBssid != null) {
				lblBssid.Dispose ();
				lblBssid = null;
			}
			if (lblSsid != null) {
				lblSsid.Dispose ();
				lblSsid = null;
			}
			if (lblSsidData != null) {
				lblSsidData.Dispose ();
				lblSsidData = null;
			}
		}
	}
}
