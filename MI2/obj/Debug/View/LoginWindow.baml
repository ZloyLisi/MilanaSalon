   M S B A M L   `   `   `  ����>  :MI2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MI2.ViewMI2.View  5   	       MI2.View.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MI2.View     5   	     � Title$  Авторизация��5      $	��450��6%   $	��450��62    � WindowStartupLocation$ CenterScreen=�6?    � Icon$ /Assets/icon.ico��6e   ���	#FFF7DAB6 � 
ResizeMode$ CanMinimize=�5	      .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��/Assets/Graf.png��6   6,   �� 5   
   $��3��6   $��2��6$   $��0��65   $��Введите логин��6B   $��Center=�6Z   $��16(�6w   $��Arial Black)�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ login��5      $��0 ��6!   $��1��62   $��3��6?   $��30��6S   $	��300��6_   $��Arial Black)�6k   $��16(�6�   �� 5   
   $��2��6   $!��Введите пароль��6   $��Center=�66   $��16(�6S   $��Arial Black)�6a   $��3��6z   G� 5   
   -   5         G�Name$ password��5      $��0��6(   $��2��68   $��3��6E   $��30��6Y   $	��300��6e   $��Arial Black)�6q   $��16(�6�   �� 5   
   -   5        $��80��5      $	��150��6   $��3��6)   $��0��6=   $��3��6M   $��
Войти��6Z   ���	#FFC2F3F0$��16(�6�   $��Arial Black)�6�   6�   5      5      