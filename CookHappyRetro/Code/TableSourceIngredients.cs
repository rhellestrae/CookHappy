using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
	public class TableSourceIngredients : UITableViewSource 
    {
		List<TableItem> tableItems;

        string cellIdentifier = "TableCell";

        IngredientsViewController owner;
	
		public TableSourceIngredients(List<TableItem> items, IngredientsViewController owner)
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "A well-stocked pantry means ready to cook; here are items to keep on hand, notes on what to buy;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Salt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Salt", "There are many kinds of salt; table - fine crystals kept in a shaker; sea - larger, chunkier and more is required;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Pepper")
            {
                UIAlertController okAlertController = UIAlertController.Create("Pepper", "Whole peppercorns, freshly ground in a pepper mill, are more flavorful than ground pepper bought in supermarket;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Oil")
            {
                UIAlertController okAlertController = UIAlertController.Create("Oil", "Use extra-virgin olive oil in recipes if flavor is important - such as salad dressing; bland vegetable oil is useful in many cooking, baking recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Butter")
            {
                UIAlertController okAlertController = UIAlertController.Create("Butter", "Use un-salted butter; salted butter is great on toast - but can make foods too salty;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Eggs", "Most recipes call for large eggs; use different sizes in egg dishes - such as an omelet; in baking recipes - use size for which recipe calls;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Milk & Dairy")
            {
                UIAlertController okAlertController = UIAlertController.Create("Milk & Dairy", "Milk, cream, half-and-half, yogurt, sour cream are common ingredients; while low-fat milk, whole milk will work same way in most recipes - don't use milk in a recipe which calls for cream;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Broth")
            {
                UIAlertController okAlertController = UIAlertController.Create("Broth", "Store-bought chicken broth, vegetable broth can be used inter-changeably in most recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Herbs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Herbs", "Fresh herbs add more flavor to dishes than dried dishes; dried oregano, thyme are OK - don't bother with dried parsley, basil, cilantro;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Spices")
            {
                UIAlertController okAlertController = UIAlertController.Create("Spices", "Ground spices - such as cumin, chili powder add flavor; keep spices in pantry for up to one year - then purchase fresh jars;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Garlic & Onions")
            {
                UIAlertController okAlertController = UIAlertController.Create("Garlic & Onions", "Many recipes call for garlic, onions; flavorful ingredients require prep, stored in pantry - not fridge;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Baking Powder, Soda")
            {
                UIAlertController okAlertController = UIAlertController.Create("Baking Powder, Soda", "Leaveners are essential in pancakes, muffins, cakes, cookies - and are not interchangeable; if activated - produce carbon dioxide, helps baked goods rise;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Flour")
            {
                UIAlertController okAlertController = UIAlertController.Create("Flour", "Stock all-purpose flour in pantry - works well in a wide range of recipes, from cakes to cookies;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Sugar")
            {
                UIAlertController okAlertController = UIAlertController.Create("Sugar", "Granulated white sugar is most commonly used sweetener, although some recipes call for confectioners' sugar or brown sugar - use either light or dark, unless recipe specifies otherwise;", UIAlertControllerStyle.Alert);
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
                UIAlertController okAlertController = UIAlertController.Create("Overview", "A well-stocked pantry means ready to cook; here are items to keep on hand, notes on what to buy;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Salt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Salt", "There are many kinds of salt; table - fine crystals kept in a shaker; sea - larger, chunkier and more is required;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Pepper")
            {
                UIAlertController okAlertController = UIAlertController.Create("Pepper", "Whole peppercorns, freshly ground in a pepper mill, are more flavorful than ground pepper bought in supermarket;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Oil")
            {
                UIAlertController okAlertController = UIAlertController.Create("Oil", "Use extra-virgin olive oil in recipes if flavor is important - such as salad dressing; bland vegetable oil is useful in many cooking, baking recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Butter")
            {
                UIAlertController okAlertController = UIAlertController.Create("Butter", "Use un-salted butter; salted butter is great on toast - but can make foods too salty;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Eggs", "Most recipes call for large eggs; use different sizes in egg dishes - such as an omelet; in baking recipes - use size for which recipe calls;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Milk & Dairy")
            {
                UIAlertController okAlertController = UIAlertController.Create("Milk & Dairy", "Milk, cream, half-and-half, yogurt, sour cream are common ingredients; while low-fat milk, whole milk will work same way in most recipes - don't use milk in a recipe which calls for cream;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Broth")
            {
                UIAlertController okAlertController = UIAlertController.Create("Broth", "Store-bought chicken broth, vegetable broth can be used inter-changeably in most recipes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Herbs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Herbs", "Fresh herbs add more flavor to dishes than dried dishes; dried oregano, thyme are OK - don't bother with dried parsley, basil, cilantro;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Spices")
            {
                UIAlertController okAlertController = UIAlertController.Create("Spices", "Ground spices - such as cumin, chili powder add flavor; keep spices in pantry for up to one year - then purchase fresh jars;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Garlic & Onions")
            {
                UIAlertController okAlertController = UIAlertController.Create("Garlic & Onions", "Many recipes call for garlic, onions; flavorful ingredients require prep, stored in pantry - not fridge;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Baking Powder, Soda")
            {
                UIAlertController okAlertController = UIAlertController.Create("Baking Powder, Soda", "Leaveners are essential in pancakes, muffins, cakes, cookies - and are not interchangeable; if activated - produce carbon dioxide, helps baked goods rise;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Flour")
            {
                UIAlertController okAlertController = UIAlertController.Create("Flour", "Stock all-purpose flour in pantry - works well in a wide range of recipes, from cakes to cookies;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                owner.PresentViewController(okAlertController, true, null);

                tableView.DeselectRow(indexPath, true);
            }
            if (tableItems[indexPath.Row].Heading == "Sugar")
            {
                UIAlertController okAlertController = UIAlertController.Create("Sugar", "Granulated white sugar is most commonly used sweetener, although some recipes call for confectioners' sugar or brown sugar - use either light or dark, unless recipe specifies otherwise;", UIAlertControllerStyle.Alert);
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