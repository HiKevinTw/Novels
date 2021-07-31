using Novels.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novels.Repository
{
	public class DataContext : DbContext
	{
		public DbSet<Novel> Novels { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<HtmlRule> HtmlRules { get; set; }
		public DataContext()
			: base("TestNovels")
		{
			this.Configuration.AutoDetectChangesEnabled = false;
			this.Configuration.ProxyCreationEnabled = false;
			this.Configuration.UseDatabaseNullSemantics = true;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Novel>()
				.HasMany<Chapter>(x => x.Chapters)
				.WithRequired(x => x.Novel)
				.HasForeignKey(x => x.NovelID)
				.WillCascadeOnDelete(true);				// 隨同父層一起被刪除

			modelBuilder.Entity<HtmlRule>()
				.HasRequired(x=>x.Novels)
				.WithMany()
				.WillCascadeOnDelete(false);            // 不隨同父層一起被刪除

			base.OnModelCreating(modelBuilder);
		}
		public  static DbContext GetContext()
		{
			var context = new DataContext();

			context.Configuration.AutoDetectChangesEnabled = false;

			return context;
		}
	}
}
