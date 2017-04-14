namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dogs", "DogName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dogs", "DogName", c => c.String());
        }
    }
}
