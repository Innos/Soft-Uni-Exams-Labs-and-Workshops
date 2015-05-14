using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine();
        while (opCode != "END")
        {
            string[] codeArgs = opCode.Split(' ');
            BigInteger result = 0;
            switch (codeArgs[0])
            {
                    //result would take a value 0 if result = operandOne++; because it gets the operand value before it increments it;
                case "INC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        result = operandOne + 1;
                        break;
                    }
                //result would take a value 0 if result = operandOne++; because it gets the operand value before it decreases it;
                case "DEC":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        result = operandOne - 1;
                        break;
                    }
                case "ADD":
                    {
                        long operandOne = long.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        BigInteger operandOne = BigInteger.Parse(codeArgs[1]);
                        long operandTwo = long.Parse(codeArgs[2]);
                        //result of 2 ints is an int must cast or parse 1 as long to get a result in long
                        result = operandOne * operandTwo;
                        break;
                    }
            }
            Console.WriteLine(result);
            opCode = Console.ReadLine();
        }
    }
}