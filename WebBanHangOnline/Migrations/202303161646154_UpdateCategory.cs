﻿namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.tb_Category", "SaleTitle", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "SeoDescription", c => c.String());
            AlterColumn("dbo.tb_Category", "SaleTitle", c => c.String());
            AlterColumn("dbo.tb_Category", "Title", c => c.String());
        }
    }
}
