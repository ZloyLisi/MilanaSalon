   M S B A M L   `   `   `  ����>  :MI2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MI2.ViewMI2.View  5   	       MI2.View.AddTovarWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MI2.View     5   	     � Title$#  Добавить платье��5   
   $	��750��6"   $	��400��6/   $	��750��6;   $	��400��6K   $	��750��6Z   $	��400��6j   ���	#FFF7DAB6 � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$ 
ToolWindow=�6.    � Icon$ /Assets/icon.ico��6H    � 	Resources 5
      (   "MI2.View.NullToVisibilityConverter   NullToVisibilityConverter��%   &	          5   
   6*   5      .��5      �� $��10q�6   .+�5   
   �� $
��Bold"�6   $��Название:��6&   �� 5   
   -   5         ��Name$ NameTextBox��5      �� 5   
   $
��Bold"�6   $��	Цена:��6&   �� 5   
   -   5        $ PriceTextBox��5      6R   �� 5   
   $
��Bold"�6   $��Фотография:��6&   �� 5   
   
���   �$��1q�6%    �� Padding$ 10q�69   $��Center=�6F   $��Center=�6c   y�6~   ��  �� ElementName$ 
DressImage�� �� Path$ Source�	 �� 	Converter#	 [  ._�5      �� -   5        
 ��Name$
 
DressImage��5      $	��300��5      $��Uniform=�5      $��10q�5      $��Center=�5      $��Center=�5       J� OpacityMask �	#FFC2F3F06(   5      �� 5   
   -   5        $+��%Добавить фотографию��5      $��10q�6/   ���	#FFC2F3F0$��Arial Black)�6p   $
��Left=�6�   �� 5!   
   $
��Bold"�6   $��Категория:��6&   �� 5"   
   -   5         ��Name$ CategoryComboBox��5"       �� DisplayMemberPath$
 Name��6-    �� SelectedValuePath$ Id��6F   �� 5$   
   $
��Bold"�6   $��Описание:��6&   �� 5%   
   -   5        $ DescriptionTextBox��5%       �� AcceptsReturn . $	��100��5&   
    �� TextWrapping$
 Wrap=�5'   
   �� 5)   
   -   5        $��Сохранить��5)      $��10q�6%   ���	#FFC2F3F0$��Arial Black)�6I   $��Center=�6z   $��31��6�   $	��116��6�   5*      5+      