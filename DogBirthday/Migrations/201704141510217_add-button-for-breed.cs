namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbuttonforbreed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dogs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Dogs", "Owner", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dogs", "Owner", c => c.String());
            AlterColumn("dbo.Dogs", "Name", c => c.String());
        }
    }
}
