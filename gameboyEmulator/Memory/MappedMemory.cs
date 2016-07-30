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
        private byte[] _memory;

        public MappedMemory(byte[] memory)
        {
            this._memory = memory;
        }

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

        public void WriteByte(Register_16_Bit bc, Register_8_Bit register8Bit)
        {
            _memory[bc.Value] = register8Bit.Value;
        }
    }
}
