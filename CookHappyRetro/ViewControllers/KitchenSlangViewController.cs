using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KitchenSlangViewController : UIViewController
    {
        public KitchenSlangViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Kitchen Slang";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Sharp Tools") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Bowls") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Heat") { SubHeading = "33 items", ImageName = "" });
          
            tblKitchenSlang.Source = new TableSourceKitchenSlang(tableItems, this);
        }

    }
}