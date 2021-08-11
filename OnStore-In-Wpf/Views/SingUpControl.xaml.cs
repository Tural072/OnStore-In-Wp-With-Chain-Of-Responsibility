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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnStore_In_Wpf
{
    /// <summary>
    /// Interaction logic for SingUpControl.xaml
    /// </summary>
    public partial class SingUpControl : UserControl
    {
        public MainWindow MainWindow { get; set; }

        public ObservableCollection<User> User_List { get; set; }
        public ObservableCollection<User> UserList { get { return UserList; } set { UserList = value; } }
       
        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();
        public User User { get; set; }
        
        string stepofchain;

        public bool singupclick = false;
        public SingUpControl()
        {
            InitializeComponent();
            stepofchain = "SingUp Chain";
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Helper.UserList = new ObservableCollection<User>();

            User user1 = new User
            {
                Name = nameTxtbx.Text,
                Email = emailTxtbx.Text,
                Password = passwordTxtbx.Text,
                StepOfChain = stepofchain,
                Surename = surenameTxtbx.Text
            };

            new_User_List.Add(user1);

            Helper.UserList.Add(user1);

            singupclick = true;

            IChain chain = new SignUpChain();
            IChain chain2 = new SignInChain();
            IChain chain3 = new OrderChain();

            chain.setNextChain(chain2);
            chain2.setNextChain(chain3);

            User User1 = new User { Name = nameTxtbx.Text, Surename = surenameTxtbx.Text, Password = passwordTxtbx.Text, Email = emailTxtbx.Text, StepOfChain = stepofchain };
            chain.Handle(User1);
            Helper.SignInWindow.MainGrid.Children.RemoveAt(1);
        }

        private void nameTxtbx_MouseEnter(object sender, MouseEventArgs e)
        {
            nameTxtbx.Text = string.Empty;
        }

        private void surenameTxtbx_MouseEnter(object sender, MouseEventArgs e)
        {
            surenameTxtbx.Text = string.Empty;
        }

        private void passwordTxtbx_MouseEnter(object sender, MouseEventArgs e)
        {
            passwordTxtbx.Text = string.Empty;
        }

        private void emailTxtbx_MouseEnter(object sender, MouseEventArgs e)
        {
            emailTxtbx.Text = string.Empty;
        }
    }
}
