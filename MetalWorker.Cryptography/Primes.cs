using System;
using System.Numerics;
using System.Security.Cryptography;

namespace MetalWorker.Cryptography
{
    /// <summary>
    /// Class for working with primes
    /// </summary>
    public static class Primes
    {
        public static BigInteger GetRandom(RandomNumberGenerator rng, uint bytesCount)
        {
            //Certainty 4 gives 
            const int certainty = 4;
            BigInteger upperBound = rng.NextUnsignedBigInteger(bytesCount, 3);

            if (upperBound % 2 == 0)
                upperBound--;
            for (; upperBound >= 2; upperBound -= 2)
            {
                if (new MillerRabinPT().IsPrime(upperBound, certainty))
                    return upperBound;
            }
            throw new Exception("Primes not found");
        }

        public static BigInteger GetRandom(RandomNumberGenerator rng, uint bytesCount, BigInteger maxValue)
        {
            BigInteger result;
            do
            {
                result = GetRandom(rng, bytesCount);
            } while (result > maxValue);
            return result;
        }
    }
}
