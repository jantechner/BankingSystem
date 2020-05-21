using System.Collections.Generic;

namespace Models.Handlers
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);
        public bool Handle(RequestType type, Dictionary<string, object> data);
    }
}