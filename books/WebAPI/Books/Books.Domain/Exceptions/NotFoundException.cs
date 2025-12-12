using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resourceType, string resourceIdentifier) : base($"{resourceType} with identifier '{resourceIdentifier}' was not found.")
        {
        }
    }
}
