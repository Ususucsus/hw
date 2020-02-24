using System;

namespace Task23
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testStackList = new StackList();
            var testStackCalculatorViaStackList = new StackCalculator(testStackList);
            testStackCalculatorViaStackList.Push(6);
            testStackCalculatorViaStackList.Push(2);
            testStackCalculatorViaStackList.Divide();
            testStackCalculatorViaStackList.Push(2);
            testStackCalculatorViaStackList.Add();
            Console.WriteLine(testStackCalculatorViaStackList.Pop());
            
            var testStackArray = new StackArray();
            var testStackCalculatorViaStackArray = new StackCalculator(testStackArray);
            testStackCalculatorViaStackArray.Push(6);
            testStackCalculatorViaStackArray.Push(2);
            testStackCalculatorViaStackArray.Divide();
            testStackCalculatorViaStackArray.Push(2);
            testStackCalculatorViaStackArray.Add();
            Console.WriteLine(testStackCalculatorViaStackArray.Pop());

        }
    }
}
