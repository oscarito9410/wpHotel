   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=1.1.3.28, Culture=neutral, PublicKeyToken=nullfCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5   	   Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   C ?Becarios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Becarios.ViewBecarios.View 5
   	      Becarios.View.Restaurante   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5   	   Z	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   -localclr-namespace:Becarios.View     5
   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$
  page��5       � Title$ Restaurante��5      $	��600��6   $	��900��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5         LeftWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� ��6   �� *commandGoBack+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��15��6    $��15��6+   ��5      �� 	 �� RelativeSource	 �� 
 �� AncestorType$
 ButtonL� �� Path$ 
Foreground� J� OpacityMask 5      !� 5       j� Stretch$
 Fill=�6*      appbar_arrow_left !� Visual# [  5      5       �� 5!      $��4 0 0 0q�6    $��Center=�5"      $��Atras��5#      5$      5%      5&      .��5(      � -   5         �Name$ rootGrid��5(      .+�5)   
   �  � RowDefinitions 5*      �� 5+      $
��AUTO �6    �� 5,      $
��AUTO �6     � ColumnDefinitions 5.      �� 5/      $��0* �6#   �� 50      �� 51      .+�53      � $��2��6   .+�54      �� $��3q�6   .+�55      �� $��Nombre cliente��6    �� 56      -   5         ��Name$ 
txtUsuario��56   .   $��1��6   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Cliente nombre��6�      ClearTextButton . ��6B   �� *clienteNombre+ �� Mode$ TwoWay=�1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 6n   �� *
clientes+.��6  57      58      5:      �� 5;      $ Vertical=�6   $��1��61   $��2��6>   .+�5<      �� -   5         ��Name$ 
groupMesas��5<      $��Mesas��6/   .��5=      � -   5        $ 	gridMesas��5=       5>      �� 5?      $
��AUTO �6/   �� 5@      $
��AUTO �6/   �� 5A      $
��AUTO �6/   �� 5B      $
��AUTO �6/   �� 5C      $
��AUTO �6/   .+�5E      �� $��0��6%   .+�5F      d� -   5         d�Name$	 uno��5F   +   $
��Left=�69   $��50��6T   $��50��5G      $��0, 10, 0, 0q�5H         MetroCircleToggleButtonStyle#���  5I      .��5J   "   �� $��20��6,   $��20��67     
BlackBrush#���  5K       5L   &   !� 5M   *   $
 Fill=�66     appbar_food_silverware# �  5N      5P   #   5Q      �� 5R      $��Mesa 1��6(   $��Center=�66   5S      �� 5T      $��1��6%   .+�5U      d� -   5        $	 dos��5U   +   $
��Left=�69   $��50��6T   $��50��5V      $��0, 10, 0, 0q�5W      #���  5X      .��5Y   "   �� $��20��6,   $��20��67   #���  5Z       5[   &   !� 5\   *   $
 Fill=�66   # �  5]      5_   #   5`      �� 5a      $��Mesa 2��6(   $��Center=�66   5b      �� 5c      $��2��6%   .+�5d      d� -   5        $
 tres��5d   +   $
��Left=�6:   $��50��6U   $��50��5e      $��0, 10, 0, 0q�5f      #���  5g      .��5h   "   �� $��20��6,   $��20��67   #���  5i       5j   &   !� 5k   *   $
 Fill=�66   # �  5l      5n   #   5o      �� 5p      $��Mesa 3��6(   $��Center=�66   5q      �� 5r      $��3��6%   .+�5s      d� -	   5        $ cuatro��5s   +   $
��Left=�6<   $��50��6W   $��50��5t      $��0, 10, 0, 0q�5u      #���  5v      .��5w   "   �� $��20��6,   $��20��67   #���  5x       5y   &   !� 5z   *   $
 Fill=�66   # �  5{      5}   #   5~      �� 5      $��Mesa 4��6(   $��Center=�66   5�      �� 5�      $��4��6%   .+�5�      d� -
   5        $ cinco��5�   +   $��Right=�6;   $��50��6W   $��50��5�      $��0,10,1,0q�5�      #���  5�      .��5�   "   �� $��20��6,   $��20��67   #���  5�       5�   &   !� 5�   *   $
 Fill=�66   # �  5�      5�   #   5�      �� 5�      $��Mesa 5��6(   $��Center=�66   5�      5�      5�      �� 5�      $��	Platillos��6   .��5�      �� .+�5�      ��  �� SelectedIndex$ 0��6#    �� SelectedItem 65   �� *selectedCategoria+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *listCategorias+5�      �� 5�      -   5        ��5�   #   �� *listPlatillos+��5�      �� 5�   "   .R�5�   &   �  5�   *   �� 5�   .   $
��auto �6?   �� 5�   .   $
��auto �6?   .+�5�   *   �� $��50��66   $��50��6A   $
��Left=�6M   .+�5�   .   �� ��64   �� *imgProducto+$ TwoWay=�5�   +   �� 5�   *   $��1��64   $��20(�6D   
�5�   .   �� 5�   2   �66   �� *descripcion+$ TwoWay=�5�   +   5�   '   5�   #   5�      5�      5�      5�      � 5�      $��2��6   .+�5�      �� 
�����_� �� CornerRadius$ 4��62   $��1q�6C   ���	#FF41B1E1._�5�      �� $ 
Horizontal=�6"   $��Center=�6;   .+�5�      �� $��FECHA:��6$   $��Center=�62   
�������$��3q�6`   �� 5�      $��3q�6a   $��Center=�6l   
���������6$   �� *fecha+ �� StringFormat$ D�� �� ConverterCulture$ es-MX��6�   5�      5�      5�      �� 5�      $��2��6   $��1��6)   .+�5�      �� $��3q�6   .+�5�      �� $��Precio unitario��6    �� 5�      $ Precio unitario��6h   ��6   �� *selectedProducto.precio+$ {0:C}��$ TwoWay=�6h   5�      �� 5�      $��3q�6   .+�5�      �� $��Cantidad��6    *   $MahApps.Metro.Controls.NumericUpDown  5�      -   5          Name$ numericUpdown��5�   Y       Minimum$  1Q�6q   !   Value! 6-   �� *selectedProducto.cantidad+5�      5�      �� 5�      $��3q�6   .+�5�      �� $��AGREGAR A LISTA��6   ��67   �� *commandAddList+�� 5�      ��6   �� *	listOrden+" �� View" 5�      �� 5�      .P�5�   "   �� # �� Width$	# 120��61   $ �� DisplayMemberBinding$ 6=   �� *descripcion+��5�   &   �� 5�   *   .��6?   
Platillo6I   5�   #   �� 5�   "   $	# 120��61   $ 6=   �� *precio+��5�   &   �� 5�   *   .��6?   Precio6G   % �� CellTemplate% 5�   &   �� 5�   *   .R�5�   .   �� ��68   �� *precio+$ {0:C}��5�   +   5�   #   �� 5�   "   $	# 120��61   $ 6=   �� *
cantidad+��5�   &   �� 5�   *   .��6?   
Cantidad6I   % 5   &   �� 5  *   .R�5  .   �� ��68   �� *precio+$ {0:C}��5  +   5  #   �� 5  "   $	# 120��61   % 5  &   �� 5  *   .R�5	  .   � .+�5
  2   �� $��55��69   $��55��6D   $	��Top=�6�     MetroCircleButtonStyle#���  6�   ��6P   �� $' !DataContext.commandDeleteFromList�	 �� "
 ����6�   �� .��5  6   �� $��20��6@   $��20��6K   #���  5      5  :   !� 5  >   $
 Fill=�6J     appbar_delete# �  5     5  7   5  3   5  /   5  +   5  #   5     5     �� 5     
�5     �� 5     $�TOTAL A PAGAR = ��6"   $��25(�6:    �� 5      $��25(�6_   $
��Bold"�6m   ���	#FF41B1E1�6"   �� *
totalPagar+$ TwoWay=�$ {0:C}��6   5"     �� 5$     $ 
Horizontal=�6!   .+�5%     �� $��70��6!   $��70��6,   $
��Left=�68   $	��Top=�6w   #���  6�   ��6S   �� *commandProcesar+.��5&     �� .+�5'  "   �� $��30��6,   $��30��67   #���  5(      5)  &   !� 5*  *   $
 Fill=�66     appbar_save# �  5+     5-  #   �� 5.  "   $��Procesar��6,   52     54     )   #MahApps.Metro.Controls.ProgressRing  56     &   IsActive& 60   �� *	isLoading+$ TwoWay=�57     5;     5>     5A     5D     5F     