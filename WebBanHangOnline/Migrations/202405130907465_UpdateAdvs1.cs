namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdvs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Adv", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Adv", "SeoTitle", c => c.String());
            AddColumn("dbo.tb_Adv", "SeoDescription", c => c.String());
            AddColumn("dbo.tb_Adv", "SeoKeywords", c => c.String());
            CreateIndex("dbo.tb_Adv", "CategoryId");
            AddForeignKey("dbo.tb_Adv", "CategoryId", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Adv", "CategoryId", "dbo.tb_Category");
            DropIndex("dbo.tb_Adv", new[] { "CategoryId" });
            DropColumn("dbo.tb_Adv", "SeoKeywords");
            DropColumn("dbo.tb_Adv", "SeoDescription");
            DropColumn("dbo.tb_Adv", "SeoTitle");
            DropColumn("dbo.tb_Adv", "CategoryId");
        }
    }
}
