using PointOfSale.Application.Interfaces;
using System.Security.Cryptography;

namespace PointOfSale.Application.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        private const int SaltSize = 16; 
        private const int KeySize = 32;  
        private const int Iterations = 10000; 
        private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;
        public string HashPassword(string password)
        {
            
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string[] parts = hashedPassword.Split('-');
            if (parts.Length != 2)
            {
                throw new FormatException("Invalid hash format.");
            }
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);
            //return inputHash.SequenceEqual(hash); //This is not a constant time comparison and is vulnerable to timing attacks.
            return CryptographicOperations.FixedTimeEquals(inputHash, hash); //This is a constant time comparison and is not vulnerable to timing attacks.
        }
    }
}
