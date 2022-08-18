using FluentValidation;
using FrameworkExample.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
using System.Linq;

namespace FrameworkExample.Core.Aspects.PostSharp.ValidationAspects
{
    [Serializable]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, StandardRoles.Validation)]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(x => x.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
