using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4
{
    public class MealBudgetCalculator
    {
        private const int MaxMeals = 21;
        private const double MaxLimit = 1000.0;

        // Main calculator method
        public BudgetResult EvaluatePlan(
            List<double> mealCosts,
            BudgetMode mode,
            double limit)
        {
            ValidateInput(mealCosts, limit);

            BudgetResult result = new BudgetResult();
            
            if (mealCosts.Count == 0)
            {
                result.Fits = true;
                return result;
            }

            if (mode == BudgetMode.PerMeal)
            {
                result.OverBudgetMeals = GetOverBudgetMeals(mealCosts, limit);
                result.Fits = result.OverBudgetMeals.Count == 0;
            }
            else
            {
                double total = CalculateTotal(mealCosts);

                result.Fits = total <= limit;
                result.RemainingBudget = limit - total;

                if (result.Fits)
                {
                    result.CloseToLimit = IsCloseToLimit(total, limit);
                }
            }

            return result;
        }

        // Helper #1
        private void ValidateInput(List<double> mealCosts, double limit)
        {
            // NULL GUARD ADDED FOR PART 3
            if (mealCosts == null)
            {
                throw new ArgumentNullException(nameof(mealCosts));
            }
            if (limit <= 0 || limit > MaxLimit)
            {
                throw new ArgumentException(
                    "Limit must be greater than $0 and at most $1,000.");
            }

            if (mealCosts.Count > MaxMeals)
            {
                throw new ArgumentException(
                    "A plan cannot contain more than 21 meals.");
            }

            foreach (double cost in mealCosts)
            {
                if (cost < 0)
                {
                    throw new ArgumentException(
                        "Meal costs cannot be negative.");
                }
            }
        }

        // Helper #2
        private double CalculateTotal(List<double> mealCosts)
        {
            return mealCosts.Sum();
        }

        // Helper #3
        private List<double> GetOverBudgetMeals(
            List<double> mealCosts,
            double limit)
        {
            return mealCosts.Where(cost => cost > limit).ToList();
        }

        // Helper #4
        private bool IsCloseToLimit(double total, double limit)
        {
            return total >= (limit * 0.90) && total <= limit;
        }
    }
}
