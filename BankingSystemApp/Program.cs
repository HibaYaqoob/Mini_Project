
using System.Security.Principal;

namespace BankingSystemApp
{
    internal class Program
    {
        // Shared data storage - all functions can access these lists
        static List<string> customerNames = new List<string>();
        static List<string> accountNumbers = new List<string>();
        static List<double> balances = new List<double>();

        static void Main(string[] args)
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.WriteLine("\n===== Welcome to Spark Bank =====");
                Console.WriteLine("1. Add New Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Show Balance");
                Console.WriteLine("5. Transfer Amount");
                Console.WriteLine("6. Display All Accounts");
                Console.WriteLine("7. Search Customer Account");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");

                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 8.");
                    continue; // skip the rest of this loop pass, show the menu again
                }
                switch (choice)
                {
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        DepositMoney();
                        break;
                    case 3:
                        WithdrawMoney();
                        break;
                    case 4:
                        ShowBalance();
                        break;
                    case 5:
                        TransferAmount();
                        break;
                    case 6:
                        DisplayAllAccounts();
                        break;
                    case 7:
                        SearchCustomerAccount();                        
                        break;
                    case 8:
                        exitApp = true;
                        Console.WriteLine("Thank you for banking with Spark Bank. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose between 1 and 8.");
                        break;
                }
            }
        }
        // ===================== SERVICE FUNCTIONS =====================
        // Each function owns ONE service end-to-end: it asks the user for
        // whatever it needs, validates it, updates the shared lists, and
        // prints the outcome. Main never reads input or prints results
        // for these services - it only shows the menu and calls them.
        static void AddAccount()
        {
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();

            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            // Check if the account number already exists
            if (accountNumbers.Contains(accountNumber))
            {
                Console.WriteLine("Account number already exists.");
                return;
            }

            double initialBalance;
            try
            {
                Console.Write("Enter the initial deposit: ");
                initialBalance = double.Parse(Console.ReadLine());


                if (initialBalance < 0)
                {
                    Console.WriteLine("Deposit cannot be negative.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            // Add the new account details to the shared lists:
            customerNames.Add(name);
            accountNumbers.Add(accountNumber);
            balances.Add(initialBalance);
            Console.WriteLine("Account created successfully!");
        }

        /// //////////////////////////////////////////////////////////////////

        static void DepositMoney()
        {
            Console.Write("Enter the account number:");
            string accountNumber = Console.ReadLine();

            //Find the account position in the list:
            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            double amount;

            try
            {
                Console.Write("Enter the deposite amonut: ");
                amount = double.Parse(Console.ReadLine());

                if (amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be positive.");
                    return;

                }
            }
            catch
            {
                Console.WriteLine("Invalid amount.");
                return;

            }

            // Update the balance using the same account index:
            balances[index] += amount;

            Console.WriteLine("Deposite Successful.");
            Console.WriteLine("New Balance: " + balances[index]);

        }

        /// //////////////////////////////////////////////////////////////////

        static void WithdrawMoney()
        {
            Console.Write("Enter the account number: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            // Checking if the account exists or not
            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter the withdraw amount: ");
            static void WithdrawMoney()
            {
                Console.Write("Enter the account number: ");
                string accountNumber = Console.ReadLine();

                int index = accountNumbers.IndexOf(accountNumber);

                // Checking if the account exists
                if (index == -1)
                {
                    Console.WriteLine("Account not found.");
                    return;
                }

                Console.Write("Enter the withdraw amount: ");
                double amount;

                if (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Please enter a valid number.");
                    return;
                }

                if (amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be greater than zero.");
                    return;
                }

                if (amount > balances[index])
                {
                    Console.WriteLine("Withdrawal failed. Your balance is not enough.");
                    Console.WriteLine("Available balance: " + balances[index]);
                    return;
                }

                balances[index] -= amount;

                Console.WriteLine("Withdrawal completed successfully.");
                Console.WriteLine("Withdrawn amount: " + amount);
                Console.WriteLine("Remaining balance: " + balances[index]);
            }
            double amount;

            // Check if the input is a valid number
            if (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            // Check if amount is negative or zero
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return;
            }

            // Check if amount is more than the balance
            if (amount > balances[index])
            {
                Console.WriteLine("Insufficient balance. You cannot withdraw more than " + balances[index]);
                return;
            }

            // Withdraw money
            balances[index] -= amount;

            // Display remaining balance
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Your remaining balance is: " + balances[index]);
        }
        /////////////////////////////////////////////////////////////////

        static void ShowBalance()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();


                int index = accountNumbers.IndexOf(accountNumber);


                if (index == -1)
                {
                    Console.WriteLine("Account not found.");
                    return;
                }
                else
                {
                    Console.WriteLine("\n===== Account Details =====");
                    Console.WriteLine("Customer Name: " + customerNames[index]);
                    Console.WriteLine("Account Number: " + accountNumbers[index]);
                    Console.WriteLine("Balance: " + balances[index]);

                }
            }
            
        
            static void TransferAmount()
            {
                Console.Write("Enter sender account number: ");
                string sender = Console.ReadLine();


                Console.Write("Enter receiver account number: ");
                string receiver = Console.ReadLine();


                int senderIndex = accountNumbers.IndexOf(sender);
                int receiverIndex = accountNumbers.IndexOf(receiver);


                if (senderIndex == -1 || receiverIndex == -1)
                {
                    Console.WriteLine("One or both accounts do not exist.");
                    return;
                }


                double amount;


                try
                {
                    Console.Write("Enter transfer amount: ");
                    amount = double.Parse(Console.ReadLine());


                    if (amount <= 0)
                    {
                        Console.WriteLine("Amount must be positive.");
                        return;
                    }


                    if (amount > balances[senderIndex])
                    {
                        Console.WriteLine("Sender does not have enough balance.");
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid amount.");
                    return;
                }


                balances[senderIndex] -= amount;
                balances[receiverIndex] += amount;


                Console.WriteLine("Transfer completed successfully.");
                Console.WriteLine("Sender Balance: " + balances[senderIndex]);
                Console.WriteLine("Receiver Balance: " + balances[receiverIndex]);
            
        }

       
        /// ////////////////////////////////////////////////////////////////////////////////////
        
        // Custom Service 1: Display all bank accounts
        static void DisplayAllAccounts()
        {
            if (accountNumbers.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            Console.WriteLine("\n===== All Bank Accounts =====");

            for (int i = 0; i < accountNumbers.Count; i++)
            {
                Console.WriteLine("Customer Name: " + customerNames[i]);
                Console.WriteLine("Account Number: " + accountNumbers[i]);
                Console.WriteLine("Balance: " + balances[i]);
                Console.WriteLine("-----------------------------");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        // Custom Service 2: Search account by account number
        static void SearchCustomerAccount()
        {
            Console.Write("Enter account number to search: ");
            string accountNumber = Console.ReadLine();

            int index = accountNumbers.IndexOf(accountNumber);

            if (index == -1)
            {
                Console.WriteLine("Account not found.");
                return;
            }
            else
            {


                Console.WriteLine("\n===== Account Found =====");
                Console.WriteLine("Customer Name: " + customerNames[index]);
                Console.WriteLine("Account Number: " + accountNumbers[index]);
                Console.WriteLine("Balance: " + balances[index]);
            }
        }
    }
}
