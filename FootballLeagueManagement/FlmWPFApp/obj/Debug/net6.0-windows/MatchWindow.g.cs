﻿#pragma checksum "..\..\..\MatchWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3C7553419E096F4FD71AB2956CC7AEC12837F224"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FlmWPFApp;
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


namespace FlmWPFApp {
    
    
    /// <summary>
    /// MatchWindow
    /// </summary>
    public partial class MatchWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInsertMatch;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateMatch;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteMatch;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvMatches;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDate;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MatchWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FlmWPFApp;component/matchwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MatchWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnInsertMatch = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\MatchWindow.xaml"
            this.btnInsertMatch.Click += new System.Windows.RoutedEventHandler(this.btnInsertMatch_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnUpdateMatch = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\MatchWindow.xaml"
            this.btnUpdateMatch.Click += new System.Windows.RoutedEventHandler(this.btnUpdateMatch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDeleteMatch = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\MatchWindow.xaml"
            this.btnDeleteMatch.Click += new System.Windows.RoutedEventHandler(this.btnDeleteMatch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvMatches = ((System.Windows.Controls.ListView)(target));
            
            #line 36 "..\..\..\MatchWindow.xaml"
            this.lvMatches.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvMatches_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbDate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\MatchWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

