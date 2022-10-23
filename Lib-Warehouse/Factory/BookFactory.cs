using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lib_Warehouses.Model;

namespace Lib_Warehouses.Factory
{
    public class BookFactory
    {
        public Book getBook(string bookID, string bookName, string genre, string authorName, string publisherName, string publishDate, string language, string edition, string bookCost, string noPages, string bookDesc, string actualStock, string currStock, string bookImgLink)
        {
            return new Book(bookID, bookName, genre, authorName, publisherName, publishDate, language, edition, bookCost, noPages, bookDesc, actualStock, currStock, bookImgLink);
        }

    }
}