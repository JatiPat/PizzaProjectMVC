using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaProject.DataAccess.Data;
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

        public PizzaController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }
        public IActionResult Index()
        {
            List<Pizza> pizzaList = _unitOfWork.Pizza.GetAll().ToList();
            
            return View(pizzaList);
        }

        public IActionResult Create()
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
            return View(pizzaVM);
        }

        [HttpPost] //Http post for create method
        public IActionResult Create(PizzaVM newPizzaVM)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Pizza.Add(newPizzaVM.Pizza); //add new style and save it. Then redirect to index
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

        public IActionResult Edit(int? id) //Can take in id of Style that's nullable
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

    }
}
