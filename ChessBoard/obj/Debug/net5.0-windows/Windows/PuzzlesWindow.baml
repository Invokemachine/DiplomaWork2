   M S B A M L   `   `   `  ����E  AChessBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ChessBoard.ControlsChessBoard.Controls  5   	   'clr-namespace:ChessBoard
ChessBoard  5   	       ChessBoard.PuzzlesWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6controls!clr-namespace:ChessBoard.Controls     5   	   *localclr-namespace:ChessBoard     5   	     � Title$  Puzzles��5	   	    � SizeToContent$ WidthAndHeight=�6    � 
ResizeMode$ CanMinimize=�68   $	��550��6Q    J� SnapsToDevicePixels$
 True��5   	    � 	Resources 5      #   ChessBoard.CellColorConverter   CellColorConverter��%   &	          5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $
��-5,0q�6>   .+�5      �� -   5         ��Name$ PreviousButton��5   (   $��Previous��6   $��5q�6@   $	��100��6K   $
��10,5q�6W   $��30��6f   $��15(�6r   ��6�   �� *PuzzlePrevious+�� 5      -   5        $ 
NextButton��5   $   $
��Next��6   $��5q�68   $
��10,5q�6C   $	��100��6R   $��30��6^   $��15(�6j   ��6x   �� *
PuzzleNext+�� 5      -   5        $ CheckButton��5   %   $��Check��6   $��5q�6:   $
��10,5q�6E   $	��100��6T   $��30��6`   $��15(�6l   ��6z   �� *PuzzlePCheck+�� 5      -   5        $ 
BackButton��5   !   $	��⏎��6   $��40��65   $��30��6@   $��Center=�6L   $��Right=�6n   6�   �� 5       -   5        	 ��Name$	 PuzzlesComboBox��5       $��60��60   
 �� Text$
 #��6;   $��30��6D   6P   �� 5!      -   5        $ AcceptButton��5!   !   $	��✔��6   $��40��67   $��30��6B   $��Center=�6N   $��Right=�6p   $��16(�6�   ��6�   �� *SelectedPuzzleShow+6�   5"      �� 5#   
   $��2��6   $��21��6D   ��6$   �� *	Numbers+��5$      �� 5%      .R�5&      � $��60��6   .+�5'      ��  �� Padding$	 5,0q�6$   $��Center=�6C    �� TextAlignment$ Center=�6^   $��16(�6u   ��62   �� 6u   5(      5)      5+      �� 5,   
   $��1��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5-      �� 5.      .R�5/      � $��60��6   .+�50      �� $��Center=�65   $ Center=�6P   $��16(�6g   ��6$   �� 6g   51      52      ��54      �� 55      .R�56      �� $ 
Horizontal=�6!   57      59      �� 5:   
   -   5         ��Name$ PuzzleBoard��5:      $��2��6,   $��1��69    �� AlternationCount$ 64��6g   ��6I   �� *Board+��5;      �� 5<      .R�5=      �� $��60��6   $��60��6(   ��64   �� *DataContext.CellCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� ��5>      �� 5?       �� 
TargetType" ��6$   .�5@   "   ��  �� Property �@�OverridesDefaultStyle �� Value$
 True��6J   �� 5A   "    � ��
 �����6?   �� 5B   "    � �� 6@   Z� �� 5C   "    � ��$ 2q�6D   �� 5D   "    � �� 5E   &   �� 5F   *   .R�5G   .   �� #��z��65   ._�5H   2   �� #��z��69   #��z��6m   ._�5I   6   $   ChessBoard.Controls.ChessPiece     Piece 6J   �� *State+5J   3   5K   /   5L   +   5N   #    �� Triggers 5O   "   �� 5P   &    �� Binding 62   �� *!(ItemsControl.AlternationIndex)+ ��  ContentPresenter �� 	Converter# [   �� Value True6�   .a�5Q   *   ��  � ��
 �`���6G   5R   '   �� 5S   &    62   �� *Active+ True6M   .a�5T   *   ��  � ��
 �  ��6H   5U   '   �� 5V   &    62   �� *PossibleMove+ True6S   .a�5W   *   ��  � ��
 � � �6H   5X   '   5Z      5\      5]      ��5_      �� 5`      .R�5a      A�  A� Columns$ 8��6"    A� Rows$ 8��6.   5b      5d      �� 5e   
   $��3��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5f      �� 5g      .R�5h      � $��60��6   .+�5i      �� $��Center=�65   $ Center=�6P   $��16(�6g   ��6$   �� 6g   5j      5k      ��5m      �� 5n      .R�5o      �� $ 
Horizontal=�6!   5p      5r      �� 5s   
   $��2��6   $��2��6$   $��21��6T   ��64   �� *	Numbers+��5t      �� 5u      .R�5v      � $��60��6   .+�5w      �� $	 5,0q�6$   $��Center=�6C   $ Center=�6^   $��16(�6u   ��62   �� 6u   5x      5y      5{      5|      5}      