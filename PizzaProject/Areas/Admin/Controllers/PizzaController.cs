using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaProject.DataAccess.Data;
using PizzaProject.DataAccess.Repository;
using PizzaProject.DataAccess.Repository.IRepository;
using PizzaProject.Models;
using PizzaProject.Models.ViewModels;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")] // this controller belongs in the Admin Area
    public class PizzaController : Controller
    {
        //private readonly PizzaDbContext _context; //underscore is added to readonly varabiles and partial views
        private readonly IUnitOfWork _unitOfWork; //switched out DbContext with IPizzaRepository in unitOfWork
        private readonly IWebHostEnvironment _webHostEnvironment; //https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment?view=aspnetcore-8.0
        public PizzaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Pizza> pizzaList = _unitOfWork.Pizza.GetAll().ToList();
            
            return View(pizzaList);
        }

        public IActionResult Upsert(int? id) //Insert and Update
        {
            /*IEnumerable<SelectListItem> PizzaStyleList = _unitOfWork.Style.GetAll().Select(
                u => new SelectListItem //Using EF Core Projections to access pizza style
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
            */
            //Viewbag (wrapper of ViewData) send info from controller to view (and not the other way around)
            //ViewBag.PizzaStyleList = PizzaStyleList; //<-- ViewBag Set up
            //ViewData must have a type casted before use in create.cshtml
            //ViewData["PizzaStyleList"] = PizzaStyleList; //They also use the same dictionary, so ViewBag key must not match
            //Avoid using Viewbags and Datas because it will look really messy. Instead, tightly bind the view with the object that you want
            //Or a ViewModel that's a combintion 
          PizzaVM pizzaVM = new()
          {
              PizzaStyleList = _unitOfWork.Style.GetAll().Select(
                u => new SelectListItem //Using EF Core Projections to access pizza style
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
            Pizza = new Pizza()
          };  //Need to pass PizzaVM for it to work
            if(id is null || id == 0)
            {//create
                return View(pizzaVM);
            }
            else
            {//update
                pizzaVM.Pizza = _unitOfWork.Pizza.Get(u => u.Id == id);
                return View(pizzaVM);
            }
            
        }

        [HttpPost] //Http post for create method
        public IActionResult Upsert(PizzaVM newPizzaVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                //Using the _webHostEnvironment, you create two strings, one with a random GUID and file exetesion
                //The other with the _webHostEnvironment.WebRootPath to store it in a specfic static location
                if (file is not null)
                { 
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string pizzaPath = Path.Combine(wwwRootPath, @"images\pizza");
                    //Using FileStream, you copy the file to the desired location https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream?view=net-8.0
                    using (var fileStream = new FileStream(Path.Combine(pizzaPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream); 
                    }

                    newPizzaVM.Pizza.ImageURL = @"\images\pizza\" + fileName;
                }
                if (newPizzaVM.Pizza.Id is 0) {
                    _unitOfWork.Pizza.Add(newPizzaVM.Pizza); //add new style and save it. Then redirect to index
                }
                else
                {
                    _unitOfWork.Pizza.Update(newPizzaVM.Pizza); //for edititng (needed or you'll get an SQL primary id error)
                }
                
              
                _unitOfWork.Save();
                TempData["passed"] = "Pizza Created!";
                return RedirectToAction("Index", "Pizza");
            }
            else //invaild inputs
            {
                newPizzaVM.PizzaStyleList = _unitOfWork.Style.GetAll().Select(
                u => new SelectListItem //Using EF Core Projections to access pizza style
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(newPizzaVM);
            }
        }

       

        public IActionResult Delete(int? id) //Can take in id of Style that's nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Pizza? pizzaFromDb = _unitOfWork.Pizza.Get(u => u.Id == id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (pizzaFromDb is null)
            {
                return NotFound();
            }
            return View(pizzaFromDb);
        }


        [HttpPost, ActionName("Delete")] //telling EF Core this is the delete method even if it's called DeletePOST
        public IActionResult DeletePOST(int? id)
        {
            Pizza? pizza = _unitOfWork.Pizza.Get(u => u.Id == id);
            if (pizza is null)
            {
                return BadRequest();
            }
            _unitOfWork.Pizza.Delete(pizza); //removing object
            _unitOfWork.Save();
            TempData["passed"] = "Pizza Deleted!";
            return RedirectToAction("Index", "Pizza");
        }

        /* public IActionResult Edit(int? id) //Can take in id of Style that's nullable
        {
            if (id is null || id == 0) //is null is better ==, and can also say //is not
            {
                return NotFound();
            }

            Pizza? pizzaFromDb = _unitOfWork.Pizza.Get(u => u.Id == id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (pizzaFromDb == null)
            {
                return NotFound();
            }
            return View(pizzaFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Pizza editPizza)
        {
            if (editPizza is not null && ModelState.IsValid)
            {
                _unitOfWork.Pizza.Update(editPizza); //only thing needed here is to update the object and save changes
                _unitOfWork.Save();
                TempData["passed"] = "Pizza Edited!";
            }

            return RedirectToAction("Index", "Pizza");
        }*/

    }
}
