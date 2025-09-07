using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptionalToursAPI.Application.Interfaces
{
    public interface IAppCache : IEnumerable<KeyValuePair<object, object>>, IMemoryCache
    {
        void Clear();
    }
}
