using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using SmartKitchen.Models;

namespace SmartKitchen_1.Models
{
	public class SmartKitchen_1Db : DbContext{

		public SmartKitchen_1Db() : base("name=SmartKitchen_1DbConnectionString") { }

		public virtual DbSet<Produtos> Produtos { get; set; }
		public virtual DbSet<Categorias> Categorias { get; set; }
		public virtual DbSet<Clientes> Clientes { get; set; }
		public virtual DbSet<Encomendas> Encomendas { get; set; }
		public virtual DbSet<Imagens> Imagens { get; set; }
		public virtual DbSet<EncProd> EncProd { get; set; }

	}
}