using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Book book, int qty)
        {
            CartItem item = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (item == null)
            {
                Items.Add(new CartItem
                {
                    Book = book,
                    Quantity = qty,
                });
            }
            else
            {
                item.Quantity = item.Quantity + qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
    }

    

    public class CartItem
    {
        public int ItemID { get; set; }
        public Book Book { get; set; }
        public int  Quantity { get; set; }
    }
}
