   M S B A M L   `   `   `  ���� I  EAutoClickTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AutoClickTimerAutoClickTimer      AutoClickTimer.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  (localclr-namespace:AutoClickTimer    � Title$  Auto Click Timer��$	��270��$	��355�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ Manual=� � Left$ 0��
 � Top$ 0��.��� $	��670��$��
0,0,-0.2,0q�$	��Top=� � RowDefinitions �� $	��95* ��� $
��239* �.+��� -    ��Name$ buttonActivate��$��Activate��$
��Left=�$��30��$��254,145,0,0q�$	��Top=�$��68���� -    ��Name$ Position��$	��0,0��$
��Left=�$��30��$��
166,14,0,0q�$	��Top=�$	��107���� $��Current Cursor Position:��$
��Left=�$��30��$��	15,14,0,0q�$	��Top=�$	��146���� $#��Event will be triggered after��$
��Left=�$��
17,132,0,0q�$	��Top=��� $��
Trigger At��$
��Left=�$��	15,57,0,0q�$	��Top=�&   Xceed.Wpf.Toolkit.DateTimePicker  -     Name$ 
timePicker��$��	20,83,0,0q�,  &Xceed.Wpf.Toolkit.Primitives.InputBase	   Text$	  ��$
��Left=�$	��205��$��27��$	��Top=��� -   $ countDownLabel��$��0��$
��Left=�$��
20,149,0,0q�$	��Top=�$	��205��9� -   $��Event Editor��$
��Left=�$��10,0.6,0,10.4q�$	��329��$��1��.��� ���	#FFE5E5E5$	��448��.+�&   System.Windows.Controls.DataGrid  -   
  Name$
 clickEventDataGrid��$
��Left=�$	��328��$��0,38,0,0q�   CanUserSortColumns .     CanUserReorderColumns .     CanUserResizeColumns .  �� -   $ addNewClickEventButton��$��+ Add A Click Event��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��144���� -   $ addWaitEventButton��$��+ Add A Wait Event��$
��Left=�$��
174,10,0,0q�$	��Top=�$	��144���� -	   $ 
saveButton��$
��Save��$
��Left=�$��
254,17,0,0q�$	��Top=�$��68���� -
   $ 
loadButton��$
��Load��$
��Left=�$��
254,44,0,0q�$	��Top=�$��68��