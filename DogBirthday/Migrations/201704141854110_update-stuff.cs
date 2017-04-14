namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestuff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dogs", "DogName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dogs", "DogName", c => c.String(nullable: false));
        }
    }
}
