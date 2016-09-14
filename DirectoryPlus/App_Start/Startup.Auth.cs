using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using CasAuthenticationMiddleware;
using DirectoryPlus.DataContexts;

namespace DirectoryPlus
{
    public partial class Startup
    {
        public DirectoryContext GetDirectoryContext()
        {
            return new DirectoryContext();
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<DirectoryContext>(GetDirectoryContext);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieName = "CAS_EXTERNAL_COOKIE",
                CookieSecure = CookieSecureOption.SameAsRequest
                /*
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }*/
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseCasAuthentication(new CasAuthenticationOptions
            {
                LoginUrl = "https://login.case.edu/cas/login",
                Validator = new CasAuthenticationValidatorV3("https://login.case.edu/cas/p3/serviceValidate")
            });
        }
    }
}