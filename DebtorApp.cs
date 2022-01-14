using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp
    {
        public BorrowerManager borrowerManager { get; set; } = new BorrowerManager();

        public void IntroduceDebtorApp()
        {
            Console.WriteLine("Hey w aplikacji Dłużnik zapisujemy listę dłużników.");
        }

        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę użytkownika, którego chcesz dodać do listy: ");

            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwotę długu: ");

            var userAmount = Console.ReadLine();

            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Pbrano niepoprawną kwotę");

                Console.WriteLine("Podaj kwotę długu: ");

                userAmount = Console.ReadLine();
            }

            borrowerManager.AddBorrower(userName, amountInDecimal);
        }

        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę użytkownika, którego chcesz usunąć z listy: ");

            var userName = Console.ReadLine();

            borrowerManager.DeleteBorrower(userName);

            Console.WriteLine("Udało się usunąć dłużnika.");
        }

        public void ListAllBorowers()
        {
            Console.WriteLine("Oto lista Twoich dłużników.");

            foreach (var borrower in borrowerManager.ListBorrowers())
            {
                Console.WriteLine(borrower);
            }
        }

        public void AskForAction()
        {
            Console.WriteLine("Podaj czynność jaką chcesz wykonać:");

            var userInput = default(string);

            while (userInput != "exit")
            {
                Console.WriteLine("add - dodawanie dłużnika");
                Console.WriteLine("del - odejmowanie dłużnika");
                Console.WriteLine("list - wypisywanie listy dłużników");
                Console.WriteLine("exit - wyjście z programu");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "list":
                        ListAllBorowers();
                        break;
                    default:
                        Console.WriteLine("Podano złą wartość!!");
                        break;
                }
            }
        }
    }
}
