using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineShop.Helpers
{
    public class Pagination<T> where T : class
    {


        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            Pageindex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }
        public int Pageindex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
