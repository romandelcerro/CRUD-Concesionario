   M S B A M L   `   `   `  ����L  HConcesionarioBBDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ConcesionarioBBDDConcesionarioBBDD  5   	        ConcesionarioBBDD.Insertar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ConcesionarioBBDD     5   	     � Title$  Insertar��5   	   $	��550��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�63    � 	Resources 5	       �� 
TargetType �� Property �� Value��%z   '��       �� 5
   
   " ��6   .�5      ��  � ��
 ��·�6+   �� 5       � ��
 �����6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��200px �6   6/   �� 5      $	��300 �6   6-   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��75px �6   6,   �� 5      $	��175 �6   6+   �� 5      $��* �6   6)   .+�5   
   ��    borderCabecera#��[  6   $��0��69   $��0��6I   $��3��6V   6l   �� 5   
     textoCabecera#��[ 6   $��Center=�6;   $��Concesionarios-DAM��6X   $��Center=�6r   $��3��6�   6�   �� 5   
   $
��Left=�6   $��20,0,0,0q�6+   $��/Imágenes/fondo.png��6=   6\   �� 5!   
   $��1��6   $��0��6"   $��3��62    �� Orientation$ Vertical=�6C   
�������.+�5"      �� 
����·�$	��1pxq�6+   	 �� CornerRadius$	 10��6A   $��
15,25,15,0q�6S   ._�5#      �� .+�5$      �� $��Bradley Hand ITC bold)�6   $��5,5,0,5q�6?   $��15(�6P   .��6^   Elige tu marca6n   	� 5%      -   5        $��	rbPeugeot��5%   "   
 d� 	IsChecked$

 TrueY�63   $��Peugeot��6\   $��5,0,0,0q�6n   $��Bradley Hand ITC)�6   $��12(�6�   6�   	� 5&      -   5        $��	rbHyundai��5&   "   $��Hyundai��6K   $��5,5,0,0q�6]   $��Bradley Hand ITC)�6n   $��12(�6�   6�   	� 5'      -   5        $��rbKia��5'   "   $	��Kia��6C   $��5,5,0,30q�6Q   $��Bradley Hand ITC)�6c   $��12(�6�   6�   5(      5)      �� 5+      $��
15,20,15,0q�6   .+�5-      �� $��0,0,0,10q�6   $��Bradley Hand ITC bold)�6*   $��15(�6M   .��6[   Elige un modelo6l   �� 5.      -   5        $��	cbModelos��5.      6\   5/      �� 51      -   5         J� Opacity$	 0.8Q�51      $��55��6$   $��55��60   $��0,90,0,0q�6;   ��52      �� 53      $ 
Horizontal=�6!   $��55��6:   .+�54      �� $��/Imágenes/home.png��6    $��0,0,0,0q�6<   6O   55      57      59      �� 5;   
   $��1��6   $��1��6"   $��2��62   $ Vertical=�6F   .+�5<      �� -   5        $��lvVehiculos��5<      $	��144��6*   $��
16,25,16,0q�67   $��Bradley Hand ITC)�6K   $��15(�6i    �� View 5=      �� 5>      .P�5?      �� $��Marca��6)    �� Width$	 112��6`    �� DisplayMemberBinding 69   �� *Marca+6`   �� 5@      $��Modelo��6)   $	 112��6b    6:   �� *Modelo+6b   �� 5A      $��Versión��6)   $	 112��6d    6;   �� *	Version+6d   �� 5B      $��Combustible��6)   $	 112��6l    6?   �� *Combustible+6l   �� 5C      $��Precio��6)   $	 112��6b    6:   �� *Precio+6b   5D      5F      5H      �� 5J   
   
����·�$	��1pxq�6'   $	 10��6=   $��1��6O   $��2��6_   $��2��6l   $	��220��6�   $��	16,0,16,0q�6�   ._�5L      �� -   5         ��Name$ imagen��5L      $��/Imágenes/logo-coche.jpg��6$   $	��210��6F   $
 0.15Q�6S   5N      �� 5P   
   $��1��6   $��2��6%   $��30,20,20,20q�62   $ Vertical=�6G   .+�5Q      �� $��15(�6   $��Características��6"   
���   �$��Center=�6O   6n   �� 5R      
����·�$	��1pxq�6+   $��0,0,0,6q�6A   6T   �� 5S      $ 
Horizontal=�6   .+�5T      �� $��Marca��6   $��12(�6(   
���   �6K   �� 5U      -   5        $��tbMarca��5U      $	��160��6)   $��10,0,0,0q�65   6I   5V      �� 5W      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5X      �� $��Modelo��6   $��12(�6)   
���   �6L   �� 5Y      -	   5        $��tbModelo��5Y      $	��160��6*   $��10,0,0,0q�66   6J   5Z      �� 5[      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5\      �� $��Versión��6   $��12(�6*   
���   �6M   �� 5]      -
   5        $��	tbVersion��5]      $	��160��6+   $��10,0,0,0q�67   6K   5^      �� 5_      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5`      �� $��Combustible��6   $��12(�6.   
���   �6Q   �� 5a      -   5        $��tbCombustible��5a      $	��160��6/   $��10,0,0,0q�6;   6O   5b      �� 5d      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5e      �� $��Precio��6   $��12(�6)   
���   �6L   �� 5f      -   5        $��tbPrecio��5f      $	��160��6*   $��10,0,0,0q�66   6J   5g      5h      �� 5j   
   $��2��6   $��2��6%   $��30,20,20,15q�62   $ Vertical=�6G   .+�5k      �� $��15(�6   $��Extras��6"   
���   �$��Center=�6F   6e   �� 5l      
����·�$	��1pxq�6+   $��0,0,0,6q�6A   6T   �� 5m      $ 
Horizontal=�6   .+�5n      �� $��Llantas��6   $��12(�6*   
���   �6M   �� 5o      -   5        $��	tbLlantas��5o      $	��160��6+   $��10,0,0,0q�67   6K   5p      �� 5q      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5r      �� $��Climatizador��6   $��12(�6/   
���   �6R   �� 5s      -   5        $��tbClimatizador��5s      $	��140��60   $��10,0,0,0q�6<   6P   5t      �� 5u      $ 
Horizontal=�6   $��0,5,0,5q�62   .+�5v      �� $��Cambio��6   $��12(�6)   
���   �6L   �� 5w      -   5        $��tbCambio��5w      $	��160��6*   $��10,0,0,0q�66   6J   5x      �� 5y      $ 
Horizontal=�6   $��0,5,0,15q�62   .+�5z      �� $��Portón��6   $��12(�6)   
���   �6L   �� 5{      -   5        $��tbPorton��5{      $	��160��6*   $��10,0,0,0q�66   6J   5|      �� 5}      -   5        $��btnInsertar��5}      $��25��6B   $	��175��6N   .��6Z   
Insertar6d   5~      5�      5�      