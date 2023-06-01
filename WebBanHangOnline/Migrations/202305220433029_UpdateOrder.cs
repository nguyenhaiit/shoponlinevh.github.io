namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "CreateBy", c => c.String());
            AddColumn("dbo.tb_Order", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_Order", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "Email");
            DropColumn("dbo.tb_Order", "ModifiedDate");
            DropColumn("dbo.tb_Order", "CreateBy");
            DropColumn("dbo.tb_Order", "CreateDate");
        }
    }
}
