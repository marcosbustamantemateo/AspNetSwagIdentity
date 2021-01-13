using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace PlantillaBack.Models
{
    public class ModelFactory
    {
        private UserManager<ApplicationUser> _AppUserManager;
        private UrlHelper _UrlHelper;

        public ModelFactory(HttpRequestMessage request, UserManager<ApplicationUser> appUserManager)
        {
            _UrlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        public UserReturn Create(ApplicationUser appUser)
        {
            return new UserReturn
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Level = appUser.Level,
                JoinDate = appUser.JoinDate,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
            };
        }

        public RoleReturn Create(IdentityRole appRole)
        {
            return new RoleReturn
            {
                Url = _UrlHelper.Link("GetUserById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }
}