﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Web.Config.PipeLines
{
    public class ValidatorBehavior<TRequest, Unit> : IPipelineBehavior<TRequest, Unit>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly IDomainNotification _domainNotification;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators,
            IDomainNotification domainNotification)
        {
            _validators = validators;
            _domainNotification = domainNotification;
        }

        public Task<Unit> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<Unit> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any() ? Notify(failures) : next();
        }

        private Task<Unit> Notify(IEnumerable<ValidationFailure> failures)
        {
            var result = default(Unit);

            foreach (var failure in failures)
            {
                _domainNotification.Handle(failure.ErrorCode, failure.ErrorMessage);
            }

            return Task.FromResult(result);
        }
    }
}

