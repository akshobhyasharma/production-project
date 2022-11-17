using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyzeApp.View
{
    /// <summary>
    /// Interaction logic for IndexView.xaml
    /// </summary>
    public partial class IndexView : UserControl
    {
        public IndexView()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            if (UserNameTextBox.Text == "Username")
            {
                UserNameTextBox.Text = "";
                UserNameTextBox.Opacity = 1;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "Password")
            {
                PasswordBox.Password = "";
                PasswordBox.Opacity = 1;
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "")
            {
                PasswordBox.Password = "Password";
                PasswordBox.Opacity = 0.5;
            }
        }

        private void UserNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameTextBox.Text == "")
            {
                UserNameTextBox.Text = "Username";
                UserNameTextBox.Opacity = 0.5;
            }
        }


        private void SignUpUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SignUpUserNameTextBox.Text == "Username")
            {
                SignUpUserNameTextBox.Text = "";
                SignUpUserNameTextBox.Opacity = 1;
            }
        }

        private void SignUpUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SignUpUserNameTextBox.Text == "")
            {
                SignUpUserNameTextBox.Text = "Username";
                SignUpUserNameTextBox.Opacity = 0.5;
            }
        }

        private void SignUpPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SignUpPasswordBox.Password == "Password")
            {
                SignUpPasswordBox.Password = "";
                SignUpPasswordBox.Opacity = 1;
            }
        }

        private void SignUpPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SignUpPasswordBox.Password == "")
            {
                SignUpPasswordBox.Password = "Password";
                SignUpPasswordBox.Opacity = 0.5;
            }
        }

        private void SignUpConfirmPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordBox.Password == "Password")
            {
                ConfirmPasswordBox.Password = "";
                ConfirmPasswordBox.Opacity = 1;
            }
        }

        private void SignUpConfirmPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ConfirmPasswordBox.Password == "")
            {
                ConfirmPasswordBox.Password = "Password";
                ConfirmPasswordBox.Opacity = 0.5;
            }
        }

        private void SignUpEmail_GotFoucs(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "Sample@mail.com")
            {
                EmailTextBox.Text= "";
                EmailTextBox.Opacity = 1;
            }
        }

        private void SignUpEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text== "")
            {
                EmailTextBox.Text= "Sample@mail.com";
                EmailTextBox.Opacity = 0.5;
            }
        }


    }
}
