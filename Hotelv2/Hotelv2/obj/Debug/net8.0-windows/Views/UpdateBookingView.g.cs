﻿#pragma checksum "..\..\..\..\Views\UpdateBookingView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "618EEA75C5110F6091FC4D9A7139AF9E14B7CE97"
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
    /// UpdateBookingView
    /// </summary>
    public partial class UpdateBookingView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker BookingDate;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckIn;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckOut;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.AutoCompleteBox ClientId;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\..\Views\UpdateBookingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.AutoCompleteBox RoomId;
        
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
            System.Uri resourceLocater = new System.Uri("/Hotelv2;component/views/updatebookingview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UpdateBookingView.xaml"
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
            
            #line 17 "..\..\..\..\Views\UpdateBookingView.xaml"
            ((Hotelv2.Views.UpdateBookingView)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Views\UpdateBookingView.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BookingDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.CheckIn = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.CheckOut = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.ClientId = ((System.Windows.Controls.AutoCompleteBox)(target));
            
            #line 156 "..\..\..\..\Views\UpdateBookingView.xaml"
            this.ClientId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationLet_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RoomId = ((System.Windows.Controls.AutoCompleteBox)(target));
            
            #line 184 "..\..\..\..\Views\UpdateBookingView.xaml"
            this.RoomId.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ValidationNumb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 199 "..\..\..\..\Views\UpdateBookingView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBooking_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 206 "..\..\..\..\Views\UpdateBookingView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveBooking_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

