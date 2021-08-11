using OnStore_In_Wpf.Chains;
using OnStore_In_Wpf.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace OnStore_In_Wpf
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();
        public ObservableCollection<User> List { get; set; } = new ObservableCollection<User>();
        string stepofchain = "SingIn Chain";
        public bool singinclick = false;
        public SignUpWindow()
        {
            InitializeComponent();
            Helper.SignInWindow = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingUpControl signUp = new SingUpControl();
            MainGrid.Children.Add(signUp);
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            List = Helper.UserList;
            foreach (var item in List)
            {
                if (item.Email == nameTxtbx.Text && item.Password == surenameTxtbx.Text)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    singinclick = true;
                }
            }
            if (!List.Any())
            {
                IChain chain = new SignUpChain();
                IChain chain2 = new SignInChain();
                IChain chain3 = new OrderChain();

                chain.setNextChain(chain2);
                chain2.setNextChain(chain3);

                User User = new User { Email = nameTxtbx.Text, Password = surenameTxtbx.Text, StepOfChain = stepofchain };
                chain2.Handle(User);
                singinclick = false;
            }
            if (!List.Any(x => x.Email == nameTxtbx.Text) || !List.Any(x => x.Password == surenameTxtbx.Text))
            {
                IChain chain = new SignUpChain();
                IChain chain2 = new SignInChain();
                IChain chain3 = new OrderChain();

                chain.setNextChain(chain2);
                chain2.setNextChain(chain3);

                User User = new User { Email = nameTxtbx.Text, Password = surenameTxtbx.Text, StepOfChain = stepofchain };
                chain2.Handle(User);

                singinclick = false;
            }
        }
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
