namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddogname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "DogName", c => c.String(nullable: false));
            DropColumn("dbo.Dogs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dogs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Dogs", "DogName");
        }
    }
}
