   M S B A M L   `   `   `  ����K  GSE1726_Group6_A1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SE1726_Group6_A1SE1726_Group6_A1  5   	   $    SE1726_Group6_A1.ProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SE1726_Group6_A1     5   	     � Title$  ProductWindow��5   	   $	��500��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   
����ح�$��10q�6I   $	��250��6U   .+�5      �� $��List of products��6   $��20(�6/   $
��Bold"�6=   $��0,0,0,10q�6O   6c   �� 5       �� Orientation$ Vertical=�6   $��0,0,0,10q�60   .+�5      �� $��Product Id:��6   �� 5      -   5         ��Name$ txtProductId��5      $��0,0,0,5q�5      ��5      ��  �� Path$ 	ProductId� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ 	lsProduct��$ SelectedItem�5      5      �� 5      $ Vertical=�6   $��0,0,0,10q�60   .+�5      �� $��Product name:��6   �� 5      -   5        $ txtProductName��5      $��0,0,0,5q�5!      ��5      �� $ ProductName�$ OneWay=� 5       �� $ 	lsProduct��$ SelectedItem�5!      5"      �� 5#      $ Vertical=�6   $��0,0,0,10q�60   .+�5$      �� $��Category id:��6   �� 5%      -   5        $ txtCategoryId��5%      $��0,0,0,5q�5(      ��5&      �� $ 
CategoryId�$ OneWay=� 5'      �� $ 	lsProduct��$ SelectedItem�5(      5)      �� 5*      $ Vertical=�6   $��0,0,0,10q�60   .+�5+      �� $��Unit price:��6   �� 5,      -   5        $ txtUnitPrice��5,      $��0,0,0,5q�5/      ��5-      �� $ 	UnitPrice�$ OneWay=� 5.      �� $ 	lsProduct��$ SelectedItem�5/      50      �� 51      $ 
Horizontal=�6   $��Center=�62   $��
30,10,30,0q�6O   .+�52      �� -   5        $��btnAdd��52      $	��Add��6'   $��50��65   $��5q�6@   6b   �� 53      -   5        $��btnEdit��53      $
��Edit��6(   $��50��67   $��5q�6B   6e   �� 54      -   5        $��	btnDelete��54      $��Delete��6*   $��50��6;   $��5q�6F   6k   55      �� 56      $ Vertical=�6   $��0,0,0,10q�60   .+�57      �� $��Search by product name��6   �� 58      -   5        $ txtSearchProductName��58      6:   �� 59      $��Search by unit price��6   �� 5:      -	   5        $ txtSearchUnitPrice��5:      68   5;      �� 5<      $ 
Horizontal=�6   $��Center=�62   $��
30,10,30,0q�6O   .+�5=      �� -
   5        $��	btnSearch��5=      $��Search��6*   $	��100��6;   $��5q�6G   6l   5>      5?      �� 5A   
   -   5        $��	lsProduct��5A   A   $��0��6   $��1��6    $��2��60   $��10q�6R   	 �� View	 5B      �� 5C      .P�5D      �� 
 �� Width$	
 100��6%   $��
Product Id��61    �� DisplayMemberBinding 6E   �� $ 	ProductId�6w   �� 5E      $	
 200��6%   $��Product Name��61    6G   �� $ ProductName�6{   �� 5F      $	
 100��6%   $��Category Id��61    6F   �� $ 
CategoryId�6y   �� 5G      $	
 100��6%   $��
Unit Price��61    6E   �� $ 	UnitPrice�6w   5H      5J      5K      5L      