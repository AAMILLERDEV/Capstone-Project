using Microsoft.Extensions.Options;
using prs_5SAudits.lib.Interfaces;
using prs_5SAudits.lib.Models;
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
        
        public Task<IEnumerable<Resources>> GetResources() => db.GetResources();
        public Task<int?> UpsertResources(Resources resources) => db.UpsertResources(resources);
        public async Task<bool> CreateResource(Resources res)
        {
            try
            {
                //UpsertResources(res);

                //int id = res.id


                //First upsert a resource record

                //Grab the ID of the added record

                //Use the ID to create a name for the photo to be used in the path

                //Get the path from the setting case (get PhotoDestPath)

                string documentsDestPath = "\\\\prsfs\\Presstran\\PressNet Apps\\Sandbox\\Photos";
                using var memStream = new MemoryStream(Convert.FromBase64String(res.ResourceData));
               // using var fileStream = System.IO.File.OpenWrite(documentsDestPath + $"/{ID}_photo.jpeg");
               // await memStream.CopyToAsync(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                //Add event log
                return false;
            }


        }

        public Task<Resources> DeleteResource(int id) => db.DeleteResource(id);


    }
}
