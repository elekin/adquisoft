   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Adquisoft.Modulos.ConfiguracionAdquisoft.Modulos.Configuracion  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   =    7Adquisoft.Modulos.Configuracion.ConfiguracionCategorias   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Adquisoft.Modulos.Configuracion     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   
   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	     � Title$  Configuracion Categorias��5   	   $	��500��6*   $	��700��67    � WindowStartupLocation$ CenterScreen=�6C   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��44* �6   �� 5      $	��93* �6   �� 5      $	��89* �6   �� 5      $
��131* �6   �� 5      $	��25* �6   �� 5      $
��114* �6   �� 5      $	��87* �6   �� 5      $	��48* �6   �� 5      $	��41* �6    � RowDefinitions 5   
   �� 5      $	��99* �6   �� 5      $��22 �6   �� 5      $	��27* �6   �� 5      $	��232 �6   �� 5       $	��15* �6   �� 5!      $��24 �6   �� 5"      $	��50* �6   .+�5$   
   �� -   5         ��Name$ lblSeleccionarCategorias��5$      $��Seleccionar Categoría��62   $��
10,0,80,22q�6R   $��1��6f   $��4��6s   $��2��6�   �� 5%   
   -   5         ��Name$ cbCategorias��5%      $��3��6)   $��
10,0,10,23q�69   $��1��6M   $��2��6Z   $��2��6n   �� 5&   
   -   5         ��Name$ 
btnAplicar��5&      $��Aplicar��6%   $��6��67   $��
10,96,10,0q�6G   $��2��6[      AccentedSquareButtonStyle#��[  6�   $��10(�6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ dg_SubCategorias��5'      $��8��6-   $��10q�6A   $��3��6M   $��1��6Z   �� 5(   
   -   5        $ btnAgregarSubcategoria��5(      $��Agregar��61   $��2��6C   $��
10,1,10,48q�6S   $��5��6g   $��2��6t   #��[  6�   $��10(�6�   6�   �� 5)   
   -   5        $ btnEditarSubcategoria��5)      $��Editar��60   $��3��6A   $��
10,1,10,48q�6Q   $��5��6e   $��2��6r   #��[  6�   $��10(�6�   6�   �� 5*   
   -   5        $ btnEliminarSubcategoria��5*      $��Eliminar��62   $��4��6E   $��
10,0,10,49q�6U   $��5��6i   $��2��6v   #��[  6�   $��10(�6�   6�   5,      5-      