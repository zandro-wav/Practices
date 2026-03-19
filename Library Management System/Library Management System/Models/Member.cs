using System;
using System.Collections.Generic;
using System.Text;
namespace Library_Management_System.Models;
public class Member
{
    public int Id;
    public string FirstName;
    public string LastName;
    public string Age;
    public string Email;
    public string PersonalNumber;
    public DateTime CreatedOn;

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {FirstName} {LastName}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Personal Number: {PersonalNumber}");
        Console.WriteLine($"Created On: {CreatedOn.Date.ToShortDateString()}");
        Console.WriteLine("---------------------");
    }
}

