using Foundation;
using System;
using UIKit;
using System.Linq;

namespace CookHappyRetro
{
    public partial class LargeTitlesViewController : UITableViewController, IUITableViewDelegate, IUITableViewDataSource, IUISearchResultsUpdating
    {
        string recipeFoodDish;
        UIImageView imageViewFoodPhoto;

        public LargeTitlesViewController (IntPtr handle) : base (handle)
        {
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return searchResults == null ? titles.Length : searchResults.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("titlecell");
            cell.TextLabel.Text = searchResults == null ? titles[indexPath.Row] : searchResults[indexPath.Row];
            cell.DetailTextLabel.Text = "";
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            TableView.DeselectRow(indexPath, true);

            var item = searchResults == null ? titles[indexPath.Row] : searchResults[indexPath.Row];

            if (item == "Deviled Eggs")
            {
                recipeFoodDish = "Deviled Eggs";
            }
            if (item == "Tacos")
            {
                recipeFoodDish = "Tacos";
            }
            if (item == "Apple Pie")
            {
                recipeFoodDish = "Apple Pie";
            }
            if (item == "Baby Back Ribs")
            {
                recipeFoodDish = "Baby Back Ribs";
            }
            if (item == "Clam Chowder")
            {
                recipeFoodDish = "Clam Chowder";
            }
            if (item == "Eggs Benedict")
            {
                recipeFoodDish = "Eggs Benedict";
            }
            if (item == "Filet Mignon")
            {
                recipeFoodDish = "Filet Mignon";
            }
            if (item == "Grilled Cheese Sandwich")
            {
                recipeFoodDish = "Grilled Cheese Sandwich";
            }
            if (item == "Hamburger")
            {
                recipeFoodDish = "Hamburger";
            }
            if (item == "Macaroni and Cheese")
            {
                recipeFoodDish = "Macaroni and Cheese";
            }
            if (item == "Nachos")
            {
                recipeFoodDish = "Nachos";
            }
            if (item == "Omelette")
            {
                recipeFoodDish = "Omelette";
            }
            if (item == "Pancakes")
            {
                recipeFoodDish = "Pancakes";
            }
            if (item == "Ravioli")
            {
                recipeFoodDish = "Ravioli";
            }
            if (item == "Strawberry Shortcake")
            {
                recipeFoodDish = "Strawberry Shortcake";
            }
            if (item == "Waffles")
            {
                recipeFoodDish = "Waffles";
            }
            if (item == "Lobster Bisque")
            {
                recipeFoodDish = "Lobster Bisque";
            }
            if (item == "Caesar Salad")
            {
                recipeFoodDish = "Caesar Salad";
            }
            if (item == "Cheesecake")
            {
                recipeFoodDish = "Cheesecake";
            }
            if (item == "Donuts")
            {
                recipeFoodDish = "Donuts";
            }
            if (item == "Club Sandwich")
            {
                recipeFoodDish = "Club Sandwich";
            }
            if (item == "Escargots")
            {
                recipeFoodDish = "Escargots";
            }
            if (item == "Fish and Chips")
            {
                recipeFoodDish = "Fish and Chips";
            }
            if (item == "Frozen Yogurt")
            {
                recipeFoodDish = "Frozen Yogurt";
            }
            if (item == "Huevos Rancheros")
            {
                recipeFoodDish = "Huevos Rancheros";
            }
            if (item == "Ice Cream")
            {
                recipeFoodDish = "Ice Cream";
            }
            if (item == "Lasagna")
            {
                recipeFoodDish = "Lasagna";
            }
            if (item == "Pizza")
            {
                recipeFoodDish = "Pizza";
            }
            if (item == "Spaghetti Bolognese")
            {
                recipeFoodDish = "Spaghetti Bolognese";
            }
            if (item == "Takoyaki")
            {
                recipeFoodDish = "Takoyaki";
            }
            if (item == "Scallops")
            {
                recipeFoodDish = "Scallops";
            }
            if (item == "Bruschetta")
            {
                recipeFoodDish = "Bruschetta";
            }
            if (item == "Carrot Cake")
            {
                recipeFoodDish = "Carrot Cake";
            }
            if (item == "French Fries")
            {
                recipeFoodDish = "French Fries";
            }
            if (item == "Fried Calamari")
            {
                recipeFoodDish = "Fried Calamari";
            }
            if (item == "Peking Duck")
            {
                recipeFoodDish = "Peking Duck";
            }
            if (item == "Red Velvet Cake")
            {
                recipeFoodDish = "Red Velvet Cake";
            }
            if (item == "Sushi")
            {
                recipeFoodDish = "Sushi";
            }
            if (item == "Steak")
            {
                recipeFoodDish = "Steak";
            }
            if (item == "Chocolate Mousse")
            {
                recipeFoodDish = "Chocolate Mousse";
            }

            CommonClass.value = recipeFoodDish;
            CommonClass.imageViewFoodPhotoSave = UIImage.FromFile("PhotoFoodThree.png");

            // Launches a new instance of PictureRecipesViewController
            PictureRecipesViewController callHistory = this.Storyboard.InstantiateViewController("PictureRecipesViewController") as PictureRecipesViewController;

            if (callHistory != null)
            {
                this.NavigationController.PushViewController(callHistory, true);
            }

        }

        string[] titles = new string[] {
            "Apple Pie",
            "Baby Back Ribs",
            "Bruschetta",
            "Caesar Salad",
            "Carrot Cake",
            "Cheesecake",
            "Chocolate Mousse",
            "Clam Chowder",
            "Club Sandwich",
            "Deviled Eggs",
            "Donuts",
            "Eggs Benedict",
            "Escargots",
            "Filet Mignon",
            "Fish and Chips",
            "French Fries",
            "Fried Calamari",
            "Frozen Yogurt",
            "Grilled Cheese Sandwich",
            "Hamburger",
            "Huevos Rancheros",
            "Ice Cream",
            "Lasagna",
            "Lobster Bisque",
            "Macaroni and Cheese",
            "Nachos",
            "Omelette",
            "Pancakes",
            "Peking Duck",
            "Pizza",
            "Ravioli",
            "Red Velvet Cake",
            "Scallops",
            "Spaghetti Bolognese",
            "Strawberry Shortcake",
            "Steak",
            "Sushi",
            "Tacos",
            "Takoyaki",
            "Waffles"
        };

    }
}