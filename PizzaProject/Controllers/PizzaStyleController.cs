using Microsoft.AspNetCore.Mvc;
using PizzaProject.Data;
using PizzaProject.Models;

namespace PizzaProject.Controllers
{
    public class PizzaStyleController : Controller
    {
        private readonly PizzaDbContext _context; //underscore is added to readonly varabiles and partial views
        public PizzaStyleController(PizzaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<PizzaStyle> styleList = _context.PizzaStyles.ToList();
            return View(styleList);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost] //Http post for create method
        public IActionResult Create(PizzaStyle newStyle)
        {
            var dupCheck = _context.PizzaStyles.Find(newStyle.DisplayOrder);
            if (dupCheck is not null) //stops users from adding same display order numbers
            { //this counts as server-side validation
                ModelState.AddModelError("displayOrder", "No duplicates for display order");
            }

            if (ModelState.IsValid)
            {
                _context.PizzaStyles.Add(newStyle); //add new style and save it. Then redirect to index
                _context.SaveChanges();
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

            PizzaStyle? styleFromDb = _context.PizzaStyles.Find(id); //find can only look for the primary key
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
                _context.PizzaStyles.Update(editStyle); //only thing needed here is to update the object and save changes
                _context.SaveChanges();
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

            PizzaStyle? styleFromDb = _context.PizzaStyles.Find(id); //find can only look for the primary key
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
            PizzaStyle? style = _context.PizzaStyles.Find(id);
            if (style is null)
            {
                return BadRequest();
            }
            _context.PizzaStyles.Remove(style); //removing object
            _context.SaveChanges();
            TempData["passed"] = "Pizza Style Deleted!";
            return RedirectToAction("Index", "PizzaStyle");
        }
    
    }
}
