   M S B A M L   `   `   `  ����U  QVesterhavsHyttenMainWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:VesterhavsHyttenMainWindowVesterhavsHyttenMainWindow  5   	   5    /VesterhavsHyttenMainWindow.ForspoergelserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:VesterhavsHyttenMainWindow     5   	     � Title$  ForspoergelserWindow��5   	   $	��801��6&   $	��490��63   .��5	      � .+�5
   
   �� -   5         ��Name$ 	textBlock��5
      $
��Left=�6'   $��	10,10,0,0q�6B   $
��Wrap=�6U   $:��47A. Er der filialer der kun udbyder huse i en etage?��6i   $	��Top=�6�   �� 5   
   -   5         ��Name$ lbl7A��5      $��Label��6   $
��Left=�6/   $��	282,5,0,0q�6J   $	��Top=�6]   $��84��6u   ���	#FFB9B8B86�   �� 5   
   -   5        $ textBlock_Copy��5      $
��Left=�6,   $��	10,55,0,0q�6G   $
��Wrap=�6Z   $��7B. Udbyder i��6n   $	��Top=�6�   �� 5   
   -   5         ��Name$ cbo7B��5   E    �� 
IsEditable .  �� 
IsReadOnly .  �� Text$ Filial��67   $
��Left=�6T   $��	86,55,0,0q�6o   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textBlock_Copy1��5      $
��Left=�6-   $��
211,55,0,0q�6H   $
��Wrap=�6\   $4��.Der sælger en-etagers-huse på mindst 180 kvm��6p   $	��Top=�6�   $��95��6�   �� 5   
   -   5         ��Name$ lbo7B��5      $
��Left=�6!   $��48��6<   $��
311,55,0,0q�6H   $	��Top=�6\   $	��161��6t   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��
10,119,0,0q�6C   $
��Wrap=�6W   $
��7C. ��6k   $	��Top=�6w   �� 5   
   -   5        $ cbo7C��5   F   $ Filial��6    .  . $
��Left=�6U   $��
35,119,0,0q�6p   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -	   5        $ textBlock1_Copy��5      $
��Left=�6-   $��160,119,0,0q�6H   $
��Wrap=�6]   $��Disse huse til salg��6q   $	��Top=�6�   �� 5   
   -
   5        $ lbo7C��5      $
��Left=�6!   $��44��6<   $��259,119,0,0q�6H   $	��Top=�6]   $	��213��6u   �� 5   
   -   5        $ textBlock1_Copy1��5      $
��Left=�6.   $��
10,182,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��286��6�   �� 6�   $�7��6�   �� 6�   $;�5D. Hvilke modeller udbydes pt ikke af nogen filialer?��6�   �� 6�   $� ��6�   6�   �� 5   
   -   5        $ lbo7D��5      $
��Left=�6!   $��33��6<   $��301,182,0,0q�6H   $	��Top=�6]   $	��171��6u   �� 5   
   -   5        $ textBlock1_Copy2��5      $
��Left=�6.   $��
10,232,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��286��6�   �� 6�   $�7��6�   �� 6�   $�E��6�   �� 6�   $ �. Hvilke modeller udbydes ��6�   �� 6�   $�kun i en enkelt��6�   �� 6�   $� filial?��6�   �� 6  $� ��6  6  �� 5   
   -   5        $ lbo7E��5      $
��Left=�6!   $��33��6<   $��282,232,0,0q�6H   $	��Top=�6]   $	��190��6u   �� 5   
   -   5        $ textBlock1_Copy3��5      $
��Left=�6.   $��
10,284,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��134��6�   �� 6�   $�7��6�   �� 6�   $�F��6�   �� 6�   $�.��6�   �� 6�   $� Hvilke modeller i filial��6�   �� 6�   $� ��6�   6�   �� 5   
   -   5        $ cbo7F��5   E   $ Filial��6    .  . $
��Left=�6T   $��149,284,0,0q�6o   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5        $ textBlock1_Copy4��5      $
��Left=�6.   $��274,284,0,0q�6I   $
��Wrap=�6^   $	��Top=�6r   $��71��6�   �� 6�   $�har det ��6�   �� 6�   �� 6�   $�største areal��6�   �� 6�   $�?��6�   6�   �� 5   
   -   5        $ lbo7F��5      $
��Left=�6!   $��64��6<   $��345,284,0,0q�6H   $	��Top=�6]   $	��127��6u   �� 5   
   -   5        $ textBlock1_Copy5��5      $
��Left=�6.   $��
10,365,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��224��6�   �� 6�   $�7��6�   �� 6�   $�G��6�   �� 6�   $�.��6�   �� 6�   $� ��6�   �� 6�   $,�&Hvilke filialer udbyder alle modeller?��6�   6  �� 5   
   -   5        $ lbo7G��5      $
��Left=�6!   $��41��6<   $��239,365,0,0q�6H   $	��Top=�6]   $	��233��6u   �� 5   
   -   5        $ textBlock1_Copy6��5      $
��Left=�6.   $��
10,431,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��462��6�   �� 6�   $�7��6�   �� 6�   $�H��6�   �� 6�   $�.��6�   �� 6�   $u�o For hver filial ønskes vist antallet af udbudte modeller, deres gennemsnitspris-, minimums- og maksimumspris.��6�   6@  �� 5   
   -   5        $ lbo7H��5      $
��Left=�6!   $	��100��6<   $��
10,493,0,0q�6I   $	��Top=�6]   $	��462��6u   �� 5    
   -   5        $ textBlock1_Copy7��5       $
��Left=�6.   $��
10,472,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��462��6�   $$��Navn - maks - min - gennemsnit��6�   �� 5!   
   -   5        $ textBlock1_Copy8��5!      $
��Left=�6.   $��
10,611,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��462��6�   $����7I. For hver filial ønskes en total for tillæg for de grunde filialen har til salg. Resultatet vises i stigende orden for tillægstotalen.��6�   �� 5"   
   -   5        $ lbo7I��5"      $
��Left=�6!   $	��100��6<   $��
10,648,0,0q�6I   $	��Top=�6]   $	��462��6u   5$      5%      