   M S B A M L   `   `   `  ����B  >Hotelv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hotelv2.ViewsHotelv2.Views  5      #    Hotelv2.Views.BookingPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Hotelv2.Views     5        N� Title$  BookingPageView��5
       � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      � 
�������.+�5   
   �  � RowDefinitions 5      �� 5      $��39 �6    �� 5      $��20 �6    �� 5      $��48 �6    �� 5      $	��438 �6    �� 5      $
��Auto �6    �� 5      .+�5      � $��0��6   .+�5      �� $��Бронирование��6   $
��Left=�5      ���#021A2D$��32(�5       $��
Montserrat)�5!      $��SemiBold"�5"      �� 5$      -   5          	addButton#��[ 5$      $��Right=�5%      .��5(      ��  �� Orientation$ 
Horizontal=�6!   .+�5)      F� +������� �?D���� ��� а�� ��� ��?D��� 	
�������$��2��5+      $��30��5,      $��30��5-      $��0 0 8 0q�5.      �� 5/      $��Добавить��6$   $��
Montserrat)�50   $   $��Center=�51   $   $��Center=�52   $   $��SemiBold"�53   $   54      56      57      � 59      $��1��6   .+�5:      �� 	 �� X1$ 0��6   	 �� Y1$ 0��5;      	 �� Y2$ 0��5=      $��Bottom=�5>      ���#CDE7EA$��1��5@      	 �� X2 5<      �� *ActualWidth+ �� RelativeSource �� 	 �� AncestorType	 Grid5@      5A      � 5C      $��2��6   5E      � 5G      $��3��6   .+�5H      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 BookingDataGrid��5H        DataGridRowStyle   RowStyle# �  5I        DataGridColumnHeaderStyle   ColumnHeaderStyle# �  5J        DataGridCellStyle   	CellStyle# �  5K        DataGridStyle#���  5L         AutoGenerateColumns$ False��5M      $��0 10 0 0q�5N         Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата брони��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5Q   -      MinWidth$ 65Q�5R   -      
IsReadOnly$
 True��5S   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5T   -   �� *BookingDate+ �� StringFormat$ 
dd.MM.yyyy��  5U      $ Дата заезда��6-   $ * 5V   -   $ 85Q�5W   -   $
 True��5X   -    5Y   -   �� *	CheckIn+$ 
dd.MM.yyyy��  5Z      $ Дата выезда��6-   $
 True��5[   -   $ 90Q�5\   -   $ * 5]   -    5^   -   �� *
CheckOut+$ 
dd.MM.yyyy��  5_      $ Сотрудники��6-   $
 True��5`   -   $	 102Q�5a   -   $ * 5b   -    5c   -   �� *StaffFullName+  5d      $ Клиенты��6-   $
 True��5e   -   $	 115Q�5f   -   $ * 5g   -    5h   -   �� *ClientFullName+  5i      $ № комнаты��6-   $
 True��5j   -   $	 100Q�5k   -   $ * 5l   -    5m   -   �� *Room.NumberRoom+4  .System.Windows.Controls.DataGridTemplateColumn  5n      $ * 61      CellTemplate 5o      �� 5p   "   .R�5q   &   �� $ 
Horizontal=�61   $��Right=�5r   1   $��0 0 30 0q�5s   1   .+�5t   *   ��  ��Name$ EditBooking��61   -   5          IconEditStyle#���  5u   1   5v   1   �� 5x   *   $ DeleteBooking��61   -   5          IconDeleteStyle#���  5y   1   $��15 0 0 0q�5z   1   5{   1   5|   '   5}   #   5      5�      5�      � 5�      $��4��6   $��Center=�5�      $��Bottom=�5�      5�      5�      5�      5�      