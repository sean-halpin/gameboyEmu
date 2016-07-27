using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    public class Register_8_Bit
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Register_8_Bit(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}
