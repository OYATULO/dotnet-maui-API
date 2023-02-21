using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workWithApi
{
    public  interface IPosts
    {
       Task<List<Posts>> GetPostsAsync();
    }
}
