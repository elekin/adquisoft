   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Adquisoft.Modulos.Evaluacion_Adquisicion(Adquisoft.Modulos.Evaluacion_Adquisicion  5   	   D    >Adquisoft.Modulos.Evaluacion_Adquisicion.EvaluacionComparativa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:Adquisoft.Modulos.Evaluacion_Adquisicion     5   	     � Title$  EvaluacionComparativa��5   	   $	��627��6'   $	��600��64   .��5	      � .+�5
   
   �� -   5         ��Name$ 
tabControl��5
      
�������.@�5      �� -   5         ��Name$ tabSelecionarSubCategoria��5      $��
Selecionar��69   .��5      � 
�������.+�5      �� -   5         ��Name$ groupBox_Copy��5      $��	Categoria��66   $��0,10,0,0q�6I   $	��Top=�6[   $��88��6s   .��5      � $
��Left=�6   $��65��6:   $��	0,0,-8,-4q�6F   $	��Top=�6Y   $	��582��6q   .+�5      �� -   5         ��Name$ label1��5   $   $��
Categoria:��64   $
��Left=�6I   $��	26,11,0,0q�6d   $	��Top=�6w   $	��158��6�   �� 5      -   5         ��Name$ comboBoxCategoria��5   '   $
��Left=�6B   $��
189,11,0,0q�6]   $	��Top=�6q   $	��185��6�   �� 5      -   5         ��Name$ buttonCategoria��5   %   $��Aplicar��6>   $
��Left=�6P   $��
404,12,0,0q�6k   $	��Top=�6   $��75��6�   6�   5      5      �� 5      -   5        $ groupBox_Copy1��5      $��Sub-Categoria��67   $��
1,108,-1,0q�6N   $	��Top=�6b   $��90��6z   .��5      � $
��Left=�6   $��65��6:   $��	0,0,-8,-4q�6F   $	��Top=�6Y   $	��582��6q   .+�5      �� -   5        $ label2��5   $   $ ��Seleccionar Sub-Categoria:��64   $
��Left=�6Y   $��	26,11,0,0q�6t   $	��Top=�6�   $	��158��6�   �� 5      -	   5        $ comboBoxSubCategoria��5   '   $
��Left=�6E   $��
189,11,0,0q�6`   $	��Top=�6t   $	��185��6�   �� 5      -
   5        $ buttonSubCategoria��5   %   $��Aplicar��6A   $
��Left=�6S   $��
404,12,0,0q�6n   $	��Top=�6�   $��75��6�   6�   5      5      �� 5      -   5        $ groupBox_Copy2��5      $'��!Software Disponibles para evaluar��67   $��
1,258,-1,0q�6b   $	��Top=�6v   $	��235��6�   .��5      � $
��Left=�6   $	��235��6:   $	��Top=�6G   $	��576��6_   $��0,0,-2,0q�6k   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$" dataGridSoftwaresRegistrados��5   '   $
��Left=�6M      SelectionMode$ Single=�6h   	   CanUserAddRows	 .  
   
IsReadOnly
 .     CanUserSortColumns .  $��	34,22,0,0q�6�   $	��Top=�6�   $	��501��6�   $	��190��6�   6  5      5      �� 5       -   5        $ buttonComparar��5       $��Iniciar Comparación��65   $
��Left=�6S   $��422,513,0,0q�6n   $	��Top=�6�   $	��145��6�   6�   �� 5!      -   5         ��Name$ textPresupuesto��5!      $
��Left=�67   $��23��6R   $��107,218,0,0q�6^    �� TextWrapping$
 Wrap=�6s   $�� ��6�   $	��Top=�6�   $	��190��6�   �� 5"      -   5        $ label��5"      $��Presupuesto: ��6+   $
��Left=�6C   $��
12,217,0,0q�6^   $	��Top=�6r   5$      5%      �� 5&      -   5        $ tabComparaciones��5&      $��Comparaciones��60   .��5'      � 
�������.+�5(      �� -   5        $ groupBox��5(      $��Costo-Calidad��61   $��
17,58,14,0q�6H   $	��Top=�6\   $	��230��6t   .��5)        -   5        $ dataGridCostoCalidad��5)   #   5*      �� 5+      -   5        $ label3��5+      $��Presupuesto:��6,   $
��Left=�6C   $��	24,18,0,0q�6^   $	��Top=�6q   $��83��6�   �� 5,      -   5        $ labelPresupuesto��5,      $��Label��66   $
��Left=�6F   $��
109,17,0,0q�6a   $	��Top=�6u   $��98��6�   5-      5.      5/      51      52      