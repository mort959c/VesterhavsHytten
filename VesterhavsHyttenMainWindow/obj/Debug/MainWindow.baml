   M S B A M L   `   `   `  ����U  QVesterhavsHyttenMainWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:VesterhavsHyttenMainWindowVesterhavsHyttenMainWindow  5   	   +    %VesterhavsHyttenMainWindow.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:VesterhavsHyttenMainWindow     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��524��6)   .��5	      �  � 	Resources 5
   
       BooleanToVisibilityConverter��%   &	        �� 5      6+   5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ cboAdmin��5      $��Admin��6%   $
��Left=�65   $��	10,28,0,0q�6P   $	��Top=�6c   $��16(�6{   6�   �� 5   
   -   5        $ cboMedarbejder��5      $��Medarbejder��6+   $
��Left=�6A   $��	21,28,0,0q�6\   $	��Top=�6o   $��1��6�   $��16(�6�   6�   �� 5   
   -   5        $ cboEksternInter��5      $��Ekstern
interessent��6,   $
��Left=�6S   $��	20,28,0,0q�6n   $	��Top=�6�   $��2��6�   $��16(�6�   6�   � 5   
   -   5         �Name$ 	gridAdmin��5      $
��Left=�6"   $	��234��6=   $��	10,75,0,0q�6J   $	��Top=�6]   $	��152��6u   y�6�   ��  �� ElementName$ cboAdmin�� �� Path$ 	IsChecked� �� 	Converter# [  .+�5      �� -   5         ��Name$ btnAdminHustype��5      $��Opret/Slet hustype��6.   $
��Left=�6K   $��	10,10,0,0q�6f   $	��Top=�6y   $	��132��6�   $��44��6�   $��14(�6�   6�   �� 5      -   5        $ btnAdminGrund��5      $��Opret/Slet grund��6,   $
��Left=�6G   $��	10,86,0,0q�6b   $	��Top=�6u   $	��132��6�   $��44��6�   $��14(�6�   6�   5      � 5   
   -   5        $ gridMedarbejder��5      $
��Left=�6(   $	��234��6C   $��	10,75,0,0q�6P   $	��Top=�6c   $	��152��6{   $��1��6�   y�6�   �� $ cboMedarbejder��$ 	IsChecked�# [  .+�5      �� -   5        $ btnMedarbejderSaelgHus��5      $��	Sælg hus��65   $
��Left=�6H   $��	10,86,0,0q�6c   $	��Top=�6v   $	��132��6�   $��44��6�   $��14(�6�   6�   �� 5      -	   5        $ btnMedarbejderGrund��5      $��Opret/Slet grund��62   $
��Left=�6M   $��	10,10,0,0q�6h   $	��Top=�6{   $	��132��6�   $��44��6�   $��14(�6�   6�   �� 5      -
   5        $" btnMedarbejderForspoergelser��5      $��Forespørgelser��6;   $
��Left=�6T   $��
10,162,0,0q�6o   $	��Top=�6�   $	��132��6�   $��44��6�   $��14(�6�   6�   5      � 5   
   -   5        $ gridEksternInter��5      $
��Left=�6)   $	��234��6D   $��	10,75,0,0q�6Q   $	��Top=�6d   $	��152��6|   $��2��6�   y�6�   �� $ cboEksternInter��$ 	IsChecked�# [  .+�5      �� -   5        $ btnEksterninter��5      $��Forespørgelser��6.   $
��Left=�6G   $��	10,10,0,0q�6b   $	��Top=�6u   $	��132��6�   $��44��6�   $��14(�6�   6�   5       5"      5#      