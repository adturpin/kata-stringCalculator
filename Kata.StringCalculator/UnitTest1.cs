using NUnit.Framework;

namespace Kata.Calculator
{
    public class Tests
    {
        [Test]
        public void Should_return_zero_when_string_empty()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("");
            Assert.AreEqual("0", result);
        }

        [Test]
        public void Should_return_number_with_one_number_in_string()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("5");
            Assert.AreEqual("5", result);
        }

        // decimal
        [Test]
        public void Should_return_decimalNumber_with_one_number_in_string()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("5.3");
            Assert.AreEqual("5.3", result);
        }


        //plusieurs nombres
        [Test]
        public void Should_return_sum_of_numbers_with_two_Int_numbers()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("3,7");
            Assert.AreEqual("10", result);
        }

        [Test]
        public void Should_return_sum_of_numbers_with_two_decimal_numbers()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("3.1,6.6");
            Assert.AreEqual("9.7", result);
        }

        [Test]
        public void Should_return_sum_of_numbers_with_two_Mixted_numbers()
        {
            StringCalculator calculator = new StringCalculator();
            var result = calculator.add("3.1,6");
            Assert.AreEqual("9.1", result);
        }

    }

    internal class StringCalculator
    {
        private const string DEFAULT_VALUE = "0";
        private const char SEPARATOR = ',';

        internal string add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return DEFAULT_VALUE;

            var splitedNumbers = numbers.Split(SEPARATOR);
            if (HaveOneNumber(splitedNumbers))
                return numbers;

            var sum = decimal.Parse(splitedNumbers[0]) + decimal.Parse(splitedNumbers[1]);
            return sum.ToString();
        }

        private static bool HaveOneNumber(string[] splitedNumbers)
        {
            return splitedNumbers.Length == 1;
        }
    }
}