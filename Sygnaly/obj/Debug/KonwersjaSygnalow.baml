   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	   B >Sygnaly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SygnalySygnaly 5   	      Sygnaly.KonwersjaSygnalow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   'localclr-namespace:Sygnaly     5   	     � Title$  Filtry��5	   	   $	��700��5
   	   $
��1400��5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���	#FFB8B6B6$��0,0,0,0q�6"    � ColumnDefinitions 5   
   �� 5      $	��450 �6   �� 5      $	��450 �6   �� 5      $	��450 �6   .+�5   
   � $��0��6   $��2��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��80 �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6     5&      �� 5'      $
��Auto �6#   �� 5(      $
��Auto �6#   .+�5+      �� $��Typ Konwersji��6   $��0��6,   $��0��69   $��Right=�6I   $	��5,5q�6e   �� 5,      -   5         ��Name$ TypKonwersji��5,      $	��5,5q�6-    �� SelectedItem$ Próbkowanie równomierne��6:   $��0��6�   $��1��6�   $
��Left=�6�   $	��230��6�   �� 5.      -   5         ��Name$ ParametryTekst��5.      $��	Parametry��60   $��1��6A   $��0��6N    �� TextAlignment$ Right=�6^   $��Right=�6t   $	��5,5q�6�   �� 5/      -   5        $ 	Parametry��5/      $ 5��6*   $��1��6;   $��1��6H   $
��Left=�6X   $	��230��6s   $	��5,5q�6   �� 51      -   5         ��Name$ 	Konwertuj��51      $��	Konwertuj��6(   $��2��6<   $��1��6I   $��14(�6Y   $
��Left=�6g   $	��5,5q�6�   $��95��6�   6�   �� 53      $��Metoda Rekonstrukcji��6   $��3��63   $��0��6@   $��Right=�6P   $	��125��6l   $	��5,5q�6x   �� 54      -   5        $ MetodaRekonstrukcji��54      $ Sinus Cardinalis��64   $��3��6T   $��1��6a   $
��Left=�6q   $	��230��6�   $	��5,5q�6�   �� 56      -   5        $ Rekonstruuj��56      $��Rekonstruuj��6*   $��5��6@   $��1��6M   $��14(�6]   $	��5,5q�6k   $
��Left=�6x   $��95��6�   6�   �� 58      $��Błąd średniokwadratowy��6   $��8��65   $��0��6B   $��Right=�6R   $	��5,5q�6n   �� 59      -   5        	 ��Name$		 MSE��59      $��1��6#   $��8��63   $
��Left=�6@   $	��5,5q�6[   $	��150��6h   �� 5;      $��Stosunek sygnał-szum��6   $��9��63   $��0��6@   $��Right=�6P   $	��5,5q�6l   �� 5<      -   5        $		 SNR��5<      $��1��6#   $��9��63   $
��Left=�6@   $	��5,5q�6[   $	��150��6h   �� 5>      $%��Szczytowy stosunek sygnał-szum��6   $��10��6=   $��0��6K   $��Right=�6[   $	��5,5q�6w   �� 5?      -	   5        $
	 PSNR��5?      $��1��6$   $��10��64   $
��Left=�6B   $	��5,5q�6]   $	��150��6j   �� 5A      $��Maksymalna różnica��6   $��11��61   $��0��6?   $��Right=�6O   $	��5,5q�6k   �� 5B      -
   5        $	 MD��5B      $��1��6"   $��11��62   $
��Left=�6@   $	��5,5q�6[   $	��150��6h   �� 5D      -   5        $ LiczStatystyki��5D      $��Policz��6-   $��13��6>   $��1��6L   $
��Left=�6\   $��95��6w   $	��5,5q�6�   6�   5E      � 5G   
   $��1��6    5H      �� 5I      $
��Auto �6    �� 5J      $
��Auto �6    �� 5K      $
��Auto �6    �� 5L      $
��Auto �6    .+�5O      �� $��Sygnał bazowy��6   $��0��6,   $
��Bold"�69   $��Center=�6K   $��1��6h   >   8System.Windows.Controls.DataVisualization.Charting.Chart  5P      -   5        
  Name$

 Baza��5P   $   $��1��62   $	��280��6?      LegendStyle 5Q      �� 5R       �� 
TargetType" ��6   .�5S      ��  �� Property � �� �� Value$ 0��62   �� 5T       � ��$ 0��63   5U      5W      �� 5Y      $��Sygnał zrekonstruowany��6   $��2��65   $
��Bold"�6B   $��Center=�6T   $��1��6q     5Z      -   5        $
 PoRekonstrukcji��5Z   $   $��3��6=   $	��280��6J    5[      �� 5\      " ��6   .�5]      ��  � ��$ 0��62   �� 5^       � ��$ 0��63   5_      5a      5b      � 5d   
   $��2��6    5e      �� 5f      $
��Auto �6    �� 5g      $
��Auto �6    .+�5j      �� $��Sygnał po konwersji��6   $��0��62   $
��Bold"�6?   $��Center=�6Q     5k      -   5        $
 PoKonwersji��5k   $   $��1��69   $	��280��6F    5l      �� 5m      " ��6   .�5n      ��  � ��$ 0��62   �� 5o       � ��$ 0��63   5p      5r      5t      5v      5w      