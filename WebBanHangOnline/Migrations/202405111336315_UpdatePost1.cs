namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_Post", newName: "tb_Posts");
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String());
            AlterColumn("dbo.tb_Posts", "Image", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoKeywords", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Posts", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String(maxLength: 250));
            RenameTable(name: "dbo.tb_Posts", newName: "tb_Post");
        }
    }
}
