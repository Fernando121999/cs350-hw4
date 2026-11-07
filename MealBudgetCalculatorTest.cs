using NUnit.Framework;
using Homework4;
using System;
using System.Collections.Generic;

namespace Homework4.Tests
{
    [TestFixture]
    public class MealBudgetCalculatorTests
    {
        private MealBudgetCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new MealBudgetCalculator();
        }
        [Test]
        public void NullMealList_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                calculator.EvaluatePlan(
                    null,
                    BudgetMode.PerMeal,
                    100));
        }

        [Test]
        public void EmptyMealList_ShouldFit()
        {
            var result = calculator.EvaluatePlan(
                new List<double>(),
                BudgetMode.PerMeal,
                100);

            Assert.That(result.Fits, Is.True);
        }

        [Test]
        public void LimitZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
                calculator.EvaluatePlan(
                    new List<double> { 10 },
                    BudgetMode.PerMeal,
                    0));
        }

        [Test]
        public void LimitOver1000_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
                calculator.EvaluatePlan(
                    new List<double> { 10 },
                    BudgetMode.PerMeal,
                    1001));
        }

        [Test]
        public void NegativeMealCost_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
                calculator.EvaluatePlan(
                    new List<double> { -5 },
                    BudgetMode.PerMeal,
                    100));
        }

        [Test]
        public void MoreThan21Meals_ShouldThrowException()
        {
            var meals = new List<double>();

            for (int i = 0; i < 22; i++)
            {
                meals.Add(10);
            }

            Assert.Throws<ArgumentException>(() =>
                calculator.EvaluatePlan(
                    meals,
                    BudgetMode.PerMeal,
                    100));
        }

        [Test]
        public void PerMeal_NoOverBudgetMeals_ShouldFit()
        {
            var result = calculator.EvaluatePlan(
                new List<double> { 10, 15, 20 },
                BudgetMode.PerMeal,
                25);

            Assert.That(result.Fits, Is.True);
        }

        [Test]
        public void PerMeal_WithOverBudgetMeal_ShouldNotFit()
        {
            var result = calculator.EvaluatePlan(
                new List<double> { 10, 30 },
                BudgetMode.PerMeal,
                20);

            Assert.That(result.Fits, Is.False);
            Assert.That(result.OverBudgetMeals.Count, Is.EqualTo(1));
        }

        [Test]
        public void PerWeek_UnderBudget_ShouldFit()
        {
            var result = calculator.EvaluatePlan(
                new List<double> { 20, 30 },
                BudgetMode.PerWeek,
                100);

            Assert.That(result.Fits, Is.True);
        }

        [Test]
        public void PerWeek_CloseToLimit_ShouldBeTrue()
        {
            var result = calculator.EvaluatePlan(
                new List<double> { 95 },
                BudgetMode.PerWeek,
                100);

            Assert.That(result.CloseToLimit, Is.True);
        }

        [Test]
        public void PerWeek_OverBudget_ShouldNotFit()
        {
            var result = calculator.EvaluatePlan(
                new List<double> { 120 },
                BudgetMode.PerWeek,
                100);

            Assert.That(result.Fits, Is.False);
        }
    }
}