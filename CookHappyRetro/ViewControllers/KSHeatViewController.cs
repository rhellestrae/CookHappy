using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSHeatViewController : UIViewController
    {
        public KSHeatViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Heat";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Melt") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Heat until Shimmer") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Simmer") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Boil") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Toast") { SubHeading = "17 items", ImageName = "" });

            tblKSHeat.Source = new TableSourceKSHeat(tableItems, this);
        }

    }
}