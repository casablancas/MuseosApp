﻿#pragma checksum "C:\Users\alex_\Documents\Visual Studio 2015\MuseosApp\ServiciosRest\InfoQR.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E3B96B451F9DD36E0DD94DF35DEDFC5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ServiciosRest {
    
    
    public partial class InfoQR : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ProgressBar loadPieza;
        
        internal System.Windows.Controls.TextBlock txtCargando;
        
        internal System.Windows.Controls.ListBox ElementosQR;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/ServiciosRest;component/InfoQR.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.loadPieza = ((System.Windows.Controls.ProgressBar)(this.FindName("loadPieza")));
            this.txtCargando = ((System.Windows.Controls.TextBlock)(this.FindName("txtCargando")));
            this.ElementosQR = ((System.Windows.Controls.ListBox)(this.FindName("ElementosQR")));
        }
    }
}

