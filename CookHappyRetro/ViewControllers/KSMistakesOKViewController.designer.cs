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
    [Register ("KSMistakesOKViewController")]
    partial class KSMistakesOKViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblMistakesOK { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblMistakesOK != null) {
                tblMistakesOK.Dispose ();
                tblMistakesOK = null;
            }
        }
    }
}