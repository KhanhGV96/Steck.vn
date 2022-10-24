namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Document : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Description", c => c.String(maxLength: 500));
        }
    }
}
