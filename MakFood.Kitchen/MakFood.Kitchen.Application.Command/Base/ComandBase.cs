using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.Base
{
    public abstract class ComandBase
    {
        public abstract void Validate();
    }
}