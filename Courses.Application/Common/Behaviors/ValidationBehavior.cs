﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasogarewa.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest:IRequest<TResponse>
    {
        private readonly  IEnumerable<IValidator<TRequest>> Validators;
       public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)=>
            Validators = validators;
       

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = Validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(failure => failure != null).ToList();
            if (failures.Count != null)
            {
                throw new FluentValidation.ValidationException(failures);
            }
            return next();
        }
    }
}