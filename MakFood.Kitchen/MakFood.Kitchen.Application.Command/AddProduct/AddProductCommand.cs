using MakFood.Kitchen.Application.Command.CommandBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommand : CommandBase , IRequest<AddProductCommandResponce>
    {
        public string Name { get;  set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ThumbnailPath { get;set; }
        public Guid SubCategoryId { get; set; }
        public string SubCategoryName { get;set; }
        public uint AvailableQuantity { get; set; }

        public override void Validate()
        {
             new AddProductCommandValidation().Validate(this);
        }
    }


}
