   M S B A M L   `   `   `  ����E  AChessBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChessBoard
ChessBoard  5   	   '    !ChessBoard.LanguageSettingsWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChessBoard     5   	     � Title$  Language settings��5   	   $	��700��6#   $	��500��60   $
��1000��6<   $	��700��6M   $	��400��6\   $	��350��6l   .��5	      � ���#EFE0E0 � ColumnDefinitions 5
   
   �� 5      6!   �� 5      $	��400 �6   6-   �� 5      6!    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      6   .+�5   
   � .+�5      �� -   5         ��Name$ 
BackButton��5      $	��⏎��6)   $��30��65   6[   5      � 5   
   $��0��6   $��10q�6!   $��1��6-   .+�5      �� $��Chess coaching��6   $��36(�6-   �� 5      $��/Resources/Queen1.png��6   65   5      �� 5   
   $��1��6   $��3��6#   $��Center=�67   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $ EnglishButton��5      $��English��60   $	��250��6B   6l   �� 5      $/��)/Resources/Flag_of_the_United_Kingdom.png��6   $��50��6K   $��70��6W   $
��Fill=�6b   5      �� 5      $ 
Horizontal=�6   .+�5       �� -   5        $ RussianButton��5       $��Russian (русский)��60   $	��250��6L   6v   �� 5!      $#��/Resources/Flag_of_Russia.png��6   $��50��6?   $��70��6K   $
��Fill=�6V   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� -   5        $ KoreanButton��5$      $��Korean (한국어)��6/   $	��250��6F   6o   �� 5%      $(��"/Resources/Flag_of_South_Korea.png��6   $��50��6D   $��70��6P   $
��Fill=�6[   5&      5'      � 5(   
   $��1��6   $��1��6$   $��Bottom=�61   .+�5)      �� -   5         ��Name$ NotificationTextBlock��5)      $��Center=�67    �� TextAlignment$ Center=�6T   $����App has got only 3 languages yet but some new ones will be probably added in the next updates. In some languages translations may be slightly different however every piece of information saves the original meaning.��6k   6K  5*      5+      5,      