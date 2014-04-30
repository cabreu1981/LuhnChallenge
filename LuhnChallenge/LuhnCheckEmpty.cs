
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuhnChallenge
{
    public class LuhnCheckEmpty : ILuhnCheck
    {
        public bool IsValidCardNumber(string inputString)
        {

            /*

            The formula verifies a number against its included check digit, which is
 *          usually appended to a partial account number to generate the full account number. This account number must pass the following test:
             *          1.	From the rightmost digit, which is the check digit, moving left, double the value of every second digit; if 
             *          product of this doubling operation is greater than 9 (e.g., 7 * 2 = 14), 
             *          then sum the digits of the products (e.g., 10: 1 + 0 = 1, 14: 1 + 4 = 5).
             *          2.	Take the sum of all the digits.
             *          3.	If the total modulo 10 is equal to 0 (if the total ends in zero) // totalModulo%10 = 0
             *          then the number is valid according to the Luhn formula; else it is not valid.

*/

            int totalModulo = 0;
            bool isValid = false;

            //Clean the card number
            var cardNumber = inputString.Replace("-", "").Replace(" ", "");

            //convert the Card Numbers to an array 
            var numbersArray = new int[cardNumber.Length];

            //add the numbers of the cardnumber variable into the numbers array
            for (int i = 0; i < cardNumber.Length; i++)
            {
                numbersArray[i] = Int32.Parse(cardNumber.Substring(i, 1));
            }

            //take the numbers in the Array in backward order
            for (int i = cardNumber.Length-1; i >=0; i--)
            {
                
                //passes the number in the array to be number where we will implement all the operations
                var actualNumber = numbersArray[i];
                
                if (isValid)
                {
                    //multiply the actual number by 2
                    actualNumber *= 2;
                    
                    //check if the actual is greather than 9 if true takes 9 from the actual number 
                    if (actualNumber > 9)
                    {
                        actualNumber -= 9;
                    }

                }
                
                // add the actual number to Mod 10
                totalModulo += actualNumber;
                isValid = !isValid;
            }


            //If Mod 10 is equals 0, the number is good and true
            return totalModulo%10 == 0;
        }
    }
}
