using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSSharpToolsViewController : UIViewController
    {
        public KSSharpToolsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Sharp Tools";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Peel") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Zest") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Chop") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Mince") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Slice") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Grate") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Shred") { SubHeading = "33 items", ImageName = "" });

            tblKSSharpTools.Source = new TableSourceKSSharpTools(tableItems, this);
        }

    }
}