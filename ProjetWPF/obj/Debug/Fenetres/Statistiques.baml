   M S B A M L   `   `   `  ����D  @ProjetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjetWPF.FenetresProjetWPF.Fenetres  5      %    ProjetWPF.Fenetres.Statistiques   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      ,local clr-namespace:ProjetWPF.Fenetres  5      -   5        .��5
      �    BackGroundGrid#��[  6     � ColumnDefinitions  5   
   �� 5      $
��154* �6   �� 5      -   5         ��Name$
 Row2��5   ,   $	��71* �6   6,   .+�5   
   (� $��1��6   .��5      ��   SimpleStack#��[ 6   $	��490��6>   $	��224��6K   $��1��6X   $��30q�6h    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6'      ShadowDepth$ 13Q�67      	Direction$ 0Q�6H      Opacity$
 0.35Q�6V   .+�5      �� $��Préférences��6   $��Center=�6.   $��Center=�6K     
LabelStyle#��[ 6f   $
��Bold"�6�   $��Arial)�6�   $��18(�6�   $��71��6�   $��18,0,18.333,0q�6�   6�   � 5      $��48��6   .+�5      �� $��Température��6   ��. $��Calibri)�6C   $��16(�6X   6h   )  #MahApps.Metro.Controls.ToggleSwitch  5      -   5          Name$ ToggTempurature��5   ,      OnLabel$  ��6X   	   OffLabel$	  ��6c   $��68,0,0.333,18.667q�6o   
   	IsChecked$

 TrueY�6�   5      � 5      $��48��6   .+�5      �� $��Pression��6   $��Calibri)�6/   $��16(�6D   6T     5      -   5        $ ToggPression��5   ,   $  ��6U   $	  ��6`   $��68,0,0.333,18.667q�6l   $

 TrueY�6�   5      � 5      .+�5      �� $��	Humidité��6   $��48��6/   $��Calibri)�6;   $��16(�6P   6`     5      -   5        $ ToggHumidite��5   ,   $  ��6U   $	  ��6`   $��68,0,0.333,18.667q�6l   $

 TrueY�6�   5       � 5!      $��48��6   .+�5"      �� $
��Vent��6   $��Calibri)�6+   $��16(�6@   6P     5#      -   5        $ ToggVent��5#   ,   $  ��6Q   $	  ��6\   $��68,0,0.333,18.667 q�6h   $

 TrueY�6�   5$      � 5%      $��48��6   .+�5&      �� $��Visibilité��6   $��Calibri)�61   $��16(�6F   6V     5'      -   5        $ ToggVisibilite��5'   ,   $  ��6W   $	  ��6b   $��68,0,0.333,18.667q�6n   $

 TrueY�6�   5(      � 5)      $��48��6   .+�5*      �� $��Précipitation��6   $��Calibri)�64   $��16(�6I   6Y     5+      -   5        $ ToggPrecipitation��5+   ,   $  ��6Z   $	  ��6e   $��68,0,0.333,18.667q�6q   $

 TrueY�6�   5,      � 5-      $��48��6   .+�5.      �� $��Nébulosité��6   $��Calibri)�61   $��16(�6F   6V     5/      -	   5        $ ToggNebulosite��5/   ,   $  ��6W   $	  ��6b   $��68,0,0.333,18.667q�6n   $

 TrueY�6�   50      52      54      � 55   
   .+�57      �   
SimpleGrid#��[ 6   $��30q�68    � RowDefinitions 58      �� 59      $	��33* �6$   �� 5:      $
��182* �6$   �� 5;      $	��15* �6$    5=        5>      $ 30Q�6'   $ 13Q�67   $ 0Q�6H   $
 0.35Q�6V   .+�5@      (� .��5A      �� $��0��6   $��Statistiques��6)   $��Center=�6@   $��Center=�6]   #��[ 6x   $
��Bold"�6�   $��36(�6�   $��175,4q�6�   5B      �� 5C      $��1��6   $
��Auto=�6,   .��5D      (� -
   5         (�Name$ ZoomView��5D      .��5E      )   #ProjetWPF.Fenetres.CarteInteractive  -   5          Name$ algerie��5E   2   $��Center=�6C   $��Center=�6`   $��-43,10,43,19q�6{   5F      5G      (� 5H      $��2��6   .��5I      � .+�5J      �� $��2��6    $
��Zoom��6-   6?   �� 5K      -   5        $��3��5K   !   $	��150��6.   6:   5L      5M      5N      5O      5P      5Q      