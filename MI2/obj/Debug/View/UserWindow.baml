   M S B A M L   `   `   `  ����>  :MI2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MI2.ViewMI2.View  5   	       MI2.View.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MI2.View     5   	     � Title$  Пользователи��5   	   $	��516��6   $	��761��6+   $	��516��67   $	��761��6G    � Icon$ /Assets/icon.ico��6W    � WindowStartupLocation$ CenterScreen=�6o   .��5
      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5      $
��Auto �6'   5      �� 5      $��1��6   .@�5      �� -   5         ��Name$
 Info��5      $��Пользователи��6(   $��20(�6>   .��5      � ��5      �� 5        �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5!   "   �  � Color$ 	#FFF19EEE��6/   	 � Offset$	 0.349Q�6A   5#       5%      �� 5&      $	��27* �6/   �� 5'      $
��767* �6/    5)      �� 5*      $
��Auto �6,   �� 5+      �� 5,      $
��Auto �6,   .+�5.      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 DGrid��5.   #      AutoGenerateColumns .     
IsReadOnly . $��8,0,8,0q�6a   $��2��6r   $��1��6�   $��20(�6�   ���	#FFF7DAB6   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��65      FontSize$ 20Q�6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Name+6m     51   "   $ Фамилия��65   $ 20Q�6b    6F   �� *	Surname+6s     52   "   $ Отчество��65   $ 20Q�6f    6G   �� *
Patronymic+6w     53   "   $ Роль��65   $ 20Q�6a    6C   �� *	Role.Name+6r     54   "   $ 
Логин��65   $ 20Q�6^    6D   �� *Login+6o     55   "   $ Пароль��65   $ 20Q�6b    6E   �� *
Password+6s   57      �� 58      $��2��6%    �� Orientation$ 
Horizontal=�59      $��Right=�5:      $��1��6.   $��2��6?   $��Bottom=�6P   .+�5;      �� $��2��6)   $ 
Horizontal=�5<      $��Right=�5=      .+�5>   "   �� -   5        $��
Выйти��5>   )   $��80��5@      $��Arial Black)�5A      $��16(�62   $��10q�5B      ���	#FFC2F3F0$��Center=�6=   $��Center=�6Z   5C      5E      5F      5H      5I      5J      5K      5L      5M      