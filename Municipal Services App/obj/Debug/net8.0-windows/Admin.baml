   M S B A M L   `   `   `  ����G  CPROG7321-POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PROG7321_POEPROG7321_POE  5   	       PROG7321_POE.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PROG7321_POE     5   	     � WindowState$  	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Admin��5
   	   $	��670��6   $	��800��6$   
������� � 	Resources 5         MenuButtonStyle �� 
TargetType �� Property �� Value��%�  &	        �� 5   
   " ��6(   .�5      ��  � ��
 �����6+   �� 5       � �� �#005f8c6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 50��6'   �� 5       � ��$ 
10,10,10,0q�6'   �� 5       � ��$ Stretch=�64   �� 5       � ��$ Center=�62   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5!      $��* �6   .+�5&   
   �� $��0��6   ���#495434$��Stretch=�6:   $��5q�6V   .+�5'      �� $��Services��6   $��20(�6(   $
��Bold"�66   
�������$��
10,20,0,20q�5(      $��Center=�6%   �� 5*      -   5        $��	Main Menu��5*      $��16(�6)   $
��Bold"�67   
����������#c4b36e$��
10,20,10,0q�5+      $��50��6"   #��[  6.   5,      �� 5.      -   5        $��Local Events��5.      $��16(�6,   $
��Bold"�6:   
����������#c6c97b$��
10,25,10,0q�5/      $��50��6"   #��[  6.   50      �� 51      -   5        $��Report Issue��51      $��16(�6,   $
��Bold"�6:   
����������#e1ad01$��
10,25,10,0q�52      $��50��6"   #��[  6.   53      �� 54      -   5        $��Service Requests��54      $��16(�60   $
��Bold"�6>   
����������#97ae6c$��
10,25,10,0q�55      $��50��6"   #��[  6.   56      �� 57      -   5        $
��BACK��57      $��16(�6$   $
��Bold"�62   
�������
�������$��Bottom=�58      $��10,375,10,0q�59      $��50��6   #��[  6#   5:      5<      (� 5?   
   $��1��6   .��5@      �� $��Center=�6   $��Center=�66   $	��650��6Q   $	��800��6^   ��5A      �� 5B       �� ImageSource$; 5/360_F_317497799_u9BNadcgmEzbWAio1Wgn7RDAyqeTrcWc.jpg��6!   .+�5E      �� $"��eThekwini Municipality Admin��6   $��35(�6@   $
��Bold"�6N   $��Center=�6`   $	��Top=�6}   $��0,40,0,0q�6�   ���#4954346�   �� 5G      $��	Username:��6   $��15(�6-   $��SemiBold"�6;   ���#495434$��-620,50,0,0q�6f   $	��100��6{   �� 5H   
   -   5        $��txtUsername��5H      $	��250��6&   $��30��62   $��-290,-30,0,0q�6>   �� 5J      $��	Password:��6   $��15(�6-   $��SemiBold"�6;   ���#495434$��145,-25,0,0q�6f   $	��100��6{   �� 5K   
   -   5        $��txtPassword��5K      $	��250��6&   $��30��62   $��420,-30,-50,0q�6>   �� 5M   
   -   5        	 ��Name$	 btnLogin��5M      $��Login��6#   $	��200��63   $��35��6?   $��20(�6K   $
��Bold"�6Y   
����������#495434$��Center=�5N   *   $��Center=�6N   $��
520,30,0,0q�6p   6�   �� 5P   
   -	   5        
 ��Name$
 
pnlDisplay��5P      $	��700��6)   $	��380��65   $��0,20,0,0q�6B   .+�5Q      �� $��Issue Reports��6    $��20(�65   $
��Bold"�6C   $��Center=�6U   $	��Top=�6r   $��0,0,0,0q�6�   ���#4954346�   &   System.Windows.Controls.DataGrid  5S      -
   5          Name$ 	dgReports��5S         AutoGenerateColumns$ False��6*      CanUserAddRows$ False��6F   $��Stretch=�6]   $��Stretch=�6{   $��10,30,10,100q�6�      Columns 5U      0  *System.Windows.Controls.DataGridTextColumn  5W      ,  &System.Windows.Controls.DataGridColumn   Header$ Location��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
location+6X     5X      $ Category��6)   $	 150 6X    6;   �� *
category+6X     5Y      $ Description��6)   $	 250 6^    6>   �� *description+6^     5Z      $ Status��6)   $	 100 6T    69   �� *status+6T     5[      $
 Date��6)   $	 150 6V    67   �� *
reportDate+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5^      $ Document��65      CellTemplate 5_   "   �� 5`   &   .R�5a   *   �� -   5        $��View Document��5a   1   
 � Tag 6d   �� *attachedFile+5b   '   5d      5i      (  "System.Windows.Controls.WebBrowser  5j      -   5          Name$ 	docViewer��5j      $��Stretch=�60   $��Bottom=�6N   $	��150��6i   $	��400��6v   $��295,0,10,10q�6�   5k      5m      5n      5o      5p      