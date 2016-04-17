namespace Durandal_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Take2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaxRate = c.Int(nullable: false),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductModels", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductModels", "LastUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductModels", "StorageAmount", c => c.Int(nullable: false));
            AddColumn("dbo.ProductModels", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductModels", "Category_Id");
            AddForeignKey("dbo.ProductModels", "Category_Id", "dbo.CategoryModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductModels", "Category_Id", "dbo.CategoryModels");
            DropIndex("dbo.ProductModels", new[] { "Category_Id" });
            DropColumn("dbo.ProductModels", "Category_Id");
            DropColumn("dbo.ProductModels", "StorageAmount");
            DropColumn("dbo.ProductModels", "LastUpdated");
            DropColumn("dbo.ProductModels", "Created");
            DropTable("dbo.CategoryModels");
        }
    }
}
