using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKSHeat : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KSHeatViewController owner;
	
		public TableSourceKSHeat(List<TableItem> items, KSHeatViewController owner)
		{
			tableItems = items;
			this.owner = owner;
		}
	
		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}
		
		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
            if (tableItems[indexPath.Row].Heading == "Melt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Melt", "To heat solid food (think butter) on stovetop, or in microwave until it becomes a liquid;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Heat until Shimmer")
            {
                UIAlertController okAlertController = UIAlertController.Create("Heat until Shimmer", "To heat oil in a pan until it begins to move slightly - which indicates oil is hot enough for cooking; if oil starts to smoke, it has been overheated, and you can start over with fresh oil;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Simmer")
            {
                UIAlertController okAlertController = UIAlertController.Create("Simmer", "To heat liquid until small bubbles gently break surface at a variable, infrequent rate - as when cooking a soup;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Boil")
            {
                UIAlertController okAlertController = UIAlertController.Create("Boil", "To heat liquid until large bubbles break surface at a rapid, constant rate - as when cooking pasta;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Toast")
            {
                UIAlertController okAlertController = UIAlertController.Create("Toast", "To heat food (nuts, bread) in a skillet, toaster, oven until golden brown, fragrant;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
           
        }

        /// <summary>
        /// Called when the DetailDisclosureButton is touched.
        /// Does nothing if DetailDisclosureButton isn't in the cell
        /// </summary>
        public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
		{
            if (tableItems[indexPath.Row].Heading == "Melt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Melt", "To heat solid food (think butter) on stovetop, or in microwave until it becomes a liquid;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Heat until Shimmer")
            {
                UIAlertController okAlertController = UIAlertController.Create("Heat until Shimmer", "To heat oil in a pan until it begins to move slightly - which indicates oil is hot enough for cooking; if oil starts to smoke, it has been overheated, and you can start over with fresh oil;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Simmer")
            {
                UIAlertController okAlertController = UIAlertController.Create("Simmer", "To heat liquid until small bubbles gently break surface at a variable, infrequent rate - as when cooking a soup;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Boil")
            {
                UIAlertController okAlertController = UIAlertController.Create("Boil", "To heat liquid until large bubbles break surface at a rapid, constant rate - as when cooking pasta;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Toast")
            {
                UIAlertController okAlertController = UIAlertController.Create("Toast", "To heat food (nuts, bread) in a skillet, toaster, oven until golden brown, fragrant;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
        }

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			var cellStyle = UITableViewCellStyle.Default;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new UITableViewCell (cellStyle, cellIdentifier);
			}

			cell.Accessory = UITableViewCellAccessory.DetailButton;
			
			cell.TextLabel.Text = tableItems[indexPath.Row].Heading;
			
			// Default style doesn't support Subtitle
			if (cellStyle == UITableViewCellStyle.Subtitle 
			   || cellStyle == UITableViewCellStyle.Value1
			   || cellStyle == UITableViewCellStyle.Value2) {
				cell.DetailTextLabel.Text = tableItems[indexPath.Row].SubHeading;
			}
			
			// Value2 style doesn't support an image
			if (cellStyle != UITableViewCellStyle.Value2)
				cell.ImageView.Image = UIImage.FromFile ("Images/" +tableItems[indexPath.Row].ImageName);
			
			return cell;
		}
	}
}