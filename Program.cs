using System;
using day_17_assign_20_LibCalculation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_17_assign_20_LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
          char continueInput;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. Search by ID");
                Console.WriteLine("4. Search by title");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input.Please enter a valid integer.");
                }

                switch (choice)
                {
                    case 1:
                        Book newBook = new Book();
                        Console.Write("Enter Book ID: ");
                        newBook.BookId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Book Title: ");
                        newBook.Title = Console.ReadLine();
                        Console.Write("Enter Book Author: ");
                        newBook.Author = Console.ReadLine();
                        Console.Write("Enter Book Genre: ");
                        newBook.Genre = Console.ReadLine();
                        Console.Write("Enter Is Available (true/false): ");
                        newBook.IsAvailable = Convert.ToBoolean(Console.ReadLine());
                        bool bookAdded = library.AddBook(newBook);
                        if (bookAdded)
                        {
                            Console.WriteLine("Book added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the book. Please check the details and try again.");
                        }
                        break;

                    case 2:
                        library.ViewAllBooks();
                        break;
                    case 3:
                        Console.Write("Enter Book ID: ");
                        int searchById = Convert.ToInt32(Console.ReadLine());
                        bool bookFoundById = library.SearchBookById(searchById);
                        if (!bookFoundById)
                        {
                            Console.WriteLine("The book with the given ID was not found in the library.");
                        }
                        break;
                    case 4:
                        Console.Write("Enter Book Title: ");
                        string searchByTitle = Console.ReadLine();
                        bool bookFoundByTitle = library.SearchBookByTitle(searchByTitle);
                        if (!bookFoundByTitle)
                        {
                            Console.WriteLine("The book you searched for is not available in the library.");
                        }
                        break;
                        case 5:
                        Console.WriteLine("Exit the Program");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("Do you wanna continue? (press 'y' to continue)"); // Add a new line for better readability
                continueInput = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (continueInput == 'y' || continueInput == 'Y');
        }
    }
}
