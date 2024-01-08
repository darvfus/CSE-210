using System;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name ");// console write is imput 
        string name =Console.ReadLine();

         Console.Write("What is your last name ");// console write is imput 
        string surname =Console.ReadLine();

        Console.WriteLine($"Your name is {surname}, {name} {surname} ");
    }
}