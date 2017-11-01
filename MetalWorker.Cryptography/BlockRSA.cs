using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

namespace MetalWorker.Cryptography
{
    /// <summary>
    /// Block RSA cryptosystem implementation
    /// </summary>
    public static class BlockRSA
    {
        public static KeyData<BigInteger> GenerateKeys(uint bytesCount)
        {
            Random rng = new Random();
            RNGCryptoServiceProvider cryptoRNG = new RNGCryptoServiceProvider();
            BigInteger p = Primes.GetRandom(cryptoRNG, bytesCount),
                q = Primes.GetRandom(cryptoRNG, bytesCount);
            
            var N = p * q;
            BigInteger phi = (p - 1) * (q - 1);
            
            return FindED_RandomE(N, phi);
        }

        public static byte[] Encrypt(byte[] msg, Key<BigInteger> encKey)
        {
            
            List<byte> result = new List<byte>();
            int cipherBlockSize = encKey.N.ToByteArray().Length;

            /* Oops, we accidentally implemented block RSA (>_<)
             * In original RSA message size should be < N size:
             * https://stackoverflow.com/questions/5866129/rsa-encryption-problem-size-of-payload-data */
            int msgBlockSize = cipherBlockSize - 1;
            msg = CompleteToFullBlocks(msg, msgBlockSize);

            for (int i = 0; i < msg.Length; i += msgBlockSize)
            {
                byte[] block = new byte[msgBlockSize];
                Array.Copy(msg, i, block, 0, msgBlockSize);
                BigInteger value = new BigInteger(block);

                byte[] r = new byte[cipherBlockSize]; //For alignment
                var s = BigInteger.ModPow(value, encKey.ED, encKey.N).ToByteArray();
                Array.Copy(s, r, s.Length); //For alignment

                result.AddRange(r);
            }
            return result.ToArray();
        }

        public static byte[] Decrypt(byte[] cipher, Key<BigInteger> decKey)
        {
            List<byte> result = new List<byte>();
            int blockSize = decKey.N.ToByteArray().Length;

            for (int i = 0; i < cipher.Length; i += blockSize)
            {
                byte[] block = new byte[blockSize];
                Array.Copy(cipher, i, block, 0, blockSize);
                BigInteger value = new BigInteger(block);

                result.AddRange(BigInteger.ModPow(value, decKey.ED, decKey.N).ToByteArray());
            }
            return result.ToArray();
        }

        private static byte[] CompleteToFullBlocks(byte[] arr, int blockSize)
        {
            int diff = arr.Length % blockSize;
            if (diff != 0)
            {
                byte[] temp = new byte[arr.Length + (blockSize - diff)];
                Array.Copy(arr, temp, arr.Length);
                arr = temp;
            }
            return arr;
        }
        
        static KeyData<BigInteger> FindED_RandomE(BigInteger N, BigInteger phi)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            KeyData<BigInteger> keyData = new KeyData<BigInteger> { N = N };
            do
            {
                keyData.E = Primes.GetRandom(rng, (uint)phi.ToByteArray().Length, phi);
                if (phi % keyData.E == 0)
                    continue;
                keyData.D = ExtendedEuclide(keyData.E % phi, phi).u1;
            } while (keyData.D < 0);
            return keyData;
        }

        private static ExtendedEuclideanResult<BigInteger> ExtendedEuclide(BigInteger a, BigInteger b)
        {
            BigInteger u1 = BigInteger.One;
            BigInteger u3 = a;
            BigInteger v1 = BigInteger.Zero;
            BigInteger v3 = b;

            while (v3 > 0)
            {
                BigInteger q0 = u3 / v3;
                BigInteger q1 = u3 % v3;

                BigInteger tmp = v1 * q0;
                BigInteger tn = u1 - tmp;
                u1 = v1;
                v1 = tn;

                u3 = v3;
                v3 = q1;
            }

            BigInteger tmp2 = u1 * (a);
            tmp2 = u3 - (tmp2);
            BigInteger res = tmp2 / (b);

            ExtendedEuclideanResult<BigInteger> result = new ExtendedEuclideanResult<BigInteger>()
            {
                u1 = u1,
                u2 = res,
                gcd = u3
            };

            return result;
        }

        /// <summary>
        /// Contains all key-related data (including private)
        /// </summary>
        public struct KeyData<IntegerType>
        {
            public IntegerType N, E, D;

            public KeyData(IntegerType N, IntegerType E, IntegerType D)
            {
                this.N = N;
                this.E = E;
                this.D = D;
            }

            public Key<IntegerType> GetOpenKey()
            {
                return new Key<IntegerType>(N, E);
            }

            public Key<IntegerType> GetPrivateKey()
            {
                return new Key<IntegerType>(N, D);
            }
        }

        /// <summary>
        /// Single open or private key
        /// </summary>
        public struct Key<IntegerType>
        {
            public IntegerType N, ED;

            public Key(IntegerType N, IntegerType ED)
            {
                this.N = N;
                this.ED = ED;
            }
        }

        private struct ExtendedEuclideanResult<IntType>
        {
            public IntType u1;
            public IntType u2;
            public IntType gcd;
        }
    }
}