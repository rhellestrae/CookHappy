using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKitchenSlang : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KitchenSlangViewController owner;
	
		public TableSourceKitchenSlang(List<TableItem> items, KitchenSlangViewController owner)
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
            if (tableItems[indexPath.Row].Heading == "Overview")
            {
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Reading a recipe can feel like reading a foreign language; here are common words in recipes - and what they mean;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Sharp Tools")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSSharpToolsViewController ctrl = (KSSharpToolsViewController)board.InstantiateViewController("KSSharpToolsViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Bowls")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSBowlsViewController ctrl = (KSBowlsViewController)board.InstantiateViewController("KSBowlsViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Heat")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSHeatViewController ctrl = (KSHeatViewController)board.InstantiateViewController("KSHeatViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
        }

        /// <summary>
        /// Called when the DetailDisclosureButton is touched.
        /// Does nothing if DetailDisclosureButton isn't in the cell
        /// </summary>
        public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
		{
            if (tableItems[indexPath.Row].Heading == "Overview")
            {
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Reading a recipe can feel like reading a foreign language; here are common words in recipes - and what they mean;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Sharp Tools")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSSharpToolsViewController ctrl = (KSSharpToolsViewController)board.InstantiateViewController("KSSharpToolsViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Bowls")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSBowlsViewController ctrl = (KSBowlsViewController)board.InstantiateViewController("KSBowlsViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Heat")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSHeatViewController ctrl = (KSHeatViewController)board.InstantiateViewController("KSHeatViewController");
                owner.NavigationController.PushViewController(ctrl, true);
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