﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;

namespace DAL.Operations.BookDt
{
    interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);

        bool CreateBook(Book b);

        bool UpdateBook(Book b);

        bool DeleteBook(int id);
    }
}
