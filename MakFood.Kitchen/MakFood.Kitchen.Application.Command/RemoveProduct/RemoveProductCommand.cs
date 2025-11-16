using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Application.Command.CommandBases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.RemoveProduct
{
    public class RemoveProductCommand : CommandBase , IRequest<bool>
    {

        public Guid ProductId { get; set; }

        public override void Validate()
        {
            new RemoveProductCommandValidation().Validate(this);
        }
    }
}
