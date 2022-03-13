using Mart_13_HW.Enums;
using Mart_13_HW.Exceptions;
using Mart_13_HW.Models;
using Mart_13_HW.Services;
using System;
using System.Text.RegularExpressions;

namespace Mart_13_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManager libraryManager = new LibraryManager();
            do
            {
                Console.WriteLine($"\n===== Hello dear user =====\n" + "\n" +
                    $"1. -- Show all Books\n" +
                    $"2. -- Add Book\n" +
                    $"3. -- Filter Book\n" +
                    $"4. -- Search Book by parameters\n" +
                    $"5. -- Show book info\n" +
                    $"6. -- Exit\n" +
                    $"+_+_+_+_+_+_+_+_+_+_+_+_+ ");

                string userchoice = Console.ReadLine();
                byte userchoicenum;

                while (!byte.TryParse(userchoice, out userchoicenum) || userchoicenum < 1 || userchoicenum > 7)
                {
                    Console.WriteLine("\nYou need to choose numbers from 1 to 6 without using any other symbols.\nTry again\n");
                    userchoice = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"-- We are preparing the process...");
                switch (userchoicenum)
                {
                    case 1:
                        ShowAllBooks(ref libraryManager);
                        break;
                    case 2:
                        AddBook(ref libraryManager);
                        break;
                    case 3:
                        Filter(ref libraryManager);
                        break;
                    case 4:
                        Search(ref libraryManager);
                        break;
                    case 5:
                        ShowInfo(ref libraryManager);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Thanks for visiting. All the best.");
                        return;
                }
            } while (true);
        }
        static void ShowAllBooks(ref LibraryManager libraryManager)
        {
            if (libraryManager.Books.Count > 0)
            {
                foreach (var item in libraryManager.Books)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                throw new BookNotFoundException("There are no books. Add them.");
            }
        }
        static void AddBook(ref LibraryManager libraryManager)
        {
            Console.WriteLine("\nPlease write down name of Book that you are going to add:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the Author Name:");
            string author = Console.ReadLine();

            while (!Regex.IsMatch(author, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(author, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven Author Name {author} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                author = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the page count");
            string pagecount = Console.ReadLine();

            while (!Regex.IsMatch(pagecount, @"^\d+$"))
            {
                Console.WriteLine($"\nSorry but page count must be in numbers!");
                pagecount = Console.ReadLine();
            }

            int pages = int.Parse(pagecount);

            Console.WriteLine("Choose the Genre of your Book:");

            foreach (var item in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine($"{(int)item} -- {item}");
            }

            string genrestr = Console.ReadLine();
            int genreint;

            while (int.TryParse(genrestr, out genreint) || genreint < 1 || genreint > 5)
            {
                Console.WriteLine("Choose from range 1 to 5");
            }
            Genres genre = (Genres)genreint;

            Book book = new Book(name, author, pages, genre);

            libraryManager.Add(book);
        }
        static void Filter(ref LibraryManager libraryManager)
        {
            Console.WriteLine("Welcome to book filter!");

            Console.WriteLine("\nWrite down the Author Name:");
            string author = Console.ReadLine();

            while (!Regex.IsMatch(author, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(author, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven Author Name {author} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                author = Console.ReadLine();
            }

            foreach (var item in Enum.GetValues(typeof(Genres)))
            {
                Console.WriteLine($"{(int)item} -- {item}");
            }

            Console.WriteLine("Write Down the number of Genre from GenresList that you see upper:");

            string genrestr = Console.ReadLine();
            int genreint;

            while (int.TryParse(genrestr, out genreint) || genreint < 1 || genreint > 5)
            {
                Console.WriteLine("Choose from range 1 to 5");
            }

            Genres genre = (Genres)genreint;

            libraryManager.Filter(author, genre);
            
        }
        static void Search(ref LibraryManager librarymanager)
        {
            Console.WriteLine("Write name, author name, genre or pagecount of book that you are looking for.");
            string input = Console.ReadLine();

            librarymanager.Search(input);
        }
        static void ShowInfo(ref LibraryManager libraryManager)
        {
            Console.WriteLine("Write down name of book that you are looking for");

            string name = Console.ReadLine();

            Console.WriteLine($"{libraryManager.ShowInfo(name)}");
        }
    }
}
