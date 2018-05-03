using es.eit.mvc_api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace es.eit.mvc_api.App_Start
{
    public class SeedIdentityInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed( ApplicationDbContext context )
        {
            if ( !context.Roles.Any( r => r.Name == "Administrator" ) )
            {
                var store = new RoleStore<IdentityRole>( context );
                var manager = new RoleManager<IdentityRole>( store );
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create( role );
            }

            if ( !context.Roles.Any( r => r.Name == "Query" ) )
            {
                var store = new RoleStore<IdentityRole>( context );
                var manager = new RoleManager<IdentityRole>( store );
                var role = new IdentityRole { Name = "Query" };

                manager.Create( role );
            }

            if ( !context.Users.Any( u => u.Email == "admin@eit.es" ) )
            {
                var store = new UserStore<ApplicationUser>( context );
                var manager = new UserManager<ApplicationUser>( store );
                var user = new ApplicationUser { UserName = "admin@eit.es" };

                manager.Create( user, "1admin@eit.es" );
                manager.AddToRole( user.Id, "Administrator" );
            }

            if ( !context.Users.Any( u => u.Email == "consulta@eit.es" ) )
            {
                var store = new UserStore<ApplicationUser>( context );
                var manager = new UserManager<ApplicationUser>( store );
                var user = new ApplicationUser { UserName = "consulta@eit.es" };

                manager.Create( user, "1consulta@eit.es" );
                manager.AddToRole( user.Id, "Query" );
            }
            //base.Seed( context );
        }
    }
}