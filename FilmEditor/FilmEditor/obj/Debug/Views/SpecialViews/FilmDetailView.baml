   M S B A M L   `   `   `  ����E  AFilmEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:FilmEditor.Views.SpecialViewsFilmEditor.Views.SpecialViews  5   	   2    ,FilmEditor.Views.SpecialViews.FilmDetailView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:FilmEditor.Views.SpecialViews     5   	     � Title$  FilmDetailView��5   	   $	��300��6    $	��300��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Close��5      6%   ]� 5      ��. .+�5      �� $��Location��6   �� 5      $
��Auto��6   ��6'   �� *Film.Location.Description+5      5      �� 5   
   $��1��6   .@�5      �� $��Actors��6   .��5      �� .��5      �� ��5      �� *Actors+ �� SelectedItem 5      �� *CurrentActor+ �� View 5      �� 5      .P�5   "   �� $��
First Name��61    �� Width$
 Auto��6E    �� DisplayMemberBinding 6R   �� *FirstMidName+�� 5   "   $��Last ame��61   $
 Auto��6C    6P   �� *
LastName+�� 5   "   $��	Birthdate��61   $
 Auto��6D    6Q   �� *Birthdate.ToShortDateString+5       5"      5#      5$      �� 5%      $��	Directors��6   .��5&      �� .��5'      �� ��5(      �� *	Directors+ 5)      �� *CurrentDirector+ 5*      �� 5+      .P�5,   "   �� $��
First Name��61   $
 Auto��6E    6R   �� *FirstMidName+�� 5-   "   $��Last ame��61   $
 Auto��6C    6P   �� *
LastName+�� 5.   "   $��	Birthdate��61   $
 Auto��6D    6Q   �� *Birthdate.ToShortDateString+5/      51      52      53      �� 54      $��	Composers��6   .��55      �� .��56      �� ��57      �� *	Composers+ 58      �� *CurrentComposer+ 59      �� 5:      .P�5;   "   �� $��
First Name��61   $
 Auto��6E    6R   �� *FirstMidName+�� 5<   "   $��Last ame��61   $
 Auto��6C    6P   �� *
LastName+�� 5=   "   $��	Birthdate��61   $
 Auto��6D    6Q   �� *Birthdate.ToShortDateString+5>      5@      5A      5B      �� 5C      $��	Countries��6   .��5D      �� .��5E      �� ��5F      �� *	Countries+ 5G      �� *CurrentCountry+ 5H      �� 5I      .P�5J   "   �� $
��Name��61   $
 Auto��6?    6L   �� *Name+�� 5K   "   $��Abbreviation��61   $
 Auto��6G    6T   �� *Abbreviation+5L      5N      5O      5P      5Q      5R      5S      