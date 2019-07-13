using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSPracticeSafetyViewController : UIViewController
    {
        UIImageView imageView;

        public KSPracticeSafetyViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Practice Safety";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Use Right Knife") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Hot Stovetops, Ovens") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Wash Hands") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Raw Foods") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Attend to Stove") { SubHeading = "5 items", ImageName = "" });

            tblPracticeSafety.Source = new TableSourceKSPracticeSafety(tableItems, this);
        }

    }
}