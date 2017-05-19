using System;

namespace PasswordGeneratorCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the PasswordGenerator (which is a .NET Framework package)
            var pwGen = new PasswordGenerator()
            // use PasswordGenerator's Fluent Api to include the character options
                            .IncludeLowercase()
                            .IncludeNumeric()
                            .IncludeSpecial()
                            .IncludeUppercase();
            // generate a password using the .NET Framework package
            var newPassword = pwGen.Next();

            Console.WriteLine($"Generated password is: {newPassword}");
        }
    }
}
