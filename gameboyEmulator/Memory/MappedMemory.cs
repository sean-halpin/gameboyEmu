using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameboyEmulator.CPU;

namespace gameboyEmulator.Memory
{
    public class MappedMemory
    {
        public int ReadByte(Register_16_Bit PC)
        {
            throw new NotImplementedException(typeof(MappedMemory).Name);
        }

        public int ReadHalfWord(Register_16_Bit PC)
        {
            var result = 0;
            result = result & ReadByte(PC++) << 8;
            result = result & ReadByte(PC++);
            return result;
        }
    }
}
