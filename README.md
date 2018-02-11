# SecurityLabs
[Orenburg State University](http://osu.ru/doc/666) laboratory works for InfoSec

*[На русском](README.ru.md)*

* [MetalWorker.Cryptography](MetalWorker.Cryptography) - contains utility classes for
  * Various [prime number tester classes](MetalWorker.Cryptography/PrimalityTesters)
  * [Random BigInteger generation](MetalWorker.Cryptography/RNGExtensions.cs)
  * [Random BigInteger prime generation](MetalWorker.Cryptography/Primes.cs)
  * [Block RSA implementation](MetalWorker.Cryptography/BlockRSA.cs)
  * [StringRSA](MetalWorker.Cryptography/StringRSA.cs) - Block RSA wrapper for strings
* [PrimalityTests](PrimalityTests) - program for testing prime numbers with various tests
* [BlockRSA_GUI](BlockRSA_GUI) - GUI client for encrypting strings with block RSA
* [Digital Signature](Digital%20signature) - GUI app for signing files with RSACryptoServiceProvider
* [AccessControlMatrix](AccessControlMatrix) - CLI users to files access control matrix simulator
* [DES](DES) - Project forked from [cyberforum project by VV_RIP](http://www.cyberforum.ru/csharp-net/thread1120037.html), I rebuilt it for VS2017 & added GUI
