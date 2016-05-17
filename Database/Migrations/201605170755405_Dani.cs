namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dani : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IsDeleted");
        }
    }
}
