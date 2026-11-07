namespace Homework4
{
    public class Program
    {
        public static void Main()
        {
            MealBudgetCalculator calculator =
                new MealBudgetCalculator();

            List<double> meals =
                new List<double> { 12, 18, 25, 15 };

            Console.WriteLine("=== Per Meal Mode ===");

            BudgetResult perMealResult =
                calculator.EvaluatePlan(
                    meals,
                    BudgetMode.PerMeal,
                    20);

            Console.WriteLine($"Fits Plan: {perMealResult.Fits}");

            if (perMealResult.OverBudgetMeals.Count > 0)
            {
                Console.WriteLine("Meals over limit:");
                foreach (double meal in perMealResult.OverBudgetMeals)
                {
                    Console.WriteLine($"${meal}");
                }
            }

            Console.WriteLine("\n=== Per Week Mode ===");

            BudgetResult perWeekResult =
                calculator.EvaluatePlan(
                    meals,
                    BudgetMode.PerWeek,
                    80);

            Console.WriteLine($"Fits Plan: {perWeekResult.Fits}");
            Console.WriteLine(
                $"Remaining Budget: ${perWeekResult.RemainingBudget}");

            if (perWeekResult.CloseToLimit)
            {
                Console.WriteLine(
                    "Warning: Total is within 10% of the limit.");
            }
        }
    }
}
