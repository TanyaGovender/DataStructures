   M S B A M L   `   `   `  ����G  CPROG7321-POE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PROG7321_POEPROG7321_POE  5   	       PROG7321_POE.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PROG7321_POE     5   	     � WindowState$  	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5	       � Title$ MainMenu��5
   	   $	��450��6   $	��800��6'   
������� � 	Resources 5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 buttoncorner	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   "	 ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5        � ��8  6+   �� 5!       � ��8  6,   �� 5"       � ��# � ��6+   �� 5#       � ��$ 1q�60   �� 5$       � ��$ Center=�6;   �� 5%       � ��$ Center=�69   �� 5&       � ��$ 1q�6(   �� 5'       � �� 5(      �� 5)      "
 ��6&   .R�5*      �� $ border��6!   #��z��61   $ 8��6[   #��z��6l   #��z��6�   $
 true��6�   ._�5+      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5,       5-      P� 5.       �@��IsDefaulted$
 true��6=   . �5/   "   �� $ border��6@   # � ��6T    � ��50      P� 51       �@J�IsMouseOver$
 true��6=   . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   54      P� 55       � ��$
 true��6;   . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � {�$ false��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   �� 5<   "   $ contentPresenter��6K   8 	  � ��6i   5=      5?      5A      5B      5C      .��5E      � .+�5F   
   (� .��5G      �� $��Center=�6   $��Center=�66   $	��450��6Q   $	��800��6^   ��5H      �� 5I       �� ImageSource$; 5/360_F_317497799_u9BNadcgmEzbWAio1Wgn7RDAyqeTrcWc.jpg��6!   .+�5L      �� $%��eThekwini Municipality Services��6   $��45(�6C   $
��Bold"�6Q   ���#495434$��Center=�6x   $��0,50,0,0q�6�   6�   �� 5N      -   5         ��Name$ btnReportIssues��5N   <   #��� 
 6   $��Report Issue��6U   
�������$
��Bold"�6   $��15(�6�   ���#97ae6c$	��255��5O   *   $	��100��66   $��-300,40,0,0q�6C   6{   �� 5P      -   5        $ btnAdmin��5P      $��Admin��6'   
�������$
��Bold"�6J   $��15(�6\   ���#c4b36e$	��255��5Q   *   $	��100��66   $��-300,30,0,0q�6C   #��� 
 6o   6�   �� 5R      -   5        $ btnLocalEvents��5R      $��Events and Announcements��6-   
�������$
��Bold"�6c   $��15(�6u   ���#c6c97b$	��225��5S   *   $	��100��66   $��300,-360,0,0q�6C   #��� 
 6v   6�   �� 5T      -   5        $ 	btnStatus��5T      $��Service Request Status��6(   
�������$
��Bold"�6\   $��15(�6n   ���#e1ad01$	��225��5U   *   $	��100��66   $��300,-100,0,0q�6C   #��� 
 6q   6�   5W      5Y      5Z      5[      