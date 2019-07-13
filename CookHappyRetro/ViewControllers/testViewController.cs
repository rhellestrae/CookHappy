using CoreGraphics;
using CoreML;
using Foundation;
using Plugin.Media;
using System;
using System.Diagnostics;
using UIKit;
using Vision;

namespace CookHappyRetro
{
    public partial class testViewController : UIViewController
    {
        UIImageView imageView;
        UIButton btnTakePicture, btnGoToRecipe;

        UIImageView imageViewFoodPhoto;

        string recipeFoodDish;

        UIScrollView scrollView;
        UIImageView imageViewBG;

        UILabel outputLabel;

        UIActivityIndicatorView activityIndication;

        VNCoreMLModel model;
        VNRequest[] classificationRequests;

        public testViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Food Photo";
            View.BackgroundColor = UIColor.White;

            imageViewBG = new UIImageView(UIImage.FromFile("BackgroundImageTakePhoto.png"));

            scrollView = new UIScrollView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            View.AddSubview(scrollView);

            imageViewFoodPhoto = new UIImageView(UIImage.FromFile("PhotoFoodThree.png"));
            imageViewFoodPhoto.Frame = new CGRect(0, 10, View.Bounds.Width, 225);

            imageView = new UIImageView(UIImage.FromFile(""));

            activityIndication = new UIActivityIndicatorView();

            activityIndication.Color = UIColor.Blue;

            activityIndication.Frame = new CGRect(20, 250, 50, 50);

            // food photo
            btnTakePicture = UIButton.FromType(UIButtonType.Custom);
            btnTakePicture.SetImage(UIImage.FromFile("TakePicture.png"), UIControlState.Normal);

            btnTakePicture.Frame = new CGRect(0, 320, View.Bounds.Width, 231);
            btnTakePicture.TouchUpInside += BtnPicture_TouchUpInside;

            outputLabel = new UILabel()
            {
                Text = "Accuracy Indicator",
                Font = UIFont.FromName("Papyrus", 20f),
                TextColor = UIColor.Magenta,
                TextAlignment = UITextAlignment.Center,
                Frame = new CGRect(0, 570, View.Bounds.Width, 40)
            };

            scrollView.ContentSize = imageViewBG.Image.Size;
            scrollView.AddSubview(imageViewBG);

            scrollView.AddSubview(imageViewFoodPhoto);
            scrollView.AddSubview(activityIndication);
            scrollView.AddSubview(btnTakePicture);
            scrollView.AddSubview(outputLabel);
        }

        async void BtnPicture_TouchUpInside(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            activityIndication.StartAnimating();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                Debug.WriteLine("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;
            Debug.WriteLine("File Location", file.Path, "OK");

            var imagedata = NSData.FromStream(file.GetStream());

            imageViewFoodPhoto.Image =
                UIImage.LoadFromData(imagedata);

            CommonClass.imageViewFoodPhotoSave = UIImage.LoadFromData(imagedata);

            var requestHandler = new VNImageRequestHandler(imagedata, new VNImageOptions());
            requestHandler.Perform(ClassificationRequest, out NSError error);

            if (error != null)
                Debug.WriteLine($"Error identifying {error}");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public VNRequest[] ClassificationRequest
        {
            get
            {
                if (model == null)
                {
                    var modelPath = NSBundle.MainBundle.GetUrlForResource("CookHappyJune", "mlmodel");
                    // var modelPath = NSBundle.MainBundle.GetUrlForResource("CookHappyThreeOne", "mlmodel");
                    var compiledPath = MLModel.CompileModel(modelPath, out NSError compileError);
                    var mlModel = MLModel.Create(compiledPath, out NSError createError);

                    model = VNCoreMLModel.FromMLModel(mlModel, out NSError mlError);
                }

                if (classificationRequests == null)
                {
                    var classificationRequest = new VNCoreMLRequest(model, HandleClassificationRequest);
                    classificationRequests = new[] { classificationRequest };
                }

                return classificationRequests;
            }
        }

        void HandleClassificationRequest(VNRequest request, NSError error)
        {
            var observations = request.GetResults<VNClassificationObservation>();
            var best = observations?[0];

            outputLabel.Text = $"{best.Identifier.Trim()}, {best.Confidence:P0}";

            activityIndication.StopAnimating();

            var saveFoodDish = best.Identifier.Trim();
            recipeFoodDish = best.Identifier.Trim();

            if (saveFoodDish == "Deviled Eggs")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Tacos")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Apple Pie")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Baby Back Ribs")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Clam Chowder")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Eggs Benedict")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Filet Mignon")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Grilled Cheese Sandwich")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Hamburger")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Lobster Bisque")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Macaroni and Cheese")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Nachos")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Omelette")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Pancakes")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Ravioli")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Strawberry Shortcake")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Waffles")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Caesar Salad")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Cheesecake")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Donuts")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Club Sandwich")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Escargots")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Fish and Chips")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Frozen Yogurt")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Huevos Rancheros")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Ice Cream")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Lasagna")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Pizza")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Spaghetti Bolognese")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Takoyaki")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Scallops")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Bruschetta")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Carrot Cake")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "French Fries")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Fried Calamari")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Peking Duck")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Red Velvet Cake")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Sushi")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Steak")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }
            if (saveFoodDish == "Chocolate Mousse")
            {
                // Create Alert
                var okCancelAlertController = UIAlertController.Create("Food Dish Photo", "Is " + saveFoodDish + " correct?", UIAlertControllerStyle.Alert);

                // Add Actions
                okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTapped(); }));

                okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTapped(); }));

                // Present Alert
                PresentViewController(okCancelAlertController, true, null);
            }

        }

        private void AlertYesTapped()
        {

            // Code to execute when user tapped Yes - Create Alert
            var okCancelAlertController = UIAlertController.Create(recipeFoodDish, "Browse Recipe?", UIAlertControllerStyle.Alert);

            // Add Actions
            okCancelAlertController.AddAction(UIAlertAction.Create("Yes", UIAlertActionStyle.Default, alert => { AlertYesTappedRecipe(); }));

            okCancelAlertController.AddAction(UIAlertAction.Create("No", UIAlertActionStyle.Cancel, alert => { AlertNoTappedRecipe(); }));

            // Present Alert
            PresentViewController(okCancelAlertController, true, null);
        }

        private void AlertNoTapped()
        {
            // Code to exectue when user tapped No

        }

        private void AlertYesTappedRecipe()
        {
            CommonClass.value = recipeFoodDish;

            // Launches a new instance of PictureRecipesViewController
            PictureRecipesViewController callHistory = this.Storyboard.InstantiateViewController("PictureRecipesViewController") as PictureRecipesViewController;

            if (callHistory != null)
            {
                this.NavigationController.PushViewController(callHistory, true);
            }
        }

        private void AlertNoTappedRecipe()
        {

        }

        protected void HandleTouchUpInside(object sender, System.EventArgs e)
        {
            var button = sender as UIButton;
            new UIAlertView(button.Title(UIControlState.Normal) + " click"
                    , "TouchUpInside Handled"
                    , null
                    , "OK"
                    , null).Show();

        }

    }
}