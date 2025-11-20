using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public UpdateProductCommandResponse(bool done)
        {
            Done = done;
        }

        public bool Done { get; set; }
    }
}
