   M S B A M L   `   `   `  ����B  >TestAlg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TestAlgTestAlg  5   	       TestAlg.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TestAlg     5   	     � Title$;  5Алгоритмы и структуры данных��5   	   $	��450��6.   $	��800��6;   .��5	      � .+�5
   
   �� $
��Left=�5       �� Orientation$ Vertical=�5      $	��Top=�5      $��	10,50,0,0q�6)   .+�5      �� $ 
Horizontal=�6   $��5q�62   .+�5      �� $	��150��6   ��6(   �� *CurrenQuestion.Question.Text+ �� Mode$ OneWay=�6e   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      	� ��6   �� *!CurrenQuestion.QuestionAndswer1+$ OneWay=� d� 	IsChecked 6_   �� *CurrenQuestion.Andswer1+6�   5      �� 5      $ 
Horizontal=�6   $��5q�63   .+�5      	� ��6   �� *!CurrenQuestion.QuestionAndswer2+$ OneWay=� 6_   �� *CurrenQuestion.Andswer2+6�   5      �� 5      $ 
Horizontal=�6   $��5q�63   .+�5      	� ��6   �� *!CurrenQuestion.QuestionAndswer3+$ OneWay=� 6_   �� *CurrenQuestion.Andswer3+6�   5      5      �� 5   
   $��20q�6   $ 
Horizontal=�6!   $��Center=�5      $
��Left=�5       .+�5"      �� -   5        $��OK��5"      $	��150��6   $��5q�6+   $��Уверен��66   {�6G   �� *CurrenQuestion.Sure+��6s   �� *IKnowCommand+�� 5#      -   5        $��NotOk��5#      $	��150��6"   $��5q�6.   $��Не уверен��69   {�6N   �� *CurrenQuestion.NotSure+��6}   �� *IDontKnowCommand+5$      �� 5%   
   $��20q�6   $ 
Horizontal=�6!   $��Bottom=�5&      $��Right=�5'      .+�5)      �� -   5        $
��Done��5)      $	��150��6!   $��5q�6-   $!��Завершить тест��68   ��6Q   �� *IDoneCommand+5*      �� 5+   
   $��20q�6   $ Vertical=�6!   $��Bottom=�5,      $
��Left=�5-      .+�5.      �� $	��Top=�6   ��60   �� *SliderValue+�� 5/       �� TickFrequency$ 1Q�6   $
��Left=�6'   $	��Top=�50      $	��392��6-    �� TickPlacement$
 Both=�69    � Cursor$	 Pen��6N    � Minimum$ 0Q�51       � Maximum 52      �� *SliderMaximum+	 � Value	 53      �� *SliderValue+54      �� 55   
   $��20q�6   $ Vertical=�6!   $��Stretch=�56      $��Right=�57      .+�58      �� $	��150��6   ��6$   �� *MyTime+6>   59      5:      5;      