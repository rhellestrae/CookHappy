using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSBowlsViewController : UIViewController
    {
        public KSBowlsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Bowls";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Stir") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Toss") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Whisk") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Beat") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Whip") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Scrape") { SubHeading = "5 items", ImageName = "" });

            tblKSBowls.Source = new TableSourceKSBowls(tableItems, this);
        }

    }
}