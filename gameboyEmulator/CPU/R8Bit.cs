using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmulator.CPU
{
    public class R8Bit
    {
        public string Name { get; set; }
        public byte Value { get; set; }

        public R8Bit(string name)
        {
            Name = name;
            Value = 0;
        }

        public static R8Bit operator ++(R8Bit reg)
        {
            reg.Value++;
            return reg;
        }
    }
}
