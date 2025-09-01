using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act_Practica_01.Data.Utils
{
    public class Parameters
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Parameters() { }

        public Parameters(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
