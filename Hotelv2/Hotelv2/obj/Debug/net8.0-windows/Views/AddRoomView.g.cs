﻿#pragma checksum "..\..\..\..\Views\AddRoomView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "067FEBBE18F02B75C4481A76844A3BCE94F8F93B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Hotelv2.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Hotelv2.Views {
    
    
    /// <summary>
    /// AddRoomView
    /// </summary>
    public partial class AddRoomView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberRoom;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Floor;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Category;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Economy;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Standard;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem JuniorSuite;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Suite;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberSeats;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\..\Views\AddRoomView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Hotelv2;component/views/addroomview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\AddRoomView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\..\Views\AddRoomView.xaml"
            ((Hotelv2.Views.AddRoomView)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Views\AddRoomView.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NumberRoom = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\..\Views\AddRoomView.xaml"
            this.NumberRoom.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationNumb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Floor = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\..\Views\AddRoomView.xaml"
            this.Floor.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationNumb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Category = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Economy = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.Standard = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.JuniorSuite = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.Suite = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.NumberSeats = ((System.Windows.Controls.TextBox)(target));
            
            #line 154 "..\..\..\..\Views\AddRoomView.xaml"
            this.NumberSeats.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationNumb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            
            #line 182 "..\..\..\..\Views\AddRoomView.xaml"
            this.Price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationNumb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 198 "..\..\..\..\Views\AddRoomView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseRoom_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 205 "..\..\..\..\Views\AddRoomView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OkRoom_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

