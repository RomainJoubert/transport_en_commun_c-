   M S B A M L   `   `   `  ����G  CTransportWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TransportWPFTransportWPF  5          TransportWPF.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,localclr-namespace:TransportWPF     5        �� 	Resources  5          MyGlassGradientStopsResource � Color � Offset  MyGlassBrushResource �� 
StartPoint �� EndPoint �� Opacity  GrayBlueGradientBrush �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name �� RadiusX �� RadiusY J� Opacity J� RenderTransformOrigin J� BitmapEffect ��Name �� Triggers P� Property P� Value �� 
TargetName �� Radius :� RoutedEvent ��Name �� 
TargetName �� TargetProperty	 W� By g� Duration �� BeginStoryboardName��%�  &	        &	 K    7   &	 �    '�� c    7  7  � 5   
   � 5      $ 
WhiteSmoke��6   $	 0.2Q�6.   � 5	      $ Transparent��6   $	 0.4Q�6/   � 5
      $ 
WhiteSmoke��6   $	 0.5Q�6.   � 5      $ Transparent��6   $
 0.75Q�6/   � 5      $ 
WhiteSmoke��6   $	 0.9Q�6.   � 5      $ Transparent��6   $ 1Q�6/   5      �� 5   
   $	 0,0&�5      $	 1,1&�6   $
 0.75Q�6%   8��  5      �� 5   
   $	 0,0&�5      $	 1,1&�6   .��5      � $ DarkGray��6   $ 0Q�6,   � 5      $ #CCCCFF��6   $	 0.5Q�6+   � 5      $ DarkGray��6   $ 1Q�6,   5      �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��$ 80��6&   �� 5       � ��$ 10q�6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5       � #��z��6   #��z��5!      }�. .+�5$      �� $
 outerRectangle��6(   $��Stretch=�6@   $��Stretch=�5%      #��z��6#   $ 20��5&      $ 20��6   $��5��6!   
������ 65   �� 5)      $
 innerRectangle��6(   $��Stretch=�6@   $��Stretch=�5*   	   
������ $��20��5+   	   #��z��5,   	   $ 20��6-   $ 20��6:   �� 50      $
 	glassCube��6(   $��Stretch=�6;   $��Stretch=�51   	   $��2��52   	   $ 10��6   $ 10��6*   $ 0Q�67   8�� $ 0.5,0.5&�54   	   ��55   "   �� 56   &   $ 0.5,0&�6:   $ 0.5,1&�6M   ��58   .   � $	 0.0Q�6;   $ 	LightBlue��6H   � 59   .   $	 1.0Q�6;   $
 Gray��6H   5;   '   z�5B   "   V� 5C   &   .~�5D   *   �� �� 5E   *   5F   '    5K   "   �� 5L   &   5N      ]� 5Q      $!��myContentPresenterDockPanel��6(   .+�5R   "   �� $ myContentPresenter��63   $��20q�6O   #��z��5S      
���   �60   5T      5U       5W      P� 5Y       �@J�IsMouseOver . . �5^   "   �� $ outerRectangle��6F   # � ��5_       � ���� 5b   "   $ 	glassCube��6V    �@J�Opacity$ 1Q�6F   6V   �� 5e   "   $ myContentPresenter��6X    �@J�BitmapEffect 5f   &   �� 5g   *   $ 1Q�6;   5i   #   5j      P� 5l       �@J�	IsFocused . . �5m   "   �� $ 	glassCube��6V    �@J�Opacity$ 1Q�6F   6V   �� 5n   "   $ outerRectangle��6E   # � ��6g    � ���� 5o   "   $ 	glassCube��6P    �@J�Opacity$ 1Q�6F   6P   5p      :� 5r      $ Mouse.MouseEnter��6+   [�5s   "   �� 5t   &   $ mouseEnterBeginStoryboard��66   .��5u   *   �� .��5w   .   W� $ 	glassCube��6>   $V P(Rectangle.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�5x      $
 -0.1X�5z      $ 0:0:0.5D�6   W� 5|   .   $ 	glassCube��5}   	   $V P(Rectangle.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�5~      $
 -0.1X�5�      $ 0:0:0.5D�6   5�   +   5�   '   5�      :� 5�      $ Mouse.MouseLeave��6+   [�5�   "   �� 5�   &   $ mouseEnterBeginStoryboard��65   5�      :� 5�      $ Button.Click��6+   [�5�   "   �� 5�   &   .��5�   *   �� .��5�   .   W� $ 	glassCube��6>   $V P(Rectangle.RenderTransform).(TransformGroup.Children)[1].(RotateTransform.Angle)�5�      $	 360X�5�      $ 0:0:0.5D�6   5�   +   5�   '   5�      5�      5�      5�      5�      5�      