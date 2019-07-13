using CoreGraphics;
using Foundation;
using SpriteKit;
using System;
using UIKit;

using GameKit;

namespace CookHappyRetro
{
    public partial class LandPageViewController : UIViewController
    {
        UIButton buttonStarRect, buttonStarCustom, btnIngredients, btnKitchenSecrets, btnKitchenSlang, btnPrepSteps;

        UIButton btnMyRecipes;

        UIButton btnSearchRecipes;

        UIScrollView scrollView;
        UIImageView imageView;
       
        public LandPageViewController()
        {
        }

        public LandPageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Cook Happy";
            View.BackgroundColor = UIColor.White;

            imageView = new UIImageView(UIImage.FromFile("BackgroundImageOneThree.png"));

            scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(scrollView);

            // food photo
            buttonStarRect = UIButton.FromType(UIButtonType.Custom);
            buttonStarRect.SetImage(UIImage.FromFile("PhotoFoodThree.png"), UIControlState.Normal);

            buttonStarRect.Frame = new CGRect(0, 10, View.Bounds.Width, 225);
            buttonStarRect.TouchUpInside += HandleTouchUpInsideFoodPhoto;

            // Search Recipes
            btnSearchRecipes = UIButton.FromType(UIButtonType.Custom);
            btnSearchRecipes.SetImage(UIImage.FromFile("RecipeSearch.png"), UIControlState.Normal);

            btnSearchRecipes.Frame = new CGRect(0, 250, View.Bounds.Width, 157);
            btnSearchRecipes.TouchUpInside += HandleTouchUpSearchRecipes;

            // My Recipes
            btnMyRecipes = UIButton.FromType(UIButtonType.Custom);
            btnMyRecipes.SetImage(UIImage.FromFile("MyRecipes.png"), UIControlState.Normal);

            btnMyRecipes.Frame = new CGRect(0, 422, View.Bounds.Width, 108);
            btnMyRecipes.TouchUpInside += HandleTouchUpInsideMyRecipes;

            // use recipes
            buttonStarCustom = UIButton.FromType(UIButtonType.Custom);
            buttonStarCustom.SetImage(UIImage.FromFile("UseARecipeNew.png"), UIControlState.Normal);

            buttonStarCustom.Frame = new CGRect(0, 545, View.Bounds.Width, 32);
            buttonStarCustom.TouchUpInside += HandleTouchUpInsideUseRecipe;

            // ingredients
            btnIngredients = UIButton.FromType(UIButtonType.Custom);
            btnIngredients.SetImage(UIImage.FromFile("Ingredients.png"), UIControlState.Normal);

            btnIngredients.Frame = new CGRect(0, 592, View.Bounds.Width, 152);
            btnIngredients.TouchUpInside += HandleTouchUpInsideIngredients;

            // kitchen secrets
            btnKitchenSecrets = UIButton.FromType(UIButtonType.Custom);
            btnKitchenSecrets.SetImage(UIImage.FromFile("KitchenSecrets.png"), UIControlState.Normal);

            btnKitchenSecrets.Frame = new CGRect(0, 759, View.Bounds.Width, 218);
            btnKitchenSecrets.TouchUpInside += HandleTouchUpInsideKitchenSecrets;

            // kitchen slang
            btnKitchenSlang = UIButton.FromType(UIButtonType.Custom);
            btnKitchenSlang.SetImage(UIImage.FromFile("KitchenSlang.png"), UIControlState.Normal);

            btnKitchenSlang.Frame = new CGRect(0, 992, View.Bounds.Width, 187);
            btnKitchenSlang.TouchUpInside += HandleTouchUpInsideKitchenSlang;

            // prep steps
            btnPrepSteps = UIButton.FromType(UIButtonType.Custom);
            btnPrepSteps.SetImage(UIImage.FromFile("PreparationSteps.png"), UIControlState.Normal);

            btnPrepSteps.Frame = new CGRect(0, 1194, View.Bounds.Width, 44);
            btnPrepSteps.TouchUpInside += HandleTouchUpInsidePrepSteps;

            scrollView.ContentSize = imageView.Image.Size;
            scrollView.AddSubview(imageView);

            scrollView.AddSubview(buttonStarRect);
            scrollView.AddSubview(btnSearchRecipes);
            scrollView.AddSubview(btnMyRecipes);
            scrollView.AddSubview(buttonStarCustom);
            scrollView.AddSubview(btnIngredients);
            scrollView.AddSubview(btnKitchenSecrets);
            scrollView.AddSubview(btnKitchenSlang);
            scrollView.AddSubview(btnPrepSteps);

        }

        protected void HandleTouchUpSearchRecipes(object sender, System.EventArgs e)
        {
            // Launches a new instance of PictureRecipesViewController
            LargeTitlesViewController callHistory = this.Storyboard.InstantiateViewController("LargeTitlesViewController") as LargeTitlesViewController;

            if (callHistory != null)
            {
                this.NavigationController.PushViewController(callHistory, true);
            }
        }

        protected void HandleTouchUpInsideMyRecipes(object sender, System.EventArgs e)
        {
            // Launches a new instance of PictureRecipesViewController
            RootViewController callHistory = this.Storyboard.InstantiateViewController("RootViewController") as RootViewController;

            if (callHistory != null)
            {
                this.NavigationController.PushViewController(callHistory, true);
            }
        }

        protected void HandleTouchUpInsideFoodPhoto(object sender, System.EventArgs e)
        {
            // Launches a new instance of testViewController
            testViewController callHistory = this.Storyboard.InstantiateViewController("testViewController") as testViewController;

            if (callHistory != null)
            {
                this.NavigationController.PushViewController(callHistory, true);
            }
        }

        protected void HandleTouchUpInsideUseRecipe(object sender, System.EventArgs e)
        {
            // Launches a new instance of UseRecipeViewController
            UseRecipeViewController useRecipeVC = this.Storyboard.InstantiateViewController("UseRecipeViewController") as UseRecipeViewController;

            if (useRecipeVC != null)
            {
                this.NavigationController.PushViewController(useRecipeVC, true);
            }
        }

        protected void HandleTouchUpInsideIngredients(object sender, System.EventArgs e)
        {
            // Launches a new instance of IngredientsViewController
            IngredientsViewController useRecipeVC = this.Storyboard.InstantiateViewController("IngredientsViewController") as IngredientsViewController;

            if (useRecipeVC != null)
            {
                this.NavigationController.PushViewController(useRecipeVC, true);
            }
        }

        protected void HandleTouchUpInsideKitchenSecrets(object sender, System.EventArgs e)
        {
            // Launches a new instance of KitchenSecretsViewController
            KitchenSecretsViewController useRecipeVC = this.Storyboard.InstantiateViewController("KitchenSecretsViewController") as KitchenSecretsViewController;

            if (useRecipeVC != null)
            {
                this.NavigationController.PushViewController(useRecipeVC, true);
            }
        }

        protected void HandleTouchUpInsideKitchenSlang(object sender, System.EventArgs e)
        {
            // Launches a new instance of KitchenSlangViewController
            KitchenSlangViewController useRecipeVC = this.Storyboard.InstantiateViewController("KitchenSlangViewController") as KitchenSlangViewController;

            if (useRecipeVC != null)
            {
                this.NavigationController.PushViewController(useRecipeVC, true);
            }
        }

        protected void HandleTouchUpInsidePrepSteps(object sender, System.EventArgs e)
        {
            // Launches a new instance of PrepStepsViewController
            PrepStepsViewController useRecipeVC = this.Storyboard.InstantiateViewController("PrepStepsViewController") as PrepStepsViewController;

            if (useRecipeVC != null)
            {
                this.NavigationController.PushViewController(useRecipeVC, true);
            }
        }

    }

}