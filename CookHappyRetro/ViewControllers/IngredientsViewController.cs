using Foundation;
using System;
using UIKit;

using CoreGraphics;
using System.Collections.Generic;

namespace CookHappyRetro
{
    public partial class IngredientsViewController : UIViewController
    {
        UITableView table;

        public IngredientsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Ingredients";
            View.BackgroundColor = UIColor.White;

            table = new UITableView(View.Bounds); // defaults to Plain style
            table.Frame = new CGRect(0, 50, View.Bounds.Width, 648);
            table.AutoresizingMask = UIViewAutoresizing.All;

            List<TableItem> tableItems = new List<TableItem>();

            tableItems.Add(new TableItem("Overview") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Salt") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Pepper") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Oil") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Butter") { SubHeading = "65 items", ImageName = "" });
            tableItems.Add(new TableItem("Eggs") { SubHeading = "17 items", ImageName = "" });
            tableItems.Add(new TableItem("Milk & Dairy") { SubHeading = "5 items", ImageName = "" });
            tableItems.Add(new TableItem("Broth") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Herbs") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Spices") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Garlic & Onions") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Baking Powder, Soda") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Flour") { SubHeading = "33 items", ImageName = "" });
            tableItems.Add(new TableItem("Sugar") { SubHeading = "33 items", ImageName = "" });

            table.Source = new TableSourceIngredients(tableItems, this);

            View.AddSubview(table);
        }

    }
}