using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKSBowls : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KSBowlsViewController owner;
	
		public TableSourceKSBowls(List<TableItem> items, KSBowlsViewController owner)
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
            if (tableItems[indexPath.Row].Heading == "Stir")
            {
                UIAlertController okAlertController = UIAlertController.Create("Stir", "To combine ingredients in bowl, cooking vessel - often with rubber spatula, wooden spoon;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Toss")
            {
                UIAlertController okAlertController = UIAlertController.Create("Toss", "To gently combine ingredients with tongs, two forks and/or spoons - in order to distribute ingredients evenly; toss salad in bowl - don't stir;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Whisk")
            {
                UIAlertController okAlertController = UIAlertController.Create("Whisk", "To combine ingredients with a whisk until uniform, evenly incorporated; for example, whisk whole eggs, before srambling;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Beat")
            {
                UIAlertController okAlertController = UIAlertController.Create("Beat", "To combine vigorously with whisk, fork, electric mixer - often with goal of adding air to increase volume of ingredients, such as beating butter and sugar together to make cookie dough;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Whip")
            {
                UIAlertController okAlertController = UIAlertController.Create("Whip", "To combine vigorously with a whisk, electric mixer - with goal of adding air to increase volume of ingredients, such as whipping cream or egg whites;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Scrape")
            {
                UIAlertController okAlertController = UIAlertController.Create("Scrape", "To push ingredients on sides of bowl, pan, blender, jar, food processor back into center; a rubber spatula is best tool;", UIAlertControllerStyle.Alert);
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
            if (tableItems[indexPath.Row].Heading == "Stir")
            {
                UIAlertController okAlertController = UIAlertController.Create("Stir", "To combine ingredients in bowl, cooking vessel - often with rubber spatula, wooden spoon;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Toss")
            {
                UIAlertController okAlertController = UIAlertController.Create("Toss", "To gently combine ingredients with tongs, two forks and/or spoons - in order to distribute ingredients evenly; toss salad in bowl - don't stir;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Whisk")
            {
                UIAlertController okAlertController = UIAlertController.Create("Whisk", "To combine ingredients with a whisk until uniform, evenly incorporated; for example, whisk whole eggs, before srambling;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Beat")
            {
                UIAlertController okAlertController = UIAlertController.Create("Beat", "To combine vigorously with whisk, fork, electric mixer - often with goal of adding air to increase volume of ingredients, such as beating butter and sugar together to make cookie dough;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Whip")
            {
                UIAlertController okAlertController = UIAlertController.Create("Whip", "To combine vigorously with a whisk, electric mixer - with goal of adding air to increase volume of ingredients, such as whipping cream or egg whites;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Scrape")
            {
                UIAlertController okAlertController = UIAlertController.Create("Scrape", "To push ingredients on sides of bowl, pan, blender, jar, food processor back into center; a rubber spatula is best tool;", UIAlertControllerStyle.Alert);
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