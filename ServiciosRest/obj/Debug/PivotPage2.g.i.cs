﻿#pragma checksum "C:\Users\alex_\Documents\Visual Studio 2015\MuseosApp\ServiciosRest\PivotPage2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E49F3C2E2A0EDA9F66079908F877077E"
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
    
    
    public partial class PivotPage2 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot PivotCategorias;
        
        internal System.Windows.Controls.Grid Arte;
        
        internal System.Windows.Controls.ProgressBar loadMuseosArte;
        
        internal System.Windows.Controls.ListBox ElementosArte;
        
        internal System.Windows.Controls.Grid Interactivo;
        
        internal System.Windows.Controls.ProgressBar loadMuseosInteractivo;
        
        internal System.Windows.Controls.ListBox ElementosInteractivo;
        
        internal System.Windows.Controls.Grid Historia;
        
        internal System.Windows.Controls.ProgressBar loadMuseosHistoria;
        
        internal System.Windows.Controls.ListBox ElementosHistoria;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ServiciosRest;component/PivotPage2.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.PivotCategorias = ((Microsoft.Phone.Controls.Pivot)(this.FindName("PivotCategorias")));
            this.Arte = ((System.Windows.Controls.Grid)(this.FindName("Arte")));
            this.loadMuseosArte = ((System.Windows.Controls.ProgressBar)(this.FindName("loadMuseosArte")));
            this.ElementosArte = ((System.Windows.Controls.ListBox)(this.FindName("ElementosArte")));
            this.Interactivo = ((System.Windows.Controls.Grid)(this.FindName("Interactivo")));
            this.loadMuseosInteractivo = ((System.Windows.Controls.ProgressBar)(this.FindName("loadMuseosInteractivo")));
            this.ElementosInteractivo = ((System.Windows.Controls.ListBox)(this.FindName("ElementosInteractivo")));
            this.Historia = ((System.Windows.Controls.Grid)(this.FindName("Historia")));
            this.loadMuseosHistoria = ((System.Windows.Controls.ProgressBar)(this.FindName("loadMuseosHistoria")));
            this.ElementosHistoria = ((System.Windows.Controls.ListBox)(this.FindName("ElementosHistoria")));
        }
    }
}

