﻿#pragma checksum "..\..\..\UserControls\PasswordRow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD6BEA73F4033D7172D3650805EDE8863B2E59EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using PasswordManager.WPF.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PasswordManager.WPF.UserControls {
    
    
    /// <summary>
    /// PasswordRow
    /// </summary>
    public partial class PasswordRow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition CheckBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Icon;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Domain;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition Username;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SelectionCheckBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageWebsiteIcon;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome LoadingImage;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome ErrorImage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextboxDomainName;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UserControls\PasswordRow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextboxUsername;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PasswordManager.WPF;component/usercontrols/passwordrow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\PasswordRow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CheckBox = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            this.Icon = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 3:
            this.Domain = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.Username = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.SelectionCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.ImageWebsiteIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.LoadingImage = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 8:
            this.ErrorImage = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 9:
            this.TextboxDomainName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TextboxUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

