   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Adquisoft.Modulos.Evaluacion_Calidad$Adquisoft.Modulos.Evaluacion_Calidad  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   :    4Adquisoft.Modulos.Evaluacion_Calidad.NuevaEvaluacion   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:Adquisoft.Modulos.Evaluacion_Calidad     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   T
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro     5	   	     � Title$  NuevaEvaluacion��5
   	   $	��600��6!   $	��650��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5      � .+�5   
   �� -   5         ��Name$ 
tabControl��5      .@�5      �� -   5         ��Name$ tabEvaluaciones��5      $��Evaluaciones��6/   .��5      � 
�������.+�5      �� -   5         ��Name$ buttonModificarEvaluacion��5         AccentedSquareButtonStyle#��[  6A   $��Ver Evaluacion��6t   $
��Left=�6�   $��
67,343,0,0q�6�   $	��Top=�6�   $	��115��6�   6�   �� 5      -   5        $ buttonNuevaEvalaucion��5      #��[  6=   $��Nueva Evaluacion��6p   $
��Left=�6�   $��232,343,0,0q�6�   $	��Top=�6�   $	��115��6�   6�   �� 5      -   5         ��Name$ groupBox��5      $��Historial de Evaluaciones��61   $
��Left=�6T   $��	27,19,0,0q�6o   $	��Top=�6�   $	��294��6�   $	��580��6�   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$( "dataGridHistorialEvaluacionCalidad��5   #      SelectionMode$ Single=�6O      CanUserAddRows .  	   
IsReadOnly	 . 
   CanUserSortColumns
 .  6�   5      5      5      �� 5      -   5        $ tabInciarEvaluacion��5      $��Iniciar Evaluacion��63   .��5      � 
�������.+�5      �� -   5        $ 	buttonAnt��5      $��Anterior��60   $
��Left=�6C   $��227,483,0,0q�6^   $	��Top=�6s   $��75��6�   6�   �� 5      -	   5        $! buttonFinalizarCuestionario��5      $��Finalizar Evaluacion��6B   {�.  $
��Left=�6s   $��472,483,0,0q�6�   $	��Top=�6�   $	��135��6�   6�   �� 5      -
   5        $ 	groupBox1��5      $��Detalle Metrica��62   $
��Left=�6K   $��	27,98,0,0q�6f   $	��Top=�6y   $	��585��6�   $	��205��6�   .��5      � $
��Left=�6   $	��175��6:   $��-5,-5,-22,-4q�6G   $	��Top=�6]   $	��600��6u   .+�5      �� -   5         ��Name$ label1��5   $   $��Nombre:��64   $
��Left=�6F   $��	14,31,0,0q�6a   $	��Top=�6t   $��70��6�   �� 5      -   5        $ labelNombre��5   $   $��Label��69   $
��Left=�6I   $��	89,31,0,0q�6d   $	��Top=�6w   $	��160��6�   �� 5      -   5        $ labelID��5   $   $��Label��65   $
��Left=�6E   $��89,7,0,0q�6`   $	��Top=�6r   $	��115��6�   �� 5      -   5        $ label5��5   $   $	��ID:��64   $
��Left=�6B   $��14,7,0,0q�6]   $	��Top=�6o   $��35��6�   �� 5       -   5        $ label1_Copy��5    $   $��Propósito:��69   $
��Left=�6N   $��	14,57,0,0q�6i   $	��Top=�6|   $��65��6�   �� 5!      -   5        $ label1_Copy1��5!   $   $��Metodo:��6:   $
��Left=�6L   $��
14,106,0,0q�6g   $	��Top=�6{   $��70��6�   �� 5"      -   5         ��Name$ labelMetodo��5"   &    �� 
IsReadOnly . $
��Left=�6e   $��60��6�   $��
89,107,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��475��6�   ��6;   Z� 6�   �� 5#      -   5        $ labelProposito��5#   &    . $
��Left=�6h   $��45��6�   $��	89,57,0,0q�6�   $
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��475��6�   ��6>   Z� 6�   5&      5(      �� 5)      -   5        $ 	groupBox2��5)      $��Perspectiva��62   $
��Left=�6G   $��	27,13,0,0q�6b   $	��Top=�6u   $	��585��6�   $��75��6�   .��5*      � $
��Left=�6   $��40��6:   $��
-5,0,-7,-4q�6F   $	��Top=�6Z   $	��585��6r   .+�5+      �� -   5        $ labelf��5+   $   $��Caracteristica:��64   $
��Left=�6N   $��9,1,0,0q�6i   $	��Top=�6z   $��90��6�   �� 5,      -   5        $ labelf_Copy��5,   $   $��SubCaracteristica:��69   $
��Left=�6V   $��	279,1,0,0q�6q   $	��Top=�6�   $	��110��6�   �� 5-      -   5        $ label_caracteristica��5-   $   $��Label:��6B   $
��Left=�6S   $��	104,2,0,0q�6n   $	��Top=�6�   $	��140��6�   �� 5.      -   5        $ label_subcaracteristica��5.   $   $��Label:��6E   $
��Left=�6V   $��	404,1,0,0q�6q   $	��Top=�6�   $	��140��6�   5/      50      �� 51      -   5        $ 	groupBox3��51      $��Formula��62   $
��Left=�6C   $��
27,313,0,0q�6^   $	��Top=�6r   $	��585��6�   $	��160��6�   .��52      � $
��Left=�6   $	��130��6:   $��
0,-5,-7,-4q�6G   $	��Top=�6[   $	��580��6s   .+�53      �� -   5        $ label2��53   $   $��A:��64   $
��Left=�6A   $��	19,48,0,0q�6\   $	��Top=�6o   $��25��6�   �� 54      -   5        $ textBoxA��54   &   $
��Left=�68   $��23��6S   $��	54,48,0,0q�6_   $
 Wrap=�6r   $��0��6�   $	��Top=�6�   $��40��6�   6�   �� 55      -   5         ��Name$ slider��55   %   $
��Left=�65    �� Ticks$&  0 10 20 30 40 50 60 70 80 90 100R�6P    �� IsSnapToTickEnabled . $��
109,52,0,0q�6�   $	��Top=�6�   $	��115��6�    � Maximum$	 100Q�6�    � Minimum$ 0Q�6�    � SmallChange$ 10Q�6	  �� 56      -   5        $ label2_Copy��56   $   $��B:��69   $
��Left=�6F   $��	19,91,0,0q�6a   $	��Top=�6t   $��30��6�   �� 57      -   5        $ textBoxB��57   &   $
��Left=�68   $��23��6S   $��	54,90,0,0q�6_   $
 Wrap=�6r   $��0��6�   $	��Top=�6�   $��40��6�   6�   �� 58      -   5        $ slider_Copy��58   %   $
��Left=�6:   $&  0 10 20 30 40 50 60 70 80 90 100R�6U    . $��
109,95,0,0q�6�   $	��Top=�6�   $	��115��6�   $	 100Q�6�   $ 0Q�6�   $ 10Q�6  �� 59      -   5        $ label1_Copy2��59   $   $��Formula:��6:   $
��Left=�6M   $��14,6,0,0q�6h   $	��Top=�6z   $��65��6�   �� 5:      -    5        $ label1_formula��5:   $   $��Label:��6<   $
��Left=�6M   $��84,6,0,0q�6h   $	��Top=�6z   $��65��6�   �� 5;      -!   5        $ label1_Copy3��5;   $   $��Mejor Valor:��6:   $
��Left=�6Q   $��	259,6,0,0q�6l   $	��Top=�6   $��75��6�   �� 5<      -"   5        $ label1_mejor_valor��5<   $   $��Label:��6@   $
��Left=�6Q   $��	344,6,0,0q�6l   $	��Top=�6   $��60��6�   �� 5=      -#   5        $ label1_Copy4��5=   $   $��Peor Valor:��6:   $
��Left=�6P   $��	419,6,0,0q�6k   $	��Top=�6~   $��70��6�   �� 5>      -$   5        $ label1_Peor_Valor��5>   $   $��Label:��6?   $
��Left=�6P   $��	504,6,0,0q�6k   $	��Top=�6~   $��65��6�   �� 5?      -%   5        $ labelDescripcionA��5?   &    . $
��Left=�6j   $��23��6�   $��
239,47,0,0q�6�   $
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��320��6�   ��6S   Z� 6�   �� 5@      -&   5        $ labelDescripcionB��5@   &    . $
��Left=�6j   $��23��6�   $��
244,86,0,0q�6�   $
 Wrap=�6�   $��TextBox��6�   $	��Top=�6�   $	��320��6�   ��6S   Z� 6�   5A      5B      �� 5C      -'   5        $ 	buttonSig��5C      $��	Siguiente��60   $
��Left=�6D   $��307,483,0,0q�6_   $	��Top=�6t   $��75��6�   6�   5E      5G      �� 5H      -(   5        $! tabReporteEvaluacionCalidad��5H      $�� ��6;   .��5I      � 
�������.+�5J      �� -)   5        $ 	groupBox4��5J      $��Nivel Sub-Caracteristicas��62   $��
17,21,14,0q�6U   $	��Top=�6i   $	��217��6�   .��5K        -*   5        $  dataGridSubCaracteristicas��5K   #   5L      �� 5M      -+   5        $ groupBox4_Copy��5M      $��Nivel Caracteristicas��67   $��17,253,14,0q�6V   $	��Top=�6k   $	��150��6�   .��5N        -,   5        $ dataGridCaracteristica��5N   #   5O      �� 5P      --   5        $ groupBox4_Copy1��5P      $��Nivel Calidad Producto��68   $��17,413,14,0q�6X   $	��Top=�6m   $	��100��6�   .��5Q        -.   5        $" dataGridNivelCalidadProducto��5Q   #   5R      5T      5V      5W      5Y      5Z      