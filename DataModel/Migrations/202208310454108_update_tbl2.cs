namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Introduce", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Introduce", "Description");
        }
    }
}
