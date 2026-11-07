using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4
{
    // Small data class
    public class BudgetResult
    {
        public bool Fits { get; set; }
        public double RemainingBudget { get; set; }
        public bool CloseToLimit { get; set; }
        public List<double> OverBudgetMeals { get; set; }

        public BudgetResult()
        {
            OverBudgetMeals = new List<double>();
        }
    }
}
