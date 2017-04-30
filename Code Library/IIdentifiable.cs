using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public interface IIdentifiable<I>
    {
        I Id { get; }
    }
}
