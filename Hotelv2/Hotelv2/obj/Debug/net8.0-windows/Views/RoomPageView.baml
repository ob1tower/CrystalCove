   M S B A M L   `   `   `  ����B  >Hotelv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hotelv2.ViewsHotelv2.Views  5           Hotelv2.Views.RoomPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Hotelv2.Views     5        N� Title$  RoomPageView��5
       � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      � 
�������.+�5   
   �  � RowDefinitions 5      �� 5      $��39 �6    �� 5      $��20 �6    �� 5      $��48 �6    �� 5      $	��438 �6    �� 5      $
��Auto �6    �� 5      .+�5      � $��0��6   .+�5      �� $��Комнаты��6   $
��Left=�5      ���#021A2D$��32(�5       $��
Montserrat)�5!      $��SemiBold"�5"      �� 5$      -   5          	addButton#��[ 5$      $��Right=�5%      .��5(      ��  �� Orientation$ 
Horizontal=�6!   .+�5)      F� +������� �?D���� ��� а�� ��� ��?D��� 	
�������$��2��5+      $��30��5,      $��30��5-      $��0 0 8 0q�5.      �� 5/      $��Добавить��6$   $��
Montserrat)�50   $   $��Center=�51   $   $��Center=�52   $   $��SemiBold"�53   $   54      56      57      � 59      $��1��6   .+�5:      �� 	 �� X1$ 0��6   	 �� Y1$ 0��5;      	 �� Y2$ 0��5=      $��Bottom=�5>      ���#CDE7EA$��1��5@      	 �� X2 5<      �� *ActualWidth+ �� RelativeSource �� 	 �� AncestorType	 Grid5@      5A      � 5C      $��2��6   .+�5D      �� -   5        
 ��Name$
 	RoomCount��5D      $
��Left=�5E      ���#021A2D$��15(�5G      $��
Montserrat)�5H      $��0 10 0 5q�5I      $��Bottom=�5J      
������� �� 
IsReadOnly$
 True��5L      $��0q�5M      $��SemiBold"�5N      �� 5P      $%��свободных комнат��6   $
��Left=�5Q      ���#459DA6$��Bottom=�5S      $��15(�5T      $��20 0 0 5q�5U      $��
Montserrat)�5V      $��SemiBold"�5W      5X      � 5Z      $��3��6   .+�5[      &   System.Windows.Controls.DataGrid  -   5          Name$ RoomDataGrid��5[        DataGridRowStyle   RowStyle# �  5\        DataGridColumnHeaderStyle   ColumnHeaderStyle# �  5]        DataGridCellStyle   	CellStyle# �  5^        DataGridStyle#���  5_         AutoGenerateColumns$ False��5`      $��0 10 0 0q�5a         Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn   Header$ № комнаты��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5d   -      MinWidth$ 25Q�5e   -      
IsReadOnly$
 True��5f   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5g   -   �� *
NumberRoom+  5h      $ Категория��6-   $ * 5i   -   $ 66Q�5j   -   $
 True��5k   -    5l   -   �� *
Category+  5m      $ Этаж��6-   $
 True��5n   -   $ 40Q�5o   -   $ * 5p   -    5q   -   �� *Floor+  5r      $ Кол-во мест��6-   $
 True��5s   -   $ 70Q�5t   -   $ * 5u   -    5v   -   �� *NumberSeats+  5w      $ Цена (₽/ночь)��6-   $
 True��5x   -   $	 120Q�5y   -   $ * 5z   -    5{   -   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5|      $ Статус��61   $	 100Q�5}   1   $ * 5~   1      CellTemplate 5      �� 5�   "   .R�5�   &   �� ��5�   *   �� 5�   .    �� 
TargetType" ��64   .�5�   2   ��  �� Property � �� �� Value$ Свободно��6I   �� 5�   2    � �� �#459DA66O    �� Triggers 5�   2   �� 5�   6    �� Binding 6B   �� *StatusBooking+ �� Value True6d   .a�5�   :   ��  � ��$ Занято��6Q   �� 5�   :    � �� �#BB00006W   5�   7   5�   /   5�   '   5�   #   5�        5�      $ * 61    5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Right=�5�   1   $��0 0 30 0q�5�   1   .+�5�   *   ��  ��Name$ EditRoom��61   -   5          IconEditStyle#���  5�   1   5�   1   �� 5�   *   $ 
DeleteRoom��61   -   5          IconDeleteStyle#���  5�   1   $��15 0 0 0q�5�   1   5�   1   5�   '   5�   #   5�      5�      5�      � 5�      $��4��6   $��Center=�5�      $��Bottom=�5�      5�      5�      5�      5�      