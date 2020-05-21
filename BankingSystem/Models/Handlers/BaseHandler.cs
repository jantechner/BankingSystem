using System;
using System.Collections.Generic;

namespace Models.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
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