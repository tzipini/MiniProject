   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UIUI  5   	       UI.Employee   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:UI     5   	     � Title$  Employee Details��5   	    � Icon$&  /UI;component/IMages/rleter4.jpg��6"   .��5	      � .+�5
   
   � $��
0,-10,0,10q�6    � RowDefinitions 5      �� 5      $��2* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��3* �6    �� 5      $��4* �6    .+�5      �� -   5         ��Name$ lblId��5      $	��ID:��6#   $��1��61   $
��Left=�6>   �� 5      -   5         ��Name$ txtId��5      $��1��6%   $��114,2,496,3q�62   $	��150��6G   $
��Left=�6S   �� 5      -   5        $ lblFname��5      $��First Name:��6&   $��2��6<   $
��Left=�6I   �� 5      -   5        $ txtFname��5      $��2��6)   $��114,5,496,3q�66   $	��150��6K   $
��Left=�6W   �� 5       -   5        $ lblLname��5       $��
Last Name:��6&   $��3��6;   $
��Left=�6H   �� 5!      -   5        $ txtLname��5!      $��3��6)   $��114,2,496,3q�66   $	��150��6K   $
��Left=�6W   �� 5"      -   5        $ lblBirthDate��5"      $��Birth Date:��6*   $��4��6@   $
��Left=�6M   �� 5#      -   5        $ lblPhone��5#      $��Phone:��6&   $��5��67   $
��Left=�6D   �� 5$      -	   5        $ 
lblAddress��5$      $��Address:��6(   $��6��6;   $
��Left=�6H   �� 5%      -
   5        $ lblArea��5%      $��Area:��6%   $��7��65   $
��Left=�6B   �� 5&      -   5        $ 	lblDegree��5&      $��Degree:��6'   $��8��69   $
��Left=�6F   �� 5'      -   5        $ lblIsMiletryGarduate��5'      $��Is military graduate?��62   $��9��6R   $
��Left=�6_   �� 5(      -   5        $ lblReccomentation��5(      $��recommendation:��6/   $��14��6I   $
��Left=�6W   �� 5)      -   5        $ lblExperianceYears��5)      $��Experiance Years:��60   $��10��6L   $
��Left=�6Z   �� 5*      -   5        $ 
lblBAnkKey��5*      $��	Bank key:��6(   $��13��6<   $
��Left=�6J   �� 5+      -   5        $ lblBranchNumber��5+      $��Branch number:��6-   $��13��6F   $
��Left=�6T   $
��0,24q�6o   �� 5,      -   5        $ lblSpecialityKey��5,      $��Speciality key:��6.   $��11��6H   $
��Left=�6V   �� 5-      -   5        $ lblAccountNumber��5-      $��Account number:��6.   $��12��6H   $
��Left=�6V   (  "System.Windows.Controls.DatePicker  5.      $��4��6   $��114,2,496,3q�6&   $	��150��6;   $
��Left=�6G   �� 5/      -   5        $ txtPhone��5/      $��5��6(   $��114,2,496,3q�65   $	��150��6J   $
��Left=�6V   �� 50      -   5        $ lblBranchNumberTown��50      $��Town:��61   $��13��6A   $
��Left=�6O   $��0,48,0,0q�6j   �� 51      -   5        $ txtAccountNumber��51      $��12��61   $��114,2,496,3q�6?   $	��150��6T   $
��Left=�6`   �� 52      -   5        $ 
txtAddress��52      $��6��6+   $��114,2,496,3q�68   $	��150��6M   $
��Left=�6Y   �� 53      -   5         ��Name$ cmbArea��53      $
��Left=�6J   $��	114,1,0,0q�6e   $��7��6x   $	��Top=�6�   $	��150��6�   $��21��6�    �� SelectedItem 6(   �� *
AreaName+6�   �� 54      -   5        $ 	cmbDegree��54      $
��Left=�6K   $��	114,1,0,0q�6f   $��8��6y   $	��Top=�6�   $	��150��6�   $��22��6�    6*   �� *	DegreeI+6�   �� 55      -   5         ��Name$ image��55      $
��Left=�6#   $	��292��6>   $��
284,20,0,0q�6K   $��12��6_   $	��Top=�6q   $	��445��6�   $��IMages/employees.jpg��6�   �� 56      -   5         ��Name$ CbxIsMilatryGarduate��56      $
��Left=�66   $��18��6Q   $��	117,6,0,0q�6]   $��9��6p   $	��Top=�6}   �� 57      -   5        $ txtNum��57      $��10��6'   $��	134,5,0,5q�6O   $��31��6b   $��0��6m   $
��Left=�6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   �� 58      -   5        
 ��Name$
 cmdUp��58      $��10��6$   $��	165,5,0,5q�6L   $��˄��6_   $��20��6k   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 59      -   5        $
 cmdDown��59      $��10��6&   $��	114,5,0,5q�6N   $��˅��6b   $��20��6n   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 5:      -   5        $ cmbSpecialityKey��5:      $
��Left=�6X   $��	114,1,0,0q�6s   $��11��6�   $	��Top=�6�   $	��150��6�   $��22��6�    61   �� *spacialityKey+6�   �� 5;      -   5        $
 
cmdUp_Copy��5;      $��13��6)   $��164,27,0,31q�6Q   $��˄��6f   $��20��6r   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 5<      -    5        $
 cmdDown_Copy��5<      $��13��6+   $��113,27,0,31q�6S   $��˅��6i   $��20��6u   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 5=      -!   5        $ txtNum_Copy��5=      $��13��6,   $��
134,5,0,53q�6T   $��31��6h   $��0��6s   $
��Left=�6�   �� 5>      -"   5        $
 cmdUp_Copy1��5>      $��13��6*   $��
165,5,0,53q�6R   $��˄��6f   $��20��6r   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 5?      -#   5        $
 cmdDown_Copy1��5?      $��13��6,   $��
114,5,0,53q�6T   $��˅��6i   $��20��6u   $	 -0.067,0.619&�6�   $
��Left=�6�   �� 5@      -$   5        $ txtNum_Copy1��5@      $��13��6-   $��133,27,0,31q�6U   $��31��6j   $��0��6u   $
��Left=�6�   $	 0.5,0.5&�6�   �� 5A      -%   5        $ txtAccountNumber_Copy��5A      $��13��66   $��
114,50,0,3q�6D   $	��150��6X   $
��Left=�6d   {�.  6   5C      5D      5E      