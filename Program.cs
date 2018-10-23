using System;
using System.Collections.Generic;
namespace firstHelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
      // WorkingWithStrings();
      // WorkingWithInts();
      var account = new BankAccount("Joshua", 1000);
      Console.WriteLine($"Account {account.Number} was created for {account.Owner} with ${account.Balance} initial balance.");
      account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
      Console.WriteLine(account.Balance);
      account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
      Console.WriteLine(account.Balance);
      Console.WriteLine(account.GetAccountHistory());
      // Tests
      // try { var invalidAccount = new BankAccount("invalid", -55); } catch (ArgumentOutOfRangeException e) { Console.WriteLine("Exception caught creating account with negative balance"); Console.WriteLine(e.ToString()); }
      // try { account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw"); } catch (InvalidOperationException e) { Console.WriteLine("Exception caught trying to overdraw"); Console.WriteLine(e.ToString()); }
    }
    public static void WorkingWithInts()
    {
      var fibonacciNumbers = new List<int> { 1, 1 };
      for (int i = fibonacciNumbers.Count; i < 20; i++)
      {
        var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
        var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2]; fibonacciNumbers.Add(previous + previous2);
      }
      foreach (var item in fibonacciNumbers) Console.WriteLine(item);
    }
    public static void WorkingWithStrings()
    {
      var names = new List<string> { "Josh", "Ana", "Felipe" };
      Console.WriteLine();
      names.Add("Maria");
      names.Add("Bill");
      names.Remove("Ana"); foreach (var name in names)
      { Console.WriteLine($"Hello {name.ToUpper()}!"); }
      Console.WriteLine($"My name is {names[0]}");
      Console.WriteLine($"I've added {names[2]} and {names[3]} to the list."); Console.WriteLine($"The list has {names.Count} people in it."); var index = names.IndexOf("Felipe");
      if (index == -1)
      { Console.WriteLine($"When an item is not found, IndexOf returns {index}"); }
      else
      { Console.WriteLine($"The name {names[index]} is at index {index}"); }
      index = names.IndexOf("Not Found");
      if (index == -1)
      { Console.WriteLine($"When an item is not found, IndexOf returns {index}"); }
      else
      { Console.WriteLine($"The name {names[index]} is at index {index}"); }
      names.Sort();
      foreach (var name in names)
      { Console.WriteLine($"{name} sorted."); }
    }
  }

}