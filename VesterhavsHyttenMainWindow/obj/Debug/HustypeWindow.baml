   M S B A M L   `   `   `  ����U  QVesterhavsHyttenMainWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:VesterhavsHyttenMainWindowVesterhavsHyttenMainWindow  5   	   .    (VesterhavsHyttenMainWindow.HustypeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:VesterhavsHyttenMainWindow     5   	     � Title$  HustypeWindow��5   	   $	��385��6   $	��420��6,   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
   <      
IsReadOnly .    SelectionMode$ Single=�6%   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|   $	��162��6�   $	��390��6�   $��14(�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5      $ Etager��6%    65   �� *Etager+  5      $ Areal��6%    64   �� *Areal+  5      $
 Navn��6%    63   �� *Navn+5      �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
10,232,0,0q�6B   $
��Wrap=�6V   $	��Id:��6j   $	��Top=�6u   $��14(�6�   �� 5   
   -   5         ��Name$ chkOpret��5      $��Opret hustype��6%   $
��Left=�6=   $��
10,180,0,0q�6X   $	��Top=�6l   6�   �� 5   
   -   5        $ chkSlet��5      $��Slet hustype��6$   $
��Left=�6;   $��129,180,0,0q�6V   $	��Top=�6k   6�   �� 5   
   -   5        	 ��Name$	 button��5      $��Submit��6!   $
��Left=�62   $��258,177,0,0q�6M   $	��Top=�6b   $	��127��6z   6�   �� 5   
   -   5        $ textBlock_Copy��5      $
��Left=�6,   $��
10,258,0,0q�6G   $
��Wrap=�6[   $��Etager:��6o   $	��Top=�6~   $��14(�6�   �� 5   
   -   5        $ textBlock_Copy1��5      $
��Left=�6-   $��
10,286,0,0q�6H   $
��Wrap=�6\   $
��Navn��6p   $	��Top=�6|   $��14(�6�   �� 5   
   -   5        
 ��Name$
 txtId��5   ;    �� 
IsReadOnly . 
�������$
��Left=�6J   $��23��6e   $��
98,229,0,0q�6q    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��287��6�   $��14(�6�   �� 5   
   -	   5        $
 	txtEtager��5      $
��Left=�6%   $��23��6@   $��
98,257,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��287��6�   $��14(�6�   �� 5   
   -
   5        $
 txtNavn��5      $
��Left=�6#   $��23��6>   $��
98,285,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��287��6�   $��14(�6�   �� 5   
   -   5        $
 txtAreal��5      $
��Left=�6$   $��23��6?   $��
98,313,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��287��6�   $��14(�6�   �� 5   
   -   5        $ textBlock_Copy2��5      $
��Left=�6-   $��
10,314,0,0q�6H   $
��Wrap=�6\   $��Areal��6p   $	��Top=�6}   $��14(�6�   5      5      