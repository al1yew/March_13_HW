﻿using Mart_13_HW.Enums;
using Mart_13_HW.Exceptions;
using Mart_13_HW.Interfaces;
using Mart_13_HW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_13_HW.Services
{
    class LibraryManager : ILibraryManager
    {
        private List<Book> _books;
        public List<Book> Books => _books;
        public LibraryManager()
        {
            _books = new List<Book>();
        }
        public void Add(Book book)
        {
            if (_books.Exists(q => q.Name == book.Name))
            {
                throw new SameBookIsAlreadyAddedExpection($"{book.Name} cannot be added due to fact of existence of same named book.");
            } //else
            _books.Add(book);
        }
        public List<Book> Filter(string author, Genres genre)
        {
            if (_books.Count > 0)
            {
                return _books.FindAll(books => books.Author == author && books.Genre == genre);
            }
            throw new BookNotFoundException($"Your input cannot be found in system. Add books first of all.");
        }
        public List<Book> Search(string input)
        {
            if (_books.Count > 0)
            {
                return _books.FindAll(books => books.Name.ToUpper().Contains(input) || books.Author.ToUpper().Contains(input) ||
                books.PageCount.ToString().Contains(input) || books.Genre.ToString().ToUpper().Contains(input));
            }
            throw new BookNotFoundException($"Your input - {input} cannot be found in system. Add books first of all.");
        }
        public Book ShowInfo(string name)
        {
            Book book = _books.Find(book => book.Name == name);
            if (book != null)
            {
                return book;
            }
            throw new BookNotFoundException($"Your input - {name} cannot be found in system. Add books first of all.");
        }
    }
}
