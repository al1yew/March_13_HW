using Mart_13_HW.Enums;
using Mart_13_HW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_13_HW.Interfaces
{
    interface ILibraryManager
    {
        List<Book> Books { get; }
        List<Book> Search(string input);
        void Add(Book book);
        Book ShowInfo(string name);
        List<Book> Filter(string author, Genres genre);
    }
}
