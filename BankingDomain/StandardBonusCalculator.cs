﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardBonusCalculator : ICalculateAccountBonuses
    {
        // Poor-Person's Dependency Injection
        ISystemTime TheSystemTime;

        public StandardBonusCalculator(ISystemTime theSystemTime) // For Testing
        {
            TheSystemTime = theSystemTime;
        }

        public StandardBonusCalculator() // For Realz
        {
            TheSystemTime = new SystemTime();
        }

        public decimal CalculateBonusUsingStandardAlgorithm(decimal balance, decimal amount)
        {
            // If the balance is above a certain cutoff & the time is before the close of day
            // they get a 10% bonus on deposits. If it is above the cutoff, and after they close
            // of the day, they get 5%
            if (hasBonusWorthyBalance(balance) && BeforeCutoff())
            {
                return amount * .10M;
            }
            if (hasBonusWorthyBalance(balance))
            {
                return amount * .05M;
            }
            return 0;
        }

        private bool hasBonusWorthyBalance(decimal balance)
        {
            return balance > 10000;
        }

        // extract and override pattern from Michael Feathers WEWLC
        private bool BeforeCutoff()
        {
            return TheSystemTime.GetCurrent().Hour <=16;
        }

        decimal ICalculateAccountBonuses.GetDepositBonusFor(decimal balance, decimal amoutToDeposit)
        {
            return CalculateBonusUsingStandardAlgorithm(balance, amoutToDeposit);
        }
    }
}