   M S B A M L   `   `   `  ����K  GSE1726_Group6_A1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SE1726_Group6_A1SE1726_Group6_A1  5   	       SE1726_Group6_A1.Login   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SE1726_Group6_A1     5   	     � Title$  Login��5   	   $	��450��6   $	��322��6$   .��5	      � .+�5
   
   �� $	��300��6   $	��400��5      
������� �� CornerRadius$ 6��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$	 -90Q�5         RenderingBias$ Quality=�5         ShadowDepth$ 2Q�5         Color$
 Gray��5      ._�5      ��  �� Orientation$ Vertical=�6   $��20q�5      .+�5      �� $��Login��6   $��25(�5      $��Center=�5      $	��Top=�5      $
��Bold"�5      	 �� Padding$	 10q�5      � 5      $��Center=�6   
 � RowDefinitions
 5      �� 5       $��* �6(   �� 5!      $��* �6(   �� 5"      $��* �6(   �� 5#      $��* �6(   .+�5%      �� $��	User Name��6   $��0��5&      $
��0,15q�5'      $
��Left=�5(      61   �� 5)      -   5        $��txtName��5)      $��	0,41,0,46q�6-   $��3��6@   $	��0,5q�6Q   $	��255��5*      $��0,0,0,1q�5+      $
��Left=�5,       J� RenderTransformOrigin$ 0.503,0.395&�60   6V   �� 5-      $��Password��6    $��2��5.      $
��0,15q�5/      $
��Left=�50      G� 51      -   5        $��txtPassword��51   /   $��3��6"    G� Password$  ��52      $	��0,5q�53      $	��255��54      $��0,0,0,1q�55      $
��Left=�56      58      �� 59      -   5         ��Name$ LoginBtn��59      $��Login��5:      
�������
���   �$
��0,25q�5=      $��35��5>      $	��250��5?      ��5@      �� 5A       �� 
TargetType" ��6    .�5B      ��  �� Property � �� �� Value 5C   "   �� 5D   &    �� 
TargetType" ��66   .R�5E   *   ��  ��Name$ LoginBorder��61   #��z��6F   $ 16��5F   -   ._�5G   .   �� $��Center=�6?   $��Center=�5H   ;   5I   +    �� Triggers 5J   *   P� 5K   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5L   2   ��  �� 
TargetName$ LoginBorder��6a    � ��
 ������� 5M   2   $ LoginBorder��6h    � ��
 �   �5N   /   5P   '   5R      5S      5U      5W      5X      5Y      5Z      