using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnStore_In_Wpf.Chains
{
    public interface IChain
    {
        IChain nextChain { get; set; }
        void setNextChain(IChain chain);
        void Handle(User user);

    }
}
