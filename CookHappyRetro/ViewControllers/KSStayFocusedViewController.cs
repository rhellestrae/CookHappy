using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSStayFocusedViewController : UIViewController
    {
        public KSStayFocusedViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Stay Focused";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Measure Carefully") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Use Senses") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Time Ranges") { SubHeading = "33 items", ImageName = "" });

            tblStayFocused.Source = new TableSourceKSStayFocused (tableItems, this);
        }

    }
}