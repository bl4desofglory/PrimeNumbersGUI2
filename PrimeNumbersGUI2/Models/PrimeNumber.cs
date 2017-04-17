using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbersGUI2.Models
{
    public class PrimeNumber
    {
        int keyPrimeNumber = 1;
        int valuePrimeNumber = 2;

        public int GetValue()
        {
            return valuePrimeNumber;
        }

        public int GetKey()
        {
            return keyPrimeNumber;
        }

        public void Find(int endKeyPrimeNumber)
        {
            if (endKeyPrimeNumber < keyPrimeNumber)
            {
                keyPrimeNumber = 1;
                valuePrimeNumber = 2;
            }
        
            while (endKeyPrimeNumber != keyPrimeNumber)
            {
                FindNextPrime(valuePrimeNumber);
            }
        }

        public void FindNextPrime(int actualPrimeNumber)
        {
            int integear = actualPrimeNumber + 1;
            while (true)
            {
                if (IsPrime(integear))
                {
                    keyPrimeNumber++;
                    valuePrimeNumber = integear;
                    break;
                }

                integear++;
            }
        }

        public bool IsPrime(int inputInteger)
        {
            int divisors = 0;

            for (int i = 1; i <= Math.Sqrt(inputInteger); i++)
            {
                if (inputInteger % i == 0)
                    divisors++;

                if (divisors > 1)
                    return false;
            }

            return true;
        }
    }
}
