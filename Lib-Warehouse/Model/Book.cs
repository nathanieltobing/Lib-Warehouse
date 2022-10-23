using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lib_Warehouses.Model
{
    public class Book
    {
        private string bookID;
        private string bookName;
        private string genre;
        private string authorName;
        private string publisherName;
        private string publishDate;
        private string language;
        private string edition;
        private string bookCost;
        private string noPages;
        private string bookDesc;
        private string actualStock;
        private string currStock;
        private string bookImgLink;

        public Book(string bookID, string bookName, string genre, string authorName, string publisherName, string publishDate, string language, string edition, string bookCost, string noPages, string bookDesc, string actualStock, string currStock, string bookImgLink)
        {
            this.BookID = bookID;
            this.BookName = bookName;
            this.Genre = genre;
            this.AuthorName = authorName;
            this.PublisherName = publisherName;
            this.PublishDate = publishDate;
            this.Language = language;
            this.Edition = edition;
            this.BookCost = bookCost;
            this.NoPages = noPages;
            this.BookDesc = bookDesc;
            this.ActualStock = actualStock;
            this.CurrStock = currStock;
            this.BookImgLink = bookImgLink;
        }

        public string BookID { get => bookID; set => bookID = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public string Genre { get => genre; set => genre = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public string PublisherName { get => publisherName; set => publisherName = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string Language { get => language; set => language = value; }
        public string Edition { get => edition; set => edition = value; }
        public string BookCost { get => bookCost; set => bookCost = value; }
        public string NoPages { get => noPages; set => noPages = value; }
        public string BookDesc { get => bookDesc; set => bookDesc = value; }
        public string ActualStock { get => actualStock; set => actualStock = value; }
        public string CurrStock { get => currStock; set => currStock = value; }
        public string BookImgLink { get => bookImgLink; set => bookImgLink = value; }
    }
}