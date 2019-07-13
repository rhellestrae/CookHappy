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
    [Register ("KSStayFocusedViewController")]
    partial class KSStayFocusedViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblStayFocused { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblStayFocused != null) {
                tblStayFocused.Dispose ();
                tblStayFocused = null;
            }
        }
    }
}