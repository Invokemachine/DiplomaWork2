   M S B A M L   `   `   `  ����E  AChessBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChessBoard
ChessBoard  5   	   9!clr-namespace:ChessBoard.ControlsChessBoard.Controls  5   	       ChessBoard.PlayWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChessBoard     5   	   6controls!clr-namespace:ChessBoard.Controls     5   	     � Title$  
WPF Window��5	   	    � SizeToContent$ WidthAndHeight=�6    � 
ResizeMode$ CanMinimize=�6;    J� SnapsToDevicePixels$
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
��-5,0q�6>   .+�5      �� -   5         ��Name$ NewGameButton��5   (   $��New Game��6   $��5q�6?   $
��10,5q�6J   $��30��6Y   $��15(�6e   ��6s   �� *NewGameCommand+�� 5      -   5        $ ClearButton��5   %   $��Clear��6   $��5q�6:   $
��10,5q�6E   $��30��6T   $��15(�6`   ��6n   �� *ClearCommand+�� 5      -   5        $ 
BackButton��5   !   $	��⏎��6   $��40��65   $��30��6@   $��Center=�6L   $��Center=�6n   6�   5      �� 5    
   $��2��6   $��21��6D   ��6$   �� *	Numbers+��5!      �� 5"      .R�5#      � $��60��6   .+�5$      �� 	 �� Padding$		 5,0q�6$   $��Center=�6C   
 �� TextAlignment$
 Center=�6^   $��16(�6u   ��62   �� 6u   5%      5&      5(      �� 5)   
   $��1��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5*      �� 5+      .R�5,      � $��60��6   .+�5-      �� $��Center=�65   $
 Center=�6P   $��16(�6g   ��6$   �� 6g   5.      5/      ��51      �� 52      .R�53      �� $ 
Horizontal=�6!   54      56      �� 57   
   $��2��6   $��1��6$    �� AlternationCount$ 64��6R   ��64   �� *Board+��58      �� 59      .R�5:      �� $��60��6   $��60��6(   ��64   �� *DataContext.CellCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� ��5;      �� 5<       �� 
TargetType" ��6$   .�5=   "   ��  �� Property �@�OverridesDefaultStyle �� Value$
 True��6J   �� 5>   "    � ��
 �����6?   �� 5?   "    � �� 6@   Z� �� 5@   "    � ��$ 2q�6D   �� 5A   "    � �� 5B   &   �� 5C   *   .R�5D   .   �� #��z��65   ._�5E   2   �� #��z��69   #��z��6m   ._�5F   6   $   ChessBoard.Controls.ChessPiece     Piece 6J   �� *State+5G   3   5H   /   5I   +   5K   #    �� Triggers 5L   "   �� 5M   &    �� Binding 62   �� *!(ItemsControl.AlternationIndex)+ ��  ContentPresenter �� 	Converter# [   �� Value True6�   .a�5N   *   ��  � ��
 �`���6G   5O   '   �� 5P   &    62   �� *Active+ True6M   .a�5Q   *   ��  � ��
 �  ��6H   5R   '   �� 5S   &    62   �� *PossibleMove+ True6S   .a�5T   *   ��  � ��
 � � �6H   5U   '   5W      5Y      5Z      ��5\      �� 5]      .R�5^      A�  A� Columns$ 8��6"    A� Rows$ 8��6.   5_      5a      �� 5b   
   $��3��6   $��1��6$   $��21��6T   ��64   �� *	Letters+��5c      �� 5d      .R�5e      � $��60��6   .+�5f      �� $��Center=�65   $
 Center=�6P   $��16(�6g   ��6$   �� 6g   5g      5h      ��5j      �� 5k      .R�5l      �� $ 
Horizontal=�6!   5m      5o      �� 5p   
   $��2��6   $��2��6$   $��21��6T   ��64   �� *	Numbers+��5q      �� 5r      .R�5s      � $��60��6   .+�5t      �� $		 5,0q�6$   $��Center=�6C   $
 Center=�6^   $��16(�6u   ��62   �� 6u   5u      5v      5x      5y      5z      