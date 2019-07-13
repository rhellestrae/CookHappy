using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSMistakesOKViewController : UIViewController
    {
        UIImageView imageView;

        public KSMistakesOKViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Mistakes are OK";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Next Time") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Enjoy Mistakes") { SubHeading = "5 items", ImageName = "" });

            tblMistakesOK.Source = new TableSourceKSMistakesOK(tableItems, this);
        }

    }
}