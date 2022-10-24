namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Solution : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Solution", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Solution", "Description", c => c.String(maxLength: 500));
        }
    }
}
