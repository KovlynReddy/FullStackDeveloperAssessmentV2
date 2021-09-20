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
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace FullStackDeveloperAssessment.Controllers
{

    public class LocationController : Controller
    {
        private readonly FullStackDeveloperAssessmentContext _context;

            public HttpClientHandler _ClientHandler { get; set; }
            public List<LocationModel> _Locations { get; set; }


        public LocationController(FullStackDeveloperAssessmentContext context)
        {
            //_ClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return (true); };
            _ClientHandler = new HttpClientHandler();
            _context = context;  
        }


        #region Locations

        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {

            var locations = _context.LocationModel.ToList();
            var mylocations = locations;

            string content = "";

            foreach (var location in mylocations)
            {
                content += location.name + "\n";
            }
            return Content(content);


        }


        //[HttpGet]
        //public async Task<IActionResult> GetAllLocations(string userid)
        //{

        //    using (var httpClient = new HttpClient(_ClientHandler))
        //    {
        //        using (var response = await httpClient.GetAsync("https://api.foursquare.com/v2/venues/explore?client_id=000MLTLRGKEVBPAYHBVUPP0NPCPRAZ11E22WXRWCL4R341GO&client_secret=M3CYWBKDUZ23R4BWVMEM1K5NFDPEGY5GM1PYKG4TQLJQZS2S&v=20180323&limit=1&feilds=name&ll=-29.688079382295278, 31.00824366802357&query=Landmark"))
        //        {

        //            string apiresponse = await response.Content.ReadAsStringAsync();
        //            // _Locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiresponse);
        //            JObject data = JObject.Parse(apiresponse);

        //            string feild = "venue";

        //            string pattern = $"(\"{feild }\":).*(,\"ca)";

        //            // Define a regular expression for repeated words.
        //            Regex rx = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        //            // Define a test string.
        //            string text = apiresponse;

        //            // Find matches.
        //            MatchCollection matches = rx.Matches(text);

        //            string venueid = matches.First().Value;
        //            string VenueId = venueid.Substring(15,24); 

        //            feild = "categories";
        //            pattern = $"(\"{feild}\":).*(,\"ve)";
        //            Regex rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string categories = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Categories = categories.Substring(6, categories.Length - 9);

        //            feild = "id";
        //            pattern = $"(\"{feild}\":).*(,\"na)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string id = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Id = id.Substring(10, 24);

        //            feild = "name";
        //            pattern = $"(\"{feild}\":).*(,\"contact)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(venueid);
        //            string name = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Name = name.Substring(8, (name.Length - 18));

        //            var text2 = venueid;
        //            matches = rx1.Matches(text2);
        //            name = matches.First().Value;

        //            feild = "lat";
        //            pattern = $"(\"{feild}\":).*(,\"lng)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string lat = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Lat = lat.Substring(6, 6);


        //            feild = "lng";
        //            pattern = $"(\"{feild}\":).*(,\"di)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string lng = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Lng = lng.Substring(6, 6);

        //            /*
        //            feild = "address";
        //            pattern = $"(\"{feild}\":).*(\"lab)";
        //            rx1 = new Regex(pattern,
        //            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //            matches = rx1.Matches(text);
        //            string address = matches.First().Value;
        //            //10()7 
        //            //var resultString = Regex.Match(venueid, @"\d+").Value;
        //            var Address = address.Substring(9, (address.Length - 12));
        //            */

        //            LocationModel location = new LocationModel();
        //            location.LocationId = VenueId;
        //            location.name = Name;
        //            location.lat = Lat;
        //            location.lng = Lng;
        //            //location.address = Address;



        //            var duplicates = _context.LocationModel.Where(m=>m.LocationId == location.LocationId);

        //            if (duplicates.Count() < 1)
        //            {
        //            _context.LocationModel.Add(location);

        //            _context.SaveChanges();
        //            }

        //            return RedirectToAction("GetLocationImage","Image",new { id = location.LocationId });
        //            return Content(apiresponse);
        //        }
        //    }

        //}

        [HttpGet]
        public async Task<IActionResult> GetLocations(string id)
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
                        //location.address = Address;


                        var duplicates = _context.LocationModel.Where(m => m.LocationId == location.LocationId);

                        if (duplicates.Count() < 1)
                        {
                            _context.LocationModel.Add(location);

                            _context.SaveChanges();
                        }
                    return RedirectToAction("GetLocationImage", "Image", new { id = location.LocationId });
                    
                    return Content(apiresponse);
                }
            }
            //            return _Locations;
            
        }

        [HttpGet]
        public async Task<LocationModel> GetLocation(string LocationClause)
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


        // GET: Location
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationModel.ToListAsync());
        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LocationName")] LocationModel locationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationModel);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel.FindAsync(id);
            if (locationModel == null)
            {
                return NotFound();
            }
            return View(locationModel);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LocationId,LocationName")] LocationModel locationModel)
        {
            if (id != locationModel.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationModelExists(locationModel.LocationId))
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
            return View(locationModel);
        }

        // GET: Location/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationModel = await _context.LocationModel
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locationModel == null)
            {
                return NotFound();
            }

            return View(locationModel);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var locationModel = await _context.LocationModel.FindAsync(id);
            _context.LocationModel.Remove(locationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationModelExists(string id)
        {
            return _context.LocationModel.Any(e => e.LocationId == id);
        }

        public Task<IActionResult> SearchForLocationByCoords(string lat,string lng) {

            return null;
        }

    }
}
