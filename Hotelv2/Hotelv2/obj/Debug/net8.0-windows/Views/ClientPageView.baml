   M S B A M L   `   `   `  ����B  >Hotelv2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hotelv2.ViewsHotelv2.Views  5      "    Hotelv2.Views.ClientPageView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Hotelv2.Views     5        N� Title$  ClientPageView��5
       � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      � 
�������.+�5   
   �  � RowDefinitions 5      �� 5      $��39 �6    �� 5      $��20 �6    �� 5      $��48 �6    �� 5      $	��438 �6    �� 5      $
��Auto �6    �� 5      .+�5      � $��0��6   .+�5      �� $��Клиенты��6   $
��Left=�5      ���#021A2D$��32(�5       $��
Montserrat)�5!      $��SemiBold"�5"      �� 5$      -   5          	addButton#��[ 5$      $��Right=�5%      .��5)      ��  �� Orientation$ 
Horizontal=�6!   .+�5*      F� +������� �?D���� ��� а�� ��� ��?D��� 	
�������$��2��5,      $��30��5-      $��30��5.      $��0 0 8 0q�5/      �� 50      $��Добавить��6$   $��
Montserrat)�51   $   $��Center=�52   $   $��Center=�53   $   $��SemiBold"�54   $   55      57      58      � 5:      $��1��6   .+�5;      �� 	 �� X1$ 0��6   	 �� Y1$ 0��5<      	 �� Y2$ 0��5>      $��Bottom=�5?      ���#CDE7EA$��1��5A      	 �� X2 5=      �� *ActualWidth+ �� RelativeSource �� 	 �� AncestorType	 Grid5A      5B      � 5D      $��2��6   .+�5E      �� -   5        
 ��Name$
 ClientCount��5E      $
��Left=�5F      ���#021A2D$��15(�5H      $��
Montserrat)�5I      $��Bottom=�5J      $��0 10 0 5q�5K      
������� �� 
IsReadOnly$
 True��5M      $��0q�5N      $��SemiBold"�5O      �� 5Q      $��клиента��6   $
��Left=�5R      ���#459DA6$��Bottom=�5T      $��15(�5U      $��20 0 0 5q�5V      $��
Montserrat)�5W      $��SemiBold"�5X      � 5Z      $��28��6   $	��209��5[      $��Right=�5\      $��Bottom=�5]      .+�5^      �� $
��15 0q�6    $��Center=�5_       ���#7FB9BF$��
Montserrat)�5a       $��Medium"�5b       $��10(�5c        J� IsHitTestVisible$ False��5d        K� ZIndex$ 1��5e       $��
Поиск��5f       y�5g       ��  �� ElementName$ Filter�� �� Path$ Text.IsEmpty� �� 	Converter# [  �� 5i      -   5        $��Filter��5i        filterTextBox#���  5j      $��
Montserrat)�5k      $��0 0 0 0q�5m      $��1q�5n      ���#E0E0E05o      F� 5q      ����Ѐ�� ��� р�� ��� ��� ��e Ӏ� �o \  Vx �# ��� �6�' V�� ��, �v� �_3 �� �t�9 8�� ��A 0� �yJ 4�� �XS 8� �_\ �� ��e �� ӌo �� Vx 8� ��� 4�� �V�� 0� �v� 8�� �� �� �8�� �v� 0� V�� 4�� ��� �8� Vx �� �o �� ��e Ӵ� �_\ 8� XS 4�� �yJ �0� ��A 8�� t�9 �� �_3 ��v� ��, V�� 6�' ��� �# �Vx \  �o �� ��e �� ��_\ �� XS \  �yJ �# ���A 6�' t�9 ��, �_3 �_3 ���, t�9 6�' ��A �# �yJ �\  XS �� �_\ �� ��e 	���#459DA6$��Right=�5s      $��Stretch=�5t      $��16��5u      $��16��5v      $��0 0 15 0q�5w      5x      5y      � 5{      $��3��6   .+�5|      &   System.Windows.Controls.DataGrid  -   5          Name$ ClientDataGrid��5|        DataGridRowStyle   RowStyle# �  5}        DataGridColumnHeaderStyle   ColumnHeaderStyle# �  5~        DataGridCellStyle   	CellStyle# �  5        DataGridStyle#���  5�         AutoGenerateColumns$ False��5�      $��0 10 0 0q�5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5�   -      MinWidth$ 25Q�5�   -      
IsReadOnly$
 True��5�   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   -   �� *	FirstName+  5�      $ Фамилия��6-   $ * 5�   -   $ 66Q�5�   -   $
 True��5�   -    5�   -   �� *
LastName+  5�      $ Отчество��6-   $
 True��5�   -   $ 65Q�5�   -   $ * 5�   -    5�   -   �� *
Patronymic+  5�      $ Паспорт��6-   $
 True��5�   -   $ 60Q�5�   -   $ * 5�   -    5�   -   �� *PassportNumber+  5�      $! Номер телефона��6-   $
 True��5�   -   $	 131Q�5�   -   $ * 5�   -    5�   -   �� *PhoneNumber+  5�      $' !Электронная почта��6-   $
 True��5�   -   $	 145Q�5�   -   $ * 5�   -    5�   -   �� *Email+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ * 61      CellTemplate 5�      �� 5�   "   .R�5�   &   �� $ 
Horizontal=�61   $��Right=�5�   1   $��0 0 30 0q�5�   1   .+�5�   *   ��  ��Name$ 
EditClient��61   -   5          IconEditStyle#���  5�   1   5�   1   �� 5�   *   $ DeleteClient��61   -   5          IconDeleteStyle#���  5�   1   $��15 0 0 0q�5�   1   5�   1   5�   '   5�   #   5�      5�      5�      � 5�      $��4��6   $��Center=�5�      $��Bottom=�5�      5�      5�      5�      5�      