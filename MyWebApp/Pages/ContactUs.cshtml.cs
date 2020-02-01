using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp
{
    public class ContactUsModel : PageModel
    {
        public class ContactFormInformation
        {
            [Display(Name = "Email")]
            [EmailAddress]
            public string EmailAddress { get; set; }
            [Display(Name = "Name")]
            public string Firstname { get; set; }
            [Display(Name = "Lastname")]
            public string Lastname { get; set; }

            [Display(Name = "Feedback type")]
            public List<string> FeedbackTypes
            {
                get
                {
                    return new List<string> { "General", "Order information", "Customer service", "Cancel my order" };
                }
            }

            [Display (Name = "Feedback type")]
            public string FeedbackType { get; set; }
            [Display(Name = "Your comments")]
            public string Comments { get; set; }

        }
       

        [BindProperty]
        public ContactFormInformation ContactForm { get; set; }
        
        public string Message { get; private set; }

        public void OnGet()
        {
            ContactForm = new ContactFormInformation();
        }

        public void OnPost()
        {
            Message = $"{ContactForm.Firstname}, you have submitted the form";
        }
    }
}