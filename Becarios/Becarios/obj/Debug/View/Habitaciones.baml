   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=1.1.3.28, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Becarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Becarios.ViewBecarios.View 5   	       Becarios.View.Habitaciones   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   Z VFirstFloor.ModernUI, Version=1.0.6.0, Culture=neutral, PublicKeyToken=2d21ec3cd074c59a0mui&http://firstfloorsoftware.com/ModernUI  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Becarios.View     5   	     � Title$  Habitación��5
   	   $	��400��6   $	��620��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K   ��5      �� 5   
    �� ImageSource$, &/Becarios;component/Imagenes/fondo.jpg��6    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5      (   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��15��6    $��15��6+   ��5      �� 	 �� RelativeSource	 �� 
 �� AncestorType$
 ButtonL� �� Path$ 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*      appbar_door_lock_open !� Visual# [  5       5"      �� 5#      $��4 0 0 0q�6    $��Center=�5$      ��5%      �� *numero+ �� Mode$ TwoWay=�5&      5'      �� 5(      ��6   �� *commandAnterior+.��5)      �� $ 
Horizontal=�6   .+�5*      �� $��15��6    $��15��6+   ��5+      �� 	 �� $
 ButtonL�$ 
Foreground� 5,      !� 5-      $
 Fill=�6*     appbar_chevron_left# [ 5.      50      �� 51      $��4 0 0 0q�6    $��Center=�52      $��Anterior��53      54      55      �� 56      ��6   �� *commandSiguiente+.��57      �� $ 
Horizontal=�6   .+�58      �� $��15��6    $��15��6+   ��59      �� 	 �� $
 ButtonL�$ 
Foreground� 5:      !� 5;      $
 Fill=�6*     appbar_chevron_right# [ 5<      5>      �� 5?      $��4 0 0 0q�6    $��Center=�5@      $��	Siguiente��5A      5B      5C      �� 5D      ��6   �� *commandSave+.��5E      �� $ 
Horizontal=�6   .+�5F      �� $��15��6    $��15��6+   ��5G      �� 	 �� $
 ButtonL�$ 
Foreground� 5H      !� 5I      $
 Fill=�6*     appbar_save# [ 5J      5L      �� 5M      $��4 0 0 0q�6    $��Center=�5N      $��Guardar��5O      5P      5Q      �� 5R      ��6   �� *commandAddNew+.��5S      �� $ 
Horizontal=�6   .+�5T      �� $��15��6    $��15��6+   ��5U      �� 	 �� $
 ButtonL�$ 
Foreground� 5V      !� 5W      $
 Fill=�6*     
appbar_add# [ 5X      5Z      �� 5[      $��4 0 0 0q�6    $��Center=�5\      $��Agregar��5]      5^      5_      �� 5`      ��6   �� *commandOpenDelete+.��5a      �� $ 
Horizontal=�6   .+�5b      �� $��15��6    $��15��6+   ��5c      �� 	 �� $
 ButtonL�$ 
Foreground� 5d      !� 5e      $
 Fill=�6*     appbar_delete# [ 5f      5h      �� 5i      $��4 0 0 0q�6    $��Center=�5j      $��Eliminar��5k      5l      5m      5n         LeftWindowCommands 5p        5q   
   .@�5r      �� ��6   �� *commandGoBack+.��5s      �� $ 
Horizontal=�6   .+�5t      �� $��15��6    $��15��6+   ��5u      �� 	 �� $
 ButtonL�$ 
Foreground� 5v      !� 5w      $
 Fill=�6*     appbar_arrow_left# [ 5x      5z      �� 5{      $��4 0 0 0q�6    $��Center=�5|      $��Atras��5}      5~      5      5�      .��5�      � .+�5�   
   �  � RowDefinitions 5�      �� 5�      $
��auto �6    �� 5�      $
��auto �6    �� 5�      $
��auto �6    .+�5�      �  � ColumnDefinitions 5�      �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      �� $��3q�6   .+�5�      �� $��Telefono��6    �� 5�      -   5        *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 
52+#######��5�      ��6L   �� *
telefono+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5�      �� 5�      $��1��6   $��3q�6-   .+�5�      �� $��Tamaño��6    �� 5�      -   5         �� SelectedIndex$ 0��5�   �    �� SelectedItem 6    �� *	tamanio+$ TwoWay=�$ PropertyChanged=���6q   �� *listTamanios+6�   5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   .+�5�      )   #MahApps.Metro.Controls.ToggleSwitch  $��3q�6(   $��0��63      OffLabel$ 
Disponible��6�      OnLabel$ Ocupado��6�      Header$ Estado��6�      	IsChecked 6C   �� *estado+$ TwoWay=�$ PropertyChanged=�6�   �� 5�      $��1��6   $��3q�6-   .+�5�      �� $��Precio��6    �� 5�      -   5         �� 
IsReadOnly . $ 	$ ###,###��5�   �   ��60   �� *precio+ �� StringFormat$ {0:C}��$ TwoWay=�$ PropertyChanged=�6�   5�      5�      5�      #   MahApps.Metro.Controls.Flyout  5�   
      Position$ Right=�6   $	��400��6+      Theme$ Light=�67      Header$ Eliminar��6H       CloseButtonVisibility$  Visible=�6[   !   IsModal! . "   IsOpen" 6�   �� *isOpen+$ TwoWay=�.��5�      �� $��8q�6   .+�5�      �� $>��8¿Estás seguro de eliminar la habitación seleccionada?��6   $��25(�6Y   # �� TextAlignment$# Center=�6g   $
��Wrap=�6~   � 5�      $��5q�6    5�      �� 5�      $��* �6+   �� 5�      $��* �6+   .+�5�      �� $��2q�6   $��0��6(     SquareButtonStyle#���  69   $��aceptar��6�   ��6e   �� *commandDelete+6�   �� 5�      $��2q�6   $��1��6(   #���  69   $��cancelar��6�   ��6e   �� *commandOpenDelete+6�   5�      5�      5�      5�      5�      