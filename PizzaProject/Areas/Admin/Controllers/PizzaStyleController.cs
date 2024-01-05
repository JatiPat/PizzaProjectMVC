using Microsoft.AspNetCore.Mvc;
using PizzaProject.DataAccess.Data;
using PizzaProject.DataAccess.Repository.IRepository;
using PizzaProject.Models;

namespace PizzaProject.Areas.Admin.Controllers
{
    [Area("Admin")] // this controller belongs in the Admin Area
    public class PizzaStyleController : Controller
    {
        //private readonly PizzaDbContext _context; //underscore is added to readonly varabiles and partial views
        private readonly IUnitOfWork _unitOfWork; //switched out DbContext with IPizzaStyleRepository

        public PizzaStyleController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }
        public IActionResult Index()
        {
            List<PizzaStyle> styleList = _unitOfWork.Style.GetAll().ToList();
            return View(styleList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Http post for create method
        public IActionResult Create(PizzaStyle newStyle)
        {
            var dupCheck = _unitOfWork.Style.Get(u => u.Id == newStyle.Id);
            if (dupCheck is not null) //stops users from adding same display order numbers
            { //this counts as server-side validation
                ModelState.AddModelError("displayOrder", "No duplicates for display order");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Style.Add(newStyle); //add new style and save it. Then redirect to index
                _unitOfWork.Save();
                TempData["passed"] = "Pizza Style Created!";
                return RedirectToAction("Index", "PizzaStyle");
            }
            else //invaild inputs
            {
                return View();
            }
        }

        public IActionResult Edit(int? id) //Can take in id of Style that's nullable
        {
            if (id is null || id == 0) //is null is better ==, and can also say //is not
            {
                return NotFound();
            }

            PizzaStyle? styleFromDb = _unitOfWork.Style.Get(u => u.Id == id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (styleFromDb == null)
            {
                return NotFound();
            }
            return View(styleFromDb);
        }


        [HttpPost]
        public IActionResult Edit(PizzaStyle editStyle)
        {
            if (editStyle is not null && ModelState.IsValid)
            {
                _unitOfWork.Style.Update(editStyle); //only thing needed here is to update the object and save changes
                _unitOfWork.Save();
                TempData["passed"] = "Pizza Style Edited!";
            }

            return RedirectToAction("Index", "PizzaStyle");
        }


        public IActionResult Delete(int? id) //Can take in id of Style that's nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            PizzaStyle? styleFromDb = _unitOfWork.Style.Get(u => u.Id == id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (styleFromDb is null)
            {
                return NotFound();
            }
            return View(styleFromDb);
        }


        [HttpPost, ActionName("Delete")] //telling EF Core this is the delete method even if it's called DeletePOST
        public IActionResult DeletePOST(int? id)
        {
            PizzaStyle? style = _unitOfWork.Style.Get(u => u.Id == id);
            if (style is null)
            {
                return BadRequest();
            }
            _unitOfWork.Style.Delete(style); //removing object
            _unitOfWork.Save();
            TempData["passed"] = "Pizza Style Deleted!";
            return RedirectToAction("Index", "PizzaStyle");
        }

    }
}
