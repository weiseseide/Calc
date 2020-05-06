using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace WpfCalc3.CalcDeterminer
{
    /* Determiner with States after input:
     * States 0=init, 1=number, 3=operator,4=comma, 6=equal
     */
    public interface IDeterminer
    {
        String PushDigit(char c);
        String PushOperator(char c);
        String Equal();
        String Clear();
        String PushComma(char c);
    }
    [Export(typeof(IDeterminer))]
    public class Determiner : IDeterminer
    {
        private StringBuilder input;
        private StringBuilder output;
        private StringBuilder tmp;
        private double operand;
        private char cOperator;

        private int state;
        private int newState;
        private bool commaUsed;
        private bool prevEquationExist;


        public Determiner()
        {
            this.input = new StringBuilder(32);
            this.output = new StringBuilder(32);
            this.tmp = new StringBuilder(32);
            this.state = 0;
            this.newState = 0;
            this.commaUsed = false;
            this.prevEquationExist = false;
        }

        public String PushDigit(char c)
        {
            newState = 1;
            if (CheckState())
            {
                input.Append(c);
                output.Append(c);
            }

            return output.ToString();
        }

        public String PushOperator(char c)
        {
            newState = 3;
            if (CheckState())
            {

                if (!prevEquationExist)
                {
                    if (state == 4 && input.Length > 0)
                    {
                        input.Length--;
                        state = 1;
                    }
                    cOperator = c;
                    prevEquationExist = true;
                    if (input.Length != 0)
                        operand = Convert.ToDouble(input.ToString());
                    input.Clear();
                    commaUsed = false;
                    return output.Append(c).ToString();
                }
                else
                {
                    String tmp = Equal();
                    input.Clear();
                    output.Clear();
                    tmp = output.Append(tmp).Append(c).ToString();
                    cOperator = c;
                    commaUsed = false;
                    prevEquationExist = true;
                    state = 3;
                    return tmp;
                }
            }

            return output.ToString();
        }

        private bool CheckState()
        {
            if (newState == 1 || (state != 3 && Math.Abs(state - newState) != 1 && state != 0))
            {
                state = newState;
                return true;
            }
            return false;
        }

        public String Equal()
        {
            double tmp = 0;

            if (state == 4 && input.Length > 0)
            {
                input.Length--;
                state = 1;
            }

            if (!prevEquationExist && state == 1)
            {
                operand = Convert.ToDouble(input.ToString());
                prevEquationExist = true;
                return operand.ToString();
            }

            if (state == 1 || state == 3)
            {
                try
                {
                    switch (cOperator)
                    {
                        case '+': tmp = operand + Convert.ToDouble(input.ToString()); break;
                        case '-': tmp = operand - Convert.ToDouble(input.ToString()); break;
                        case 'x': tmp = operand * Convert.ToDouble(input.ToString()); break;
                        case '/': tmp = operand / Convert.ToDouble(input.ToString()); break;
                    }

                    _ = tmp == Convert.ToInt32(tmp) ? commaUsed = false : commaUsed = true;
                    prevEquationExist = false;
                    input.Clear();
                    output.Clear();
                    state = 6;

                    operand = tmp;
                    output.Append(operand);
                    input.Append(operand);
                }
                catch
                {
                    output.Append(Clear()).Append("NaN");
                }

                return output.ToString();
            }
            else
            {
                input.Clear();
                return output.ToString();
            }

        }

        public String Clear()
        {
            operand = 0;
            prevEquationExist = false;
            commaUsed = false;
            output.Clear();
            input.Clear();
            return "";
        }

        public String PushComma(char c)
        {
            newState = 4;
            if (!commaUsed && state != 0 && state != 3)
            {
                if (CheckState())
                {
                    input.Append(c);
                    output.Append(c);
                    commaUsed = true;
                }
            }
            else
            {
                newState = state;
            }

            return output.ToString();
        }


    }
}
