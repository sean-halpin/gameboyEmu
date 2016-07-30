using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    public class Register_16_Bit
    {
        public string Name { get; set; }
        public Register_8_Bit h { get; set; }
        public Register_8_Bit l { get; set; }

        public int Value
        {
            get
            {
                return (h.Value << 8) & l.Value;
            }
            set
            {
                h.Value = value & 0xF0;
                l.Value = value & 0x0F;
            }
        }

        public Register_16_Bit(Register_8_Bit r1, Register_8_Bit r2)
        {
            Name = r1.Name + r2.Name;
            h = r1;
            l = r2;
        }

        public Register_16_Bit(string name)
        {
            this.Name = name;
            h = new Register_8_Bit(name.ToCharArray()[0].ToString());
            l = new Register_8_Bit(name.ToCharArray()[1].ToString());
        }

        public static Register_16_Bit operator ++(Register_16_Bit reg)
        {
            reg.Value++;
            return reg;
        }
    }
}
