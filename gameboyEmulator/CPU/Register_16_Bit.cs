using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    class Register_16_Bit
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Register_16_Bit(Register_8_Bit r1, Register_8_Bit r2)
        {
            Name = r1.Name + r2.Name;
            Value = ((r1 << 8) & r2).Value;
        }
    }
}
