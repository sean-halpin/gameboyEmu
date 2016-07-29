using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var split = opCode._mneumonic.Split(' ');
                opCode.method = split[0];
                if (split.Length > 1)
                {
                    opCode.argTypes = split[1].Replace("(", "").Replace(")", "")
                        .Replace("AF", "R16")
                        .Replace("BC", "R16")
                        .Replace("DE", "R16")
                        .Replace("HL", "R16")
                        .Replace("SP", "R16")
                        .Replace("PC", "R16")
                        .Replace("A", "R8")
                        .Replace("B", "R8")
                        .Replace("C", "R8")
                        .Replace("D", "R8")
                        .Replace("E", "R8")
                        .Replace("H", "R8")
                        .Replace("L", "R8")
                        .Replace("F", "R8F")
                        ;
                }
                else
                {
                    opCode.argTypes = "";
                }
            }
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
        public string argTypes;

        public OpCode(string opHexCode, string m, string length, string cycles, string flags)
        {
            _opCodeHex = opHexCode;
            _mneumonic = m;
            _byteLength = length;
            _cycles = cycles;
            _flags = flags;
        }
    }
}
