namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Alias", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.ProductCategories", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.ProductCategories", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.ProductCategories", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.ProductCategories", "Icon", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Icon", c => c.String());
            DropColumn("dbo.ProductCategories", "SeoKeywords");
            DropColumn("dbo.ProductCategories", "SeoDescription");
            DropColumn("dbo.ProductCategories", "SeoTitle");
            DropColumn("dbo.ProductCategories", "Alias");
        }
    }
}
