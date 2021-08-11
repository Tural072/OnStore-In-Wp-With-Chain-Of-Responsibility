﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnStore_In_Wpf.Chains
{
    public class OrderChain : IChain
    {
        public IChain nextChain { get; set ; }

        public void Handle(User user)
        {
            if (user.StepOfChain=="Order Chain" && !string.IsNullOrEmpty(user.Email)&&!string.IsNullOrEmpty(user.Password)&&!string.IsNullOrEmpty(user.Name))
            {
                nextChain.Handle(user);
            }
            else
            {
                MessageBox.Show("Can't order");
            }
        }

        public void setNextChain(IChain chain)
        {
            nextChain = chain;
        }
    }
}
