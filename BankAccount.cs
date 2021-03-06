using System;
using System.Collections.Generic;
using System.Transactions;

namespace firstHelloWorld
{
  public class BankAccount
  {

    private List<Transaction> allTransactions = new List<Transaction>();

    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
      get
      {
        decimal balance = 0;
        foreach (var item in allTransactions)
        {
          balance += item.Amount;
        }
        return balance;
      }
    }
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
      if (amount <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");
      }
      var deposit = new Transaction(amount, date, note);
      allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if (amount <= 0) { throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive."); }
      if (Balance - amount < 0) { throw new InvalidOperationException("Not sufficient funds for this withdrawal."); }
      var withdrawal = new Transaction(-amount, date, note);
      allTransactions.Add(withdrawal);
    }
    public string GetAccountHistory()
    {
      var report = new System.Text.StringBuilder();
      report.AppendLine("Date\t\tAmount\tNote");
      foreach (var item in allTransactions)
      {
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");

      }
      return report.ToString();
    }

    public BankAccount(string name, decimal intitialBalance)
    {
      this.Owner = name;
      MakeDeposit(intitialBalance, DateTime.Now, "Initial balance");
      this.Number = Guid.NewGuid().ToString();
    }
  }

}