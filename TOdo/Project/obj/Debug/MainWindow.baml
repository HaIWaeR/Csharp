   M S B A M L   `   `   `  ����B  >TodoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TodoAppTodoApp  5   	       TodoApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TodoApp     5   	   -   5          � Title$  ToDoApp��5   	   $	��450��5	   	   $
��1000��5
   	   ���	#FFD8BFD8$��Segoe UI)�5   	    � 	Resources 5      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell)  #System.Windows.Controls.DataGridRow �� Triggers P� Property P� Value��%  '        '      '  �    '  g    �� 5   
   "  6   .�5      ��  � �� �	#FFE6E6FA6+   �� 5       � �� �	#FF2E08546+   �� 5       � �� �	#FF8000806,   �� 5       � ��$ 1q�60   �� 5       �@ RowBackground
 �����6.   �� 5        �@ AlternatingRowBackground �	#FFF5F0FA69   �� 5       �@ GridLinesVisibility$
 None=�64   �� 5       �@ HeadersVisibility$ Column=�62   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   "  6   .�5       ��  � �� �	#FF8000806+   �� 5!       � ��
 �����6+   �� 5"       � ��$
 Bold"�6+   �� 5#       � ��$
 10,5q�6(   5$      �� 5'   
   "  6   .�5(      ��  � ��$ 0,0,1,1q�60   �� 5)       � �� �	#FFD8BFD86,   �� 5*       � ��$
 10,5q�6(   5+      �� 5.   
   "  6    5/      P� 50       �@J�IsMouseOver . . �51      ��  � �� �	#FFE0B0FF63   52      54      55      .��57        -   5          Name$ 
dgTodoList��57      $��10q�58      	   AutoGenerateColumns	 .  
   Columns
 5:   
   0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Дата создания��5=          Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 5>       1  +System.Windows.Controls.DataGridBoundColumn   Binding 5;   !   �� *CreationDate+ �� StringFormat$ {0:yyyy-MM-dd HH:mm}��5>       4	  .System.Windows.Controls.DataGridCheckBoxColumn	  5?       .  $ Выполнено��5A   $   $ 80 5B   $    5?   %   �� *IsDone+ �� UpdateSourceTrigger$ PropertyChanged=�5B   $     5C       .  $ Задача��5E       $ * 5F        5C   !   �� *Text+5F       4
  .System.Windows.Controls.DataGridTemplateColumn
  5G      $ Дедлайн��6%   $	 150 66    
  CellTemplate 5H      �� 5I      .R�5J      (  "System.Windows.Controls.DatePicker  $��0q�5K   %   
������    SelectedDate 5J   %   �� *
Deadline+$ PropertyChanged=�5L   %   5M      5O        5P       . $ Статус��5R       $	 150 5S        5P   !   �� *DaysRemaining+5S       5U      5V      