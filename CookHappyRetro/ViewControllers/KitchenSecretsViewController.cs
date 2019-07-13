using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KitchenSecretsViewController : UIViewController
    {
        UIImageView imageView;

        public KitchenSecretsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Kitchen Secrets";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Read Carefully") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Stay Focused") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Practice Safety") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Mistakes are OK") { SubHeading = "33 items", ImageName = "" });

            tblKitchenSecrets.Source = new TableSourceKitchenSecrets(tableItems, this);
        }

    }
}