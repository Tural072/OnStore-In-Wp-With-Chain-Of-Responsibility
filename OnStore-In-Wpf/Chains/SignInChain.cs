using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore_In_Wpf.Chains
{
    public class SignInChain:IChain
    {
        public IChain nextChain { get; set; }

        public void Handle(User user)
        {
            if (user.StepOfChain == "SignIn Chain" && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Name))
            {
                nextChain.Handle(user);
            }
        }

        public void setNextChain(IChain chain)
        {
            nextChain = chain;
        }
    }
}
