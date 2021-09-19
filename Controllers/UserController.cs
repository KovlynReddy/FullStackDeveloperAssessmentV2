using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStackAPIAssessment.Models;
using FullStackDeveloperAssessment.Data;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using FullStackAPIAssessment.Interfaces;

namespace FullStackDeveloperAssessment.Controllers
{
    public class UserController : Controller
    {
        private readonly FullStackDeveloperAssessmentContext _context;
        private readonly ILocationsDB db;

        public HttpClientHandler _ClientHandler { get; set; }
        public List<LocationModel> _Locations { get; set; }

        public UserController(FullStackDeveloperAssessmentContext context)
        {
            _context = context;
            //this.db = db;
            _ClientHandler = new HttpClientHandler();
        }

        [HttpGet]
        public async Task<IActionResult> GetMyLocations(string id) {

            db.GetAllMyImages(id);

            return null;
        }


        [HttpGet]
        public async Task<IActionResult> GetLocations(string id,string userid)
        {
            if (id.Contains(':'))
            {
                bool flag = true;
            }
            else
            {
            }
            if (id == null)
            {
                id = "durban";
            }

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync($"https://api.foursquare.com/v2/venues/explore?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20180323&limit=1&feilds=name&ll=-29.688079382295278, 31.00824366802357&query={id}"))
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    // _Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);
                    JObject data = JObject.Parse(apiresponse);

                    string feild = "venue";

                    string pattern = $"(\"{feild }\":).*(,\"ca)";

                    // Define a regular expression for repeated words.
                    Regex rx = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

                    // Define a test string.
                    string text = apiresponse;

                    // Find matches.
                    MatchCollection matches = rx.Matches(text);

                    string venueid = matches.First().Value;
                    string VenueId = venueid.Substring(15, 24);

                    feild = "categories";
                    pattern = $"(\"{feild}\":).*(,\"ve)";
                    Regex rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string categories = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Categories = categories.Substring(6, categories.Length - 9);

                    feild = "id";
                    pattern = $"(\"{feild}\":).*(,\"na)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    id = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Id = id.Substring(10, 24);

                    feild = "name";
                    pattern = $"(\"{feild}\":).*(,\"contact)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(venueid);
                    string name = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Name = name.Substring(8, (name.Length - 18));

                    var text2 = venueid;
                    matches = rx1.Matches(text2);
                    name = matches.First().Value;

                    feild = "lat";
                    pattern = $"(\"{feild}\":).*(,\"lng)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string lat = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Lat = lat.Substring(6, 6);


                    feild = "lng";
                    pattern = $"(\"{feild}\":).*(,\"di)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string lng = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Lng = lng.Substring(6, 6);

                    /*
                    feild = "address";
                    pattern = $"(\"{feild}\":).*(\"lab)";
                    rx1 = new Regex(pattern,
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    matches = rx1.Matches(text);
                    string address = matches.First().Value;
                    //10()7 
                    //var resultString = Regex.Match(venueid, @"\d+").Value;
                    var Address = address.Substring(9, (address.Length - 12));
                    */

                    LocationModel location = new LocationModel();
                    location.LocationId = VenueId;
                    location.name = Name;
                    location.lat = Lat;
                    location.lng = Lng;
                    location.meta = userid;
                    //location.address = Address;


                    var duplicates = _context.LocationModel.Where(m => m.LocationId == location.LocationId && location.meta == userid);

                    if (duplicates.Count() < 1)
                    {
                        _context.LocationModel.Add(location);

                        _context.SaveChanges();
                    }
                    return RedirectToAction("GetLocationImage", "User", new { id = location.LocationId , userid = userid });

                    return Content(apiresponse);
                }
            }
            //            return _Locations;

        }

        [HttpGet]
        public async Task<IActionResult> GetLocationImage(string id,string userid)
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

                    prefix = prefix.Replace(@"\", "");


                    ImageModel image = new ImageModel();
                    image.venueid = VenueId;
                    image.prefix = Prefix;
                    image.suffix = Suffix;
                    image.width = Width;
                    image.height = Height;
                    image.meta = userid;


                    var duplicates = _context.ImageModel.Where(m => m.venueid == image.venueid && m.meta == userid);

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

                    image.prefix = image.prefix.Replace("\\", "");

                    //string url = (image.prefix + $"{image.width}x{image.height}" + image.suffix + "png");
                    string url = (image.prefix + $"300x500" + image.suffix + "jpg");
                    return Redirect(url);

                    //            return _Locations;
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMyLocations(string id) {

            var mylocations = db.GetAllMyLocations(id);

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMyImages(string id)
        {

            var mylocations = db.GetAllMyImages(id);

            return null;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserModel.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,UserId,UserName,UserPassKey")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,UserId,UserName,UserPassKey")] UserModel userModel)
        {
            if (id != userModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.id))
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
            return View(userModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.UserModel.FindAsync(id);
            _context.UserModel.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModel.Any(e => e.id == id);
        }
    }
}
