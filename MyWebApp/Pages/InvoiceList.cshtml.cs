using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp
{
    [BindProperties(SupportsGet = true)]
    public class InvoiceListModel : PageModel
    {
        public class Invoice
        {
            public class Item
            {
                public int ItemId { get; set; }
                public string ItemName { get; set; }
            }

            public class SelectedItem
            {
                public int ItemId { get; set; }
                public int Quantity { get; set; }
            }

            public int InvoiceNumber { get; set; }
        }

        [BindProperty]
        public int Id { get; set; }

        public Invoice CurrentInvoice { get; set; }

        public List<Invoice.Item> AvailableItems { get; set; }

        [BindProperty]
        public List<Invoice.SelectedItem> SelectedItems { get; set; }

        public string Message { get; set; }

        public void OnGet(int id)
        {
            InitializeInvoice(id);
        }

        private void InitializeInvoice(int id)
        {
            Id = id;
            AvailableItems = new List<Invoice.Item>
                {
                    new Invoice.Item { ItemId = 1, ItemName = "Sandwich de pollo" },
                    new Invoice.Item { ItemId = 2, ItemName = "Sandwich de queso" },
                    new Invoice.Item { ItemId = 3, ItemName = "Sandwich de jamón" },
                    new Invoice.Item { ItemId = 4, ItemName = "Sandwich de jamón y queso" }

                };

            CurrentInvoice = new Invoice
            {
                InvoiceNumber = Id,
            };

            SelectedItems = new List<Invoice.SelectedItem>();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            InitializeInvoice(id);
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Message = "You have deleted this thing! 🤓";
            InitializeInvoice(id);
            return Page();
        }

    }
}