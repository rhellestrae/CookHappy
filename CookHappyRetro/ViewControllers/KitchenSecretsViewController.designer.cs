// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CookHappyRetro
{
    [Register ("KitchenSecretsViewController")]
    partial class KitchenSecretsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblKitchenSecrets { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblKitchenSecrets != null) {
                tblKitchenSecrets.Dispose ();
                tblKitchenSecrets = null;
            }
        }
    }
}