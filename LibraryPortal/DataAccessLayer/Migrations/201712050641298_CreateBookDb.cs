namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBookDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.String(maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 255),
                        Author = c.String(nullable: false, maxLength: 255),
                        Publish = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookDbs");
        }
    }
}
