using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Visitors
{
    using CustomerService.Models;

    public interface IVisitor
    {
        void Visit(Customer customer);
    }
}
