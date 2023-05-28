﻿#pragma checksum "..\..\..\..\Windows\BeginnerTheoryWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0918845EE7E9E1446BCAF35297F76DACDBA3154"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ChessBoard.Windows;
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


namespace ChessBoard.Windows {
    
    
    /// <summary>
    /// BeginnerTheoryWindow
    /// </summary>
    public partial class BeginnerTheoryWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleLabel;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PawnTextBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock KnightTextBlock;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BishopTextBlock;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RookTextBlock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QueenTextBlock;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock KingTextBlock;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock1;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock2;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock3;
        
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
            System.Uri resourceLocater = new System.Uri("/ChessBoard;component/windows/beginnertheorywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
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
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Windows\BeginnerTheoryWindow.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.PawnTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.KnightTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.BishopTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.RookTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.QueenTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.KingTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TextBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.TextBlock2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.TextBlock3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

