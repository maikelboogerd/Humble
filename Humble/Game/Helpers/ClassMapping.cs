using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class ClassMapping
    {
        private Dictionary<object, Type> dictionary = new Dictionary<object, Type>();

        public void Add(object item, Type type)
        {
            dictionary.Add(item, type);
        }

        public Type Get(object item)
        {
            return dictionary[item];
        }
    }
}
