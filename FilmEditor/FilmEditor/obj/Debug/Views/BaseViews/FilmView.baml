   M S B A M L   `   `   `  ����E  AFilmEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FilmEditor.Views.BaseViewsFilmEditor.Views.BaseViews  5   	   )    #FilmEditor.Views.BaseViews.FilmView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FilmEditor.Views.BaseViews     5   	   $��Times New Roman)�5   	   $
��Bold"�5	   	   $��14(�5
   	   
����  �$��4q�5   	     � Title$  FilmView��5   	   $	��300��6   $	��300��6'   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � .+�5      �� -   5        $��Close��5      6%   �� 5      -   5        $��Set Location��5      6,   5      � 5   
   $��1��6    5      �� 5      $
��1.6* �6    �� 5      $
��1.6* �6    �� 5      $
��1.6* �6    �� 5      $
��1.6* �6    �� 5      $
��1.6* �6    �� 5      $��2* �6     � ColumnDefinitions 5!      �� 5"      $
��Auto �6#   �� 5#      $��* �6#   .+�5%      �� $��Barcode��6   �� 5&      -   5         ��Name$ barcodeTextBox��5&      $��1��6.   ��6>   �� *	Barcode+ �� Mode$ TwoWay=��� 5'      $��Title��6   $��1��6$   �� 5(      -   5        $ titleTextBox��5(      $��1��6,   $��1��69   ��6I   �� *Title+$ TwoWay=��� 5)      $
��Year��6   $��2��6#   �� 5*      -   5        $ yearTextBox��5*      $��2��6+   $��1��68   ��6H   �� *Year+$ TwoWay=��� 5+      $��Length��6   $��3��6%   �� 5,      -   5        $ lengthTextBox��5,      $��3��6-   $��1��6:   ��6J   �� *Length+$ TwoWay=��� 5-      $��Location��6   $��4��6'   �� 5.      -   5        $ locationtextBox��5.      $��4��6/   $��1��6<   ��6L   �� *Location.Description+$ TwoWay=�]� 5/      $��5��6   $��2��6%   ��. .+�50      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   .+�51      �� $��German Subtitles��6   �� 52       d� 	IsChecked 6   �� *HasGermanSubtitles+$ TwoWay=�53      �� 54      $ 
Horizontal=�6   $��Right=�66   .+�55      ��  6   �� *
IsBluray+$ TwoWay=��� 56      $��Blu-ray��6   57      �� 58      59      5:      ]� 5;   
   $��2��6   ��. .+�5<      �� -   5        $��Accept��5<      $
��Left=�67   �� 5=      -	   5        $��Reject��5=      $��Right=�67   �� 5>      5?      5@      5A      