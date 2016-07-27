using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    class CPU
    {
        //accumulator
        Register_8_Bit a;
        //flag
        Register_8_Bit f;
        //general
        Register_8_Bit b; Register_8_Bit c;
        Register_16_Bit bc;
        Register_8_Bit d; Register_8_Bit e;
        Register_16_Bit de;
        Register_8_Bit h; Register_8_Bit l;
        Register_16_Bit hl;
        //program counter
        Register_8_Bit pc;
        //stack pointer
        Register_8_Bit sp;

        public CPU()
        {
            a = new Register_8_Bit("a");
            f = new Register_8_Bit("f");
            b = new Register_8_Bit("b");
            c = new Register_8_Bit("c");
            Register_16_Bit bc = new Register_16_Bit(b, c);
            d = new Register_8_Bit("d");
            e = new Register_8_Bit("e");
            Register_16_Bit de = new Register_16_Bit(d, e);
            h = new Register_8_Bit("h");
            l = new Register_8_Bit("l");
            Register_16_Bit hl = new Register_16_Bit(h, l);
            pc = new Register_8_Bit("pc");
            sp = new Register_8_Bit("sp");
        }
    }
}
