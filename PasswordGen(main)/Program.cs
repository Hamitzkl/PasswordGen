using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Password Generator");

        Console.Write("Enter the length of the password: ");
        int length = int.Parse(Console.ReadLine());

        string password = GeneratePassword(length);

        Console.WriteLine("Generated Password: " + password);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static string GeneratePassword(int length)
    {
        const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_-+=<>?/[]{}|";

        Random random = new Random();
        char[] password = new char[length];

        // Ensure at least one uppercase, one lowercase, one number, and one special character
        password[0] = uppercaseChars[random.Next(uppercaseChars.Length)];
        password[1] = lowercaseChars[random.Next(lowercaseChars.Length)];
        password[2] = numberChars[random.Next(numberChars.Length)];
        password[3] = specialChars[random.Next(specialChars.Length)];

        // Fill the rest of the password with random characters
        for (int i = 4; i < length; i++)
        {
            string validChars = uppercaseChars + lowercaseChars + numberChars + specialChars;
            password[i] = validChars[random.Next(validChars.Length)];
        }

        // Shuffle the password characters
        for (int i = length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            char temp = password[i];
            password[i] = password[j];
            password[j] = temp;
        }

        return new string(password);
    }
}
