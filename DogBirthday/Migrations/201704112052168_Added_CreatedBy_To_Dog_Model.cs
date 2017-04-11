namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_CreatedBy_To_Dog_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "CreatedBy", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "CreatedBy");
        }
    }
}
