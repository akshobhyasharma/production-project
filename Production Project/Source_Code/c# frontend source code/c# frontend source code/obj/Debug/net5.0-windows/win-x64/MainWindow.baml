   M S B A M L   `   `   `  ????E  AAnalyzeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AnalyzeApp
AnalyzeApp  5   	   ;"clr-namespace:AnalyzeApp.ViewModelAnalyzeApp.ViewModel  5   	       AnalyzeApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AnalyzeApp     5   	   8	viewModel"clr-namespace:AnalyzeApp.ViewModel     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 6X   -   5        $	??600??5   	   $	??920??6     ? WindowStyle$
  None=?5   	    ? 
ResizeMode$ NoResize=?5   	   
??????  ? AllowsTransparency$
 True??5   	   .??5      ?? ??5   
   ?? 5       ?? Opacity$
 0.97Q?6"    ?? 
StartPoint$	 0,0&?61    ?? EndPoint$	 1,1&?6B   .??5      ?  ? Color$ #272537??6    ? Offset$	 0.0Q?6/   ? 5      $ 	#FF5AC3DD??6   $ 1Q?61   5      ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6#   ?? 5      	 ? RowDefinitions	 5      ?? 5       $??75 ?6    ?? 5!      .+?5#      ?? $??	10,14,0,0q?6   $
??Fill=?6'   $ ??/Resource/Image/index3.jpg??66   $??2??6Z   $??2??6n   
 J? Opacity$	
 0.7Q?6    J? Effect 5$      -  'System.Windows.Media.Effects.BlurEffect  5%         Radius$ 30Q?6!   6/   5'      ?? 5(      $??	SplicerAI??6   $??Center=?6)   $??Center=?6D   
???????$??29(?6t   ?? 5*      $??1??6   $??2??6*   $??0??6>   ??6N   ?? *currentViewModel+?? 5+      $??2??6   $	??120??6)   $??Center=?65   $??Right=?6P   $??0 0 80 0q?6l   y?6~   ?? *
IsLogged+    BooleanToVisibilityConverter ?? 	Converter# [  .+?5,      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 2Q?6&   ???#073687$y?Visible=?6S   $	??120??6h   .??5-      o? )  #MaterialDesignThemes.Wpf.MenuAssist   TopLevelMenuItemHeight$ 28Q?5.      
???????
?????? ???#073687$	??120??6}   5/      50      A? 51      -   5        $
??25px??51       ? ToolTip$ Close??6#   $??0??63   $??681,10,14,40q?6@   $
??25px??6?   $??1??6?    ? Cursor$
 Hand??6?   ??52      ?? 53      $	 1,0&?6*   $
 0.98Q?6;   $	 0,1&?6J   .??54      ? $ silver??6'   $	 0.0Q?66   ? 55      $ black??6'   $ 1Q?65   56       58      3  -System.Windows.Media.Effects.DropShadowEffect  59         ShadowDepth$ 4Q?6'      Opacity$	 0.4Q?67      	Direction$	 270Q?6E      Color$
 Gray??6U      
BlurRadius$ 8Q?6b   5;      .  (MahApps.Metro.IconPacks.PackIconMaterial  5<      -   5        $??0??5<   )   $??1??66      Kind$ Power=?6F   
???????$??15??6f   $
 Hand??6q   $??
686,14,0,0q?6?   A? 5=      -   5        $
??25px??5=      $ Minimize??6#   $??0??66   $??644,10,51,40q?6C   $
??25px??6?   $??1??6?   $
 Hand??6?   ??5>      ?? 5?      $	 1,0&?6*   $
 0.98Q?6;   $	 0,1&?6J   .??5@      ? $ silver??6'   $	 0.0Q?66   ? 5A      $ black??6'   $ 1Q?65   5B       5D        5E      $ 4Q?6'   $	 0.4Q?67   $	 270Q?6E   $
 Gray??6U   $ 8Q?6b   5G        5H      -   5        $??0??5H   )   $??1??66   $ WindowMinimize=?6F   
???????$??15??6o   $
 Hand??6z   $??
649,14,0,0q?6?   5J      5K      5L      