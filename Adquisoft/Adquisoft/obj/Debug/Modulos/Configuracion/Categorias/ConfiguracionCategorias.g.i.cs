﻿#pragma checksum "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC8DCB828502597B1B40581520D96AB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Adquisoft.Modulos.Configuracion;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
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
using System.Windows.Interactivity;
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


namespace Adquisoft.Modulos.Configuracion {
    
    
    /// <summary>
    /// ConfiguracionCategorias
    /// </summary>
    public partial class ConfiguracionCategorias : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSeleccionarCategorias;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCategorias;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAplicar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_SubCategorias;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarSubcategoria;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditarSubcategoria;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarSubcategoria;
        
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
            System.Uri resourceLocater = new System.Uri("/Adquisoft;component/modulos/configuracion/categorias/configuracioncategorias.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
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
            this.lblSeleccionarCategorias = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cbCategorias = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.btnAplicar = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
            this.btnAplicar.Click += new System.Windows.RoutedEventHandler(this.btnAplicar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dg_SubCategorias = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.btnAgregarSubcategoria = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
            this.btnAgregarSubcategoria.Click += new System.Windows.RoutedEventHandler(this.btnAgregarSubcategoria_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEditarSubcategoria = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
            this.btnEditarSubcategoria.Click += new System.Windows.RoutedEventHandler(this.btnEditarSubcategoria_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEliminarSubcategoria = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\..\Modulos\Configuracion\Categorias\ConfiguracionCategorias.xaml"
            this.btnEliminarSubcategoria.Click += new System.Windows.RoutedEventHandler(this.btnEliminarSubcategoria_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
