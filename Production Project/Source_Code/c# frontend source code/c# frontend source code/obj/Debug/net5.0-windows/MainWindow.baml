   M S B A M L   `   `   `  ????E  AAnalyzeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AnalyzeApp
AnalyzeApp  5   	   ;"clr-namespace:AnalyzeApp.ViewModelAnalyzeApp.ViewModel  5   	       AnalyzeApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AnalyzeApp     5   	   8	viewModel"clr-namespace:AnalyzeApp.ViewModel     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5        $	??600??5
   	   $	??920??6     ? WindowStyle$
  None=?5   	    ? 
ResizeMode$ NoResize=?5   	   
??????  ? AllowsTransparency$
 True??5   	   .??5      ?? ??5   
   ?? 5       ?? Opacity$
 0.97Q?6"    ?? 
StartPoint$	 0,0&?61    ?? EndPoint$	 1,1&?6B   .??5      ?  ? Color$ #272537??6    ? Offset$	 0.0Q?6/   ? 5      $ 	#FF5AC3DD??6   $ 1Q?61   5      ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??200 ?6#   ?? 5      	 ? RowDefinitions	 5      ?? 5      $??75 ?6    ?? 5      .+?5!      ?? $??	10,14,0,0q?6   $
??Fill=?6'   $ ??/Resource/Image/index3.jpg??66   $??2??6Z   $??2??6n   
 J? Opacity$	
 0.7Q?6    J? Effect 5"      -  'System.Windows.Media.Effects.BlurEffect  5#         Radius$ 30Q?6!   6/   5%      ?? 5&      $??	SplicerAI??6   $??Center=?6)   $??Center=?6D   
???????$??29(?6t   ?? 5(      $??1??6   $??2??6*   $??0??6>   ??6N   ?? *currentViewModel+A? 5+      -   5        $
??25px??5+       ? ToolTip$ Close??6#   $??0??63   $??681,10,14,40q?6@   $
??25px??6?   $??1??6?    ? Cursor$
 Hand??6?   ??5,      ?? 5-      $	 1,0&?6*   $
 0.98Q?6;   $	 0,1&?6J   .??5.      ? $ silver??6'   $	 0.0Q?66   ? 5/      $ black??6'   $ 1Q?65   50       52      3  -System.Windows.Media.Effects.DropShadowEffect  53         ShadowDepth$ 4Q?6'      Opacity$	 0.4Q?67      	Direction$	 270Q?6E      Color$
 Gray??6U      
BlurRadius$ 8Q?6b   55      .  (MahApps.Metro.IconPacks.PackIconMaterial  56      -   5        $??0??56   )   $??1??66      Kind$ Power=?6F   
???????$??15??6f   $
 Hand??6q   $??
686,14,0,0q?6?   58      59      5:      