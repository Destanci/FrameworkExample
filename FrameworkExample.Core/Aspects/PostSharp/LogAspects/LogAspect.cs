using FrameworkExample.Core.CrossCuttingConcerns.Logging;
using FrameworkExample.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using PostSharp.Extensibility;
using System;
using System.Linq;
using System.Reflection;

namespace FrameworkExample.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    [AspectRoleDependency(AspectDependencyAction.Order, AspectDependencyPosition.Before, "Logging")]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private readonly Type _loggerType;
        LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled) return;

            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i),
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType?.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters,
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }
        }

    }
}
