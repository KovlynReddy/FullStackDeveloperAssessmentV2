using FullStackAPIAssessment.Interfaces;
using FullStackAPIAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackDeveloperAssessment.Data.DataAccess
{
    public class LocationProccessor : ILocationsDB
    {
        private readonly FullStackDeveloperAssessmentContext context;

        public LocationProccessor(FullStackDeveloperAssessmentContext context)
        {
            this.context = context;
        }

        public ImageModel AddImage(ImageModel model)
        {
            throw new NotImplementedException();
        }

        public LocationModel AddLocation(LocationModel model)
        {
            throw new NotImplementedException();
        }

        public ImageModel DeleteImage(ImageModel model)
        {
            throw new NotImplementedException();
        }

        public ImageModel DeleteImage(string id)
        {
            throw new NotImplementedException();
        }

        public LocationModel DeleteLocation(LocationModel model)
        {
            throw new NotImplementedException();
        }

        public LocationModel DeleteLocation(string id)
        {
            throw new NotImplementedException();
        }

        public ImageModel EditImage(ImageModel model)
        {
            throw new NotImplementedException();
        }

        public LocationModel EditLocation(LocationModel model)
        {
            throw new NotImplementedException();
        }

        public List<ImageModel> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public List<LocationModel> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public List<LocationModel> GetAllMyLocations(string id)
        {
            var locations = context.LocationModel.ToList();
            return locations = locations.Where(m => m.photoid == id).ToList(); 
        }

        public ImageModel GetImage(int id)
        {
            throw new NotImplementedException();
        }

        public ImageModel GetImage(string id)
        {
            throw new NotImplementedException();
        }

        public LocationModel GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        public LocationModel GetLocation(string id)
        {
            throw new NotImplementedException();
        }

        List<ImageModel> ILocationsDB.GetAllMyImages(string id)
        {
            var images = context.ImageModel.ToList();
            return images.Where(m => m.meta == id).ToList();
        }
    }
}
