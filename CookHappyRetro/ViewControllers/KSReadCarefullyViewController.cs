using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class KSReadCarefullyViewController : UIViewController
    {
        public KSReadCarefullyViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Read Carefully";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Start with Statistics") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Right Ingredients, Equipment") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Follow Recipe") { SubHeading = "33 items", ImageName = "" });

            tblReadCarefully.Source = new TableSourceKSReadCarefully(tableItems, this);
        }

    }
}