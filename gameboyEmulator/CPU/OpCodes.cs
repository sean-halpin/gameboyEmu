using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gameboyEmulator.ROM;

namespace gameboyEmulator.CPU
{
    public class OpCodes
    {
        public static void Execute(int opCode)
        {
            switch (opCode)
            {
                case 0x00: NOP_(); break;
                case 0x01: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x02: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x03: INC_Register_16_bit_bb_(); break;
                case 0x04: INC_Register_8_bit_b_(); break;
                case 0x05: DEC_Register_8_bit_b_(); break;
                case 0x06: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x07: RLCA_(); break;
                case 0x08: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x09: ADD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x0A: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x0B: DEC_Register_16_bit_bb_(); break;
                case 0x0C: INC_Register_8_bit_b_(); break;
                case 0x0D: DEC_Register_8_bit_b_(); break;
                case 0x0E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x0F: RRCA_(); break;
                case 0x10: STOP_Int32_num_(); break;
                case 0x11: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x12: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x13: INC_Register_16_bit_bb_(); break;
                case 0x14: INC_Register_8_bit_b_(); break;
                case 0x15: DEC_Register_8_bit_b_(); break;
                case 0x16: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x17: RLA_(); break;
                case 0x18: JR_Register_16_bit_bb_(); break;
                case 0x19: ADD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x1A: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x1B: DEC_Register_16_bit_bb_(); break;
                case 0x1C: INC_Register_8_bit_b_(); break;
                case 0x1D: DEC_Register_8_bit_b_(); break;
                case 0x1E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x1F: RRA_(); break;
                case 0x20: JR_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0x21: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x22: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x23: INC_Register_16_bit_bb_(); break;
                case 0x24: INC_Register_8_bit_b_(); break;
                case 0x25: DEC_Register_8_bit_b_(); break;
                case 0x26: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x27: DAA_(); break;
                case 0x28: JR_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0x29: ADD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x2A: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x2B: DEC_Register_16_bit_bb_(); break;
                case 0x2C: INC_Register_8_bit_b_(); break;
                case 0x2D: DEC_Register_8_bit_b_(); break;
                case 0x2E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x2F: CPL_(); break;
                case 0x30: JR_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0x31: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x32: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x33: INC_Register_16_bit_bb_(); break;
                case 0x34: INC_Register_16_bit_bb_(); break;
                case 0x35: DEC_Register_16_bit_bb_(); break;
                case 0x36: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x37: SCF_(); break;
                case 0x38: JR_(); break;
                case 0x39: ADD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0x3A: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x3B: DEC_Register_16_bit_bb_(); break;
                case 0x3C: INC_Register_8_bit_b_(); break;
                case 0x3D: DEC_Register_8_bit_b_(); break;
                case 0x3E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x3F: CCF_(); break;
                case 0x40: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x41: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x42: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x43: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x44: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x45: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x46: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x47: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x48: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x49: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x4A: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x4B: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x4C: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x4D: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x4E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x4F: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x50: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x51: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x52: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x53: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x54: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x55: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x56: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x57: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x58: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x59: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x5A: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x5B: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x5C: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x5D: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x5E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x5F: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x60: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x61: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x62: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x63: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x64: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x65: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x66: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x67: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x68: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x69: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x6A: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x6B: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x6C: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x6D: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x6E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x6F: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x70: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x71: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x72: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x73: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x74: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x75: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x76: HALT_(); break;
                case 0x77: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0x78: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x79: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x7A: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x7B: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x7C: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x7D: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x7E: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x7F: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x80: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x81: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x82: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x83: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x84: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x85: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x86: ADD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x87: ADD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x88: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x89: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x8A: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x8B: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x8C: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x8D: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x8E: ADC_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x8F: ADC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x90: SUB_Register_8_bit_b_(); break;
                case 0x91: SUB_Register_8_bit_b_(); break;
                case 0x92: SUB_Register_8_bit_b_(); break;
                case 0x93: SUB_Register_8_bit_b_(); break;
                case 0x94: SUB_Register_8_bit_b_(); break;
                case 0x95: SUB_Register_8_bit_b_(); break;
                case 0x96: SUB_Register_16_bit_bb_(); break;
                case 0x97: SUB_Register_8_bit_b_(); break;
                case 0x98: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x99: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x9A: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x9B: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x9C: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x9D: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0x9E: SBC_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0x9F: SBC_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0xA0: AND_Register_8_bit_b_(); break;
                case 0xA1: AND_Register_8_bit_b_(); break;
                case 0xA2: AND_Register_8_bit_b_(); break;
                case 0xA3: AND_Register_8_bit_b_(); break;
                case 0xA4: AND_Register_8_bit_b_(); break;
                case 0xA5: AND_Register_8_bit_b_(); break;
                case 0xA6: AND_Register_16_bit_bb_(); break;
                case 0xA7: AND_Register_8_bit_b_(); break;
                case 0xA8: XOR_Register_8_bit_b_(); break;
                case 0xA9: XOR_Register_8_bit_b_(); break;
                case 0xAA: XOR_Register_8_bit_b_(); break;
                case 0xAB: XOR_Register_8_bit_b_(); break;
                case 0xAC: XOR_Register_8_bit_b_(); break;
                case 0xAD: XOR_Register_8_bit_b_(); break;
                case 0xAE: XOR_Register_16_bit_bb_(); break;
                case 0xAF: XOR_Register_8_bit_b_(); break;
                case 0xB0: OR_Register_8_bit_b_(); break;
                case 0xB1: OR_Register_8_bit_b_(); break;
                case 0xB2: OR_Register_8_bit_b_(); break;
                case 0xB3: OR_Register_8_bit_b_(); break;
                case 0xB4: OR_Register_8_bit_b_(); break;
                case 0xB5: OR_Register_8_bit_b_(); break;
                case 0xB6: OR_Register_16_bit_bb_(); break;
                case 0xB7: OR_Register_8_bit_b_(); break;
                case 0xB8: CP_Register_8_bit_b_(); break;
                case 0xB9: CP_Register_8_bit_b_(); break;
                case 0xBA: CP_Register_8_bit_b_(); break;
                case 0xBB: CP_Register_8_bit_b_(); break;
                case 0xBC: CP_Register_8_bit_b_(); break;
                case 0xBD: CP_Register_8_bit_b_(); break;
                case 0xBE: CP_Register_16_bit_bb_(); break;
                case 0xBF: CP_Register_8_bit_b_(); break;
                case 0xC0: RET_Register_8_bit_blag_bond_(); break;
                case 0xC1: POP_Register_16_bit_bb_(); break;
                case 0xC2: JP_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xC3: JP_Register_16_bit_bb_(); break;
                case 0xC4: CALL_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xC5: PUSH_Register_16_bit_bb_(); break;
                case 0xC6: ADD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xC7: RST_Int32_num_(); break;
                case 0xC8: RET_Register_8_bit_blag_bond_(); break;
                case 0xC9: RET_(); break;
                case 0xCA: JP_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xCB: PREFIX_Opbode_bb_(); break;
                case 0xCC: CALL_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xCD: CALL_Register_16_bit_bb_(); break;
                case 0xCE: ADC_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xCF: RST_Int32_num_(); break;
                case 0xD0: RET_Register_8_bit_blag_bond_(); break;
                case 0xD1: POP_Register_16_bit_bb_(); break;
                case 0xD2: JP_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xD4: CALL_Register_8_bit_blag_bond_Register_16_bit_bb_(); break;
                case 0xD5: PUSH_Register_16_bit_bb_(); break;
                case 0xD6: SUB_Register_16_bit_bb_(); break;
                case 0xD7: RST_Int32_num_(); break;
                case 0xD8: RET_Register_8_bit_b_(); break;
                case 0xD9: RETI_(); break;
                case 0xDA: JP_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xDC: CALL_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xDE: SBC_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xDF: RST_Int32_num_(); break;
                case 0xE0: LDH_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0xE1: POP_Register_16_bit_bb_(); break;
                case 0xE2: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0xE5: PUSH_Register_16_bit_bb_(); break;
                case 0xE6: AND_Register_16_bit_bb_(); break;
                case 0xE7: RST_Int32_num_(); break;
                case 0xE8: ADD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0xE9: JP_Register_16_bit_bb_(); break;
                case 0xEA: LD_Register_16_bit_bb_Register_8_bit_b_(); break;
                case 0xEE: XOR_Register_16_bit_bb_(); break;
                case 0xEF: RST_Int32_num_(); break;
                case 0xF0: LDH_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xF1: POP_Register_16_bit_bb_(); break;
                case 0xF2: LD_Register_8_bit_b_Register_8_bit_b_(); break;
                case 0xF3: DI_(); break;
                case 0xF5: PUSH_Register_16_bit_bb_(); break;
                case 0xF6: OR_Register_16_bit_bb_(); break;
                case 0xF7: RST_Int32_num_(); break;
                case 0xF8: LD_Register_16_bit_bb_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0xF9: LD_Register_16_bit_bb_Register_16_bit_bb_(); break;
                case 0xFA: LD_Register_8_bit_b_Register_16_bit_bb_(); break;
                case 0xFB: EI_(); break;
                case 0xFE: CP_Register_16_bit_bb_(); break;
                case 0xFF: RST_Int32_num_(); break;
            }
        }

        public static void NOP_() { }
        public static void LD_Register_16_bit_bb_Register_16_bit_bb_() { }
        public static void LD_Register_16_bit_bb_Register_8_bit_b_() { }
        public static void INC_Register_16_bit_bb_() { }
        public static void INC_Register_8_bit_b_() { }
        public static void DEC_Register_8_bit_b_() { }
        public static void LD_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void RLCA_() { }
        public static void ADD_Register_16_bit_bb_Register_16_bit_bb_() { }
        public static void DEC_Register_16_bit_bb_() { }
        public static void RRCA_() { }
        public static void STOP_Int32_num_() { }
        public static void RLA_() { }
        public static void JR_Register_16_bit_bb_() { }
        public static void RRA_() { }
        public static void JR_Register_8_bit_blag_bond_Register_16_bit_bb_() { }
        public static void DAA_() { }
        public static void CPL_() { }
        public static void SCF_() { }
        public static void JR_() { }
        public static void CCF_() { }
        public static void LD_Register_8_bit_b_Register_8_bit_b_() { }
        public static void HALT_() { }
        public static void ADD_Register_8_bit_b_Register_8_bit_b_() { }
        public static void ADD_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void ADC_Register_8_bit_b_Register_8_bit_b_() { }
        public static void ADC_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void SUB_Register_8_bit_b_() { }
        public static void SUB_Register_16_bit_bb_() { }
        public static void SBC_Register_8_bit_b_Register_8_bit_b_() { }
        public static void SBC_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void AND_Register_8_bit_b_() { }
        public static void AND_Register_16_bit_bb_() { }
        public static void XOR_Register_8_bit_b_() { }
        public static void XOR_Register_16_bit_bb_() { }
        public static void OR_Register_8_bit_b_() { }
        public static void OR_Register_16_bit_bb_() { }
        public static void CP_Register_8_bit_b_() { }
        public static void CP_Register_16_bit_bb_() { }
        public static void RET_Register_8_bit_blag_bond_() { }
        public static void POP_Register_16_bit_bb_() { }
        public static void JP_Register_8_bit_blag_bond_Register_16_bit_bb_() { }
        public static void JP_Register_16_bit_bb_() { }
        public static void CALL_Register_8_bit_blag_bond_Register_16_bit_bb_() { }
        public static void PUSH_Register_16_bit_bb_() { }
        public static void RST_Int32_num_() { }
        public static void RET_() { }
        public static void PREFIX_Opbode_bb_() { }
        public static void CALL_Register_16_bit_bb_() { }
        public static void RET_Register_8_bit_b_() { }
        public static void RETI_() { }
        public static void JP_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void CALL_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void LDH_Register_16_bit_bb_Register_8_bit_b_() { }
        public static void LDH_Register_8_bit_b_Register_16_bit_bb_() { }
        public static void DI_() { }
        public static void LD_Register_16_bit_bb_Register_16_bit_bb_Register_16_bit_bb_() { }
        public static void EI_() { }
    }
}
