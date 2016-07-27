using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    class Register_8_Bit_Flag : Register_8_Bit
    {
        public Register_8_Bit_Flag(string name) : base(name) { }

        public bool ZeroFlag { get { return (Value & 0x80) != 0; } set { setFlagBit(value, 0x80); } }
        public bool SubFlag { get { return (Value & 0x40) != 0; } set { setFlagBit(value, 0x40); } }
        public bool HalfCarryFlag { get { return (Value & 0x20) != 0; } set { setFlagBit(value, 0x20); } }
        public bool CarryFlag { get { return (Value & 0x10) != 0; } set { setFlagBit(value, 0x10); } }

        private void setFlagBit(bool bit, int mask)
        {
            if (bit)
                Value |= mask;
            else
                Value &= ~mask;
        }
    }
}
