   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Adquisoft.Modulos.ConfiguracionAdquisoft.Modulos.Configuracion  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   @    :Adquisoft.Modulos.Configuracion.ConfiguracionMenuPrincipal   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Adquisoft.Modulos.Configuracion     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$  ConfiguracionMenu��5       � Title$  ConfiguracionMenuPrincipal��5   	   $	��500��6,   $	��700��69    � WindowStartupLocation$ CenterScreen=�6E   .��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $
��235* �6#   �� 5      $
��235* �6#   �� 5      $
��235* �6#    � RowDefinitions 5      �� 5      $	��35* �6    �� 5      $	��65* �6    �� 5      $
��191* �6    �� 5      $
��120* �6    �� 5      $	��58* �6    .+�5      !  MahApps.Metro.Controls.Tile  -   5          Name$ btnCategorias��5      $
��Auto��63   $
��Auto��6@      Title$ Categorías��6N    J� Opacity$
 0.95Q�6a   $��
10,10,10,0q�6p   $��2��6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   ShadowDepth$	 9Q�6'   
   
BlurRadius$
 8Q�67   .��5!      �� $2��,/Adquisoft;component/Imagenes/categorias.png��6   $	��143��6N   $	��119��6Z   5"        5#      -   5        $ btnMetricas��5#      $
��Auto��61   $
��Auto��6>   $ Metricas��6L   $
 0.95Q�6]   $��	8,10,10,0q�6l   $��2��6   $��1��6�    5$        5%      $	 9Q�6'   $
 8Q�67   .��5'      �� $/��)/Adquisoft;component/Imagenes/metrica.png��6   $	��143��6K   $	��119��6W   5(        5)      -   5        $ btn_menu_principal��5)      $
��Auto��68   $
��Auto��6E   $ Inicio��6S   $
 0.95Q�6b   $��
10,10,10,0q�6q   $��2��6�    5*        5+      $	 9Q�6'   $
 8Q�67   .��5-      �� $.��(/Adquisoft;component/Imagenes/inicio.png��6   $	��143��6J   $	��119��6V   5.      50      52      53      