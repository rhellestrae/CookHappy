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
    [Register ("KSBowlsViewController")]
    partial class KSBowlsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblKSBowls { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblKSBowls != null) {
                tblKSBowls.Dispose ();
                tblKSBowls = null;
            }
        }
    }
}