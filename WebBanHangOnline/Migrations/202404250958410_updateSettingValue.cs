namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSettingValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_SystemSetting", "SettingValue", c => c.String(maxLength: 4000));
            DropColumn("dbo.tb_SystemSetting", "SetiingValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_SystemSetting", "SetiingValue", c => c.String(maxLength: 4000));
            DropColumn("dbo.tb_SystemSetting", "SettingValue");
        }
    }
}
