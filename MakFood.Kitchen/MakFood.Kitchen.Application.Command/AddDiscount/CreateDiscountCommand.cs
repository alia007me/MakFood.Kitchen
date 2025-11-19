using MakFood.Kitchen.Application.Command.Base;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.AddDiscount
{
    public class CreateDiscountCommand : ComandBase, IRequest<CreateDiscountCommandResponse>
    {

        public string Title { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public uint Percent { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public decimal MaximumBalance { get; set; }
        public decimal MinimumBalance { get; set; }
        public DiscountPolicyType DiscountPolicy { get; set; }
        public override void Validate()
        {
            new CreateDiscountCommandValidator().Validate(this).ThrowIfNeeded();
        }
    }
}