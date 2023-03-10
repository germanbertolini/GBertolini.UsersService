using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBertolini.UsersService.Models.Attributes
{
    public class FactoryAttribute : Attribute
    {
        public Type CreateInstanceOf { get; }

        public FactoryAttribute(Type CreateInstanceOf)
        {
            this.CreateInstanceOf = CreateInstanceOf;
        }
    }
}
