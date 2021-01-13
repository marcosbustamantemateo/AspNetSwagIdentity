using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PlantillaBack.Models;
using System.Web.Http;

namespace PlantillaBack.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;

        public BaseApiController()
        {
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }

        protected UserManager<ApplicationUser> AppUserManager
        {
            get
            {
                var appUserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));
                return appUserManager;
            }
        }

        protected RoleManager<IdentityRole> AppRoleManager
        {
            get
            {
                var appRoleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
                return appRoleManager;
            }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
