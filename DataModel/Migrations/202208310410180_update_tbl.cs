namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Introduce", "Image", c => c.String(maxLength: 250));
            AddColumn("dbo.Introduce", "CategoryID", c => c.Long());
            AddColumn("dbo.Introduce", "TopHot", c => c.DateTime());
            AddColumn("dbo.Introduce", "ViewCount", c => c.Int());
            AddColumn("dbo.Introduce", "Tags", c => c.String(maxLength: 500));
            AlterColumn("dbo.Introduce", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Introduce", "Status", c => c.Boolean());
            DropColumn("dbo.Introduce", "Tags");
            DropColumn("dbo.Introduce", "ViewCount");
            DropColumn("dbo.Introduce", "TopHot");
            DropColumn("dbo.Introduce", "CategoryID");
            DropColumn("dbo.Introduce", "Image");
        }
    }
}
