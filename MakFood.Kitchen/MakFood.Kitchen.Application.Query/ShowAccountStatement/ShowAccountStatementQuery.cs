using MakFood.Kitchen.Application.Query.ShowAccountStatement;
using MediatR;


namespace MakFood.Kitchen.Application.Query.ShowAccount
{
    public class ShowAccountStatementQuery : QueryBase, IRequest<ShowAccountStatementQueryResponce>
    {
        public Guid CustomerId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public override void validate()
        {
            new ShowAccountStatementQueryValidation().Validate(this);
        }
    }
}
