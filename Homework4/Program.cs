namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new MealBudgetCalculator();

            var result = calculator.EvaluatePlan(
                new List<double> { 10, 15, 12 },
                BudgetMode.PerWeek,
                50);

            Console.WriteLine(result.Fits);
        }
    
}
}
