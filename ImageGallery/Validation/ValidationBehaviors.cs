using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Behaviors
{
    public class ValidationBehaviors<Trequest, TResponse> : IPipelineBehavior<Trequest, TResponse> where Trequest : IRequest<TResponse>

    {
        private readonly IEnumerable<IValidator<Trequest>> validators;
        public ValidationBehaviors(IEnumerable<IValidator<Trequest>> _validators)
        {
            validators = _validators;
        }
        public Task<TResponse> Handle(Trequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = validators
             .Select(x => x.Validate(request))
             .SelectMany(x => x.Errors)
             .Where(x => x != null)
             .ToList();

            if (failures.Any())
                throw new ValidationException(failures);
            return next();
        }
    }
}