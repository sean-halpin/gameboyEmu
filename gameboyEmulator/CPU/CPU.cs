using gameboyEmulator.ROM;
using gameboyEmulator.Memory;
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
        Register_8_Bit A;
        //flag
        Register_8_Bit_Flag F;
        //general
        Register_16_Bit AF;
        Register_8_Bit B;
        Register_8_Bit C;
        Register_16_Bit BC;
        Register_8_Bit D;
        Register_8_Bit E;
        Register_16_Bit DE;
        Register_8_Bit H;
        Register_8_Bit L;
        Register_16_Bit HL;
        //program counter
        Register_16_Bit PC;
        //stack pointer
        Register_16_Bit SP;
        //ROM
        private MappedMemory _memory;

        public CPU(CartROM currentRom, MappedMemory memory)
        {
            _memory = memory;
            //Create Registers
            A = new Register_8_Bit("a");
            F = new Register_8_Bit_Flag("f");
            AF = new Register_16_Bit(A, F);
            B = new Register_8_Bit("b");
            C = new Register_8_Bit("c");
            BC = new Register_16_Bit(B, C);
            D = new Register_8_Bit("d");
            E = new Register_8_Bit("e");
            DE = new Register_16_Bit(D, E);
            H = new Register_8_Bit("h");
            L = new Register_8_Bit("l");
            HL = new Register_16_Bit(H, L);
            PC = new Register_16_Bit("pc");
            SP = new Register_16_Bit("sp");
        }

        private void BeginExecution()
        {
            while (true)
                Execute(_memory.ReadByte(PC));
        }

        private void Execute(int opCode)
        {
            switch (opCode)
            {
                case 0x00: NOP(F); break;
                case 0x01: LD_RR_d16(BC, PC, F); break;
                case 0x02: LD_RR_r(BC, A, F); break;
                case 0x03: INC_RR(BC, F); break;
                case 0x04: INC_r(B, F); break;
                case 0x05: DEC_r(B, F); break;
                case 0x06: LD_r_d8(B, SP, F); break;
                case 0x07: RLCA(F); break;
                case 0x08: LD_a16_SP(SP, SP, F); break;
                case 0x09: ADD_RR_RR(HL, BC, F); break;
                case 0x0A: LD_r_RR(A, BC, F); break;
                case 0x0B: DEC_RR(BC, F); break;
                case 0x0C: INC_r(C, F); break;
                case 0x0D: DEC_r(C, F); break;
                case 0x0E: LD_r_d8(C, SP, F); break;
                case 0x0F: RRCA(F); break;
                case 0x10: STOP_num(0, F); break;
                case 0x11: LD_RR_d16(DE, SP, F); break;
                case 0x12: LD_RR_r(DE, A, F); break;
                case 0x13: INC_RR(DE, F); break;
                case 0x14: INC_r(D, F); break;
                case 0x15: DEC_r(D, F); break;
                case 0x16: LD_r_d8(D, SP, F); break;
                case 0x17: RLA(F); break;
                case 0x18: JR_r8(SP, F); break;
                case 0x19: ADD_RR_RR(HL, DE, F); break;
                case 0x1A: LD_r_RR(A, DE, F); break;
                case 0x1B: DEC_RR(DE, F); break;
                case 0x1C: INC_r(E, F); break;
                case 0x1D: DEC_r(E, F); break;
                case 0x1E: LD_r_d8(E, SP, F); break;
                case 0x1F: RRA(F); break;
                case 0x20: JR_NZ_r8(!F.ZeroFlag, SP, F); break;
                case 0x21: LD_RR_d16(HL, SP, F); break;
                case 0x22: LD_RRInc_r(HL, A, F); break;
                case 0x23: INC_RR(HL, F); break;
                case 0x24: INC_r(H, F); break;
                case 0x25: DEC_r(H, F); break;
                case 0x26: LD_r_d8(H, SP, F); break;
                case 0x27: DAA(F); break;
                case 0x28: JR_Z_r8(F.ZeroFlag, SP, F); break;
                case 0x29: ADD_RR_RR(HL, HL, F); break;
                case 0x2A: LD_r_RRInc(A, HL, F); break;
                case 0x2B: DEC_RR(HL, F); break;
                case 0x2C: INC_r(L, F); break;
                case 0x2D: DEC_r(L, F); break;
                case 0x2E: LD_r_d8(L, SP, F); break;
                case 0x2F: CPL(F); break;
                case 0x30: JR_Nr_r8(!F.CarryFlag, SP, F); break;
                case 0x31: LD_SP_d16(SP, SP, F); break;
                case 0x32: LD_RRrec_r(HL, A, F); break;
                case 0x33: INC_SP(SP, F); break;
                case 0x34: INC_RR(HL, F); break;
                case 0x35: DEC_RR(HL, F); break;
                case 0x36: LD_RR_d8(HL, SP, F); break;
                case 0x37: SCF(F); break;
                case 0x38: JR(F); break;
                case 0x39: ADD_RR_SP(HL, SP, F); break;
                case 0x3A: LD_r_RRrec(A, HL, F); break;
                case 0x3B: DEC_SP(SP, F); break;
                case 0x3C: INC_r(A, F); break;
                case 0x3D: DEC_r(A, F); break;
                case 0x3E: LD_r_d8(A, SP, F); break;
                case 0x3F: CCF(F); break;
                case 0x40: LD_r_r(B, B, F); break;
                case 0x41: LD_r_r(B, C, F); break;
                case 0x42: LD_r_r(B, D, F); break;
                case 0x43: LD_r_r(B, E, F); break;
                case 0x44: LD_r_r(B, H, F); break;
                case 0x45: LD_r_r(B, L, F); break;
                case 0x46: LD_r_RR(B, HL, F); break;
                case 0x47: LD_r_r(B, A, F); break;
                case 0x48: LD_r_r(C, B, F); break;
                case 0x49: LD_r_r(C, C, F); break;
                case 0x4A: LD_r_r(C, D, F); break;
                case 0x4B: LD_r_r(C, E, F); break;
                case 0x4C: LD_r_r(C, H, F); break;
                case 0x4D: LD_r_r(C, L, F); break;
                case 0x4E: LD_r_RR(C, HL, F); break;
                case 0x4F: LD_r_r(C, A, F); break;
                case 0x50: LD_r_r(D, B, F); break;
                case 0x51: LD_r_r(D, C, F); break;
                case 0x52: LD_r_r(D, D, F); break;
                case 0x53: LD_r_r(D, E, F); break;
                case 0x54: LD_r_r(D, H, F); break;
                case 0x55: LD_r_r(D, L, F); break;
                case 0x56: LD_r_RR(D, HL, F); break;
                case 0x57: LD_r_r(D, A, F); break;
                case 0x58: LD_r_r(E, B, F); break;
                case 0x59: LD_r_r(E, C, F); break;
                case 0x5A: LD_r_r(E, D, F); break;
                case 0x5B: LD_r_r(E, E, F); break;
                case 0x5C: LD_r_r(E, H, F); break;
                case 0x5D: LD_r_r(E, L, F); break;
                case 0x5E: LD_r_RR(E, HL, F); break;
                case 0x5F: LD_r_r(E, A, F); break;
                case 0x60: LD_r_r(H, B, F); break;
                case 0x61: LD_r_r(H, C, F); break;
                case 0x62: LD_r_r(H, D, F); break;
                case 0x63: LD_r_r(H, E, F); break;
                case 0x64: LD_r_r(H, H, F); break;
                case 0x65: LD_r_r(H, L, F); break;
                case 0x66: LD_r_RR(H, HL, F); break;
                case 0x67: LD_r_r(H, A, F); break;
                case 0x68: LD_r_r(L, B, F); break;
                case 0x69: LD_r_r(L, C, F); break;
                case 0x6A: LD_r_r(L, D, F); break;
                case 0x6B: LD_r_r(L, E, F); break;
                case 0x6C: LD_r_r(L, H, F); break;
                case 0x6D: LD_r_r(L, L, F); break;
                case 0x6E: LD_r_RR(L, HL, F); break;
                case 0x6F: LD_r_r(L, A, F); break;
                case 0x70: LD_RR_r(HL, B, F); break;
                case 0x71: LD_RR_r(HL, C, F); break;
                case 0x72: LD_RR_r(HL, D, F); break;
                case 0x73: LD_RR_r(HL, E, F); break;
                case 0x74: LD_RR_r(HL, H, F); break;
                case 0x75: LD_RR_r(HL, L, F); break;
                case 0x76: HALT(F); break;
                case 0x77: LD_RR_r(HL, A, F); break;
                case 0x78: LD_r_r(A, B, F); break;
                case 0x79: LD_r_r(A, C, F); break;
                case 0x7A: LD_r_r(A, D, F); break;
                case 0x7B: LD_r_r(A, E, F); break;
                case 0x7C: LD_r_r(A, H, F); break;
                case 0x7D: LD_r_r(A, L, F); break;
                case 0x7E: LD_r_RR(A, HL, F); break;
                case 0x7F: LD_r_r(A, A, F); break;
                case 0x80: ADD_r_r(A, B, F); break;
                case 0x81: ADD_r_r(A, C, F); break;
                case 0x82: ADD_r_r(A, D, F); break;
                case 0x83: ADD_r_r(A, E, F); break;
                case 0x84: ADD_r_r(A, H, F); break;
                case 0x85: ADD_r_r(A, L, F); break;
                case 0x86: ADD_r_RR(A, HL, F); break;
                case 0x87: ADD_r_r(A, A, F); break;
                case 0x88: ADC_r_r(A, B, F); break;
                case 0x89: ADC_r_r(A, C, F); break;
                case 0x8A: ADC_r_r(A, D, F); break;
                case 0x8B: ADC_r_r(A, E, F); break;
                case 0x8C: ADC_r_r(A, H, F); break;
                case 0x8D: ADC_r_r(A, L, F); break;
                case 0x8E: ADC_r_RR(A, HL, F); break;
                case 0x8F: ADC_r_r(A, A, F); break;
                case 0x90: SUB_r(B, F); break;
                case 0x91: SUB_r(C, F); break;
                case 0x92: SUB_r(D, F); break;
                case 0x93: SUB_r(E, F); break;
                case 0x94: SUB_r(H, F); break;
                case 0x95: SUB_r(L, F); break;
                case 0x96: SUB_RR(HL, F); break;
                case 0x97: SUB_r(A, F); break;
                case 0x98: SBC_r_r(A, B, F); break;
                case 0x99: SBC_r_r(A, C, F); break;
                case 0x9A: SBC_r_r(A, D, F); break;
                case 0x9B: SBC_r_r(A, E, F); break;
                case 0x9C: SBC_r_r(A, H, F); break;
                case 0x9D: SBC_r_r(A, L, F); break;
                case 0x9E: SBC_r_RR(A, HL, F); break;
                case 0x9F: SBC_r_r(A, A, F); break;
                case 0xA0: AND_r(B, F); break;
                case 0xA1: AND_r(C, F); break;
                case 0xA2: AND_r(D, F); break;
                case 0xA3: AND_r(E, F); break;
                case 0xA4: AND_r(H, F); break;
                case 0xA5: AND_r(L, F); break;
                case 0xA6: AND_RR(HL, F); break;
                case 0xA7: AND_r(A, F); break;
                case 0xA8: XOR_r(B, F); break;
                case 0xA9: XOR_r(C, F); break;
                case 0xAA: XOR_r(D, F); break;
                case 0xAB: XOR_r(E, F); break;
                case 0xAC: XOR_r(H, F); break;
                case 0xAD: XOR_r(L, F); break;
                case 0xAE: XOR_RR(HL, F); break;
                case 0xAF: XOR_r(A, F); break;
                case 0xB0: OR_r(B, F); break;
                case 0xB1: OR_r(C, F); break;
                case 0xB2: OR_r(D, F); break;
                case 0xB3: OR_r(E, F); break;
                case 0xB4: OR_r(H, F); break;
                case 0xB5: OR_r(L, F); break;
                case 0xB6: OR_RR(HL, F); break;
                case 0xB7: OR_r(A, F); break;
                case 0xB8: CP_r(B, F); break;
                case 0xB9: CP_r(C, F); break;
                case 0xBA: CP_r(D, F); break;
                case 0xBB: CP_r(E, F); break;
                case 0xBC: CP_r(H, F); break;
                case 0xBD: CP_r(L, F); break;
                case 0xBE: CP_RR(HL, F); break;
                case 0xBF: CP_r(A, F); break;
                case 0xC0: RET_NZ(!F.ZeroFlag, F); break;
                case 0xC1: POP_RR(BC, F); break;
                case 0xC2: JP_NZ_a16(!F.ZeroFlag, SP, F); break;
                case 0xC3: JP_a16(SP, F); break;
                case 0xC4: CALL_NZ_a16(!F.ZeroFlag, SP, F); break;
                case 0xC5: PUSH_RR(BC, F); break;
                case 0xC6: ADD_r_d8(A, SP, F); break;
                case 0xC7: RST_num(0, F); break;
                case 0xC8: RET_Z(F.ZeroFlag, F); break;
                case 0xC9: RET(F); break;
                case 0xCA: JP_Z_a16(F.ZeroFlag, SP, F); break;
                case 0xCB: PREFIX_CB(0, F); break;
                case 0xCC: CALL_Z_a16(F.ZeroFlag, SP, F); break;
                case 0xCD: CALL_a16(SP, F); break;
                case 0xCE: ADC_r_d8(A, SP, F); break;
                case 0xCF: RST_num(0x08, F); break;
                case 0xD0: RET_Nr(!F.CarryFlag, F); break;
                case 0xD1: POP_RR(DE, F); break;
                case 0xD2: JP_Nr_a16(!F.CarryFlag, SP, F); break;
                case 0xD4: CALL_Nr_a16(!F.CarryFlag, SP, F); break;
                case 0xD5: PUSH_RR(DE, F); break;
                case 0xD6: SUB_d8(SP, F); break;
                case 0xD7: RST_num(0x10, F); break;
                case 0xD8: RET_r(F.CarryFlag, F); break;
                case 0xD9: RETI(F); break;
                case 0xDA: JP_r_a16(C, SP, F); break;
                case 0xDC: CALL_r_a16(C, SP, F); break;
                case 0xDE: SBC_r_d8(A, SP, F); break;
                case 0xDF: RST_num(0x18, F); break;
                case 0xE0: LDH_a8_r(SP, A, F); break;
                case 0xE1: POP_RR(HL, F); break;
                case 0xE2: LD_r_r(C, A, F); break;
                case 0xE5: PUSH_RR(HL, F); break;
                case 0xE6: AND_d8(SP, F); break;
                case 0xE7: RST_num(0x20, F); break;
                case 0xE8: ADD_SP_r8(SP, SP, F); break;
                case 0xE9: JP_RR(HL, F); break;
                case 0xEA: LD_a16_r(SP, A, F); break;
                case 0xEE: XOR_d8(SP, F); break;
                case 0xEF: RST_num(0x28, F); break;
                case 0xF0: LDH_r_a8(A, SP, F); break;
                case 0xF1: POP_RR(AF, F); break;
                case 0xF2: LD_r_r(A, C, F); break;
                case 0xF3: DI(F); break;
                case 0xF5: PUSH_RR(AF, F); break;
                case 0xF6: OR_d8(SP, F); break;
                case 0xF7: RST_num(0x30, F); break;
                case 0xF8: LD_RR_SP_r8(HL, SP, SP, F); break;
                case 0xF9: LD_SP_RR(SP, HL, F); break;
                case 0xFA: LD_r_a16(A, SP, F); break;
                case 0xFB: EI(F); break;
                case 0xFE: CP_d8(SP, F); break;
                case 0xFF: RST_num(0x38, F); break;
                default:
                    throw new NotImplementedException("OPCODE : 0x" + opCode.ToString("X2"));
            }
        }

        public void ADC_r_d8(Register_8_Bit A, Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADC_r_r(Register_8_Bit A, Register_8_Bit B, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADC_r_RR(Register_8_Bit A, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_r_d8(Register_8_Bit A, Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_r_r(Register_8_Bit A, Register_8_Bit B, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_r_RR(Register_8_Bit A, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_RR_RR(Register_16_Bit HL, Register_16_Bit BC, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_RR_SP(Register_16_Bit HL, Register_16_Bit SP, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void ADD_SP_r8(Register_16_Bit SP, Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void AND_d8(Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void AND_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void AND_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CALL_a16(Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CALL_Nr_a16(bool NC, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CALL_NZ_a16(bool NZ, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CALL_r_a16(Register_8_Bit C, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CALL_Z_a16(bool Z, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CCF(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CP_d8(Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CP_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CP_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void CPL(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void DAA(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void DEC_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void DEC_RR(Register_16_Bit BC, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void DEC_SP(Register_16_Bit SP, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void DI(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void EI(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void HALT(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void INC_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void INC_RR(Register_16_Bit BC, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void INC_SP(Register_16_Bit SP, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_a16(Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_Nr_a16(bool NC, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_NZ_a16(bool NZ, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_r_a16(Register_8_Bit C, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JP_Z_a16(bool Z, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JR(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JR_Nr_r8(bool NC, Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JR_NZ_r8(bool NZ, Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JR_r8(Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void JR_Z_r8(bool Z, Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_a16_r(Register_16_Bit a16, Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_a16_SP(Register_16_Bit a16, Register_16_Bit SP, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_a16(Register_8_Bit A, Register_16_Bit a16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_d8(Register_8_Bit A, Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_r(Register_8_Bit A, Register_8_Bit B, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_RR(Register_8_Bit A, Register_16_Bit BC, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_RRInc(Register_8_Bit A, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_r_RRrec(Register_8_Bit A, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        //LD BC,d16 3  12 - - - -
        public void LD_RR_d16(Register_16_Bit BC, Register_16_Bit PC, Register_8_Bit_Flag flag)
        {
            BC.Value = _memory.ReadHalfWord(PC);
        }
        public void LD_RR_d8(Register_16_Bit HL, Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_RR_r(Register_16_Bit BC, Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_RR_SP_r8(Register_16_Bit HL, Register_16_Bit SP, Register_16_Bit r8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_RRInc_r(Register_16_Bit HL, Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_RRrec_r(Register_16_Bit HL, Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_SP_d16(Register_16_Bit SP, Register_16_Bit d16, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LD_SP_RR(Register_16_Bit SP, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LDH_a8_r(Register_16_Bit a8, Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void LDH_r_a8(Register_8_Bit A, Register_16_Bit a8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void NOP(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void OR_d8(Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void OR_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void OR_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void POP_RR(Register_16_Bit AF, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void PREFIX_CB(int CB, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void PUSH_RR(Register_16_Bit AF, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RET(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RET_Nr(bool NC, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RET_NZ(bool NZ, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RET_r(bool C, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RET_Z(bool Z, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RETI(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RLA(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RLCA(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RRA(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RRCA(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void RST_num(Int32 num, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SBC_r_d8(Register_8_Bit A, Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SBC_r_r(Register_8_Bit A, Register_8_Bit B, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SBC_r_RR(Register_8_Bit A, Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SCF(Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void STOP_num(Int32 num, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SUB_d8(Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SUB_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void SUB_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void XOR_d8(Register_16_Bit d8, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void XOR_r(Register_8_Bit A, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
        public void XOR_RR(Register_16_Bit HL, Register_8_Bit_Flag flag) { throw new NotImplementedException(); }
    }

}

