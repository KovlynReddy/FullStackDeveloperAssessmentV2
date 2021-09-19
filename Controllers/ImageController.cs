using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStackAPIAssessment.Models;
using FullStackDeveloperAssessment.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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

            var locations = _context.ImageModel.ToList();
            var mylocations = locations;

            string content = "";

            foreach (var location in mylocations)
            {
                content += location.name + "\n";
            }
            return Content(content);



        }



        //[HttpGet]
        //public async Task<ContentResult> GetAllImages(string id)
        //{

        //    using (var httpClient = new HttpClient(_ClientHandler))
        //    {
        //        using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/4b9cd8adf964a520747e36e3/photos?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20190425&group=venue&limit=10"))
        //        {

        //            string apiresponse = await response.Content.ReadAsStringAsync();
        //            //_Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);
        //            string feild = "id";

        //            string pattern = $"(\"{feild }\":).*(,)";

        //            // Define a regular expression for repeated words.
        //            Regex rx = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        //            // Define a test string.
        //            string text = apiresponse;

        //            // Find matches.
        //            MatchCollection matches = rx.Matches(text);


        //            feild = "id";
        //            pattern = $"(\"{feild}\":).*(,\"c)";
        //            Regex rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string venueid = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var VenueId = venueid.Substring(6, 24);

        //            feild = "prefix";
        //            pattern = $"(\"{feild}\":).*(,\"s)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string prefix = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Prefix = prefix.Substring(10, (prefix.Length - 14));

        //            feild = "suffix";
        //            pattern = $"(\"{feild}\":).*(,\"w)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string suffix = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Suffix = suffix.Substring(11, (suffix.Length - 18));

        //            feild = "width";
        //            pattern = $"(\"{feild}\":).*(,\"h)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string width = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Width = width.Substring(8, 4);


        //            feild = "height";
        //            pattern = $"(\"{feild}\":).*(,\"v)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string height = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Height = height.Substring(9, (height.Length - 12));



        //            ImageModel image = new ImageModel();
        //            image.venueid = VenueId;
        //            image.prefix = Prefix;
        //            image.suffix = Suffix;
        //            image.width = Width;
        //            image.height = Height;


        //            var duplicates = _context.ImageModel.Where(m => m.venueid == image.venueid);

        //            if (duplicates.Count() < 1)
        //            {
        //                _context.ImageModel.Add(image);
        //                _context.SaveChanges();
        //            }

        //            // Report on each match.
        //            foreach (Match match in matches)
        //            {
        //                var buffer = match.Value;
        //            }


        //            return Content(apiresponse);
        //        }
        //    }

        //}

        [HttpGet]
        public async Task<IActionResult> GetLocationImage(string id)
        {

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/{id}/photos?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20190425&group=venue&limit=10"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    //_Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);
                    string feild = "id";

                    string pattern = $"(\"{feild }\":).*(,)";

                    // Define a regular expression for repeated words.
                    Regex rx = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

                    // Define a test string.
                    string text = apiresponse;

                    // Find matches.
                    MatchCollection matches = rx.Matches(text);


                    feild = "id";
                    pattern = $"(\"{feild}\":).*(,\"c)";
                    Regex rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string venueid = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var VenueId = venueid.Substring(6, 24);

                    feild = "prefix";
                    pattern = $"(\"{feild}\":).*(,\"s)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string prefix = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Prefix = prefix.Substring(10, (prefix.Length - 14));

                    feild = "suffix";
                    pattern = $"(\"{feild}\":).*(,\"w)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string suffix = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Suffix = suffix.Substring(11, (suffix.Length - 18));

                    feild = "width";
                    pattern = $"(\"{feild}\":).*(,\"h)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string width = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Width = width.Substring(8, 4);


                    feild = "height";
                    pattern = $"(\"{feild}\":).*(,\"v)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string height = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Height = height.Substring(9, (height.Length - 12));

                    prefix = prefix.Replace(@"\","");


                    ImageModel image = new ImageModel();
                    image.venueid = VenueId;
                    image.prefix = Prefix;
                    image.suffix = Suffix;
                    image.width = Width;
                    image.height = Height;


                    var duplicates = _context.ImageModel.Where(m => m.venueid == image.venueid);

                    if (duplicates.Count() < 1)
                    {
                        _context.ImageModel.Add(image);
                        _context.SaveChanges();
                    }


                    // Report on each match.
                    foreach (Match match in matches)
                    {
                        var buffer = match.Value;
                    }

                    image.prefix = image.prefix.Replace("\\","");

                    string url = (image.prefix + $"{image.width}x{image.height}" + image.suffix+"jpg");
                    return Redirect(url);

                    //            return _Locations;
                }
            }
            }

        [HttpGet]
        public async Task<LocationModel> GetImage(string LocationClause)
        {

            LocationModel Location = new LocationModel();

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/explore?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20180323&limit=1&feilds=name&ll=-29.688079382295278, 31.00824366802357&query={LocationClause}"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Location = JsonConvert.DeserializeObject<LocationModel>(apiresponse);

                }
            }

            return Location;
        }
        #endregion


        public async Task<IActionResult> GetImageDetails(string id) {


            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync(@$"https://api.foursquare.com/v2/venues/explore?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20180323&limit=1&feilds=name&ll=-29.688079382295278, 31.00824366802357&query={LocationClause}"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
 
                }
            }

            return null;

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
