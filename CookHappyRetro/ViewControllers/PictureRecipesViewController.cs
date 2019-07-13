using CoreGraphics;
using Foundation;
using System;
using UIKit;

using Social;
using Accounts;
using System.Text.RegularExpressions;

namespace CookHappyRetro
{
    public partial class PictureRecipesViewController : UIViewController
    {
        SLComposeViewController twitterComposer = SLComposeViewController.FromService(SLServiceType.Twitter);
        ACAccount twitterAccount;

        string recipeFoodDish;

        UIActivityIndicatorView activityIndication;

        UIImage savePhotoImage;
        UIImageView imageViewFoodPhoto;

        public bool isTwitterAvailable
        {
            get
            {
                return SLComposeViewController.IsAvailable(SLServiceKind.Twitter);
            }
        }

        public SLComposeViewController TwitterComposer
        {
            get
            {
                return twitterComposer;
            }
        }

        public ACAccount TwitterAccount
        {
            get
            {
                return twitterAccount;
            }
        }

        UIButton btnIngredients, btnDirections, btnNutritionFacts;

        UIButton btnMyRecipes;

        UIButton btnSubmitRecipe;

        UIScrollView scrollView;
        UIImageView imageView;

        string useFoodDish;

        public PictureRecipesViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            recipeFoodDish = CommonClass.value;

            savePhotoImage = CommonClass.imageViewFoodPhotoSave;

            // Initialize Twitter Account access 
            var accountStore = new ACAccountStore();
            var accountType = accountStore.FindAccountType(ACAccountType.Twitter);

            // Request access to Twitter account
            accountStore.RequestAccess(accountType, null, (granted, error) => {
                // Allowed by user?
                if (granted)
                {
                    // Get account
                    if (accountStore.Accounts.Length == 0)
                        return;

                    twitterAccount = accountStore.Accounts[accountStore.Accounts.Length - 1];
                    InvokeOnMainThread(() => {
                        // Update UI
                        // RequestTwitterTimeline.Enabled = true;
                    });
                }
            });

            useFoodDish = CommonClass.value;

            Title = useFoodDish;
            View.BackgroundColor = UIColor.White;

            imageView = new UIImageView(UIImage.FromFile("BackgroundImageTakePhoto.png"));

            scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(scrollView);

            // Ingredients
            btnIngredients = UIButton.FromType(UIButtonType.Custom);
            btnIngredients.SetImage(UIImage.FromFile("IngredientsRecipe.png"), UIControlState.Normal);

            btnIngredients.Frame = new CGRect(0, 20, View.Bounds.Width, 177);
            btnIngredients.TouchUpInside += HandleTouchUpInsideIngredients;

            activityIndication = new UIActivityIndicatorView();
            activityIndication.Color = UIColor.Blue;
            activityIndication.Frame = new CGRect(120, 192, 50, 50);

            // Directions
            btnDirections = UIButton.FromType(UIButtonType.Custom);
            btnDirections.SetImage(UIImage.FromFile("directions.png"), UIControlState.Normal);

            btnDirections.Frame = new CGRect(0, 212, View.Bounds.Width, 98);
            btnDirections.TouchUpInside += HandleTouchUpInsideDirections;

            // Nutrition Facts
            btnNutritionFacts = UIButton.FromType(UIButtonType.Custom);
            btnNutritionFacts.SetImage(UIImage.FromFile("Nutrition.png"), UIControlState.Normal);

            btnNutritionFacts.Frame = new CGRect(0, 325, View.Bounds.Width, 169);
            btnNutritionFacts.TouchUpInside += HandleTouchUpInsideNutritionFacts;

            scrollView.ContentSize = imageView.Image.Size;
            scrollView.AddSubview(imageView);

            scrollView.AddSubview(activityIndication);

            scrollView.AddSubview(btnIngredients);
            scrollView.AddSubview(btnDirections);
            scrollView.AddSubview(btnNutritionFacts);
        }

        private void SendTweet_TouchUpInside()
        {
            // The input string.
            string input = recipeFoodDish;

            // See if input matches one of these starts.
            if (input.StartsWith("A") || input.StartsWith("E") || input.StartsWith("O"))
            {
                input = "an";
            }
            else
            {
                input = "a";
            }

            var url = new NSUrl("https://itunes.apple.com/us/app/cook-happy/id1455744934?mt=8");
            var urlNew = new Uri("https://apple.co/2HyPfjW");
            Uri uriTest = new Uri("https://apple.co/2HyPfjW");

            string testU = "https://itunes.apple.com/us/app/cook-happy/id1455744934?mt=8";

            string stringy = "<a href=https://" + testU + ">ClickMe</a> ";

            var stringyTest = ConvertTextUrlToLink(testU);

            UITextView uiview = new UITextView();

            uiview.DataDetectorTypes = UIDataDetectorType.Link;
            uiview.Text = @"https://itunes.apple.com/us/app/cook-happy/id1455744934?mt=8";


            // Set initial message
            TwitterComposer.SetInitialText("I made " + input + " " + recipeFoodDish + " recipe with Cook Happy directions :) learn more about Cook Happy - a kitchen starter kit... https://apple.co/2HyPfjW");
            // TwitterComposer.SetInitialText.(String.Format("Blah blah blah blah. Click {0} for more information.", "<a href=\"http://www.example.com\">here</a>"));
            TwitterComposer.AddImage(savePhotoImage);
            // TwitterComposer.AddUrl(url);
            TwitterComposer.CompletionHandler += (result) => {
                InvokeOnMainThread(() => {
                    DismissViewController(true, null);
                    activityIndication.StopAnimating();
                    Console.WriteLine($"Results: {result}");
                });
            };

            // Display controller
            PresentViewController(TwitterComposer, true, null);
        }

        private string ConvertTextUrlToLink(string url)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.
   [a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(url, "a href=\"$1\" title=\"Click here to open in a new window or tab\" target =\"_blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }

        private void AlertOKTapped()
        {
            activityIndication.StopAnimating();
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

        protected void HandleTouchUpInsideIngredients(object sender, System.EventArgs e)
        {
            if (useFoodDish == "Deviled Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "6 hard-cooked eggs, 2 tablespoons mayonnaise, 1 teaspoon white sugar, 1 teaspoon white vinegar, 1 teaspoon prepared mustard, 1/2 teaspoon salt, 1 tablespoon finely chopped onion, 1 tablespoon finely chopped celery, 1 pinch paprika, or to taste;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Tacos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 cup all-purpose flour, 2 tablespoons cornstarch, 1 teaspoon baking powder, 1/2 teaspoon salt, 1 egg, 1 cup beer, 1/2 cup plain yogurt, 1/2 cup mayonnaise, 1 lime, juiced, 1 jalapeno pepper, minced, 1 teaspoon minced capers, 1/2 teaspoon dried oregano, 1/2 teaspoon ground cumin, 1/2 teaspoon dried dill weed, 1 teaspoon ground cayenne pepper, 1 quart oil for frying, 1 pound cod fillets, cut into 2 to 3 ounce portions, 1 (12 ounce) package corn tortillas, 1/2 medium head cabbage, finely shredded;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Apple Pie")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 1/2 cups peeled, cored and sliced apples, 1 teaspoon ground cinnamon, 1 teaspoon white sugar, 1 cup white sugar, 3/4 cup margarine, melted, 1/2 cup chopped pecans, 1 cup all-purpose flour, 1 egg, lightly beaten, 1 pinch salt;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Baby Back Ribs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 cup hoisin sauce, 1/3 cup white wine, 1/2 cup soy sauce, 1 cup white sugar, 1/2 cup tomato paste, 1/4 cup chopped garlic, 2 tablespoons hot pepper sauce (such as Tabasco®), or to taste, 2 pounds baby back ribs, cut into 1-inch riblets;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Clam Chowder")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1/2 pound bacon, cut into 1/2 inch pieces, 5 unpeeled potatoes, diced, 2 carrots, diced, salt and pepper to taste, 2 (6.5 ounce) cans chopped clams with juice, 2 (1.8 ounce) packages dry leek soup mix, 1 quart half-and-half;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Eggs Benedict")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "4 egg yolks, 3 1/2 tablespoons lemon juice, 1 pinch ground white pepper, 1/8 teaspoon Worcestershire sauce, 1 tablespoon water, 1 cup butter, melted, 1/4 teaspoon salt, 8 eggs, 1 teaspoon distilled white vinegar, 8 strips Canadian-style bacon, 4 English muffins, split, 2 tablespoons butter, softened;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Filet Mignon")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 (4 ounce) filet mignon steaks, 1/2 teaspoon freshly ground black pepper to taste, salt to taste, 1/4 cup balsamic vinegar, 1/4 cup dry red wine;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Grilled Cheese Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "4 slices white bread, 3 tablespoons butter, divided, 2 slices Cheddar cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Hamburger")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 pounds ground beef sirloin, 1/2 onion, grated, 1 tablespoon grill seasoning, 1 tablespoon liquid smoke flavoring, 2 tablespoons Worcestershire sauce, 2 tablespoons minced garlic, 1 tablespoon adobo sauce from canned chipotle peppers, 1 chipotle chile in adobo sauce, chopped, salt and pepper to taste, 6 (1 ounce) slices sharp Cheddar cheese (optional), 6 hamburger buns;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lobster Bisque")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 cup chicken broth, 2 medium slices onion, 2 tablespoons butter, 2 tablespoons all-purpose flour, 2 cups milk, 1/2 teaspoon salt, 1 pound cooked and cubed lobster meat, 1/2 teaspoon Worcestershire sauce, 1 pinch ground cayenne pepper;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Macaroni and Cheese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "8 ounces uncooked elbow macaroni, 2 cups shredded sharp Cheddar cheese, 1/2 cup grated Parmesan cheese, 3 cups milk, 1/4 cup butter, 2 1/2 tablespoons all-purpose flour, 2 tablespoons butter, 1/2 cup bread crumbs, 1 pinch paprika;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Nachos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 pound ground beef, 1 (1.25 ounce) package taco seasoning mix, 3/4 cup water, 1 (18 ounce) package restaurant-style tortilla chips, 1 cup shredded sharp Cheddar cheese, or more to taste, 1 (15.5 ounce) can refried beans, 1 cup salsa, 1 cup sour cream, or more to taste, 1 (10 ounce) can pitted black olives, drained and chopped, 4 green onions, diced, 1 (4 ounce) can sliced jalapeno peppers, drained, Add all ingredients to list;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Omelette")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1/2 (1 pound) loaf white bread, cut into cubes, 1 1/2 pounds Cheddar cheese, shredded, 1 cup cubed cooked ham, 8 eggs, 2 cups milk, 1 pinch salt, 1 dash hot pepper sauce, or to taste, 1/4 cup chopped green onion;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pancakes")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "5 eggs, 1 1/2 cups milk, 6 tablespoons butter, melted, 5 cups buttermilk, 5 cups all-purpose flour, 5 teaspoons baking powder, 5 teaspoons baking soda, 1 pinch salt (optional), 5 tablespoons sugar;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ravioli")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 pound ground beef, 1/2 (25 ounce) package frozen cheese ravioli, 1 (14 ounce) jar spaghetti sauce, 1 (14.5 ounce) can diced tomatoes, drained, 1 cup shredded mozzarella cheese, 1 cup shredded Monterey Jack cheese, 1 tablespoon grated Parmesan cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Strawberry Shortcake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "3 pints fresh strawberries, 1/2 cup white sugar, 2 1/4 cups all-purpose flour, 4 teaspoons baking powder, 2 tablespoons white sugar, 1/4 teaspoon salt, 1/3 cup shortening, 1 egg, 2/3 cup milk, 2 cups whipped heavy cream;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Waffles")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 eggs, 2 cups all-purpose flour, 1 3/4 cups milk, 1/2 cup vegetable oil, 1 tablespoon white sugar, 4 teaspoons baking powder, 1/4 teaspoon salt, 1/2 teaspoon vanilla extract;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Caesar Salad")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "6 cups tightly packed chopped romaine lettuce; 1 pound cooked boneless skinless chicken breasts, cut into strips; 1/2 cup CRACKER BARREL Finely Shredded 100% Parmesan Cheese; 1/2 cup seasoned croutons; 1/4 cup KRAFT Creamy Caesar Dressing;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Cheesecake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 (8 ounce) packages cream cheese, softened; 1/2 cup white sugar; 1/2 teaspoon vanilla extract; 2 eggs; 1 (9 inch) prepared graham cracker crust; 1/2 cup pumpkin puree; 1/2 teaspoon ground cinnamon; 1 pinch ground cloves; 1 pinch ground nutmeg; 1/2 cup frozen whipped topping, thawed;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Donuts")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 1/2 cups all-purpose flour; 1/2 cup white sugar; 1 tablespoon baking powder; 1/2 teaspoon salt; 1 teaspoon ground cinnamon; 1/4 teaspoon ground nutmeg; 1 cup milk; 1 egg, beaten; 1/4 cup butter, melted and cooled; 2 teaspoons vanilla extract; 2 quarts oil for deep frying; 1/2 teaspoon ground cinnamon; 1/2 cup white sugar;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Club Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 slices bacon; 3 slices bread, toasted; 3 tablespoons mayonnaise; 2 leaves lettuce; 2 (1 ounce) slices cooked deli turkey breast; 2 slices tomato;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Escargots")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 (7 ounce) can escargots, drained; 6 tablespoons butter; 1 clove garlic, minced; 20 mushrooms, stems removed; 1/3 cup white wine; 1/3 cup cream; 1 tablespoon all-purpose flour; 1 pinch ground black pepper to taste; 1/4 teaspoon dried tarragon; 1/4 cup grated Parmesan cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fish and Chips")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 quart vegetable oil for frying; 1 pound red snapper fillets; 1 egg, beaten; 1/2 cup dry bread crumbs;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Frozen Yogurt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 (8 ounce) package cream cheese, softened; 1 cup white sugar; 1 tablespoon lemon juice; 3 cups plain Greek yogurt; 2 cups pitted, chopped fresh cherries;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Huevos Rancheros")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 tablespoons vegetable oil; 4 (6 inch) corn tortillas; 1 cup refried beans with green chilies; 1 teaspoon butter; 4 eggs; 1 cup shredded Cheddar cheese; 8 slices bacon, cooked and crumbled; 1/2 cup salsa (optional);", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ice Cream")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "4 cups half-and-half; 4 cups milk; 1 (14 ounce) can sweetened condensed milk; 4 eggs; 1 3/4 cups white sugar; 1 teaspoon vanilla extract;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lasagna")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 pound sweet Italian sausage; 3/4 pound lean ground beef; 2 cloves garlic, crushed; 1 (28 ounce) can crushed tomatoes; 2 (6 ounce) cans tomato paste; 2 (6.5 ounce) cans canned tomato sauce; 1/2 cup water; 2 tablespoons white sugar; 1 1/2 teaspoons dried basil leaves; 1/2 teaspoon fennel seeds; 1 teaspoon Italian seasoning; 1 tablespoon salt; 1/4 teaspoon ground black pepper; 4 tablespoons chopped fresh parsley; 12 lasagna noodles; 16 ounces ricotta cheese; 1 egg; 1/2 teaspoon salt; 3/4 pound mozzarella cheese, sliced; 3/4 cup grated Parmesan cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pizza")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1/2 pound ground beef; 1 medium onion, diced; 1 clove garlic, minced; 1 tablespoon chili powder; 1 teaspoon ground cumin; 1/2 teaspoon paprika; 1/2 teaspoon black pepper; 1/2 teaspoon salt; 1 (16 ounce) can refried beans; 4 (10 inch) flour tortillas; 4 (10 inch) flour tortillas; 1 cup shredded Cheddar cheese; 1 cup shredded Monterey Jack cheese; 2 green onions, chopped; 2 roma (plum) tomatoes, diced; 1/4 cup thinly sliced jalapeno pepper; 1/4 cup sour cream (optional);", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Spaghetti Bolognese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 (16 ounce) package spaghetti; 2 tablespoons olive oil; 3 slices bacon, diced; 1 large onion, finely choppedl; 1 stalk celery, finely chopped; 1 carrot, finely chopped; 1 teaspoon dried oregano; 3 cloves garlic, minced; 1 pound lean ground beef; 2 tablespoons balsamic vinegar; 2 (28 ounce) cans crushed tomatoes; 2 tablespoons tomato paste; 2 teaspoons white sugar; salt and ground black pepper to taste; 2 tablespoons chopped fresh basil; 1/4 cup freshly grated Parmesan cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Takoyaki")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 cups (480ml) Dashi; 2 eggs; 1 tsp soy sauce; 1/4 tsp salt; 1 cup plus 2 Tbsp all purpose flour; 2-3 green onions, finely chopped; 2 Tbsp Benishoga (pickled red ginger), chopped; 5-6 oz octopus, cut into 1/2\" cubes; oil; Takoyaki sauce or Okonomiyaki sauce; mayo; Aonori (green dried seaweed); Katsuobushi (dried bonito flakes);", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Scallops")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "4 tablespoons butter, melted; 1 1/2 pounds bay scallops, rinsed and drained; 1/2 cup seasoned dry bread crumbs; 1 teaspoon onion powder; 1 teaspoon garlic powder; 1/2 teaspoon paprika; 1/2 teaspoon dried parsley; 3 cloves garlic, minced; 1/4 cup grated Parmesan cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Bruschetta")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 tomatoes, cubed; 1 teaspoon dried basil; 4 tablespoons grated Parmesan cheese; 2 tablespoons olive oil; 1 clove garlic, crushed; seasoning salt to taste; ground black pepper to taste;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Carrot Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2 cups white sugar; 3/4 cup vegetable oil; 3 eggs; 1 teaspoon vanilla extract; 3/4 cup buttermilk; 2 cups grated carrots; 1 cup flaked coconut; 1 (15 ounce) can crushed pineapple, drained; 2 cups all-purpose flour; 2 teaspoons baking soda; 2 teaspoons ground cinnamon; 1 1/2 teaspoons salt; 1 cup chopped walnuts; 1/2 cup butter; 1 (8 ounce) package cream cheese; 1 teaspoon vanilla extract; 4 cups confectioners' sugar;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "French Fries")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 russet potato, cut into evenly sized strips; 1 quart vegetable oil for frying; salt to taste;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fried Calamari")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 cup all-purpose flour; 2 teaspoons salt; 1 teaspoon paprika; 1/4 teaspoon ground black pepper; 1 teaspoon garlic powder; 6 cups vegetable oil for frying; 12 ounces frozen calamari rings, thawed and drained; salt to taste; 2 tablespoons cocktail sauce, or to taste; 1 lemon, quartered;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Peking Duck")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 (4 pound) whole duck, dressed; 1/2 teaspoon ground cinnamon; 1/2 teaspoon ground ginger; 1/4 teaspoon ground nutmeg; 1/4 teaspoon ground white pepper; 1/8 teaspoon ground cloves; 3 tablespoons soy sauce; 1 tablespoon honey; 1 orange, sliced in rounds; 1 tablespoon chopped fresh parsley, for garnish; 5 green onions; 1/2 cup plum jam; 1 1/2 teaspoons sugar; 1 1/2 teaspoons distilled white vinegar; 1/4 cup finely chopped chutney;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Red Velvet Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "Cake: 1/2 cup shortening; 1 1/2 cups white sugar; 2 eggs; 2 tablespoons cocoa; 4 tablespoons red food coloring; 1 teaspoon salt; 1 teaspoon vanilla extract; 1 cup buttermilk; 2 1/2 cups sifted all-purpose flour; 1 1/2 teaspoons baking soda; 1 tablespoon distilled white vinegar; Icing: 5 tablespoons all-purpose flour; 1 cup milk; 1 cup white sugar; 1 cup butter, room temperature; 1 teaspoon vanilla extract;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Sushi")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "2/3 cup uncooked short-grain white rice; 3 tablespoons rice vinegar; 3 tablespoons white sugar; 1 1/2 teaspoons salt; 4 sheets nori seaweed sheets; 1/2 cucumber, peeled, cut into small strips; 2 tablespoons pickled ginger; 1 avocado; 1/2 pound imitation crabmeat, flaked;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Steak")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "4 (1/2 pound) strip steaks, cut 1/2 inch thick; salt to taste; freshly ground black pepper to taste; 1 teaspoon dry mustard, divided; 1/4 cup margarine; 3 tablespoons lemon juice; 2 teaspoons minced fresh chives; 1 teaspoon Worcestershire sauce;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Chocolate Mousse")
            {
                UIAlertController okAlertController = UIAlertController.Create("Ingredients", "1 cup chocolate cookie crumbs; 3 tablespoons butter, melted; 2 pints fresh strawberries, halved; 2 cups semisweet chocolate chips; 1/2 cup water; 2 tablespoons light corn syrup; 2 1/2 cups heavy cream, divided; 1 tablespoon white sugar;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
        }

        protected void HandleTouchUpInsideDirections(object sender, System.EventArgs e)
        {
            activityIndication.StartAnimating();

            if (useFoodDish == "Deviled Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions - Prep: 15 minutes, Ready In: 15 minutes;", "Slice eggs in half lengthwise and remove yolks; set whites aside; Mash yolks with a fork in a small bowl; Stir in mayonnaise, sugar, vinegar, mustard, salt, onion, and celery; mix well; Stuff or pipe egg yolk mixture into egg whites; Sprinkle with paprika; Refrigerate until serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Tacos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions - Prep: 40 minutes, Cook: 20 minutes, Ready In: 1 hour;", "To make beer batter: In a large bowl, combine flour, cornstarch, baking powder, and salt. Blend egg and beer, then quickly stir into the flour mixture (don't worry about a few lumps); To make white sauce: In a medium bowl, mix together yogurt and mayonnaise; Gradually stir in fresh lime juice until consistency is slightly runny; Season with jalapeno, capers, oregano, cumin, dill, and cayenne; Heat oil in deep-fryer to 375 degrees F (190 degrees C); Dust fish pieces lightly with flour. Dip into beer batter, and fry until crisp and golden brown; Drain on paper towels; Lightly fry tortillas; not too crisp; To serve, place fried fish in a tortilla, and top with shredded cabbage, and white sauce;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Apple Pie")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions - Prep: 15 minutes, Cook: 1 hour, 5 minutes, Ready In: 1 hour, 5 minutes;", "Preheat oven to 350 degrees F (175 degrees C). Lightly grease a 9 inch pie pan with margarine; Fill 2/3 of the pan with sliced apples; Sprinkle with cinnamon and 1 teaspoon sugar; In a medium bowl, mix 1 cup sugar with the melted margarine; Stir in pecans, flour, egg and salt; Mix well; Spread mixture over the apples; Bake in preheated oven for 65 minutes, or until golden brown;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Baby Back Ribs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 15 minutes, Cook: 1 hour, 30 minutes, Ready In: 1 hour, 45 minutes;", "Preheat oven to 350 degrees F (175 degrees C); Combine the hoisin sauce, white wine, soy sauce, sugar, tomato paste, garlic, and hot sauce in large bowl; mix well; Place the riblets in a large roasting pan and bake in the preheated oven, uncovered, for 45 minutes; Pour sauce over riblets and toss to coat; Return the pan to the oven; bake, stirring often, until ribs are tender and sauce has thickened, about 45 minutes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Clam Chowder")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 15 minutes, Cook: 40 minutes, Ready In: 55 minutes;", "Place the bacon in a large pot and cook over medium-high heat, stirring occasionally, until crisped and browned, about 10 minutes; Remove the bacon with a slotted spoon, leaving the drippings in the pot; Set the bacon aside; Stir the potatoes and carrots into the bacon fat; Season with salt and pepper, and cook for 5 minutes, stirring frequently; Pour the juice from the clams into the pot, and add enough water to just cover the potatoes; Bring to a boil, then reduce heat to medium-low, cover, and simmer until the potatoes are just tender, 10 to 15 minutes; Gently stir the leek soup mix into the potatoes until no lumps of soup remain; Stir in the clams, reserved bacon, and half-and-half cream; Cook and stir until the chowder returns to a simmer and thickens, about 10 minutes more;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Eggs Benedict")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 25 minutes, Cook: 5 minutes, Ready In: 30 minutes;", "To Make Hollandaise: Fill the bottom of a double boiler part-way with water; Make sure that water does not touch the top pan; Bring water to a gentle simmer; In the top of the double boiler, whisk together egg yolks, lemon juice, white pepper, Worcestershire sauce, and 1 tablespoon water; Add the melted butter to egg yolk mixture 1 or 2 tablespoons at a time while whisking yolks constantly; If hollandaise begins to get too thick, add a teaspoon or two of hot water; Continue whisking until all butter is incorporated; Whisk in salt, then remove from heat; Place a lid on pan to keep sauce warm; Preheat oven on broiler setting; To Poach Eggs: Fill a large saucepan with 3 inches of water; Bring water to a gentle simmer, then add vinegar; Carefully break eggs into simmering water, and allow to cook for 2 1/2 to 3 minutes; Yolks should still be soft in center; Remove eggs from water with a slotted spoon and set on a warm plate; While eggs are poaching, brown the bacon in a medium skillet over medium-high heat and toast the English muffins on a baking sheet under the broiler; Spread toasted muffins with softened butter, and top each one with a slice of bacon, followed by one poached egg; Place 2 muffins on each plate and drizzle with hollandaise sauce; Sprinkle with chopped chives and serve immediately;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Filet Mignon")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 15 minutes, Ready In: 20 minutes;", "Sprinkle freshly ground pepper over both sides of each steak, and sprinkle with salt to taste; Heat a nonstick skillet over medium-high heat; Place steaks in hot pan, and cook for 1 minute on each side, or until browned; Reduce heat to medium-low, and add balsamic vinegar and red wine; Cover, and cook for 4 minutes on each side, basting with sauce when you turn the meat over; Remove steaks to two warmed plates, spoon one tablespoon of glaze over each, and serve immediately;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Grilled Cheese Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 15 minutes, Ready In: 20 minutes;", "Preheat skillet over medium heat; Generously butter one side of a slice of bread; Place bread butter-side-down onto skillet bottom and add 1 slice of cheese; Butter a second slice of bread on one side and place butter-side-up on top of sandwich; Grill until lightly browned and flip over; continue grilling until cheese is melted; Repeat with remaining 2 slices of bread, butter and slice of cheese;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Hamburger")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 25 minutes, Cook: 10 minutes, Ready In: 35 minutes;", "Preheat an outdoor grill for medium-high heat; Combine ground sirloin, onion, grill seasoning, liquid smoke, Worcestershire sauce, garlic, adobo sauce, and chipotle pepper in a large bowl; Form the mixture into 6 patties; Season with salt and pepper; Place burgers on preheated grill and cook until no longer pink in the center; Place a slice of Cheddar cheese on top of each burger one minute before they are ready; Place burgers on buns to serve;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lobster Bisque")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 15 minutes, Ready In: 20 minutes;", "In a small frying pan place 1/4 cup chicken broth and the onion; Cook over a low heat for 5 to 7 minutes; In a medium size pot over medium heat melt the butter; Slowly whisk in flour; Whisk until a creamy mixture is created; Gradually pour in broth, whisking constantly; Whisk in milk, salt, onion, lobster meat, Worcestershire sauce and cayenne pepper; Heat until soup is almost boiling; Do not boil the soup as the milk will curdle when boiled;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Macaroni and Cheese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: 30 minutes, Ready In: 50 minutes;", "Cook macaroni according to the package directions; Drain; In a saucepan, melt butter or margarine over medium heat; Stir in enough flour to make a roux; Add milk to roux slowly, stirring constantly; Stir in cheeses, and cook over low heat until cheese is melted and the sauce is a little thick; Put macaroni in large casserole dish, and pour sauce over macaroni; Stir well; Melt butter or margarine in a skillet over medium heat;Bake at 350 degrees F (175 degrees C) for 30 minutes; Serve; Add breadcrumbs and brown; Spread over the macaroni and cheese to cover; Sprinkle with a little paprika;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Nachos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 20 minutes, Ready In: 50 minutes;", "Cook and stir ground beef in a skillet over medium heat until meat is crumbly and no longer pink, 5 to 10 minutes; Drain excess grease; Stir in taco seasoning mix and water and simmer until beef mixture has thickened, 8 to 10 minutes; Set the oven rack about 6 inches from the heat source and preheat the broiler; Line a baking sheet with aluminum foil; Spread tortilla chips on the prepared baking sheet; top with Cheddar cheese and dot with refried beans and ground beef mixture; Broil in the preheated oven until cheese is melted, watching carefully to prevent burning, 3 to 5 minutes; Top nachos with salsa, sour cream, black olives, green onions, and jalapeno peppers;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Omelette")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 15 minutes, Cook: 1 hour, Ready In: 1 hour, 15 minutes;", "Preheat oven to 350 degrees F (175 degrees C); Lightly grease a 9x13 inch baking pan; Place half of the bread cubes on bottom of baking pan; Sprinkle with half of the ham and then half of the cheese; repeat; In a large bowl, beat together eggs, milk, salt, hot sauce and green onions; Pour egg mixture into pan; Place pan on top of a baking sheet with a rim and place in oven; Pour water into baking sheet and bake for 60 minutes, or until eggs have set;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pancakes")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: 10 minutes, Cook: 5 minutes, Ready In: 15 minutes;", "In a large bowl, whisk together the eggs, milk, butter and buttermilk; Combine the flour, baking powder, baking soda and sugar; stir into the wet ingredients just until blended; Adjust the thickness of the batter to your liking by adding more flour or buttermilk if necessary; Heat a large skillet over medium heat, and coat with cooking spray; Pour 1/4 cupfuls of batter onto the skillet, and cook until bubbles appear on the surface; Flip with a spatula, and cook until browned on the other side; Continue with remaining batter;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ravioli")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: 30 minutes, Ready In: 50 minutes;", "Preheat the oven to 450 degrees F (230 degrees C); Crumble the ground beef into a large skillet over medium-high heat; Cook and stir until no longer pink; Drain grease, then stir in the spaghetti sauce and tomatoes; Spread 1/3 of the sauce in the bottom of an 11x7 inch baking dish; Arrange 1/2 of the ravioli over the sauce; Sprinkle 1/2 of the mozzarella cheese and 1/2 of the Monterey Jack cheese over the ravioli; Repeat layers, ending with the last of the sauce on top; Cover with aluminum foil; Bake for 30 minutes in the preheated oven; Sprinkle Parmesan cheese over the top before serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Strawberry Shortcake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 20 minutes, Ready In: 50 minutes;", "Slice the strawberries and toss them with 1/2 cup of white sugar; Set aside; Preheat oven to 425 degrees F (220 degrees C); Grease and flour one 8 inch round cake pan; In a medium bowl combine the flour, baking powder, 2 tablespoons white sugar and the salt; With a pastry blender cut in the shortening until the mixture resembles coarse crumbs; Make a well in the center and add the beaten egg and milk; Stir until just combined; Spread the batter into the prepared pan; Bake at 425 degrees F (220 degrees C) for 15 to 20 minutes or until golden brown; Let cool partially in pan on wire rack; Slice partially cooled cake in half, making two layers; Place half of the strawberries on one layer and top with the other layer; Top with remaining strawberries and cover with the whipped cream;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Waffles")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 15 minutes, Ready In: 20 minutes;", "Preheat waffle iron; Beat eggs in large bowl with hand beater until fluffy; Beat in flour, milk, vegetable oil, sugar, baking powder, salt and vanilla, just until smooth; Spray preheated waffle iron with non-stick cooking spray; Pour mix onto hot waffle iron; Cook until golden brown; Serve hot;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Caesar Salad")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: NA, Ready In: 10 minutes;", "Cover 4 plates with lettuce; Top with all remaining ingredients except dressing; Drizzle with dressing just before serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Cheesecake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 40 minutes, Ready In: 4 hours, 10 minutes;", "Preheat oven to 325 degrees F (165 degrees C); In a large bowl, combine cream cheese, sugar and vanilla; Beat until smooth; Blend in eggs one at a time; Remove 1 cup of batter and spread into bottom of crust; set aside; Add pumpkin, cinnamon, cloves and nutmeg to the remaining batter and stir gently until well blended; Carefully spread over the batter in the crust; Bake in preheated oven for 35 to 40 minutes, or until center is almost set; Allow to cool, then refrigerate for 3 hours or overnight; Cover with whipped topping before serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Donuts")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 2 hours, Cook: 15 minutes, Ready In: 2 hours, 5 minutes;", "In a large bowl, stir together the flour, 1/2 cup sugar, baking powder, salt, 1 teaspoon of cinnamon and nutmeg; Make a well in the center and pour in the milk, egg, butter, and vanilla; Mix until well blended; Cover and refrigerate for 1 hour; Heat oil in a deep heavy skillet or deep-fryer to 370 degrees F (185 degrees C); On a floured board, roll chilled dough out to 1/2 inch thickness; Use a 3 inch round cutter to cut out doughnuts; Use a smaller cutter to cut holes from center; If you do not have a small cutter, use the mouth of a bottle; Fry doughnuts in hot oil until golden brown, turning once; Remove from oil to drain on paper plates; Combine the remaining 1/2 teaspoon cinnamon and 1/2 cup sugar in a large resealable bag; Place a few warm donuts into the bag at a time, seal and shake to coat;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Club Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 5 minutes, Ready In: 10 minutes;", "Place bacon in a heavy skillet; Cook over medium high heat until evenly brown; Drain on paper towels; Spread each slice of bread with mayonnaise; On one slice of toast, place the turkey and lettuce; Cover with a slice of toast, then the bacon and tomato; Top with last slice of toast;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Escargots")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 15 minutes, Cook: 25 minutes, Ready In: 45 minutes;", "Place escargots in a small bowl, and cover with cold water; set aside for 5 minutes; This will help to remove the canned flavor they may have; Preheat oven to 350 degrees F (175 degrees C); Lightly grease an 8x8 inch baking dish; Drain the water from the escargots and pat dry with a paper towel; Melt butter with the garlic in a large skillet over medium-high heat; Add the escargots and mushroom caps; cook and stir until the mushroom caps begin to soften, about 5 minutes; Whisk together wine, cream, flour, pepper, and tarragon in a small bowl until the flour is no longer lumpy; Pour this into the skillet, and bring to a boil; Cook, stirring occasionally until the sauce thickens, about 10 minutes; Remove the skillet from the heat, and use a spoon to place the mushrooms upside down into the prepared baking dish; Spoon an escargot into each mushroom cap; Pour the remaining sauce over the mushroom caps and into the baking dish; Sprinkle grated Parmesan cheese overtop; Bake in preheated oven until the Parmesan cheese has turned golden brown, 10 to 15 minutes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fish and Chips")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 5 minutes, Cook: 10 minutes, Ready In: 15 minutes;", "In a large heavy skillet, heat oil to 375 degrees F (190 degrees C); Dip fillets into beaten egg and dredge in bread crumbs; Gently slide fish into hot oil and fry until golden brown; Drain briefly on paper towels; Serve hot;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Frozen Yogurt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 25 minutes, Cook: NA, Ready In: 4 hours, 25 minutes;", "In a large bowl, mash the cream cheese with sugar until thoroughly combined; stir in the lemon juice, and mix in the yogurt, about a cup at a time, until the mixture is smooth and creamy; Mix in the cherries; Cover the bowl with plastic wrap, and chill until very cold, at least 4 hours; Pour the mixture into an ice cream freezer, and freeze according to manufacturer's instructions; For firmer texture, pack the frozen yogurt into a covered container, and freeze for several hours;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Huevos Rancheros")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: 10 minutes, Ready In: 20 minutes;", "Heat oil in a small skillet over medium-high heat; Fry tortillas one at a time until firm, but not crisp; Remove to paper towels to drain grease; Meanwhile, combine the refried beans and butter in a microwave-safe dish; Cover, and cook in the microwave until heated through; When tortillas are done, fry eggs over easy in the skillet; Add more oil if the tortillas have absorbed it all; Place tortillas onto plates, and spread a layer of beans on them; Top with cheese, a fried egg, crumbled bacon and if desired, salsa;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ice Cream")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: NA, Ready In: 1 hour, 10 minutes;", "Beat half-an-half, milk, sweetened condensed milk, and eggs together in a bowl on low mixer speed; slowly add sugar while continuously beating, followed by vanilla extract; Pour milk mixture into ice cream maker's container and freeze according to manufacturer's directions;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lasagna")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 2 hours, 30 minutes, Ready In: 3 hours, 15 minutes;", "In a Dutch oven, cook sausage, ground beef, onion, and garlic over medium heat until well browned; Stir in crushed tomatoes, tomato paste, tomato sauce, and water; Season with sugar, basil, fennel seeds, Italian seasoning, 1 tablespoon salt, pepper, and 2 tablespoons parsley; Simmer, covered, for about 1 1/2 hours, stirring occasionally; Bring a large pot of lightly salted water to a boil; Cook lasagna noodles in boiling water for 8 to 10 minutes; Drain noodles, and rinse with cold water; In a mixing bowl, combine ricotta cheese with egg, remaining parsley, and 1/2 teaspoon salt; Preheat oven to 375 degrees F (190 degrees C); To assemble, spread 1 1/2 cups of meat sauce in the bottom of a 9x13 inch baking dish; Arrange 6 noodles lengthwise over meat sauce; Spread with one half of the ricotta cheese mixture; Top with a third of mozzarella cheese slices; Spoon 1 1/2 cups meat sauce over mozzarella, and sprinkle with 1/4 cup Parmesan cheese. Repeat layers, and top with remaining mozzarella and Parmesan cheese; Cover with foil: to prevent sticking, either spray foil with cooking spray, or make sure the foil does not touch the cheese; Bake in preheated oven for 25 minutes; Remove foil, and bake an additional 25 minutes; Cool for 15 minutes before serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pizza")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: 25 minutes, Ready In: 45 minutes;", "Preheat the oven to 350 degrees F (175 degrees C); Coat 2 pie plates with non-stick cooking spray; Place beef, onion and garlic in a skillet over medium heat; Cook until beef is evenly browned; Drain off grease; Season the meat with chili powder, cumin, paprika, salt and pepper; Lay one tortilla in each pie plate, and cover with a layer of refried beans; Spread half of the seasoned ground beef over each one, and then cover with a second tortilla; Bake for 10 minutes in the preheated oven; Remove the plates from the oven, and let cool slightly; Spread half of the salsa over each top tortilla; Cover each pizza with half of the Cheddar and Monterey Jack cheeses; Place half of the tomatoes, half of the green onions, and half of the jalapeno slices onto each one; Return the pizzas to the oven, and bake for 5 to 10 more minutes, until the cheese is melted; Remove from the oven, and let cool slightly before slicing each one into 4 pieces;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Spaghetti Bolognese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: 40 minutes, Ready In: 1 hour;", "Bring a large pot of lightly salted water to a rolling boil; Cook the spaghetti in the boiling water until cooked through yet firm to the bite, about 12 minutes; drain; Heat the olive oil in a large pot over medium heat; Cook the bacon in the oil until crisp, 8 to 10 minutes; Stir the onion, celery, carrot, and oregano into the bacon; continue cooking until the vegetables begin to soften, another 8 to 10 minutes; Add the garlic and cook until fragrant, about 2 minutes; Crumble the ground beef into the vegetable mixture; cook and stir until the beef is completely cooked and no longer pink, 8 to 10 minutes; Pour the balsamic vinegar over the ground beef mixture; allow to simmer until the liquid evaporates, about 5 minutes. Stir the crushed tomatoes, tomato paste, and sugar into the ground beef mixture; bring the mixture to a boil, season with salt and black pepper, and remove from heat. Stir the fresh basil into the mixture; Ladle the sauce over the cooked spaghetti; Top with Parmesan cheese to serve;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Takoyaki")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 1 hour, Cook: 6 minutes, Ready In: 20 minutes;", "In a large bowl, mix well Dashi, eggs, soy sauce, salt, and flour with a whisk; Heat a Takoyaki pan with oil to very hot, just until the oil begins to smoke; Use enough oil to coat the pan using a paper towel so that the batter won't stick; Then pour batter to fill the holes of the pan; Drop octopus pieces in the batter in each hole, and sprinkle chopped green onions and ginger all over the pan; Cook at medium heat for 1-2 minutes and turn over using a Takoyaki turner (you can use a chopstick too); It can be a little tricky at first, so watch the video to see the technique; Cook another 3-4 minutes, turning constantly; Place the cooked Takoyaki on a plate and pour Takoyaki sauce and mayo over them (to taste); Finish the dish by sprinkling the Takoyaki with Aonori (green dried seaweed) and Katsuobushi (dried bonito flakes);", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Scallops")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 20 minutes, Ready In: 50 minutes;", "Preheat oven to 400 degrees F (200 degrees C); Pour melted butter into a 2 quart oval casserole dish; Distribute butter and scallops evenly inside the dish; Combine the bread crumbs, onion powder, garlic powder, paprika, parsley, minced garlic and Parmesan cheese; Sprinkle this mixture over the scallops; Bake in pre-heated oven until scallops are firm, about 20 minutes;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Bruschetta")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: not applicable, Ready In: 8 hours, 20 minutes;", "In a medium bowl, mix tomatoes, dried basil, Parmesan cheese, olive oil, garlic, seasoning salt and ground black pepper; Cover and chill in the refrigerator 8 hours, or overnight, before serving;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Carrot Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 30 minutes, Cook: 55 minutes, Ready In: 2 hours;", "Preheat oven to 350 degrees F (175 degrees C); Grease a 9x13 inch baking pan; Set aside; In a large bowl, mix together sugar, oil, eggs, vanilla, and buttermilk. Stir in carrots, coconut, vanilla, and pineapple; In a separate bowl, combine flour, baking soda, cinnamon, and salt; gently stir into carrot mixture; Stir in chopped nuts; Spread batter into prepared pan; Bake for 55 minutes or until toothpick inserted into cake comes out clean; Remove from oven, and set aside to cool; in a medium mixing bowl, combine butter or margarine, cream cheese, vanilla, and confectioners sugar; Blend until creamy; Frost cake while still in the pan;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "French Fries")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: 10 minutes, Ready In: 50 minutes;", "Soak potatoes in a large bowl of water for about 30 minutes; Pat dry thoroughly with paper towels; Heat oil in a deep-fryer or large saucepan to 275 degrees F (135 degrees C); Gently add the potatoes in the hot oil for about 5 minutes, stirring and flipping the potatoes occasionally; Remove potatoes from oil with a slotted spoon to drain on paper towel and to cool completely; Heat oil in a deep-fryer or large saucepan to 350 degrees F (175 degrees C); Fry the potatoes again until golden brown, 5 to 6 minutes; Blot with a paper towel; Sprinkle with salt to serve;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fried Calamari")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 10 minutes, Cook: 10 minutes, Ready In: 20 minutes;", "Stir flour, 2 teaspoons salt, paprika, and black pepper together in a shallow bowl; Heat oil in a deep-fryer or large saucepan to 375 degrees F (190 degrees C); Press calamari rings into the flour mixture until evenly coated, shaking off excess flour; Working in batches, fry calamari rings in the hot oil until golden brown, 3 to 4 minutes; Transfer cooked calamari to a paper towel-lined plate; sprinkle with salt; Serve calamari with cocktail and lemon wedges;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Peking Duck")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 15 minutes, Cook: 1 hour, 35 minutes, Ready In: 3 hours, 50 minutes;", "Rinse the duck inside and out, and pat dry; Cut off tail and discard; In a small bowl, mix together the cinnamon, ginger, nutmeg, white pepper and cloves; Sprinkle one teaspoon of the mixture into the cavity of the duck; Stir one tablespoon of the soy sauce into the remaining spice mixture and rub evenly over the entire outside of the bird; Cut one of the green onions in half and tuck inside the cavity; Cover and refrigerate the bird for at least 2 hours, or overnight; Place duck breast side up on a rack in a big enough wok or pot and steam for an hour adding a little more water, if necessary, as it evaporates; Lift duck with two large spoons, and drain juices and green onion; Preheat the oven to 375 degrees F (190 degrees C); Place duck breast side up in a roasting pan and prick skin all over using a fork; Roast for 30 minutes in the preheated oven; While the duck is roasting, mix together the remaining 2 tablespoons of soy sauce and honey; After 30 minutes, brush the honey mixture onto the duck and return it to the oven; Turn the heat up to 500 degrees F (260 degrees C); Roast for 5 minutes, or until the skin is richly browned; Do not allow the skin to char; Prepare the duck sauce by mixing the plum jam with the sugar, vinegar and chutney in a small serving bowl; Chop remaining green onions and place them into a separate bowl; Place whole duck onto a serving platter and garnish with orange slices and fresh parsley; Use plum sauce and onions for dipping;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Red Velvet Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 25 minutes, Cook: 30 minutes, Ready In: 2 hours, 25 minutes;", "Preheat oven to 350 degrees F (175 degrees C); Grease two 9-inch round pans; Beat shortening and 1 1/2 cups sugar until very light and fluffy; Add eggs and beat well; Make a paste of cocoa and red food coloring; add to creamed mixture. Mix salt, 1 teaspoon vanilla, and buttermilk together. Add the flour to the batter, alternating with the buttermilk mixture, mixing just until incorporated; Mix soda and vinegar and gently fold into cake batter; Don't beat or stir the batter after this point; Pour batter into prepared pans; Bake in preheated oven until a tester inserted into the cake comes out clean, about 30 minutes; Cool cakes completely on wire rack; To Make Icing: Cook 5 tablespoons flour and milk over low heat till thick, stirring constantly; Let cool completely! While mixture is cooling, beat 1 cup sugar, butter, and 1 teaspoon vanilla until light and fluffy; Add cooled flour mixture and beat until frosting is a good spreading consistency; Frost cake layers when completely cool;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Sushi")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 45 minutes, Cook: Not Applicable, Ready In: 45 minutes", "In a medium saucepan, bring 1 1/3 cups water to a boil; Add rice, and stir. Reduce heat, cover, and simmer for 20 minutes; In a small bowl, mix the rice vinegar, sugar,and salt; Blend the mixture into the rice; Preheat oven to 300 degrees F (150 degrees C); On a medium baking sheet, heat nori in the preheated oven 1 to 2 minutes, until warm; Center one sheet nori on a bamboo sushi mat. Wet your hands; Using your hands, spread a thin layer of rice on the sheet of nori, and press into a thin layer; Arrange 1/4 of the cucumber, ginger, avocado, and imitation crabmeat in a line down the center of the rice; Lift the end of the mat, and gently roll it over the ingredients, pressing gently; Roll it forward to make a complete roll; Repeat with remaining ingredients; Cut each roll into 4 to 6 slices using a wet, sharp knife;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Steak")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 20 minutes, Cook: 20 minutes, Ready In: 40 minutes", "Pound steaks to be 1/4 inch thick, and sprinkle each side with salt, black pepper, and 1/8 teaspoon mustard; rub into the meat; Melt margarine in a large skillet over medium-high heat; Fry 2 of the steaks for 2 minutes on each side, and transfer to a hot serving plate; Repeat with remaining 2 steaks; Add lemon juice, chives, Worcestershire sauce, and remaining mustard to the pan, and bring to a boil; Return the steaks to the pan to heat through, and coat with sauce;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Chocolate Mousse")
            {
                UIAlertController okAlertController = UIAlertController.Create("Directions, Prep: 45 minutes, Cook: 1 minute, Ready In: 4 hours, 46 minutes", "In a bowl, mix crumbs and butter to blend thoroughly; Press evenly onto bottom of 9-inch springform pan; Arrange strawberry halves around the pan side-by-side, pointed ends up, with cut sides against the side of pan; set aside; Place chocolate chips in blender container; Pour water and corn syrup into a small saucepan. Bring to a boil and simmer for 1 minute; Immediately pour over chocolate chips and blend until smooth; Pour into a mixing bowl and cool to room temperature; While chocolate cools, whip 1 1/2 cups of the cream to form stiff peaks; Use a rubber spatula or large whisk to fold 1/3 of the whipped cream into the cooled chocolate to lighten it; Gently fold in the remaining whipped cream until mixture is thoroughly blended; Transfer the mousse into the prepared pan and smooth the top; The points of the strawberries might extend about the chocolate mixture; Cover with plastic wrap and refrigerate for 4 to 24 hours; Up to 2 hours before serving, in a medium mixing bowl, beat remaining 1/2 cup of cream to form soft peaks; Add sugar; Beat to form stiff peaks; Remove the side of the springform pan and place the cake on a serving plate; Pipe or dollop whipped cream onto top of cake; Arrange remaining halved strawberries on whipped cream; To serve, cut into wedges with thin knife, wiping blade between cuts;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => { AlertOKTapped(); }));
                okAlertController.AddAction(UIAlertAction.Create("Send Tweet", UIAlertActionStyle.Default, alert => { SendTweet_TouchUpInside(); }));
                PresentViewController(okAlertController, true, null);
            }
        }

        protected void HandleTouchUpInsideNutritionFacts(object sender, System.EventArgs e)
        {
            if (useFoodDish == "Deviled Eggs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 327 calories; 26 g fat; 4.7 g carbohydrates; 19.3 g protein; 563 mg cholesterol; 902 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Tacos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 409 calories; 18.8 g fat; 43 g carbohydrates; 17.3 g protein; 54 mg cholesterol; 407 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Apple Pie")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 386 calories; 22.8 g fat; 44.6 g carbohydrates; 3.2 g protein; 17 mg cholesterol; 207 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Baby Back Ribs")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 774 calories; 31.7 g fat; 90 g carbohydrates; 30.2 g protein; 119 mg cholesterol; 3235 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Clam Chowder")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 681 calories; 38.7 g fat; 53.5 g carbohydrates; 30.5 g protein; 128 mg cholesterol; 1338 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Eggs Benedict")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 879 calories; 71.1 g fat; 29.6 g carbohydrates; 31.8 g protein; 742 mg cholesterol; 1719 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Filet Mignon")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 367 calories; 26.2 g fat; 5.7 g carbohydrates; 20.3 g protein; 81 mg cholesterol; 64 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Grilled Cheese Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 400 calories; 28.3 g fat; 25.7 g carbohydrates; 11.1 g protein; 76 mg cholesterol; 639 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Hamburger")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 537 calories; 29.7 g fat; 26.6 g carbohydrates; 38.7 g protein; 121 mg cholesterol; 1035 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lobster Bisque")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 245 calories; 9 g fat; 11.2 g carbohydrates; 28.1 g protein; 108 mg cholesterol; 1060 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Macaroni and Cheese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 858 calories; 48.7 g fat; 66.7 g carbohydrates; 37.7 g protein; 142 mg cholesterol; 879 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Nachos")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts:", "Per Serving: 432 calories; 24.5 g fat; 39.7 g carbohydrates; 15.2 g protein; 44 mg cholesterol; 1081 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Omelette")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts:", "Per Serving: 375 calories; 25.6 g fat; 12.6 g carbohydrates; 23.2 g protein; 193 mg cholesterol; 692 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pancakes")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 347 calories; 9.8 g fat; 51.8 g carbohydrates; 12.4 g protein; 99 mg cholesterol; 865 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ravioli")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 465 calories; 23.8 g fat; 30.6 g carbohydrates; 30.5 g protein; 100 mg cholesterol; 746 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Strawberry Shortcake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 430 calories; 21.4 g fat; 55.2 g carbohydrates; 6.6 g protein; 66 mg cholesterol; 347 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Waffles")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 382 calories; 21.6 g fat; 38 g carbohydrates; 8.7 g protein; 68 mg cholesterol; 390 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Caesar Salad")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 333 calories; 16.7 g fat; 5.9 g carbohydrates; 36.4 g protein; 90 mg cholesterol; 385 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Cheesecake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 426 calories; 29 g fat; 35.5 g carbohydrates; 7.2 g protein; 108 mg cholesterol; 354 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Donuts")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 257 calories; 14.7 g fat; 28.6 g carbohydrates; 3 g protein; 20 mg cholesterol; 167 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Club Sandwich")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 818 calories; 61.7 g fat; 44.2 g carbohydrates; 22.4 g protein; 76 mg cholesterol; 1874 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Escargots")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 86 calories; 5.4 g fat; 2.8 g carbohydrates; 5.9 g protein; 29 mg cholesterol; 81 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fish and Chips")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 386 calories; 26.2 g fat; 9.8 g carbohydrates; 26.8 g protein; 92 mg cholesterol; 175 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Frozen Yogurt")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 212 calories; 11.7 g fat; 23.3 g carbohydrates; 4.7 g protein; 32 mg cholesterol; 88 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Huevos Rancheros")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 494 calories; 32.9 g fat; 24.2 g carbohydrates; 26.6 g protein; 247 mg cholesterol; 1194 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Ice Cream")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 462 calories; 18.2 g fat; 65.2 g carbohydrates; 11.4 g protein; 122 mg cholesterol; 154 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Lasagna")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 448 calories; 21.3 g fat; 36.5 g carbohydrates; 29.7 g protein; 82 mg cholesterol; 1788 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Pizza")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 370 calories; 18.6 g fat; 31.6 g carbohydrates; 19.6 g protein; 55 mg cholesterol; 848 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Spaghetti Bolognese")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 451 calories; 14 g fat; 59.8 g carbohydrates; 23.5 g protein; 43 mg cholesterol; 459 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Takoyaki")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 79 calories; 5.8 g fat; 4.2 g carbohydrates; 2.4 g protein; 49 mg cholesterol; 85 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Scallops")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 363 calories; 19 g fat; 15.6 g carbohydrates; 31.3 g protein; 88 mg cholesterol; 565 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Bruschetta")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 47 calories; 4.2 g fat; 1.5 g carbohydrates; 1.3 g protein; 2 mg cholesterol; 40 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Carrot Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 616 calories; 30.2 g fat; 83.5 g carbohydrates; 6.2 g protein; 70 mg cholesterol; 540 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "French Fries")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 471 calories; 44.1 g fat; 18.6 g carbohydrates; 2.2 g protein; 0 mg cholesterol; 6 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Fried Calamari")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 532 calories; 38.4 g fat; 31.5 g carbohydrates; 15.3 g protein; 170 mg cholesterol; 1503 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Peking Duck")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 556 calories; 31 g fat; 48.1 g carbohydrates; 22.4 g protein; 91 mg cholesterol; 748 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Red Velvet Cake")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 513 calories; 25.7 g fat; 66.6 g carbohydrates; 5.8 g protein; 74 mg cholesterol; 502 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Sushi")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 152 calories; 3.9 g fat; 25.8 g carbohydrates; 3.9 g protein; 6 mg cholesterol; 703 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Steak")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 543 calories; 43.6 g fat; 1.6 g carbohydrates; 34.6 g protein; 106 mg cholesterol; 230 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
            if (useFoodDish == "Chocolate Mousse")
            {
                UIAlertController okAlertController = UIAlertController.Create("Nutrition Facts", "Per Serving: 404 calories; 31.1 g fat; 34 g carbohydrates; 3.2 g protein; 76 mg cholesterol; 100 mg sodium;", UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
            }
        }

    }
}