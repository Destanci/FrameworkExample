using PostSharp.Aspects;
using System;
using System.Transactions;

// TODO Transaction not working
// Temporaryly removed from the projects
// Use in manager methods : [TransactionScopeAspect]

namespace FrameworkExample.Core.Aspects.PostSharp.TransactionScopeAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private readonly TransactionScopeOption _option;

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {

        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
            throw new TransactionException("Transaction Failed", innerException: args.Exception);
        }
    }
}
