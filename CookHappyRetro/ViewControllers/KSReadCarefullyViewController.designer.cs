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
    [Register ("KSReadCarefullyViewController")]
    partial class KSReadCarefullyViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblReadCarefully { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblReadCarefully != null) {
                tblReadCarefully.Dispose ();
                tblReadCarefully = null;
            }
        }
    }
}