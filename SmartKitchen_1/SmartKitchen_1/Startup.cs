﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using SmartKitchen_1.Models;

namespace SmartKitchen_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }

		public void iniciaApp() {

			ApplicationDbContext db = new ApplicationDbContext();

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

			// criar a Role 'Clientes' 
			 if (!roleManager.RoleExists("Clientes"))
			{
				// não existe a 'role' 
			// então, criar essa role 

				var role = new IdentityRole();

				role.Name = "Clientes";
				roleManager.Create(role);

 }
			 // criar a Role 'Condutores' 

			 if (!roleManager.RoleExists("Gestores"))
			{
			// não existe a 'role' 

			 // então, criar essa role 
			var role = new IdentityRole();
			role.Name = "Gestores";
			roleManager.Create(role);

 }
						// criar um utilizador 'Agente' 
			var user = new ApplicationUser();
			user.UserName = "susMart@mail.com";
			user.Email = "susMart@mail.com";
			//  user.Nome = "Luís Freitas"; 
			string userPWD = "123_Asd";
			var chkUser = userManager.Create(user, userPWD);

			//Adicionar o Utilizador à respetiva Role-Agente- 

			  if (chkUser.Succeeded)
						{
			var result1 = userManager.AddToRole(user.Id, "Clientes");
			  }

			  } 

			   // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97 


 

		}
    }
}
