using System.Numerics;

namespace MetalWorker.Cryptography
{
    public interface IPrimalityTester
    {
        bool IsPrime(BigInteger number, int certainty);
    }
}
