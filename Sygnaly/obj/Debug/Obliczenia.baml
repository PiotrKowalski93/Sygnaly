   M S B A M L   `   `   `  ����B  >Sygnaly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SygnalySygnaly  5   	   | xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   
       Sygnaly.Obliczenia   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Sygnaly     5   	   �toolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   
     � Title$  
Obliczenia��5	   	   $��755.6��6   $��1453.2��6+   .��5
      � ���	#FFB8B6B6$��0,0,-6.6,0.6q�6"    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $	��450 �6   �� 5      $��1051.2 �6   .+�5   
   � $��2��6   $��29,51,290.6,429q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ Srednia��5      $��0��6%   $��Srednia��62   $��Center=�6D   $��Center=�6a   $	��5,5q�6|   $��25��6�   �� 5      -   5        $ SredniaBezwzgledna��5      $��1��60   $��Srednia Bezwzgledna��6=   $��Center=�6[   $��Center=�6x   $	��5,5q�6�   $��25��6�   �� 5      -   5        $ WartoscSkuteczna��5      $��2��6.   $��Wartosc Skuteczna��6;   $��Center=�6W   $��Center=�6t   $	��5,5q�6�   $��25��6�   �� 5      -   5        $ 	Wariancja��5      $��3��6'   $��	Wariancja��64   $��Center=�6H   $��Center=�6e   $	��5,5q�6�   $��25��6�   �� 5      -   5        $ 	MocSrdnia��5      $��4��6'   $��Srednia Moc��64   $��Center=�6J   $��Center=�6g   $	��5,5q�6�   $��25��6�   5       � 5"   
   $��2��6   $��204,51,155.6,459q�6    5#      �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $��16 �6    �� 5)      $��20 �6    .+�5,      �� -   5         ��Name$ SredniaSygnal1��5,      $��0��60   $��Center=�6=   $��Center=�6Z   $
��25,6q�6u   $��24��6�   $��40��6�   �� 5-      -   5        $ SredniaBezwSygnal1��5-      $��1��64   $��Center=�6A   $��Center=�6^   $
��25,6q�6y   $��24��6�   $��40��6�   �� 5.      -   5        $ SkutecznaSygnal1��5.      $��2��62   $��Center=�6?   $��Center=�6\   $
��25,6q�6w   $��24��6�   $��40��6�   �� 5/      -	   5        $ WariancjaSygnal1��5/      $��3��62   $��Center=�6?   $��Center=�6\   $
��25,6q�6w   $��24��6�   $��40��6�    J� RenderTransformOrigin$ 	0.5,1.224&�6�   �� 50      -
   5        $ MocSredniaSygnal1��50      $��4��63   $��Center=�6@   $��Center=�6]   $
��25,6q�6x   $��24��6�   $��40��6�   $��2��6�   51      � 53   
   $��2��6   $��2��6   $��1.2,0,1048.6,0q�63    54      �� 55      $��25 �6    �� 56      $	��250 �6    �� 57      $��25 �6    �� 58      $	��250 �6    .+�5;      �� $��  Składowa Rzeczywiska ��6   $��Center=�66   $��0��6S   $��795,8,-496,242q�6`   $��2��6x   $	��152��6�   >  8System.Windows.Controls.DataVisualization.Charting.Chart  5<      -   5          Name$ AmplitudaRzeczywista��5<      $��322,25.4,-389,225q�6:   $��3��6U   $��1��6f   �� 5>      $��Składowa Urojona ��6   $��Center=�60   $��3��6M   $��816,47.4,-472,169q�6Z     5?      -   5        $ AmplitudaUrojona��5?      $��3��66   $��322,86.4,-389,-126q�6C   5@      � 5B   
   $��3��6   $��
52.6,0,0,0q�6   $
��Left=�63   $	��651��6N    5C      �� 5D      $��25 �6    �� 5E      $	��250 �6    �� 5F      $��25 �6    �� 5G      $	��250 �6    .+�5I        -   5        $ HistogramRzeczywista��5I      $��397,28.4,-255,0q�6:   $��1��6S   $	��276��6`   $	��Top=�6m   $��3��6�     5J      -   5        $ HistogramUrojona��5J      $��3��66   $��397,91.4,-255,-127q�6C   5K      5M      5N      