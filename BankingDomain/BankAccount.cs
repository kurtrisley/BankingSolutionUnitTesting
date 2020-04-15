﻿using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal balance = 1200;
        public decimal GetBalance()
        {
            return balance;
        }

        // virtual = overrideable
        public virtual void Deposit(decimal amountToDeposit)
        {
            balance += amountToDeposit;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            balance -= amountToWithdraw;
        }
    }
}