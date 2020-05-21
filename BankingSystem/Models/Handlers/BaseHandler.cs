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

        public virtual void Handle(string requestType, Dictionary<string, object> requestData)
        {
            if (_nextHandler != null)
            {
                _nextHandler?.Handle(requestType, requestData);
            }
            else
            {
                throw new NotSupportedException($"Operation '{requestType}' is not supported");
            }
        }
    }
}