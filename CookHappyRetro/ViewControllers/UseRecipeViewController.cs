using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class UseRecipeViewController : UIViewController
    {
        public UseRecipeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Use a Recipe";
            View.BackgroundColor = UIColor.White;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Prepare Ingredients") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Gather Cooking Equipment") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Start Cooking") { SubHeading = "33 items", ImageName = "" });
          
            tblUseRecipe.Source = new TableSource(tableItems, this);
        }
    }
}