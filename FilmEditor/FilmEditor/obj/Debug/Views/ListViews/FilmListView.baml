   M S B A M L   `   `   `  ����E  AFilmEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FilmEditor.Views.ListViewsFilmEditor.Views.ListViews  5   	   -    'FilmEditor.Views.ListViews.FilmListView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FilmEditor.Views.ListViews     5   	   $��Times New Roman)�5   	   $
��Bold"�5	   	   $��14(�5
   	   
����  �$��4q�5   	     � Title$  FilmListView��5   	   $	��300��6   $	��800��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� .@�5      m� -   5        $��Close��5      6&   m� 5      -   5        $
��Find��5      6%   m� 5      -   5        $
��Edit��5      6%   m� 5       $
��Crud��6   .@�5"      m� -   5        $	��New��5"      6(   m� 5$      -   5        $
��Save��5$      6)   m� 5%      -   5        $��Save All��5%      6-   m� 5'      -   5        $��Delete��5'      6+   m� 5)      -   5        $��Update��5)      6+   5+      m� 5-      $��Add a contributor��6   .@�5/      m� -	   5        $��Actor��5/      6*   m� 51      -
   5        $��Composer��51      6-   m� 53      -   5        $��Director��53      6-   55      m� 57      $��Show Contributors��6   .@�59      m� -   5        $��Actor��59      6*   m� 5;      -   5        $��Composer��5;      6-   m� 5=      -   5        $��Director��5=      6-   5?      m� 5@      -   5        $��Add a Country��5@      6.   m� 5A      -   5        $��Show Countries��5A      6/   m� 5B      -   5        $��Show Details��5B      6-   5C      �� 5E   
   $��1��6   .��5G      �� -   5         ��Name$ filmListView��5I      ��5K      �� *Films+ �� SelectedItem 5M      �� *CurrentFilm+ �� View 5O      �� 5Q      .P�5S      �� $��Barcode��6)    �� Width$
 Auto��6:    �� DisplayMemberBinding 6G   �� *	Barcode+ �� Mode$ TwoWay=��� 5U      $��Title��6)   $
 Auto��68    6E   �� *Title+$ TwoWay=��� 5W      $
��Year��6)   $
 Auto��67    6D   �� *Year+$ TwoWay=��� 5Y      $��Length��6)   $
 Auto��69    6F   �� *Length+$ TwoWay=��� 5[      $��Location��6)   $
 Auto��6;    6H   �� *Location.Description+$ TwoWay=��� 5]      $��	Subtitles��6)   $
 Auto��6<    6I   �� *HasGermanSubtitles+$ TwoWay=��� 5_      $��Blu-ray��6)   $
 Auto��6:    6G   �� *
IsBluray+$ TwoWay=�5a      5e      5g      5i      5j      