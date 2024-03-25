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

        public async Task<IEnumerable<Resources>> GetResourcesByAuditId(int audit_ID)
        {
            var resources = await FetchResources(audit_ID);
            
            var updatedResources = new List<Resources>();

            foreach (var resource in resources)
            {
                string documentsDestPath = "..\\prs.5SAudits.lib\\Assets\\PhotosRepository\\" + resource.ID + "_photo.jpeg"; ;

                if (File.Exists(documentsDestPath))
                {
                    byte[] image = await File.ReadAllBytesAsync(documentsDestPath);
                    string imageBase64 = Convert.ToBase64String(image);

                    var newResource = new Resources
                    {
                        ID = resource.ID,
                        Audit_ID = resource.Audit_ID,
                        DateAdded = resource.DateAdded,
                        Score_ID = resource.Score_ID,
                        IsDeleted = resource.IsDeleted,
                        IsAfter = resource.IsAfter,
                        ResourceData = imageBase64
                    };

                    updatedResources.Add(newResource);
                }
            }

            return updatedResources;
        }

        public Task<IEnumerable<Resources>> FetchResources(int audit_ID) => db.GetResourcesByAuditId(audit_ID);

        public Task<bool> DeleteResource(int id) => db.DeleteResource(id);
        public async Task<int?> UpsertResources(Resources resources)
        {
            var id = await db.UpsertResources(resources);

            if (id != null)
            {
                CreateResource(resources, (int)id);
            }

            return id;
        }

        public async Task<bool> CreateResource(Resources resource, int id)
        {
            try
            {

                string documentsDestPath = "..\\prs.5SAudits.lib\\Assets\\PhotosRepository\\";
                using var memStream = new MemoryStream(Convert.FromBase64String(resource.ResourceData));
                using var fileStream = File.OpenWrite(documentsDestPath + $"{id}_photo.jpeg");
                await memStream.CopyToAsync(fileStream);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
