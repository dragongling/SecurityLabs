using System.Numerics;
using System.Security.Cryptography;

namespace MetalWorker.Cryptography
{
    public class FermatPT : IPrimalityTester
    {
        public bool IsPrime(BigInteger number, int certainty)
        {
            //filtering input
            if (number == 2)
                return true;
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            for (int i = 0; i < certainty; ++i)
            {
                BigInteger a = rng.NextBigInteger(2, number - 2);
                if (BigInteger.ModPow(a, number - 1, number) != 1)
                    return false;
            }
            return true;
        }
    }
}
