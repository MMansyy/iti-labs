using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{

    interface IPrintable
    {
        void PrintDetails();
    }

    interface ITransactable
    {
        void Deposit(double amount);
        void Withdraw(double amount);
    }


    internal abstract class Account : IPrintable, ITransactable
    {
        public string AccountNumber { get; }
        public string OwnerName { get; set; }
        public double Balance { get; protected set; }

        protected Account(string accountNumber, string ownerName, double balance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = balance;
        }
        public abstract double CalculateInterest();

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
                Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
                Balance -= amount;
        }

        public void ApplyInterest()
        {
            Balance += CalculateInterest();
        }

        public virtual void PrintDetails()
        {
            Console.WriteLine(
                $"Account: {AccountNumber}, Owner: {OwnerName}, Balance: {Balance}"
            );
        }
    }

    class SavingsAccount : Account
    {
        private double interestRate;
        private double minimumBalance;

        public SavingsAccount(
            string accountNumber,
            string ownerName,
            double balance,
            double interestRate,
            double minimumBalance
        ) : base(accountNumber, ownerName, balance)
        {
            this.interestRate = interestRate;
            this.minimumBalance = minimumBalance;
        }

        public override double CalculateInterest()
        {
            return Balance * interestRate;
        }

        public override void Withdraw(double amount)
        {
            if (Balance - amount >= minimumBalance)
                Balance -= amount;
            else
                Console.WriteLine("Cant withdraw");
        }
    }


    class CheckingAccount : Account
    {
        private double overdraftLimit;

        public CheckingAccount(
            string accountNumber,
            string ownerName,
            double balance,
            double overdraftLimit
        ) : base(accountNumber, ownerName, balance)
        {
            this.overdraftLimit = overdraftLimit;
        }

        public override double CalculateInterest()
        {
            return 0;
        }

        public override void Withdraw(double amount)
        {
            if (Balance - amount >= -overdraftLimit)
                Balance -= amount;
            else
                Console.WriteLine("limit exceeded");
        }
    }

}
