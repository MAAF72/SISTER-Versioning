using Microsoft.AspNetCore.Mvc;
using sister_versioning_server.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sister_versioning_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class versioningController : ControllerBase
    {
        public static string currentVersion = "0.0.1";

        public static List<Versioning> versionings = new List<Versioning>()
        {
            new Versioning(currentVersion, "Insert Link Here", "Insert Desc Here")
        };

        // GET: api/<VersioningController>
        /// <summary>
        /// Get Lastest Version
        /// </summary>
        /// <returns>lastest version</returns>
        [HttpGet]
        public Versioning GetLastestVersion()
        {
            return versionings.Count > 0 ? versionings[versionings.Count - 1] : null;
        }

        // GET api/<VersioningController>/5
        /// <summary>
        /// Get version configuraton
        /// </summary>
        /// <param name="version">version to get</param>
        /// <returns>selected version</returns>
        [HttpGet("{version}")]
        public Versioning GetSelectedVersion(string version)
        {
            return versionings.Find(ver => ver.Version == version);
        }

        // POST api/<VersioningController>
        /// <summary>
        /// Post version configuraton
        /// </summary>
        /// <param name="versioning">version to post</param>
        [HttpPost]
        public void Post([FromBody] Versioning versioning)
        {
            versionings.Add(versioning);
            currentVersion = versioning.Version;
        }

        // PUT api/<VersioningController>/5
        /// <summary>
        /// Update version configuraton 
        /// </summary>
        /// <param name="version">version to update</param>
        /// <param name="versioning">json configuration</param>
        [HttpPut("{version}")]                       
        public void Put(string version, [FromBody] Versioning versioning)
        {
            int index = versionings.FindIndex(vers => vers.Version == version);
            if (index != -1)
                versionings[index] = versioning;

            currentVersion = versionings[versionings.Count - 1].Version;
        }

        // DELETE api/<VersioningController>/5
        /// <summary>
        /// Remove version configuraton
        /// </summary>
        /// <param name="version">version to delete</param>
        [HttpDelete("{version}")]
        public void Delete(string version)
        {
            versionings = versionings.Where(ver => ver.Version != version).ToList();
            currentVersion = versionings.Count > 0 ? versionings[versionings.Count - 1].Version:"-1";
        }
    }
}
