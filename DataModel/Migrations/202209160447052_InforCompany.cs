namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InforCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InforCompany", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.InforCompany", "ModifiedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InforCompany", "ModifiedBy");
            DropColumn("dbo.InforCompany", "ModifiedDate");
        }
    }
}
