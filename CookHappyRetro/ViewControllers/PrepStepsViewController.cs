using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class PrepStepsViewController : UIViewController
    {
        UIImageView imageView;

        public PrepStepsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Prepare and Cook";
            View.BackgroundColor = UIColor.White;

            // imageView = new UIImageView(UIImage.FromFile("PreparationSteps.png"));
            // imageView.Frame = new CGRect(0, 100, View.Bounds.Width, 44);

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Crack, Separate Eggs") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Melt Butter") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Mince Garlic") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Chop Onions, Shallots") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Chop Fresh Herbs") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Grate, Shred Cheese") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Zest, Juice Fruit") { SubHeading = "33 items", ImageName = "" });

            tblPrepSteps.Source = new TableSourcePrepSteps(tableItems, this);

            // View.AddSubview(imageView);
        }

    }
}