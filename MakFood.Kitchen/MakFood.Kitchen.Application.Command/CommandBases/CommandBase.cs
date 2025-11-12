using MakFood.Kitchen.Application.Command.AddProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.CommandBases
{
    public abstract class CommandBase
    {
        public abstract void Validate();

      
    }
}

   
