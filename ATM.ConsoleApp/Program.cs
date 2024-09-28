using System;
using ATM.CredentialCheck;
using ATM.CheckBalance;
using ATM.DebitAmount;
using ATM.CreditAmount;

namespace ATM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var credentialService = new CredentialService();
            Console.WriteLine("Welcome to the ATM");
            Console.Write("Enter card number: ");
            var cardNumber = Console.ReadLine();
            Console.Write("Enter PIN: ");
            var pin = ReadPin();

            if (!credentialService.ValidateCredentials(cardNumber, pin))
            {
                Console.WriteLine("Invalid card number or PIN. Exiting.");
                return;
            }

            decimal initialBalance = 1000m;
            var balanceService = new BalanceService(initialBalance);
            var debitService = new DebitService(initialBalance);
            var creditService = new CreditService(initialBalance);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Debit Amount");
                Console.WriteLine("3. Credit Amount");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your balance is: {balanceService.GetBalance():C}");
                        break;
                    case "2":
                        Console.Write("Enter amount to debit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal debitAmount))
                        {
                            if (debitService.Debit(debitAmount))
                            {
                                Console.WriteLine("Amount debited successfully.");
                                Console.WriteLine($"New balance: {debitService.GetBalance():C}");
                                // Update the balance in other services to maintain consistency
                                balanceService.SetBalance(debitService.GetBalance());
                                creditService.SetBalance(debitService.GetBalance());
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter amount to credit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal creditAmount))
                        {
                            creditService.Credit(creditAmount);
                            Console.WriteLine("Amount credited successfully.");
                            Console.WriteLine($"New balance: {creditService.GetBalance():C}");
                            // Update the balance in other services to maintain consistency
                            balanceService.SetBalance(creditService.GetBalance());
                            debitService.SetBalance(creditService.GetBalance());
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount.");
                        }
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // Method to read PIN without displaying it on the console
        private static string ReadPin()
        {
            string pin = "";
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (char.IsDigit(keyInfo.KeyChar))
                {
                    pin += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pin.Length > 0)
                {
                    pin = pin.Substring(0, pin.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pin;
        }
    }
}
