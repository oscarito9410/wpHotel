   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=1.1.3.28, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Becarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Becarios.ViewBecarios.View 5   	   !   Becarios.View.ProductosView   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Becarios.View     5   	     � Title$  ProductosView��5
   	   $	��400��6   $	��620��6,    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   ��5      �� 5   
    �� ImageSource$, &/Becarios;component/Imagenes/fondo.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5      (   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��15��6    $��15��6+   ��5      �� 	 �� RelativeSource	 �� 
 �� AncestorType$
 ButtonL� �� Path$ 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*      appbar_door_lock_open !� Visual# [  5      5       �� 5!      $��4 0 0 0q�6    $��Center=�5"      ��5#      �� *clvProducto+ �� Mode$ TwoWay=�5$      5%      �� 5&      ��6   �� *commandAnterior+.��5'      �� $ 
Horizontal=�6   .+�5(      �� $��15��6    $��15��6+   ��5)      �� 	 �� $
 ButtonL�$ 
Foreground� 5*      !� 5+      $
 Fill=�6*     appbar_chevron_left# [ 5,      5.      �� 5/      $��4 0 0 0q�6    $��Center=�50      $��Anterior��51      52      53      �� 54      ��6   �� *commandSiguiente+.��55      �� $ 
Horizontal=�6   .+�56      �� $��15��6    $��15��6+   ��57      �� 	 �� $
 ButtonL�$ 
Foreground� 58      !� 59      $
 Fill=�6*     appbar_chevron_right# [ 5:      5<      �� 5=      $��4 0 0 0q�6    $��Center=�5>      $��	Siguiente��5?      5@      5A      �� 5B      ��6   �� *commandSave+.��5C      �� $ 
Horizontal=�6   .+�5D      �� $��15��6    $��15��6+   ��5E      �� 	 �� $
 ButtonL�$ 
Foreground� 5F      !� 5G      $
 Fill=�6*     appbar_save# [ 5H      5J      �� 5K      $��4 0 0 0q�6    $��Center=�5L      $��Guardar��5M      5N      5O      �� 5P      ��6   �� *commandAddNew+.��5Q      �� $ 
Horizontal=�6   .+�5R      �� $��15��6    $��15��6+   ��5S      �� 	 �� $
 ButtonL�$ 
Foreground� 5T      !� 5U      $
 Fill=�6*     
appbar_add# [ 5V      5X      �� 5Y      $��4 0 0 0q�6    $��Center=�5Z      $��Agregar��5[      5\      5]      �� 5^      ��6   �� *commandOpenDelete+.��5_      �� $ 
Horizontal=�6   .+�5`      �� $��15��6    $��15��6+   ��5a      �� 	 �� $
 ButtonL�$ 
Foreground� 5b      !� 5c      $
 Fill=�6*     appbar_delete# [ 5d      5f      �� 5g      $��4 0 0 0q�6    $��Center=�5h      $��Eliminar��5i      5j      5k      5l         LeftWindowCommands 5n        5o   
   .@�5p      �� ��6   �� *commandGoBack+.��5q      �� $ 
Horizontal=�6   .+�5r      �� $��15��6    $��15��6+   ��5s      �� 	 �� $
 ButtonL�$ 
Foreground� 5t      !� 5u      $
 Fill=�6*     appbar_arrow_left# [ 5v      5x      �� 5y      $��4 0 0 0q�6    $��Center=�5z      $��Atras��5{      5|      5}      5~      .��5�      � -   5         �Name$ rootGrid��5�      .+�5�   
   �  � ColumnDefinitions 5�      �� 5�      $��3* �6#   �� 5�      $��* �6#   .+�5�      � $��0��6    � RowDefinitions 5�      �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   .+�5�      �  5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��3q�6!   .+�5�      �� $��Descripción��6$   �� 5�      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Descripción��6"   ��6Q   �� *descripcion+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5�      �� 5�      $��1��6!   $��3q�61   .+�5�      �� $��Precio��6$   �� 5�      -   5        $ 	$ ###,###��5�   �   ��6#   �� *precio+ �� StringFormat$ {0:C}��$ TwoWay=�$ PropertyChanged=�6�   5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��0��6!   $��3q�61   .+�5�      �� $��Cantidad��6$   *   $MahApps.Metro.Controls.NumericUpDown  5�      $ 1��6|      Value 61   �� *
cantidad+$ TwoWay=�$ PropertyChanged=�6|   5�      �� 5�      $��1��6!   $��3q�61   .+�5�      �� $��	Categoria��6$   �� 5�       �� SelectedItem 6$   �� *	categoria+$ TwoWay=�$ PropertyChanged=���6w   �� *listCategorias+$ PropertyChanged=�5�      5�      5�      � 5�      $��1��6   .+�5�      �� $��3q�6   .+�5�      �� $	��150��6   $	��150��6(   ��65   �� *imgProducto+$ TwoWay=��� 5�      $��Agregar imagen��6   ��66   �� *commandOpenFileDialog+5�      5�      5�      #   MahApps.Metro.Controls.Flyout  5�   
      Position$ Right=�6   $	��400��6+      Theme$ Light=�67      Header$ Eliminar��6H      CloseButtonVisibility$ Visible=�6[      IsModal .    IsOpen 6�   �� *isOpen+$ TwoWay=�.��5�      �� $��8q�6   .+�5�      �� $;��5¿Estás seguro de eliminar el producto seleccionado?��6   $��25(�6W    �� TextAlignment$ Center=�6e   $
��Wrap=�6|   � 5�      $��5q�6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��2q�6   $��0��6(     SquareButtonStyle#���  69   $��aceptar��6�   ��6e   �� *commandDelete+6�   �� 5�      $��2q�6   $��1��6(   #���  69   $��cancelar��6�   ��6e   �� *commandOpenDelete+6�   5�      5�      5�      5�      5�      