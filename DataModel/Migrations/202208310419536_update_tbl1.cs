namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Introduce", "Detail", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Introduce", "Detail");
        }
    }
}
