using System;
using UnityEngine;

namespace Resources.Cash
{
    public class CashComponent
    {
        public double CashAmount { get; private set; }
        public double AddCash(double amount)
        {
            CashAmount = Math.Max(0, CashAmount += amount);
            return CashAmount;
        }
    }
}