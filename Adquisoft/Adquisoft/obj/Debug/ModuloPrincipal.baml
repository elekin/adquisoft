   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	    	Adquisoft   Adquisoft.ModuloPrincipal   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6F     � Title$S  MMenu Principal: Evaluación de Calidad Para la adquisición de Nuevo Software��5   	   
�������$	��555��6p   $
��1060��6}    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��36* �6   �� 5      $	��23* �6   �� 5      $
��204* �6   �� 5      $
��261* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   $	��250��6,   �� 5      $
��Auto �6   $	��250��6,   �� 5      $
��Auto �6   $	��258��6,   .+�5   
   !   MahApps.Metro.Controls.Tile  -   5          Name$ btnRegistroSoftware��5      $
��Auto��65   $
��Auto��6B      Title$ Registro Software��6P    J� Opacity$
 0.95Q�6j   $��13,16,16,62q�6y   $��1��6�   $��3��6   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 9Q�6#   	   
BlurRadius$	 8Q�63   .��5      �� $��Imagenes/sw.png��6   $	��143��6-   $	��119��69   5        5   
   -   5        $ btnEvaluacionCalidad��5      $
��Auto��66   $
��Auto��6C   $ Evaluación Calidad��6Q   $
 0.95Q�6l   $��
13,5,22,16q�6{   $��2��6�   $��2��6�    5        5       $ 9Q�6#   $	 8Q�63   .��5"      �� $��Imagenes/quality.png��6   $	��143��62   $	��119��6>   5#        5$   
   -   5        $ btnConfiguracion��5$      $
��Auto��62   $
��Auto��6?   $ Configuración��6M   $
 0.95Q�6c   $��
20,5,39,16q�6r   $��3��6�   $��2��6�    5%        5&      $ 9Q�6#   $	 8Q�63   .��5(      �� $"��Imagenes/configuracion_2.png��6   $	��143��6:   $	��119��6F   5)        5*   
   -   5        $ btnInformesEvaluacion��5*      $
��Auto��67   $
��Auto��6D   $ Informes evaluación��6R   $
 0.95Q�6n   $��20,16,39,62q�6�   $��3��6�   $��3��63   5+        5,      $ 9Q�6#   $	 8Q�63   .��5.      �� $��Imagenes/informe1.png��6   $	��143��63   $	��119��6?   5/        50   
   -   5        $ btnEvaluacionAdquisicion��50      $
��Auto��6:   $
��Auto��6G   $ Evaluación Adquisición��6U   $
 0.95Q�6t   $��13,16,22,62q�6�   $��2��6�   $��3��6�    51        52      $ 9Q�6#   $	 8Q�63   .��54      �� $��Imagenes/costo.png��6   $	��143��60   $	��119��6<   55        56   
   -   5        $ btnPerfil_usuario��56      $
��Auto��63   $
��Auto��6@   $ Perfil Usuario��6N   $
 0.95Q�6e   $��
13,5,16,16q�6t   $��1��6�   $��2��6�    57        58      $ 9Q�6#   $	 8Q�63   .��5:      �� $��Imagenes/usuario.png��6   $	��143��62   $	��119��6>   5;        5<   
   -   5        $ btnAdministracion��5<      $
��Auto��63   $
��Auto��6@   $ Administración��6N   $
 0.95Q�6e   $��
35,5,18,62q�6t   $��2��6�   $��2��6�    5=        5>      $ 9Q�6#   $	 8Q�63   .��5@      �� $��Imagenes/administra1.png��6   $	��143��66   $	��119��6B   5A      �� 5B   
   -   5        
 ��Name$
 label��5B      $��Sesión:��6   $��3��61   $��
10,0,181,0q�6A   �� 5C   
   -	   5         ��Name$ image��5C      $��2��6   $��	202,0,0,0q�6/   $��Imagenes/userr.png��6B   �� 5D   
   -
   5        $
 lbl_nombre_usuario��5D      $
��user��6,   $��3��6;   $��Right=�6K   $��	0,0,87,19q�6g   $��89��6z   $��2��6�   �� 5E   
   -   5         ��Name$ btn_cerrar_sesion��5E      $��cerrar sesion��6,   $��3��6D   $
��Left=�6T   $��
152,10,0,0q�6o   $	��Top=�6�   $��67��6�   $��26��6�   $��7(�6�   $��Oblique$�6�   $��0q�6�   $ 0.995Q�6�   ��6�   Z� 6  5L      5M      