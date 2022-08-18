using FrameworkExample.Core.Utilities.Enum;
using System;
using System.Reflection;

namespace FrameworkExample.Business.ReturnData
{
    public class StatusData<T>
    {
        private Enums.StatusEnum _status;
        public T Entity { get; set; }
        public Enums.StatusEnum Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public bool Any(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public string Message { get; set; }
        public Exception Exception { get; set; }
        public MethodBase MethodBase { get; set; }
    }
}
