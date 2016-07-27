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

        public static Register_8_Bit operator <<(Register_8_Bit r1, int operand)
        {
            r1.Value = r1.Value << operand;
            return r1;
        }

        public static Register_8_Bit operator >>(Register_8_Bit r1, int operand)
        {
            r1.Value = r1.Value >> operand;
            return r1;
        }

        public static Register_8_Bit operator &(Register_8_Bit r1, Register_8_Bit r2)
        {
            r1.Value = r1.Value & r2.Value;
            return r1;
        }
    }
}
