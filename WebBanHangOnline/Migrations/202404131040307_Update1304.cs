namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1304 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            AddColumn("dbo.tb_OrderDetail", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.tb_OrderDetail", "Quantity", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_OrderDetail", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_OrderDetail");
            AlterColumn("dbo.tb_OrderDetail", "Quantity", c => c.String());
            DropColumn("dbo.tb_OrderDetail", "Id");
            AddPrimaryKey("dbo.tb_OrderDetail", new[] { "OrderId", "ProductId" });
        }
    }
}
