using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.RemoveProduct
{
    public class RemoveProductCommandResponse
    {
        public RemoveProductCommandResponse(bool done)
        {
            Done = done;
        }

        public bool Done { get; set; }
    }
}
