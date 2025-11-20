using MakFood.Kitchen.Application.Command.AddProduct;
using MakFood.Kitchen.Application.Command.CommandBases;
using MakFood.Kitchen.Application.Command.CommandBases.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{
    public class UpdateProductCommand : CommandBase, IRequest<UpdateProductCommandResponse>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ThumbnailPath { get; set; }
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public uint QuantityToDecrease { get; set; }
        public uint QuantityToIncrease { get; set; }
        public override void Validate()
        {
            new UpdateProductCommandValidation().Validate(this).ThrowIfNeeded();
        }
    }


}
