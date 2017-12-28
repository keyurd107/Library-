namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolesInUserDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDbs", "Roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDbs", "Roles");
        }
    }
}
