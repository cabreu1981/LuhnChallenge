using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnChallenge
{
    public class LuhnCheckOptimal : ILuhnCheck
    {
        private static readonly int[] Deltas = { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
        private static readonly bool[] ChecksumAnswers = new bool[200];
        public LuhnCheckOptimal()
        {
            for (int i = 0; i < 200; i++)
            {
                if (i % 10 == 0)
                {
                    ChecksumAnswers[i] = true;
                }
                else
                {
                    ChecksumAnswers[i] = false;
                }
            }
        }


        public bool IsValidCardNumber(string inputString)
        {


            var checksum = 0;
            var doubleDigit = false;

            var chars = inputString.ToCharArray();
            for (var i = chars.Length - 1; i > -1; i--)
            {
                var j = chars[i] ^ 0x30;

                checksum += j;

                if (doubleDigit)
                {
                    checksum += Deltas[j];
                }

                doubleDigit = !doubleDigit;
            }

            return ChecksumAnswers[checksum];
        }
    }
}
