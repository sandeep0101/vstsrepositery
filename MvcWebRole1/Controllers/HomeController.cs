using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MvcWebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //LocalResource localResource = RoleEnvironment.GetLocalResource("LocalStorageConnectionString");
            //string text = "Azure Rocks! ";
            //System.IO.File.WriteAllText(localResource.RootPath + "\\myFile.txt", text);

            CloudStorageAccount account = CloudStorageAccount.Parse(
    CloudConfigurationManager.GetSetting("StorageConnectionString"));



            CloudBlobClient blobClient = account.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob12");

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(@"C:\Users\OM\Desktop\Ploicy\IMG_20180108_155038.jpg"))
            {
                
                blockBlob.UploadFromStream(fileStream);
            }


            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
