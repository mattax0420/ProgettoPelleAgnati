   M S B A M L   `   `   `  ����K  GpellegrinoAgnati, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:pellegrinoAgnatipellegrinoAgnati  5   	   !    pellegrinoAgnati.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:pellegrinoAgnati     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5      � ��5   
   �� 5       �� ImageSource$ Assets/sfondo.png��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5    
   �� -   5         ��Name$ grigliaGioco��5       $��1��5!      $��1��5"      
���   �$	��250��5$      $	��500��6   $
}�True��5%      5&      �� 5)   
   -   5         ��Name$ Score��5)      $��0��5*      $��1��5+      $��Punti:��5,      
�������$��	0,10,0,10q�5.       �� TextAlignment$ Center=�5/      �� 53   
   $��1��6   $��2��54      $	��Top=�55      $
��Left=�56      .+�57      �� $
��Next��6   
�������$ Center=�59       �� 5:      -   5         ��Name$ prossima��5:      $	��125��5;      5<      � 5@   
   -   5         �Name$ gameOverMenu��5@      $y�Hidden=�5A      ���	#CC000000$��2��5C      $��3��5D      .+�5F      �� $��Center=�6   $��Center=�5G      $	��250��64   $	��332��6A   .+�5H      �� $��GameOver��6   
�������$��40(�5J      $ Center=�5K      �� 5L      $��FinalScore: ��6   
�������$��20(�5N      $
 Left=�5O      �� 5P      -   5        $��Gioca ancora��5P      
��� � �5R      5S      5T      5U      5[      