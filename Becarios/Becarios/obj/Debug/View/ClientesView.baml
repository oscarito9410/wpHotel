   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=1.1.3.28, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Becarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Becarios.ViewBecarios.View 5   	       Becarios.View.ClientesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   'localclr-namespace:Becarios.View  5   	   $	��620��5	      $	��620��6)     � 
ResizeMode$  NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � Title$ Cliente��6p   (   "MahApps.Metro.Controls.MetroWindow   EnableDWMDropShadow . ��5
      �� 5   
    �� ImageSource$, &/Becarios;component/Imagenes/fondo.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5         LeftWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� ��6   �� *commandGoBack+.��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� $��15��6    $��15��6+   ��5      �� 
 �� RelativeSource
 ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*      appbar_arrow_left !� Visual# [  5       5"      �� 5#      $��4 0 0 0q�6    $��Center=�5$      $��Atras��5%      5&      5'      5(         RightWindowCommands 5+        5,   
   .@�5-      �� .��5.      �� $	 
Horizontal=�6   .+�5/      �� $��15��6    $��15��6+   ��50      �� 
 �� $ ButtonL�$ 
Foreground� 51      !� 52      $
 Fill=�6*     appbar_user# [ 53      55      �� 56      $��4 0 0 0q�6    $��Center=�57      ��58      �� *id+ �� Mode$ TwoWay=�59      5:      �� 5;      ��6   �� *commandAnterior+.��5<      �� $	 
Horizontal=�6   .+�5=      �� $��15��6    $��15��6+   ��5>      �� 
 �� $ ButtonL�$ 
Foreground� 5?      !� 5@      $
 Fill=�6*     appbar_chevron_left# [ 5A      5C      �� 5D      $��4 0 0 0q�6    $��Center=�5E      $��Anterior��5F      5G      5H      �� 5I      ��6   �� *commandSiguiente+.��5J      �� $	 
Horizontal=�6   .+�5K      �� $��15��6    $��15��6+   ��5L      �� 
 �� $ ButtonL�$ 
Foreground� 5M      !� 5N      $
 Fill=�6*     appbar_chevron_right# [ 5O      5Q      �� 5R      $��4 0 0 0q�6    $��Center=�5S      $��	Siguiente��5T      5U      5V      �� 5W      ��6   �� *commandSave+.��5X      �� $	 
Horizontal=�6   .+�5Y      �� $��15��6    $��15��6+   ��5Z      �� 
 �� $ ButtonL�$ 
Foreground� 5[      !� 5\      $
 Fill=�6*     appbar_save# [ 5]      5_      �� 5`      $��4 0 0 0q�6    $��Center=�5a      $��Guardar��5b      5c      5d      �� 5e      ��6   �� *commandAddNew+.��5f      �� $	 
Horizontal=�6   .+�5g      �� $��15��6    $��15��6+   ��5h      �� 
 �� $ ButtonL�$ 
Foreground� 5i      !� 5j      $
 Fill=�6*     
appbar_add# [ 5k      5m      �� 5n      $��4 0 0 0q�6    $��Center=�5o      $��Agregar��5p      5q      5r      �� 5s      ��6   �� *commandOpenDelete+.��5t      �� $	 
Horizontal=�6   .+�5u      �� $��15��6    $��15��6+   ��5v      �� 
 �� $ ButtonL�$ 
Foreground� 5w      !� 5x      $
 Fill=�6*     appbar_delete# [ 5y      5{      �� 5|      $��4 0 0 0q�6    $��Center=�5}      $��Eliminar��5~      5      5�      5�      .��5�      � .+�5�   
   �  � RowDefinitions 5�      �� 5�      $
��auto �6    �� 5�      $
��auto �6    �� 5�      $
��auto �6    �� 5�      $
��auto �6    .+�5�      � $��0��6    � ColumnDefinitions 5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��0��6   $��3q�6-   .+�5�      �� $��Nombre��6    �� 5�      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Nombre��6g   ��6   �� *nombre+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6g   5�      �� 5�      $��1��6   $��3q�6-   .+�5�      �� $��Número tarjeta��6    �� 5�      -   5        $ Número tarjeta��5�   i   ��6   �� *	tarjeta+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $��2��6   $��3q�6-   .+�5�      �� $��Acompañantes��6    *   $MahApps.Metro.Controls.NumericUpDown  5�      $ 1��6}      Value 6-   �� *acompaniantes+$ TwoWay=�$ PropertyChanged=�6}   5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��0��6   $��3q�6-   .+�5�      �� $��Telefono��6    �� 5�      -   5        $ 
52+#######��5�   j   ��6   �� *
telefono+$ TwoWay=�$ PropertyChanged=�6�   5�      �� 5�      $��1��6   $��3q�6-   .+�5�      �� $��Email��6    �� 5�      $ cliente@dominio.com��6g   ��6   �� *email+$ TwoWay=�$ PropertyChanged=�6g   5�      �� 5�      $��2��6   $��3q�6-   .+�5�      �� $��Origen��6    �� 5�      $ Ciudad/País de origen��6h   ��6   �� *origen+$ TwoWay=�$ PropertyChanged=�6h   5�      5�      � 5�      $��2��6    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��0��6   $��3q�6-   .+�5�      �� $��Día de entrada��6    (  "System.Windows.Controls.DatePicker  5�      $# Selecciona el día de entrada��6x      SelectedDate 6!   �� *dateEntrada+$ TwoWay=�$ PropertyChanged=�6x   5�      �� 5�      $��1��6   $��3q�6-   .+�5�      �� $��Días de instancia��6      5�      $ 1��6|    6-   �� *diasEstancia+$ TwoWay=�$ PropertyChanged=�6|   5�      �� 5�      $��2��6   $��3q�6-   .+�5�      �� $��Días de salida��6      5�      $# Selecciona la fecha de salida��6u    6!   �� *
dateSalida+$ TwoWay=�$ PropertyChanged=�6u   5�      5�      �� 5�      $��3��6   $��Habitación��6$   
������ .��5�      �  5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��6!   $��3q�61   .+�5�      �� $��Tipo de habitación��6$   �� 5�      -   5         �� SelectedIndex$ 0��5�   #   ��65   �� *listTamanios+$ TwoWay=�6f   �� 5�      $��Precio��6$   �� 5�      ��6"   �� *selectedPrecio+ �� StringFormat$ {0:C}��$ TwoWay=� �� FallbackValue$	 200��5�      �� 5�      $��1��6   $��Habitaciones disponibles��6/   .��5�      �� ��6"   �� *listHabitacionesDisponibles+$ TwoWay=� �� SelectedItem 6b   �� *selectedHabitacion+$ TwoWay=���5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   $��* �6?   �� 5�   .   $��* �6?   .+�5�   *   �� ���	#FF3CB1E0$��50��6L   $��50��6W   .+�5�   .   �� $��/Imagenes/puerta.png��64   5�   +   �� 5�   *   $��1��64   $��25(�6D   
�5�   .   �� 5�   2   $�Habitación n°��66    �� 5�   2   �66   �� *numero+$ TwoWay=�5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      #   MahApps.Metro.Controls.Flyout  5�   
      Position$ Right=�6   $	��400��6+      Theme$ Light=�67      Header$ Eliminar��6H      CloseButtonVisibility$ Visible=�6[       IsModal  . !   IsOpen! 6�   �� *isOpen+$ TwoWay=�.��5�      �� $��8q�6   .+�5�      �� $:��4¿Estás seguro de eliminar el cliente seleccionado?��6   $��25(�6V   " �� TextAlignment$" Center=�6d   $
��Wrap=�6{   � 5�      $��5q�6    5�      �� 5      $��* �6+   �� 5     $��* �6+   .+�5     �� $��2q�6   $��0��6(     SquareButtonStyle#���  69   $��aceptar��6�   ��6e   �� *commandDelete+6�   �� 5     $��2q�6   $��1��6(   #���  69   $��cancelar��6�   ��6e   �� *commandOpenDelete+6�   5     5     5	     5
     5     