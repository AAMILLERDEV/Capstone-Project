using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
using System.Numerics;
using System.Runtime.InteropServices;

namespace prs_5SAudits.lib.Repositories
{
    public class ResourcesRepository : IResources
    {
        private readonly IDBSQLRepository db;

        public ResourcesRepository(IOptionsMonitor<AppSettings> options)
        {
            db = new DBSQLRepository(options.CurrentValue.DbConn);
        }
        
        public Task<IEnumerable<Resources>> GetResourcesByAuditId(int audit_ID) => db.GetResourcesByAuditId(audit_ID);
        public async Task<int?> UpsertResources(Resources resources)
        {
            int? ID = await db.UpsertResources(resources);
            if (ID.HasValue)
            {
                CreateResource(resources, ID.Value);
            }
            return ID;
        }

        public async Task<bool> CreateResource(Resources resource, int ID)
        {
            try
            {

                //First upsert a resource record

                //Grab the ID of the added record

                //Use the ID to create a name for the photo to be used in the path

                //Get the path from the setting case (get PhotoDestPath)

                string documentsDestPath = "..\\prs.5SAudits.lib\\Assets\\PhotosRepository";

                string absolutePath = Path.GetFullPath(documentsDestPath);

                Console.WriteLine("Absolute Path: " + absolutePath);

                using var memStream = new MemoryStream(Convert.FromBase64String(resource.ResourceData));
                using var fileStream = System.IO.File.OpenWrite(documentsDestPath + $"/{ID}_photo.jpeg");
                await memStream.CopyToAsync(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                //Add event log
                return false;
            }


        }

        
        public Task<bool> DeleteResource(int id) => db.DeleteResource(id);


    }
}
