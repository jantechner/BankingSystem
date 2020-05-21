using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;
        protected List<string> _requiredParams;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        protected void ValidateRequest(Dictionary<string, object> data)
        {
            if (data.Keys.Any(key => !_requiredParams.Contains(key))) throw new ArgumentException();
        }

        public virtual bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (_nextHandler == null)
            {
                throw new NotSupportedException($"Operation '{type.ToString()}' is not supported");
            }
            return _nextHandler.Handle(type, data);
        }
    }
}