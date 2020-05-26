using System.Collections;
using System.Collections.Generic;

namespace LabIteratorsAndComparators
{
    public class Library : IEnumerable
    {
        internal List<Book> Books { get; set; }

        public Library (params Book[] books)
        {
            Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndx;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose(){ }
            public bool MoveNext() => ++this.currentIndx < this.books.Count;
            public void Reset() => this.currentIndx = -1;
            public Book Current => this.books[this.currentIndx];
            object IEnumerator.Current => this.Current;
            
        }
    }
}
