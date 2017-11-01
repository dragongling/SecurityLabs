using System.Numerics;
using System.Security.Cryptography;

namespace MetalWorker.Cryptography
{
    public class MillerRabinPT : IPrimalityTester
    {
        public bool IsPrime(BigInteger m, int certainty)
        {
            //Фильтрация ввода
            if (m == 2 || m == 3)
                return true;
            if (m < 2 || m % 2 == 0)
                return false;

            //m - 1 = 2^s * t
            BigInteger t = m - 1;
            int s = 0;

            while (t % 2 == 0)
            {
                t /= 2;
                s += 1;
            }

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            //Цикл A
            for (int i = 0; i < certainty; i++)
            {
                BigInteger a = rng.NextBigInteger(2, m - 2);

                //x = a^t mod m
                BigInteger x = BigInteger.ModPow(a, t, m);
                if (x == 1 || x == m - 1)
                    continue;

                //Цикл B
                for (int r = 1; r < s; r++)
                {
                    //x = x^2 mod m
                    x = BigInteger.ModPow(x, 2, m);
                    if (x == 1)
                        return false;
                    if (x == m - 1)
                        break;
                }

                if (x != m - 1)
                    return false;
            }

            return true;
        }
    }
}
