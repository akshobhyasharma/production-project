   M S B A M L   `   `   `  ???? E  AAnalyzeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AnalyzeApp.ViewAnalyzeApp.View  =#clr-namespace:AnalyzeApp.ComponentsAnalyzeApp.Components      AnalyzeApp.View.IndexView   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:AnalyzeApp.View     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   6
components#clr-namespace:AnalyzeApp.Components   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .???   ? ColumnDefinitions  ?? $	??350 ??? $	??350 ? ? RowDefinitions ?? $	??525 ?.+?? $??0??$??
50 20 0 20q? ?? $
??auto ??? $
??auto ??? .+???  ?? CornerRadius$ 10??$??3??????  ?? Opacity$
 0.70Q?.???  ? Color$ #5bc3ff?? ? Offset$	 0.0Q?? $ #3aa0ff??$ 1Q?? $??0??  ?? $??* ??? $
??auto ??? $
??auto ??? $??1??$??Center=?$??	0 30 0 40q?.+??? $ ??/Resource/Image/log_in.png??$??60??$??60???? $??Login??$??24(?$??Center=?
???????$??0 10 0 0q?? $??2??  ?? $??1* ??? $
??auto ??? $??1* ? ?? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ?.+??? $??1??$??0?? ?? Orientation$ 
Horizontal=?$	??250??.+??? -    ??Name$ UserNameTextBox?? !  MaterialDesignOutlinedTextBox#??[  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username??
???????
???????$	??250?????? *
UserName+	 ?? UpdateSourceTrigger$	 PropertyChanged=?{??? 
 ?? Path$
 	IsChecked? ?? ElementName$6 0MaterialDesignOutlinedPasswordBoxEnabledComboBox???? $??2??$??1??$ 
Horizontal=?$	??250??$??0 20 0 0q?.+?/   )AnalyzeApp.Components.BindablePasswordBox  -     Name$ PasswordBox??   Password ?? *PasswordValue+$	 PropertyChanged=? ?? Mode$ TwoWay=?? $??4??$??1??.+??? $??0 25 0 0q?$??Center=?$??14(? J? Opacity$ 1Q?
???????$??DemiBold"??? ??? *ValidationMessage+? $??5??$??1??$??0 20 0 0q?.+??? $??Center=?$??Login?????? *LoginCommand+? $??1??$??
50 20 0 20q? ?? $
??auto ??? $??2* ??? $??3* ??? $??1* ?  ?? ?? $	??250 ??? .+??? $ 10??$??4??$??3?????? $
 0.70Q? ?? 
StartPoint$	 1,0&? ?? EndPoint$	 0,1&?.??? $ #4eff91??$	 0.0Q?? $ #3aa0ff??$ 1Q??? $??1??$??1??$ Vertical=?$??Center=?.+??? $!??/Resource/Image/sign_up.png??$??64???? $??Sign Up??$??24(?$??Center=?
???????$??0 10 0 0q?? $??2??$??1?? ?? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ??? $
??auto ?.+??? $??0??$ 
Horizontal=?$	??250??.+??? -   $ SignUpUserNameTextBox??$ Username??
???????
???????$	??250?????? *SignUpUserName+$	 PropertyChanged=?{??? $
 	IsChecked?$6 0MaterialDesignOutlinedPasswordBoxEnabledComboBox???? $??2??$ 
Horizontal=?$	??250??$??0 20 0 0q?.+?7   1AnalyzeApp.Components.BindablePasswordBoxUserInfo  -     Name$ SignUpPasswordBox??$ Password??
???????
???????$	??250??   Password ?? *SignUpPassword1+$	 PropertyChanged=?$ TwoWay=??? $??4??$ 
Horizontal=?$	??250??$??0 20 0 0q?.+?  -   $ ConfirmPasswordBox??$ Password??
???????
???????$	??250?? ?? *SignUpPassword2+$	 PropertyChanged=?$ TwoWay=??? $??6??$ 
Horizontal=?$	??250??$??0 20 0 0q?.+??? -   $ EmailTextBox??$ Email??
???????
???????$	??250?????? *Email+$	 PropertyChanged=?{??? $
 	IsChecked?$6 0MaterialDesignOutlinedPasswordBoxEnabledComboBox??? $??8??.+??? $??0 25 0 0q?$??Center=?$??14(?$ 1Q?
???????$??DemiBold"??? ??? *SignUpValidationMessage+? $??4??$??1??.+??? $??Center=?$	??Top=?$??SignUp?????? *SignUpCommand+