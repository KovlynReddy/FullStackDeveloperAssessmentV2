using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStackAPIAssessment.Models;
using FullStackDeveloperAssessment.Data;

namespace FullStackDeveloperAssessment.Controllers
{
    public class ImageController : Controller
    {
        private readonly FullStackDeveloperAssessmentContext _context;

        public HttpClientHandler _ClientHandler { get; set; }
        public List<LocationModel> _Locations { get; set; }


        public ImageController(FullStackDeveloperAssessmentContext context)
        {
            _ClientHandler = new HttpClientHandler();
            _context = context;
        }

        #region Locations

        [HttpGet]
        public async Task<ContentResult> GetAllImages()
        {

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/4bb9e5161261d13a22f3e998/photos?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20190425&group=venue&limit=10"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    //_Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);

                    return Content(apiresponse);
                }
            }

        }

        [HttpGet]
        public async Task<ContentResult> GetLocationImage(string id)
        {

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/{id}/photos?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20190425&group=venue&limit=10"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    //_Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);
                    return Content(apiresponse);
                }
            }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            return Content("Hello");
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ImageId")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ImageId")] ImageModel imageModel)
        {
            if (id != imageModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.ImageModel.FindAsync(id);
            _context.ImageModel.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(int id)
        {
            return _context.ImageModel.Any(e => e.id == id);
        }
    }
}
