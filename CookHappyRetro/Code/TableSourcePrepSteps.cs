using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourcePrepSteps : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        PrepStepsViewController owner;
	
		public TableSourcePrepSteps(List<TableItem> items, PrepStepsViewController owner)
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Most ingredients must be prepared before they can be used in a recipe; learn how to prepare seven ingredients - and you will be able to make many recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Crack, Separate Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Crack, Separate Eggs", "Unless hard-cooking eggs, start by cracking open; in some recipes, separate yolk (yellow part) and white (clear part) - and use differently; cold eggs are easier to separate; 1) to crack: gently hit side of egg against flat surface of counter, cutting board; 2) pull shell apart into two pieces over bowl; let yolk, white drop into bowl; discard shell; 3) to separate yolk, white: use hand to gently transfer yolk to second bowl;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Melt Butter")
            {
                UIAlertController okAlertController = UIAlertController.Create("Melt Butter", "Butter can be melted in a small saucepan on stove (use medium-low heat), but microwave is easier; 1) cut butter into one-tablespoon pieces; place butter in microwave-sage bowl; 2) place bowl in microwave, cover bowl with small plate; use 50% power to heat butter until melted, 30 to 60 seconds - longer if melting a lot of butter; watch butter, stop microwave as soon as butter has melted; use oven mitts to remove bowl from microwave;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mince Garlic")
            {
                UIAlertController okAlertController = UIAlertController.Create("Mince Garlic", "Garlic is sticky, so you may need to carefully wipe it from sides of knife to get pieces of garlic onto cutting board - where you can cut them; you can also use a garlic press to both peel, mince garlic; 1) crush clove with bottom of measuring cup to loosen papery skin; use fingers to remove, discard papery skin; 2) place one hand on handle of chef's knife, rest fingers of hand on top of blade; use rocking motion, pivoting knife as you chop garlic repeatedly to cut it into small pieces;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop Onions, Shallots")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop Onions, Shallots", "Shallots are smaller, milder cousins to onions; if working with a small shallot - there is no need to cut it in half; 1) halve onion through root end - then use fingers to remove peel; trim top of onion; 2) place onion half flat side down; starting one inch from root end - make several vertical cuts; 3) rotate onion, slice across first cuts; as you slice - onion will fall apart into chopped pieces;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop Fresh Herbs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop French Herbs", "Fresh herbs need to be washed, dried before they are chopped - or minced; 1) use fingers to remove leaves from stems- discard stems; 2) gather leaves into small pile; place one hand on handle of chef's knife, rest fingers of other hand on top of blade; use rocking motion - pivoting knife as you chop;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Grate, Shred Cheese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Grate, Shred Cheese", "Cheese is often cut into small pieces to flavor pasta, egg dishes, quesadillas; when grating, shredding - use a big piece of cheese so hand stays safely away from sharp holes; 1) to grate: hard cheeses such as parmesan can be rubbed against a rasp grater- or small holes of a box grater to make a fluffy pile of cheese; 2) to shred: semisoft cheeses such as cheddar, mozzarella can be rubbed against large holes of a box grater to make long pieces of cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Zest, Juice Fruit")
            {
                UIAlertController okAlertController = UIAlertController.Create("Zest, Juice Fruit", "Flavorful skin from lemons, limes oranges (called zest) is often removed, used in recipes; if you need zest, it is best to zest before juicing; after juicing - use a small spoon to remove any seeds from bowl of juice; 1) to zest: rub fruit against rasp grater to remove zest; turn fruit as you go to avoid bitter white layer underneath zest; 2) to huice: cut fruit in half through equator - not through ends; 3) place one half of fruit in citrus juicer; hold juicer over bowl, squeeze to extract juice;", UIAlertControllerStyle.Alert);
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "Most ingredients must be prepared before they can be used in a recipe; learn how to prepare seven ingredients - and you will be able to make many recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Crack, Separate Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Crack, Separate Eggs", "Unless hard-cooking eggs, start by cracking open; in some recipes, separate yolk (yellow part) and white (clear part) - and use differently; cold eggs are easier to separate; 1) to crack: gently hit side of egg against flat surface of counter, cutting board; 2) pull shell apart into two pieces over bowl; let yolk, white drop into bowl; discard shell; 3) to separate yolk, white: use hand to gently transfer yolk to second bowl;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Melt Butter")
            {
                UIAlertController okAlertController = UIAlertController.Create("Melt Butter", "Butter can be melted in a small saucepan on stove (use medium-low heat), but microwave is easier; 1) cut butter into one-tablespoon pieces; place butter in microwave-sage bowl; 2) place bowl in microwave, cover bowl with small plate; use 50% power to heat butter until melted, 30 to 60 seconds - longer if melting a lot of butter; watch butter, stop microwave as soon as butter has melted; use oven mitts to remove bowl from microwave;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Mince Garlic")
            {
                UIAlertController okAlertController = UIAlertController.Create("Mince Garlic", "Garlic is sticky, so you may need to carefully wipe it from sides of knife to get pieces of garlic onto cutting board - where you can cut them; you can also use a garlic press to both peel, mince garlic; 1) crush clove with bottom of measuring cup to loosen papery skin; use fingers to remove, discard papery skin; 2) place one hand on handle of chef's knife, rest fingers of hand on top of blade; use rocking motion, pivoting knife as you chop garlic repeatedly to cut it into small pieces;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop Onions, Shallots")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop Onions, Shallots", "Shallots are smaller, milder cousins to onions; if working with a small shallot - there is no need to cut it in half; 1) halve onion through root end - then use fingers to remove peel; trim top of onion; 2) place onion half flat side down; starting one inch from root end - make several vertical cuts; 3) rotate onion, slice across first cuts; as you slice - onion will fall apart into chopped pieces;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Chop Fresh Herbs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Chop French Herbs", "Fresh herbs need to be washed, dried before they are chopped - or minced; 1) use fingers to remove leaves from stems- discard stems; 2) gather leaves into small pile; place one hand on handle of chef's knife, rest fingers of other hand on top of blade; use rocking motion - pivoting knife as you chop;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Grate, Shred Cheese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Grate, Shred Cheese", "Cheese is often cut into small pieces to flavor pasta, egg dishes, quesadillas; when grating, shredding - use a big piece of cheese so hand stays safely away from sharp holes; 1) to grate: hard cheeses such as parmesan can be rubbed against a rasp grater- or small holes of a box grater to make a fluffy pile of cheese; 2) to shred: semisoft cheeses such as cheddar, mozzarella can be rubbed against large holes of a box grater to make long pieces of cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Zest, Juice Fruit")
            {
                UIAlertController okAlertController = UIAlertController.Create("Zest, Juice Fruit", "Flavorful skin from lemons, limes oranges (called zest) is often removed, used in recipes; if you need zest, it is best to zest before juicing; after juicing - use a small spoon to remove any seeds from bowl of juice; 1) to zest: rub fruit against rasp grater to remove zest; turn fruit as you go to avoid bitter white layer underneath zest; 2) to huice: cut fruit in half through equator - not through ends; 3) place one half of fruit in citrus juicer; hold juicer over bowl, squeeze to extract juice;", UIAlertControllerStyle.Alert);
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