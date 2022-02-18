using Banks.Core.SystemObjects.Types.BankObjects;
using Banks.Core.Abstructions;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts.AccountObjects;
using Banks.Core.Enums;
using Banks.Core.SystemObjects.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banks
{
    internal static class Program
    {
        private static CentralBank CentralBank = new CentralBank();

        private static BankCondition BankConditionCreation()
        {

            Console.WriteLine("\t\nSet parameters of bank condition");
            Console.WriteLine("\t\n1) Write debit persent: ");
            double debitPersent = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n2) Write credit commision: ");
            double creditCommision = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n3) Write credit limit: ");
            double creditLimit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n4) Write suspended account limit: ");
            double suspendedAccountLimit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\n5) Write deposit persents(3 pairs): ");
            Dictionary<double, double> depositPersents = new Dictionary<double, double>();
            depositPersents.Add(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            depositPersents.Add(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            depositPersents.Add(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
            return new BankCondition(debitPersent, creditCommision, creditLimit, suspendedAccountLimit, depositPersents);
        }

        private static Client ClientCreateMenu()
        {
            Console.WriteLine("\nHow set your new client\n");
            Console.WriteLine("1) Write your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\n2) Write your surname: ");
            string surname = Console.ReadLine();
            Client client = new Client(name, surname);
            Console.WriteLine("\nDo you want to add more info?\n1) Yes, i want to add all needed info(address, passportId)\n2) Yes, but i set only address\n3) Yes, but i set only passportId\n4) No");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("1) Write your address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine("\n2) Write your passportId: ");
                        string passportId = Console.ReadLine();
                        client.AddAddress(address);
                        client.AddPassportId(passportId);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("1) Write your address: ");
                        string address = Console.ReadLine();
                        client.AddAddress(address);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("\n1) Write your passportId: ");
                        string passportId = Console.ReadLine();
                        client.AddPassportId(passportId);
                        break;
                    }
                case "4":
                    {
                        break;
                    }
                default:
                    Console.WriteLine("\nWrong");
                    break;
            }
            client.StatusCheck();
            return client;
        }

        private static IAccount AccountCreateMenu(Client client, Bank bank)
        {
            Console.WriteLine("\nChoose your account type:\n1) Credit\n2) Debit\n3) Deposit");
            IAccount account;
            switch(Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("\n1) Write amount of money you want to open an account: ");
                        account = bank.AddCreditAccount(client, Convert.ToDouble(Console.ReadLine()));
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("\n1) Write amount of money you want to open an account: ");
                        account = bank.AddDebitAccount(client, Convert.ToDouble(Console.ReadLine()));
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("\n1) Write amount of money you want to open an account: ");
                        double sum = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine(("\n2) Write end date of the contract: "));
                        account = bank.AddDepositAccount(client, sum, Convert.ToDateTime(Console.ReadLine()));
                        break;
                    }
                default :
                    Console.WriteLine("\nWarning: you need to create the account!");
                    account = AccountCreateMenu(client, bank);
                    break;
            }
            return account;
        }

        private static void AccountMenu(IAccount account1, IAccount account2)
        {
            Console.WriteLine("\nChoose what you need: \n1) Replenish \n2) Withdraw \n3) Transfer");
            switch(Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("\n1) Write amount you want top up: ");
                        account1.Replenishment(Convert.ToDouble(Console.ReadLine()));
                        Console.WriteLine("\nSuccesfuly, your account amount: ");
                        account1.ShowValueAmount();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("\n1) Write amount you want withdraw: ");
                        account1.Withdrawal(Convert.ToDouble(Console.ReadLine()));
                        Console.WriteLine("\nSuccesfuly, your account amount: ");
                        account1.ShowValueAmount();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("\n1) Write amount you want to transfer: ");
                        double sum = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\n2) This version have only one account what you can transfer with");
                        account1.Transfer(sum, account2);
                        Console.WriteLine("\nSuccesfuly, your account amount: ");
                        account1.ShowValueAmount();
                        break;
                    }
                default:
                    Console.WriteLine("Wrong answer");
                    AccountMenu(account1, account2);
                    break;
            }
        }

        private static void Main()
        {
            Console.WriteLine("\tYou must set the program's operating conditions");
            Console.WriteLine("\n\tBegin with, we will create our own bank and enter it into the Centralbank");
            BankCondition bankCondition = BankConditionCreation();
            Console.WriteLine("\nNow you should to set the name of bank:");
            CentralBank.CreateBank(Console.ReadLine(), bankCondition);
            Console.WriteLine("\nBank created successfully");
            Bank bank1 = CentralBank.GetBanksList()[0];
            Client client1 = ClientCreateMenu();
            CentralBank.AddBankClient(bank1, client1);
            Console.WriteLine("\nYou successfully add to the bank");
            Console.WriteLine("\nNow you should to add client account");
            IAccount account1 = AccountCreateMenu(client1, bank1);
            //
            CentralBank.CreateBank("Sberbank", bankCondition);
            Client client2 = new Client("Sber", "Kot", "vk", "1337");
            CentralBank.AddBankClient(CentralBank.GetBanksList()[1], client2);
            IAccount account2 = CentralBank.GetBanksList()[1].AddDebitAccount(client2, 0);
            //
            Console.WriteLine("\nNow you have to do some transaction with your account!");
            AccountMenu(account1, account2);
        }
    }
}
