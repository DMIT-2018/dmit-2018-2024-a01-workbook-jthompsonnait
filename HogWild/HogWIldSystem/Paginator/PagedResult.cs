using System.Collections.Generic;
using System.ComponentModel;
// https://github.com/villainoustourist/Blazor.Pagination/tree/master


namespace HogWildSystem.Paginator
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public T[] Results { get; set; }
    }
}