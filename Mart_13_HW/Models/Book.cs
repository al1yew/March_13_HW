using Mart_13_HW.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_13_HW.Models
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public Genres Genre { get; set; }

        public Book(string name, string author, int pagecount, Genres genre)
        {
            Name = name;
            Author = author;
            PageCount = pagecount;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"Name: {Name.ToUpper()}\n" +
                $"Author: {Author.ToUpper()}\n" +
                $"Page count: {PageCount}\n" +
                $"Genre: {Genre.ToString().Replace('_', ' ')}";
        }
    }
}
