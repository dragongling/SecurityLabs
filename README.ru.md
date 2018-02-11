# SecurityLabs
Лабораторные работы для [Оренбургского Государственного Университета](http://osu.ru) по информационной безопасности
* [MetalWorker.Cryptography](MetalWorker.Cryptography) - содержит вспомогательные классы
  * Различные [методы для проверки чисел на простоту](MetalWorker.Cryptography/PrimalityTesters)
  * [Генератор случайных BigInteger](MetalWorker.Cryptography/RNGExtensions.cs)
  * [Генератор случайных простых BigInteger](MetalWorker.Cryptography/Primes.cs)
  * [Реализация блочного RSA](MetalWorker.Cryptography/BlockRSA.cs)
  * [StringRSA](MetalWorker.Cryptography/StringRSA.cs) - обёртка блочного RSA для строк
* [PrimalityTests](PrimalityTests) - программа для проверки чисел на простоту различными методами
* [BlockRSA_GUI](BlockRSA_GUI) - GUI клиент для шифрования строк блочным RSA
* [Digital Signature](Digital%20signature) - GUI приложение для цифровой подписи файлов с помощью RSACryptoServiceProvider
* [AccessControlMatrix](AccessControlMatrix) - CLI симулятор матричной модели доступа пользователей к файлам
* [DES](DES) - Форк [проекта на cyberforum от VV_RIP](http://www.cyberforum.ru/csharp-net/thread1120037.html), я пересобрал для VS2017 и добавил GUI
