using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Book gatsby = new Book("The Gatsby", "Fitgerald", 1925);
            MenuOperations.MainMenuChoices();
        }
    }
    class Book
    {
        public string Title;
        public string Author;
        public int Year;
        public Book(string _title, string _author, int _year)
        {
            this.Title = _title;
            this.Author = _author;
            this.Year = _year;
            BookListHolder.bookList.Add(this);
        }
    }
    //class with static fields 
    class BookListHolder
    {
        public static List<Book> bookList = new List<Book>();
        public static void ShowAllBooks()
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + bookList[i].Title + " | " + bookList[i].Author + " | " + bookList[i].Year);
            }
        }
    }
    //class with static fields
    class MenuOperations
    {
        //showing all books and providing choices
        public static void MainMenuChoices()
        {
            BookListHolder.ShowAllBooks();

            Console.WriteLine("----------------------");
            Console.WriteLine("1. Buy a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Update/Change a book");
            Console.WriteLine("");
            Console.WriteLine("Enter the number of the operation you want to carry out");
            // managing the user's choice
            int enteredOperation = Convert.ToInt32(Console.ReadLine());
            switch (enteredOperation)
            {
                case 1:
                    BuyingBook();
                    break;
                case 2:
                    RemovingBook();
                    break;
                case 3:
                    UpdatingBook();
                    break;
                default:
                    Console.WriteLine("Incorrect Operation!!!!!!!!!!");
                    break;

            }
            Console.WriteLine("");
            MainMenuChoices();
        }
        // adding a book
        private static void BuyingBook()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Enter the details of the new book");
            Console.WriteLine("------------");

            Console.WriteLine("Enter the Title of the new Book");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter the Author of the new Book");
            string newAuthor = Console.ReadLine();

            Console.WriteLine("Enter the Year of the new Book");
            int newYear = Convert.ToInt32(Console.ReadLine());

            new Book(newTitle, newAuthor, newYear);

            Console.WriteLine("The book '" + newTitle + "' is successfully created");
            Console.WriteLine("");
        }
        // removing a book
        private static void RemovingBook()
        {
            BookListHolder.ShowAllBooks();

            Console.WriteLine("-------------");

            Console.WriteLine("Enter the number of the book you want to remove");
            int enteredNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Book '" + BookListHolder.bookList[enteredNum - 1].Title + "' is successfully removed");

            BookListHolder.bookList.Remove(BookListHolder.bookList[enteredNum - 1]);

            Console.WriteLine("");
        }
        private static void UpdatingBook()
        {
            BookListHolder.ShowAllBooks();

            Console.WriteLine("-------------");

            Console.WriteLine("Enter the number of the book you want to change/update");
            int enteredNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The selected book is below");
            Console.WriteLine(BookListHolder.bookList[enteredNum - 1].Title + " ~ " + BookListHolder.bookList[enteredNum - 1].Author + " ~ " + BookListHolder.bookList[enteredNum - 1].Year);

            Console.WriteLine("Enter the Title of the new Book");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Enter the Author of the new Book");
            string newAuthor = Console.ReadLine();

            Console.WriteLine("Enter the Year of the new Book");
            int newYear = Convert.ToInt32(Console.ReadLine());

            BookListHolder.bookList[enteredNum - 1].Title = newTitle;
            BookListHolder.bookList[enteredNum - 1].Author = newAuthor;
            BookListHolder.bookList[enteredNum - 1].Year = newYear;

            Console.WriteLine("The book '" + newTitle + "' is successfully updated");
            Console.WriteLine("");
        }
    }

}
