﻿#pragma checksum "..\..\..\UserControls\PasswordDataGrid.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BB272B2D480266CFB948F0E489FCA37C877C7E04"
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
    /// PasswordDataGrid
    /// </summary>
    public partial class PasswordDataGrid : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UserControls\PasswordDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid PasswordDataGridBody;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControls\PasswordDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HeaderGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\UserControls\PasswordDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelCategory;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControls\PasswordDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome dropdownImage;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UserControls\PasswordDataGrid.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PasswordGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/PasswordManager.WPF;component/usercontrols/passworddatagrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\PasswordDataGrid.xaml"
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
            this.PasswordDataGridBody = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.HeaderGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.LabelCategory = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.dropdownImage = ((FontAwesome.WPF.ImageAwesome)(target));
            
            #line 32 "..\..\..\UserControls\PasswordDataGrid.xaml"
            this.dropdownImage.MouseEnter += new System.Windows.Input.MouseEventHandler(this.DropdownImage_MouseEnter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\UserControls\PasswordDataGrid.xaml"
            this.dropdownImage.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DropdownImage_MouseLeave);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\UserControls\PasswordDataGrid.xaml"
            this.dropdownImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DropdownImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PasswordGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 37 "..\..\..\UserControls\PasswordDataGrid.xaml"
            this.PasswordGrid.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Grid_PreviewMouseWheel);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\UserControls\PasswordDataGrid.xaml"
            this.PasswordGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PasswordGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

