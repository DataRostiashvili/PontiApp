using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public class ImageRepository : IImageRepository
    {
        public MongoClient client { get; set; }
        public IMongoDatabase DB { get; set; }
        public GridFSBucket FS { get; set; }
        public IHttpClientFactory ClientFac { get; set; }

        public ImageRepository(MongoClient _client,IHttpClientFactory _ClientFac)
        {
            client = _client;
            DB = client.GetDatabase("DBname");
            FS = new GridFSBucket(DB);
            
            
        }
        public async Task DeleteImage(string FileID)=>await FS.DeleteAsync(FileID);

        public async Task<byte[]> GetImage(string FileID)=> await FS.DownloadAsBytesAsync(FileID);


        public async Task PostImage(byte[] imgData)
        { 

        }
        

        public async Task PostImage(string Uri)
        {
            var httpClient = ClientFac.CreateClient();
            var imgData = await httpClient.GetByteArrayAsync(Uri);
            await FS.UploadFromBytesAsync(new Guid().ToString(),imgData);
        }
    }
}
