using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Image.Model
{
    public class PictureMap
    {
        public PictureMap()
        {
            BsonClassMap.RegisterClassMap<PictureModel>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
