   M S B A M L   `   `   `  ����E  AFilmEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FilmEditor.Views.BaseViewsFilmEditor.Views.BaseViews  5   	   ,    &FilmEditor.Views.BaseViews.CountryView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FilmEditor.Views.BaseViews     5   	   $��Times New Roman)�5   	   $
��Bold"�5	   	   $��14(�5
   	   
����  �$��4q�5   	     � Title$  CountryView��5   	   $	��180��6   $	��500��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Close��5      6%   5      � 5   
   $��1��6    5      �� 5      $��55.333 �6    �� 5       � ColumnDefinitions 5      �� 5      $��78 �6#   �� 5      $��* �6#   .+�5       �� $
��Name��6   $��0,0,0,0.333q�6#   �� 5!      -   5         ��Name$ nameTextBox��5!      $��1��6N   $��0,0,-0.667,54.667q�6^   $��2��6y   ��6+   �� *Name+ �� Mode$ TwoWay=�6y   �� 5"      $��Abbreviation��6   $��0,55,0,-0.333q�6+   $��2��6B   �� 5#      -   5        $ abbreviationTextBox��5#      $��1��63   $��0,55,-0.667,-0.333q�6n   $��2��6�   ��6C   �� *Abbreviation+$ TwoWay=�6�   5$      ]� 5%   
   $��2��6   ��. .+�5&      �� -   5        $��Accept��5&      $
��Left=�67   �� 5'      -   5        $��Reject��5'      $��Right=�67   $��20��6N   $	��Top=�6Z   �� 5(      5)      5*      5+      