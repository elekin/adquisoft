   M S B A M L   `   `   `  ����D  @Adquisoft, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Adquisoft.Modulos.Perfil_usuario Adquisoft.Modulos.Perfil_usuario  5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	   Z=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   4    .Adquisoft.Modulos.Perfil_usuario.Perfilusuario   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Adquisoft.Modulos.Perfil_usuario     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	     � Title$  Perfilusuario��5   	   $	��637��6   $	��700��6,    � WindowStartupLocation$ CenterScreen=�68   .��5      � .+�5   
   �� -   5         ��Name$ groupInformacionUser��5      $��Información Usuario��61   $��
10,35,10,0q�6N   $	��235��6b   $	��Top=�6o   �� 5   
   -   5        $ groupGestionAcceso��5      $��Gestion Acceso��6/   $��10,290,10,86q�6G   .��5      � $��4,0,4,4q�6    � ColumnDefinitions 5      �� 5      $
��135* �6'   �� 5      $
��215* �6'   �� 5      $	��75* �6'   �� 5      $
��130* �6'   �� 5      $	��97* �6'    � RowDefinitions 5      �� 5      $	��17* �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $	��55* �6$   .+�5!      �� -   5         ��Name$ LblUser��5!      $��Usuario��6)   $��
10,10,10,0q�6;   $��1��6O   �� 5"      -   5        $ lblPassword��5"      $��Contraseña��6-   $��
10,14,10,0q�6B   $��2��6V   �� 5#      -   5         ��Name$ textUser��5#      $��10,0,0,-0.002q�6,    �� TextWrapping$
 Wrap=�6C   $��1��6W   $��1��6g   $��20��6t   $��Bottom=�6�   G� 5$      -   5         G�Name$ passwordBox_user��5$      $��25��68   $��10,14,0,-0.001q�6D   $��1��6\   $��2��6l   �� 5%      -   5        $ lblRepitepassword��5%      $��Repite Contraseña��63   $��
10,14,10,0q�6O   $��3��6c   $y�Hidden=�6p   G� 5&      -   5        $ passwordBox_user_repite��5&      $��25��6?   $��10,14,0,-0.001q�6K   $��1��6c   $��3��6s   $y�Hidden=�6�   �� 5'      -	   5        	 ��Name$	 btnModificarPassword��5'      $��Cambiar Contraseña��67   $��0,10,0,-0.001q�6T   $��3��6k   $��2��6{   6�   �� 5(      -
   5        $"	 btnModificarPassword_Guardar��5(      $��Guardar��6?   $��0,10,0,39.999q�6Q   $��3��6h   $��2��6x   $��2��6�   $y�Hidden=�6�   6�   5)      5*      � 5+   
   $��
10,75,30,0q�6   $	��180��6#   $	��Top=�60    5,      �� 5-      $
��150* �6#   �� 5.      $
��305* �6#   �� 5/      $
��207* �6#    51      �� 52      $��40 �6    �� 53      $��40 �6    �� 54      $��40 �6    �� 55      $��40 �6    �� 56      .+�58      �� -   5        $ 
textNombre��58      $��1��6*   $��
10,10,10,0q�6:   $
 Wrap=�6N   �� 59      -   5        $ label��59      $��Nombre��6#   $��
10,10,10,0q�64   �� 5:      -   5        $ 
label_Copy��5:      $��Apellido paterno��6(   $��
10,10,10,0q�6C   $��1��6W   �� 5;      -   5        $ label_Copy1��5;      $��Apellido Materno��6)   $��
10,10,10,0q�6D   $��2��6X   �� 5<      -   5        $ textApellido1��5<      $��1��6-   $��
10,10,10,0q�6=   $
 Wrap=�6Q   $��1��6e   �� 5=      -   5        $ textApellido2��5=      $��1��6-   $��
10,10,10,0q�6=   $
 Wrap=�6Q   $��2��6e   �� 5>      -   5        $ lblCargo��5>      $��Cargo��6&   $��
10,10,10,0q�66   $��3��6J   �� 5?      -   5        $ 	textCargo��5?      $��1��6)   $��
10,10,10,0q�69   $
 Wrap=�6M   $��3��6a   �� 5@      -   5        $	 btnModificar��5@      $��	Modificar��6+   $
��Left=�6?   $��	70,10,0,0q�6Z   $	��Top=�6m   $��75��6�   $��2��6�   $��3��6�   6�   �� 5A      -   5        $	 btnModificar_guardar��5A      $��Guardar��63   $
��Left=�6E   $��	70,10,0,0q�6`   $	��Top=�6s   $��75��6�   $��2��6�   $��3��6�   $��Hidden=�6�   $y�Hidden=�6  5B      5D      5E      