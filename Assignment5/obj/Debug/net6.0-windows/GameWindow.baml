   M S B A M L   `   `   `  ����F  BAssignment5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment5Assignment5  5   	       Assignment5.GameWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment5     5   	     � Title$  
Math PALeo��5   	   $	��700��6   $
��1000��6)   .��5	      � ��5
   
   �� 5       �� ImageSource$ /Images/jungle.png��6   .+�5   
   �� 
�������$��10q�6%   $��Stretch=�6:   $��30q�6X   $��Stretch=�6d   ���	#72FFFFFF �� CornerRadius$ 50��6�   ._�5      � .+�5      �� -   5        $��gameBoardStackpanel��5      .+�5      � .+�5      �� ���#c45404$��5q�67   $	��200��6K   $��50��6W   $
��Left=�6c   $��20q�6~   $ 10��6�   
�������._�5      �� -   5        $��
timerLabel��5   $   $��Snap ITC)�66   $��20(�6L   $��Center=�6Z   $��Center=�6w   .��6�   
00:00:006�   5      �� 5      -   5        $��
exitButton��5   !   $��Right=�63   $	��Top=�6O   $	��100��6g   $	��100��6s   ��5      �� 5   "   $ /Images/RedX.png��6-   5      5      �� 5      -   5        $��feedbackLabel��5      $��	Good Job!��61   $��Snap ITC)�6E   $��40(�6[   ���#c45404$��Center=�6~   �� 5       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�5      �� -   5        $��equationLabel��5       $��1 + 1 =��65   $��Center=�6G   $��Snap ITC)�6d   $	��100(�6z   $��20,20q�6�   �� 5      ���#c45404$
��20,0q�67   
�������$��5q�6X   $	��200��6l   $ 20��6y   $	��260��6�   ._�5      �� -   5        $��answerTextBox��5   &   $��Snap ITC)�6;   $	��100(�6Q   $��Center=�6`   $��Center=�6}   $	��230��6�   $	��170��6�    �� TextWrapping$
 Wrap=�6�   6�   5      5!      �� 5"      -   5        $��submitButton��5"      $��Snap ITC)�61   $��40(�6G   $��Center=�6U   $��Center=�6r   $	��200��6�   $	��200��6�    � 	Resources 5#       �� 
TargetType �� Property �� Value��%`   '��       �� 5$      " ��6$   .�5%   "   ��  �@��CornerRadius$	 100��6A   5&      5'      ��5(      �� 5)      $ /Images/greenArrow.png��6)   5+      5,      �� 5-      -   5        $��startButtonBorder��5-      ���#c45404
�������$��Center=�6[   $��Center=�6x   $��5q�6�   $	��200��6�   $ 20��6�   $	��300��6�   ._�5.      �� -	   5        $��startButton��5.      $��Start��60   
��� � �
�������$��Snap ITC)�6f   $��80(�6|   $��Center=�6�   $��Center=�6�   $	��270��6�   $	��170��6�   6�   5/      �� 50      $!��/Images/dinos/pterosaur.png��6   $	��300��6=   $	��200��6I   $
��Left=�6V   $	��Top=�6q   $��460,-36,0,0q�6�   �� 51      $#��/Images/dinos/allosaurus2.png��6   $	��400��6?   $	��249��6K   $
��Left=�6X   $��Bottom=�6s   $��-72,0,0,-58q�6�   �� 52      $#��/Images/dinos/stegosaurus.png��6   $	��400��6?   $	��249��6K   $��Right=�6X   $��Bottom=�6t   $��0,0,-442,-38q�6�   z�53      V� 54      .~�55      �� 	 �� ScaleX$	 -1Q�6-   �� 56      �� 57      T� 58      59      5;      5<      5=      5>      5?      