using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using gameboyEmulator.CPU;
using TechTalk.SpecFlow;

namespace gameboyEmulator.Tests
{
    [Binding]
    public sealed class CommonStepDefinitions
    {
        private ScenarioContext _currentContext = ScenarioContext.Current;

        [Given(@"a table of opcode details")]
        public void GivenATableOfOpcodeDetails(Table table)
        {
            var index = 0;
            var listOpCodes = new List<OpCode>();
            foreach (var row in table.Rows)
            {
                if (!row["Mneumonic"].Equals(""))
                    listOpCodes.Add(
                        new OpCode(
                            index.ToString("X2"),
                            row["Mneumonic"],
                            row["Bytes"],
                            row["Cycles"],
                            row["Flags"]
                        ));
                index++;
            }
            _currentContext.Set(listOpCodes);
        }

        [Then(@"give me the cases in C Sharp")]
        public void ThenGiveMeTheCasesInCSharp()
        {
            var list = _currentContext.Get<List<OpCode>>();
            foreach (var opCode in list)
            {
                var split = opCode._mneumonic.Replace("(", " ").Replace(")", " ").Replace(",", " ").Split(' ').ToList();
                opCode.method = split[0];
                foreach (var arg in split.Skip(1).ToList())
                {
                    if (!string.IsNullOrEmpty(arg) && !opCode._opCodeHex.Equals(0x38.ToString("X2")))
                        opCode.args.Add(ConvertStringToArg(arg));
                }
            }

            var str = new StringBuilder();
            foreach (var opCode in list)
            {
                str.AppendLine(opCode.toSwitchCase());
                Debug.WriteLine(opCode.toSwitchCase());
            }
        }

        private static KeyValuePair<Type, string> ConvertStringToArg(string arg)
        {
            return string.IsNullOrEmpty(arg)
                ? new KeyValuePair<Type, string>(null, null)
                : new KeyValuePair<Type, string>(GetArgType(arg), arg);
        }

        private static Type GetArgType(string s)
        {
            Type thisArgType = null;
            switch (s)
            {
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                case "H":
                case "L":
                    thisArgType = typeof(Register_8_Bit);
                    break;
                case "F":
                    thisArgType = typeof(Register_8_Bit_Flag);
                    break;
                case "AF":
                case "BC":
                case "DE":
                case "HL":
                case "HL+":
                case "HL-":
                case "SP":
                case "PC":
                case "d16":
                case "d8":
                case "a16":
                case "a8":
                case "r8":
                    thisArgType = typeof(Register_16_Bit);
                    break;
                case "NZ":
                case "Z":
                case "NC":
                    //case "C":
                    thisArgType = typeof(Register_8_Bit_Flag);
                    break;
                case "0":
                case "00H":
                case "08H":
                case "18H":
                case "28H":
                case "38H":
                case "10H":
                case "20H":
                case "30H":
                    thisArgType = typeof(int);
                    break;
                case "CB":
                    thisArgType = typeof(OpCode);
                    break;
                default:
                    throw new NotImplementedException(s);
            }
            return thisArgType;
        }
    }

    internal class OpCode
    {
        public string _opCodeHex;
        public string _mneumonic;
        public string _byteLength;
        public string _cycles;
        public string _flags;

        public string method;
        public List<KeyValuePair<Type, string>> args;

        public OpCode(string opHexCode, string m, string length, string cycles, string flags)
        {
            _opCodeHex = opHexCode;
            _mneumonic = m;
            _byteLength = length;
            _cycles = cycles;
            _flags = flags;
            Initializer();
        }

        private void Initializer()
        {
            args = new List<KeyValuePair<Type, string>>();
        }

        public string toSwitchCase()
        {
            string a = "";
            var argz = args.Select(arg => arg.Key.Name + "_" + arg.Value + "_");
            foreach (var argstring in argz)
            {
                var genericArg = FindGenericArg(argstring);
                a += genericArg;
            }
            return "case 0x" + _opCodeHex
                + " : " + method + "_"
                + a + "() break;";
        }

        private string FindGenericArg(string argstring)
        {
            var genericArg = argstring
                .Replace("AF", "BB")
                .Replace("BC", "BB")
                .Replace("DE", "BB")
                .Replace("HL+", "BB")
                .Replace("HL-", "BB")
                .Replace("HL", "BB")
                .Replace("SP", "BB")
                .Replace("PC", "BB")
                .Replace("d16", "BB")
                .Replace("d8", "BB")
                .Replace("a16", "BB")
                .Replace("a8", "BB")
                .Replace("r8", "BB")
                .Replace("NZ", "Cond")
                .Replace("Z", "Cond")
                .Replace("NC", "Cond")
                .Replace("00H", "num")
                .Replace("08H", "num")
                .Replace("18H", "num")
                .Replace("28H", "num")
                .Replace("38H", "num")
                .Replace("10H", "num")
                .Replace("20H", "num")
                .Replace("30H", "num")
                .Replace("0", "num")
                .Replace("CB", "CB")
                .Replace("A", "b")
                .Replace("B", "b")
                .Replace("C", "b")
                .Replace("D", "b")
                .Replace("E", "b")
                .Replace("H", "b")
                .Replace("L", "b")
                .Replace("F", "b");
            return genericArg;
        }
    }
}
