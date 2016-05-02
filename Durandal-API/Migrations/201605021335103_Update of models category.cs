namespace Durandal_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateofmodelscategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductModels", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.ProductModels", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductModels", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.ProductModels", name: "CategoryId", newName: "Category_Id");
        }
    }
}
