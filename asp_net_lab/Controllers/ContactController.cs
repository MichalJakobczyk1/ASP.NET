using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class ContactController : Controller
    {
        public List<Contact> Contacts = new List<Contact>()
        {
            new Contact() {Id = 1, Name = "Filip", Age = 17, Email = "filip@gmail.com"},
            new Contact() {Id = 2, Name = "Bartek", Age = 20, Email = "bartek@gmail.com"},
            new Contact() {Id = 3, Name = "Dawid", Age = 30, Email = "dawid@gmail.com"},
            new Contact() {Id = 4, Name = "Kacper", Age = 45, Email = "kacper@gmail.com"},
            new Contact() {Id = 5, Name = "Ola", Age = 17, Email = "ola@gmail.com"},
            new Contact() {Id = 6, Name = "Michał", Age = 28, Email = "michał@gmail.com"},
            new Contact() {Id = 7, Name = "Jakub", Age = 29, Email = "jakub@gmail.com"},
            new Contact() {Id = 8, Name = "Tymek", Age = 46, Email = "tymek@gmail.com"},
            new Contact() {Id = 9, Name = "Konrad", Age = 31, Email = "konrad@gmail.com"},
            new Contact() {Id = 10, Name = "Kamil", Age = 15, Email = "kamil@gmail.com"},
            new Contact() {Id = 11, Name = "Dawid", Age = 80, Email = "dawid@gmail.com"},
            new Contact() {Id = 12, Name = "Daniel", Age = 76, Email = "daniel@gmail.com"}

        };       
        public IActionResult Index()
        {
            return View(Contacts);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            Contact c = Contacts.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                Contacts.Remove(c);
            }
            return View("Index", Contacts);
        }
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact([FromForm] Contact Contact)
        {           
            if (ModelState.IsValid)
            {
                int counter = Contacts.Count();
                Contact.Id = ++counter;
                Contacts.Add(Contact);
                return View("Index", Contacts);
            }
            return View();
        }
        public IActionResult EditContact([FromRoute] int id)
        {
            var Contact = Contacts.FirstOrDefault(x => x.Id == id);
            return View(Contact);
        }
        [HttpPost]
        public IActionResult EditContact([FromForm] Contact Contact, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var index = Contacts.FindIndex(x => x.Id == id);
                Contacts[index] = Contact;
                return View("Index", Contacts);
            }
            return View();
        }
    }
}
