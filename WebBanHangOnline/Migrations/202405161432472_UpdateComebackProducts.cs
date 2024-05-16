namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComebackProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductCategoryProducts", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductCategoryProducts", "Product_Id", "dbo.tb_Product");
            DropIndex("dbo.ProductCategoryProducts", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductCategoryProducts", new[] { "Product_Id" });
            CreateIndex("dbo.tb_Product", "ProductCategoryId");
            AddForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.ProductCategories", "Id", cascadeDelete: true);
            DropTable("dbo.ProductCategoryProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategoryProducts",
                c => new
                    {
                        ProductCategory_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductCategory_Id, t.Product_Id });
            
            DropForeignKey("dbo.tb_Product", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.tb_Product", new[] { "ProductCategoryId" });
            CreateIndex("dbo.ProductCategoryProducts", "Product_Id");
            CreateIndex("dbo.ProductCategoryProducts", "ProductCategory_Id");
            AddForeignKey("dbo.ProductCategoryProducts", "Product_Id", "dbo.tb_Product", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductCategoryProducts", "ProductCategory_Id", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
    }
}
