using System.Numerics;

namespace MetalWorker.Cryptography
{
    public class BrutePT : IPrimalityTester
    {
        public bool IsPrime(BigInteger number, int certainty)
        {
            if (number % 2 == 0)
                return false;

            //Нечётные от 3 до половины, квадратный корень в BigInteger сложен
            for (BigInteger i = 3; i < number / 2; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
