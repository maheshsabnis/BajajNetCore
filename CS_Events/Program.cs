// See https://aka.ms/new-console-template for more information
using CS_Events.BankingApp;

Console.WriteLine("Event DEmo");

Banking bank = new Banking(80000);

// Subscribe to Event Notification Receivig
// Passing the Infor to EventNotifier so that
// Notifications from it can be received
EventNotification evt = new EventNotification(bank);


bank.Deposit(50000);
Console.WriteLine($"After Deposit Net Balance = {bank.GetBalance()}");

bank.Withdawal(127000);
Console.WriteLine($"After Withdrawal Net Balance = {bank.GetBalance()}");


Console.ReadLine();


