   M S B A M L   `   `   `  ����N  JPasswordManager.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PasswordManager.WPFPasswordManager.WPF  5   	   '    !PasswordManager.WPF.AdvancedLogin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PasswordManager.WPF     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  Advanced Options��5	   	   $	��250��5   	   $	��300��5   	    � WindowStyle$ 
ToolWindow=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ TextBoxServerAddress��5      $��30��60   $��Center=�6<   $��0,44,0,0q�6Y    �� TextWrapping$ NoWrap=�6k   $�� ��6�   $	��Top=�6�   $	��250��6�   $��18(�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ LabelServerAddress��5      $��Server Address��6,   $
��Left=�6E   $��	16,14,0,0q�6`   $	��Top=�6s   $��15(�6�   �� 5   
   -   5        $ TextBoxPortNumber��5      $��Center=�6-   $��30��6J   $��	0,108,0,0q�6V   $ NoWrap=�6i   $�� ��6   $	��Top=�6�   $	��250��6�   $��18(�6�   $��Center=�6�   �� 5   
   -   5        $ LabelPortNumber��5      $��Port Number��6)   $
��Left=�6?   $��	16,78,0,0q�6Z   $	��Top=�6m   $��15(�6�   �� 5   
   -   5         ��Name$ 
ButtonSave��5      $
��Save��6%   $��Center=�64   $	��150��6Q   $��40��6]   $��18(�6i   $
��Bold"�6w   
����������#0066ff���#3366cc$��	0,140,0,0q�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 �	#FF1C7BCA63   �� 5       � ��
	 �����63   �� 5       � ��	 5      �� 5      
 �� 
TargetType"
 ��6.   .R�5   "   �� $��border��6)   #��z��67   $��1q�6a   ���	#FF5397D1 �� CornerRadius$ 3��6�   ._�5   &   �� $��Center=�67   $��Center=�6T   5    #    �� Triggers 5!   "   P� 5"   &    P� Property � �� P� Value . . �5#   *   ��  �� 
TargetName$ border��61    � ��
	 ���� 6\   5$   '   P� 5%   &    �@J�IsMouseOver . . �5&   *   ��  � ��
	 �  ��6G   �� 5'   *    �@�Cursor$
	 Hand��6C   5(   '   5*      5,      5-      5/      51      52      