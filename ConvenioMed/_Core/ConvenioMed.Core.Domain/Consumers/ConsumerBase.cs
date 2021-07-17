
using MediatR;

namespace ConvenioMed.Core.Domain.Consumers
{
    public abstract class ConsumerBase
    {
        protected readonly IMediator _mediator;

        protected ConsumerBase(IMediator mediator)
        {
            this._mediator = mediator; 
        } 
    } 
} 
