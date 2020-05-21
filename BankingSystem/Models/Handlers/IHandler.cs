using System.Collections.Generic;

namespace Models.Handlers
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);
        public void Handle(string requestType, Dictionary<string, object> data);
    }
}