using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKSReadCarefully : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KSReadCarefullyViewController owner;
	
		public TableSourceKSReadCarefully(List<TableItem> items, KSReadCarefullyViewController owner)
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "If you are learning to cook - chances are you are reading a recipe; it will take time to understand language used in recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Start with Statistics")
            {
                UIAlertController okAlertController = UIAlertController.Create("Start with Statistics", "Start with key statistics; how much food does recipe make? how long will it take? when you are hungry for an after-school snack, choose a recipe that serves one, two people - and takes 15 minutes to prepare, rather than an hour;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Right Ingredients, Equipment")
            {
                UIAlertController okAlertController = UIAlertController.Create("Right Ingredients, Equipment", "Make sure you have right ingredients, equipment; don't start a guacamole recipe only to realize there are no avocados in kitchen; likewise, don't prepare batter for a cake before making sure you have right size cake pan;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Follow Recipe")
            {
                UIAlertController okAlertController = UIAlertController.Create("Follow Recipe", "Follow recipe as written - at least first time; you can always improvise once you understand how recipe works; customize recipes to suit your taste;", UIAlertControllerStyle.Alert);
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
            if (tableItems[indexPath.Row].Heading == "Overview")
            {
                UIAlertController okAlertController = UIAlertController.Create("Overview", "If you are learning to cook - chances are you are reading a recipe; it will take time to understand language used in recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Start with Statistics")
            {
                UIAlertController okAlertController = UIAlertController.Create("Start with Statistics", "Start with key statistics; how much food does recipe make? how long will it take? when you are hungry for an after-school snack, choose a recipe that serves one, two people - and takes 15 minutes to prepare, rather than an hour;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Right Ingredients, Equipment")
            {
                UIAlertController okAlertController = UIAlertController.Create("Right Ingredients, Equipment", "Make sure you have right ingredients, equipment; don't start a guacamole recipe only to realize there are no avocados in kitchen; likewise, don't prepare batter for a cake before making sure you have right size cake pan;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Follow Recipe")
            {
                UIAlertController okAlertController = UIAlertController.Create("Follow Recipe", "Follow recipe as written - at least first time; you can always improvise once you understand how recipe works;", UIAlertControllerStyle.Alert);
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