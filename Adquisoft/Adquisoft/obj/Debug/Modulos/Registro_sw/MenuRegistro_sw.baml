   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Adquisoft.Modulos.Registro_swAdquisoft.Modulos.Registro_sw  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   3    -Adquisoft.Modulos.Registro_sw.MenuRegistro_sw   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Adquisoft.Modulos.Registro_sw     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	     � Title$  Registro de software��5   	   $	��500��6&   $	��700��63    � WindowStartupLocation$ CenterScreen=�6?   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��235* �6   �� 5      $
��235* �6   �� 5      $
��235* �6    � RowDefinitions 5   
   �� 5      $	��35* �6   �� 5      $	��65* �6   �� 5      $
��191* �6   �� 5      $
��120* �6   �� 5      $	��58* �6   .+�5   
   !  MahApps.Metro.Controls.Tile  -   5          Name$ btn_registro��5      $
��Auto��6.   $
��Auto��6;      Title$ Área Registro��6I    J� Opacity$
 0.95Q�6_   $��
10,10,10,0q�6�   $��2��6�   $��2��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 9Q�6#   	   
BlurRadius$	 8Q�63   .��5      �� $1��+/Adquisoft;component/Imagenes/registro2.png��6   $	��143��6I   $	��119��6U   5        5    
   -   5        $ btn_nuevo_sw��5       $
��Auto��6.   $
��Auto��6;   $ Nuevo Software��6I   $
 0.95Q�6`   $��	8,10,10,0q�6o   $��2��6�   $��1��6�    5!        5"      $ 9Q�6#   $	 8Q�63   .��5$      �� $-��'/Adquisoft;component/Imagenes/nuevo.png��6   $	��143��6E   $	��119��6Q   5%        5&   
   -   5        $! btn_regresar_menu_principal��5&      $
��Auto��6=   $
��Auto��6J   $ Inicio��6X   $
 0.95Q�6g   $��
10,10,10,0q�6v   $��2��6�    5'        5(      $ 9Q�6#   $	 8Q�63   .��5*      �� $.��(/Adquisoft;component/Imagenes/inicio.png��6   $	��143��6F   $	��119��6R   5+      5-      5.      