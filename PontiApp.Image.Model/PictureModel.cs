using MongoDB.Bson;
using System;

namespace PontiApp.Image.Model
{
    public class PictureModel
    {
        public ObjectId _id { get; set; }
        public string ImgArrString { get; set; }
    }
}
