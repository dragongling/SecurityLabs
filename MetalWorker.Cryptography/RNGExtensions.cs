using System;
using System.Numerics;
using System.Security.Cryptography;

namespace MetalWorker.Cryptography
{
    /// <summary>
    /// Extensions for RandomNumberGenerator to easily create random BigIntegers
    /// </summary>
    public static class RandomNumberGeneratorExtensions
    {
        public static BigInteger NextBigInteger(this RandomNumberGenerator rng, BigInteger minValue, BigInteger maxValue)
        {
            return minValue + NextBigInteger(rng, maxValue - minValue);
        }

        public static BigInteger NextBigInteger(this RandomNumberGenerator rng, BigInteger bound)
        {
            //Get a byte buffer capable of holding any value below the bound
            var buffer = (bound << 16).ToByteArray(); // << 16 adds two bytes, which decrease the chance of a retry later on

            //Compute where the last partial fragment starts, in order to retry if we end up in it
            var generatedValueBound = BigInteger.One << (buffer.Length * 8 - 1); //-1 accounts for the sign bit
            var validityBound = generatedValueBound - generatedValueBound % bound;

            while (true)
            {
                //generate a uniformly random value in [0, 2^(buffer.Length * 8 - 1))
                rng.GetBytes(buffer);
                buffer[buffer.Length - 1] &= 0x7F; //force sign bit to positive
                var r = new BigInteger(buffer);

                //return unless in the partial fragment
                if (r >= validityBound) continue;
                return r % bound;
            }
        }

        public static BigInteger NextUnsignedBigInteger(this RandomNumberGenerator rng, uint bytesCount)
        {
            if (bytesCount == 0)
                throw new ArgumentException();
            var buffer = new byte[bytesCount];
            rng.GetBytes(buffer);
            buffer[buffer.Length - 1] &= 0x7F; //force sign bit to positive
            return new BigInteger(buffer);
        }

        public static BigInteger NextUnsignedBigInteger(this RandomNumberGenerator rng, uint bytesCount, BigInteger min)
        {
            BigInteger result;
            do
            {
                result = rng.NextUnsignedBigInteger(bytesCount);
            } while (result < min);
            return result;
        }

        public static BigInteger NextUnsignedBigInteger(this RandomNumberGenerator rng, uint bytesCount, BigInteger min, BigInteger max)
        {
            BigInteger result;
            do
            {
                result = rng.NextUnsignedBigInteger(bytesCount);
            } while (result < min || result > max);
            return result;
        }
    }
}
