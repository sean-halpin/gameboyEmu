using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    public class R16Bit
    {
        public string Name { get; set; }
        public R8Bit h { get; set; }
        public R8Bit l { get; set; }

        public int Value
        {
            get
            {
                return (h.Value << 8) & l.Value;
            }
            set
            {
                h.Value = (byte)((value & 0xF0) >> 8);
                l.Value = (byte)(value & 0x0F);
            }
        }

        public R16Bit(R8Bit r1, R8Bit r2)
        {
            Name = r1.Name + r2.Name;
            h = r1;
            l = r2;
        }

        public R16Bit(string name)
        {
            this.Name = name;
            h = new R8Bit(name.ToCharArray()[0].ToString());
            l = new R8Bit(name.ToCharArray()[1].ToString());
        }

        public static R16Bit operator ++(R16Bit reg)
        {
            reg.Value++;
            return reg;
        }
    }
}
