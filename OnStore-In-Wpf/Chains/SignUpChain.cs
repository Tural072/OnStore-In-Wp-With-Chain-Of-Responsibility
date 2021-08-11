using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnStore_In_Wpf.Chains
{
    public class SignUpChain:IChain
    {
        public IChain nextChain { get; set; }

        public void Handle(User user)
        {
            if (user.StepOfChain == "SignUp Chain" && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Name))
            {
                nextChain.Handle(user);
            }
            if (user.StepOfChain == "SignUp Chain" && (user.Name==string.Empty||user.Password==string.Empty||user.Email==string.Empty))
            {
                MessageBox.Show("Can't Sign Up");
            }
        }

        public void setNextChain(IChain chain)
        {
            nextChain = chain;
        }
    }
}

