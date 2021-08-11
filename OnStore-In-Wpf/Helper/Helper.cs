using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore_In_Wpf.Extensions
{
    public class Helper
    {
        public static MainWindow MainWindow { get; set; }
        public static SignUpWindow SignInWindow { get; set; }

        public static ObservableCollection<User> UserList { get; set; } = new ObservableCollection<User>();
    }
}
