using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKSSharpTools : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KSSharpToolsViewController owner;
	
		public TableSourceKSSharpTools(List<TableItem> items, KSSharpToolsViewController owner)
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
            if (tableItems[indexPath.Row].Heading == "Peel")
            {
                UIAlertController okAlertController = UIAlertController.Create("Peel", "To remove outer skin, rind, layer from food - usually a piece of fruit, vegetable; often done with a vegetable peeler;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Zest")
            {
                UIAlertController okAlertController = UIAlertController.Create("Zest", "To remove flavorful outer peel from a lemon, lime, orange; does not include bitter white layer, called pith, under zest;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop", "To cut food with knife into small pieces; chopped fine - 1/8 to 1/4 inch pieces; chopped - 1/4 to 1/2 inch pieces; chopped coarse - 1/2 to 3/4 inch pieces; use ruler to understand doifferent sizes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mince")
            {
                UIAlertController okAlertController = UIAlertController.Create("Mince", "To cut food with knife into 1/8 inch pieces - or smaller;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Slice")
            {
                UIAlertController okAlertController = UIAlertController.Create("Slice", "To cut food with knife into pieces with two flat sides - with thickness dependent on recipe instructions; for example, slicing a celery stalk;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Grate")
            {
                UIAlertController okAlertController = UIAlertController.Create("Grate", "To cut food, often cheese, into small, uniform pieces - using a rasp grater, or small holes on a box grater;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Shred")
            {
                UIAlertController okAlertController = UIAlertController.Create("Shred", "To cut food (often cheese, also vegatables & fruits) into small, uniform pieces using large holes on a box grater - or shredding disk of food processor;", UIAlertControllerStyle.Alert);
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
            if (tableItems[indexPath.Row].Heading == "Peel")
            {
                UIAlertController okAlertController = UIAlertController.Create("Peel", "To remove outer skin, rind, layer from food - usually a piece of fruit, vegetable; often done with a vegetable peeler;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Zest")
            {
                UIAlertController okAlertController = UIAlertController.Create("Zest", "To remove flavorful outer peel from a lemon, lime, orange; does not include bitter white layer, called pith, under zest;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop", "To cut food with knife into small pieces; chopped fine - 1/8 to 1/4 inch pieces; chopped - 1/4 to 1/2 inch pieces; chopped coarse - 1/2 to 3/4 inch pieces; use ruler to understand doifferent sizes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mince")
            {
                UIAlertController okAlertController = UIAlertController.Create("Mince", "To cut food with knife into 1/8 inch pieces - or smaller;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Slice")
            {
                UIAlertController okAlertController = UIAlertController.Create("Slice", "To cut food with knife into pieces with two flat sides - with thickness dependent on recipe instructions; for example, slicing a celery stalk;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Grate")
            {
                UIAlertController okAlertController = UIAlertController.Create("Grate", "To cut food, often cheese, into small, uniform pieces - using a rasp grater, or small holes on a box grater;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Shred")
            {
                UIAlertController okAlertController = UIAlertController.Create("Shred", "To cut food (often cheese, also vegatables & fruits) into small, uniform pieces using large holes on a box grater - or shredding disk of food processor;", UIAlertControllerStyle.Alert);
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