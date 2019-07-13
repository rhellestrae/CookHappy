using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceKitchenSecrets : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        KitchenSecretsViewController owner;
	
		public TableSourceKitchenSecrets(List<TableItem> items, KitchenSecretsViewController owner)
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Cooking is not rocket science; humans have been cooking since we learned how to control fire; cooking does require attention to detail - here are four secrets to becoming a kitchen professional;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Read Carefully")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSReadCarefullyViewController ctrl = (KSReadCarefullyViewController)board.InstantiateViewController("KSReadCarefullyViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Stay Focused")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSStayFocusedViewController ctrl = (KSStayFocusedViewController)board.InstantiateViewController("KSStayFocusedViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Practice Safety")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSPracticeSafetyViewController ctrl = (KSPracticeSafetyViewController)board.InstantiateViewController("KSPracticeSafetyViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mistakes are OK")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSMistakesOKViewController ctrl = (KSMistakesOKViewController)board.InstantiateViewController("KSMistakesOKViewController");
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Cooking is not rocket science; humans have been cooking since we learned how to control fire; cooking does require attention to detail - here are four secrets to becoming a kitchen professional;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Read Carefully")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSReadCarefullyViewController ctrl = (KSReadCarefullyViewController)board.InstantiateViewController("KSReadCarefullyViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Stay Focused")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSStayFocusedViewController ctrl = (KSStayFocusedViewController)board.InstantiateViewController("KSStayFocusedViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Practice Safety")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSPracticeSafetyViewController ctrl = (KSPracticeSafetyViewController)board.InstantiateViewController("KSPracticeSafetyViewController");
                owner.NavigationController.PushViewController(ctrl, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mistakes are OK")
            {
                UIStoryboard board = UIStoryboard.FromName("Main", null);
                KSMistakesOKViewController ctrl = (KSMistakesOKViewController)board.InstantiateViewController("KSMistakesOKViewController");
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