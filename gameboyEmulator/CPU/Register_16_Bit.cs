using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    class Register_16_Bit
    {
        private string v;

        public string Name { get; set; }
        public Register_8_Bit reg1 { get; set; }
        public Register_8_Bit reg2 { get; set; }

        public Register_16_Bit(Register_8_Bit r1, Register_8_Bit r2)
        {
            Name = r1.Name + r2.Name;
            reg1 = r1;
            reg2 = r2;
        }

        public Register_16_Bit(string v)
        {
            this.v = v;
        }
    }
}
