   M S B A M L   `   `   `  ����E  AFilmEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FilmEditor.Views.ListViewsFilmEditor.Views.ListViews  5   	   /    )FilmEditor.Views.ListViews.PersonListView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FilmEditor.Views.ListViews     5   	   $��Times New Roman)�5   	   $
��Bold"�5	   	   $��14(�5
   	   
����  �$��4q�5   	     � Title$  PersonListView��5   	   $	��300��6    $	��500��6-   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� .@�5      m� -   5        $��Close��5      6&   m� 5      -   5        $
��Find��5      6%   m� 5      -   5        $
��Edit��5      6%   m� 5      $
��Crud��6   .@�5      m� -   5        $	��New��5      6(   m� 5      -   5        $
��Save��5      6)   m� 5      -   5        $��Save All��5      6-   m� 5      -   5        $��Delete��5      6+   m� 5      -   5        $��Update��5      6+   5      m� 5      $��Show Contributions��6   .@�5      m� -	   5        $��	Played in��5      6.   m� 5       -
   5        $��Directed��5       6-   m� 5!      -   5        $��Composed��5!      6-   5"      5#      �� 5$   
   $��1��6   .��5%      �� -   5         ��Name$ personListView��5&      ��5(      �� *People+ �� SelectedItem 5)      �� *CurrentPerson+ �� View 5*      �� 5+      .P�5,      �� $
��Name��6)    �� Width$
 Auto��67    �� DisplayMemberBinding 6D   �� *
FullName+�� 5-      $��	Birthdate��6)   $
 Auto��6<    6I   �� *ShortBirthdate+5.      50      51      52      53      