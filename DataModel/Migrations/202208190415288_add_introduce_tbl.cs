namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_introduce_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Introduce",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                        Language = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Content", "Introduce_ID", c => c.Long());
            CreateIndex("dbo.Content", "Introduce_ID");
            AddForeignKey("dbo.Content", "Introduce_ID", "dbo.Introduce", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Content", "Introduce_ID", "dbo.Introduce");
            DropIndex("dbo.Content", new[] { "Introduce_ID" });
            DropColumn("dbo.Content", "Introduce_ID");
            DropTable("dbo.Introduce");
        }
    }
}
