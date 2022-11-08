using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class ContactController : Controller
    {
        public List<ContactModel> contactModels = new List<ContactModel>()
        {
            new ContactModel() {Id = 1, Name = "Filip", Age = 17, Email = "filip@gmail.com"},
            new ContactModel() {Id = 2, Name = "Bartek", Age = 20, Email = "bartek@gmail.com"},
            new ContactModel() {Id = 3, Name = "Dawid", Age = 30, Email = "dawid@gmail.com"},
            new ContactModel() {Id = 4, Name = "Kacper", Age = 45, Email = "kacper@gmail.com"},
            new ContactModel() {Id = 5, Name = "Ola", Age = 17, Email = "ola@gmail.com"},
            new ContactModel() {Id = 6, Name = "Michał", Age = 28, Email = "michał@gmail.com"},
            new ContactModel() {Id = 7, Name = "Jakub", Age = 29, Email = "jakub@gmail.com"},
            new ContactModel() {Id = 8, Name = "Tymek", Age = 46, Email = "tymek@gmail.com"},
            new ContactModel() {Id = 9, Name = "Konrad", Age = 31, Email = "konrad@gmail.com"},
            new ContactModel() {Id = 10, Name = "Kamil", Age = 15, Email = "kamil@gmail.com"},
            new ContactModel() {Id = 11, Name = "Dawid", Age = 80, Email = "dawid@gmail.com"},
            new ContactModel() {Id = 12, Name = "Daniel", Age = 76, Email = "daniel@gmail.com"}

        };       
        public IActionResult Index()
        {
            return View(contactModels);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            ContactModel c = contactModels.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                contactModels.Remove(c);
            }
            return View("Index", contactModels);
        }
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact([FromForm] ContactModel contactModel)
        {           
            if (ModelState.IsValid)
            {
                int counter = contactModels.Count();
                contactModel.Id = ++counter;
                contactModels.Add(contactModel);
                return View("Index", contactModels);
            }
            return View();
        }
        public IActionResult EditContact([FromRoute] int id)
        {
            var contactModel = contactModels.FirstOrDefault(x => x.Id == id);
            return View(contactModel);
        }
        [HttpPost]
        public IActionResult EditContact([FromForm] ContactModel contactModel, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var index = contactModels.FindIndex(x => x.Id == id);
                contactModels[index] = contactModel;
                return View("Index", contactModels);
            }
            return View();
        }
    }
}
