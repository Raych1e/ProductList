﻿#pragma checksum "..\..\..\Pages\TradeList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "02FF57184EF0A09E4B8E604EA1F0A8F73EC43F71D5FE618609ECD101582BC2F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProductsList.Pages;
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


namespace ProductsList.Pages {
    
    
    /// <summary>
    /// TradeList
    /// </summary>
    public partial class TradeList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Pages\TradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBProductSearch;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\TradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBManafacturers;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\TradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBSort;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\TradeList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVProducts;
        
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
            System.Uri resourceLocater = new System.Uri("/ProductsList;component/pages/tradelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TradeList.xaml"
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
            this.TBProductSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Pages\TradeList.xaml"
            this.TBProductSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBProductSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CBManafacturers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\..\Pages\TradeList.xaml"
            this.CBManafacturers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBManafacturers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CBSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\Pages\TradeList.xaml"
            this.CBSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LVProducts = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            
            #line 74 "..\..\..\Pages\TradeList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenAddItemPage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

