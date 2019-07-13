using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CookHappyRetro
{
    public partial class StockDetailViewController : UITableViewController
    {
        public StockDetailViewController(IntPtr handle) : base(handle)
        {
        }

        Stock currentStock { get; set; }

        public RootViewController Delegate { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Ingredients.Layer.BorderWidth = 1.0f;
            Ingredients.Layer.BorderColor = UIColor.LightGray.CGColor;

            Directions.Layer.BorderWidth = 1.0f;
            Directions.Layer.BorderColor = UIColor.LightGray.CGColor;

            Nutrition.Layer.BorderWidth = 1.0f;
            Nutrition.Layer.BorderColor = UIColor.LightGray.CGColor;

            SaveButton.TouchUpInside += (sender, e) => {
                currentStock.Name = Name.Text;
                // currentStock.Symbol = Code.Text;
                currentStock.Ingredients = Ingredients.Text;
                currentStock.Directions = Directions.Text;
                currentStock.NutritionFacts = Nutrition.Text;

                Delegate.SaveStock(currentStock);
            };
            DeleteButton.TouchUpInside += (sender, e) => {
                if (currentStock == null) return;
                Delegate.DeleteStock(currentStock);
            };
        }

        // this will be called before the view is displayed 
        public void SetStock(RootViewController d, Stock Stock)
        {
            Delegate = d;
            currentStock = Stock;
        }

        // when displaying, set-up the properties
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (currentStock == null) currentStock = new Stock(); ;
            Name.Text = currentStock.Name;
            // Code.Text = currentStock.Symbol;
            Ingredients.Text = currentStock.Ingredients;
            Directions.Text = currentStock.Directions;
            Nutrition.Text = currentStock.NutritionFacts;
        }
    }
}