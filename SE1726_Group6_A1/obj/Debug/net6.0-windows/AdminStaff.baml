   M S B A M L   `   `   `  ����K  GSE1726_Group6_A1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SE1726_Group6_A1SE1726_Group6_A1  5   	   !    SE1726_Group6_A1.AdminStaff   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SE1726_Group6_A1     5   	     � Title$  
AdminStaff��5   	   $	��800��6   $	��620��6)   .��5	      ]� $	��Top=�6   $��10q�6(   .+�5
   
   �  � ColumnDefinitions 5      �� 5      $	��25* �6#   �� 5      $
��249* �6#   �� 5      $
��326* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      �� 
����ح� �� Orientation$ Vertical=�60   $
��Left=�5      $	��620��6,   $��3��68   .+�5      �� -   5        $��lbInstruction��5      
����  �$��DemiBold"�6?   $��20(�5      $��Staff Information��6   �� 5      -   5        $��	lbStaffId��5      $��StaffId��6)   �� 5      -   5        $��
txtStaffId��5      $
��Left=�6,   $��25��5      $	��500��6   ��5      ��  �� Path$ StaffId� �� Mode$ OneWay=� � DataContext 5       ��  �� ElementName$ lvStaff��$ SelectedItem�6R   �� 5"      -   5        $��lbStaffName��5"      $��
Staff Name��6+   �� 5#      -   5        $��txtStaffName��5#      $
��Left=�6.   $��25��5$      $	��500��6   ��6'   �� $ 	StaffName�$ OneWay=� 5%      �� $ lvStaff��$ SelectedItem�6M   �� 5(      -   5        $��
lbPassword��5(      $��Password��6*   �� 5)      -   5        $��txtPassword��5)      $
��Left=�6-   $��25��5*      $	��500��6   ��6'   �� $ Password�$ OneWay=� 5+      �� $ lvStaff��$ SelectedItem�6M   �� 5-      -   5        $��lbRole��5-      $
��Role��6&   �� 5.      -	   5        $��txtRole��5.      $
��Left=�6)   $��25��5/      $	��500��6   ��6&   �� $
 Role�$ OneWay=� 50      �� $ lvStaff��$ SelectedItem�6L   �� 56      $ 
Horizontal=�6   $
��Left=�66   .+�57      �� -
   5         ��Name$ 	btnInsert��57      $��10q�60   $��70��6<   $��Insert��6G   6X   �� 5:      -   5        $ 	btnUpdate��5:      $��10q�60   $��70��6<   $��Update��6G   6X   �� 5=      -   5        $ 	btnDelete��5=      $��10q�60   $��70��6<   $��Delete��6G   6X   �� 5?      -   5        $ btnBack��5?      $��10q�6.   $��70��6:   $
��Back��6E   6T   5A      �� 5B      $ 
Horizontal=�6   $
��Left=�66   .+�5C      �� -   5        $��txtSearchStaff��5C      $��25��64   $	��300��6@   $��	0,10,0,10q�6L   6_   �� 5D      -   5        $ 	btnSearch��5D      $��70��60   $��Search��6;   $��
10,10,0,10q�6L   6`   5E      5F      �� 5G      -   5        	 ��Name$	 lvStaff��5G      $	��600��6I   $��3��6�   $��	0,325,0,0q�6�   $��2��6�   ��6(   �� *
AllStaff+
 �� View
 5H      �� 5I      .P�5J      �� $��Staff ID��6)    �� Width$	 150��6;    �� DisplayMemberBinding 6G   �� *	StaffId+�� 5K      $��
Staff Name��6)   $	 150��6=    6I   �� *Name+�� 5L      $��Password��6)   $	 150��6;    6G   �� *
Password+�� 5M      $
��Role��6)   $	 150��67    6C   �� *Role+5N      5P      5R      5S      5T      