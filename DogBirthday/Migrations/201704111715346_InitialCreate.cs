namespace DogBirthday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        BreedID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BreedID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        DogID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DogGender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        BreedID = c.Int(nullable: false),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.DogID)
                .ForeignKey("dbo.Breeds", t => t.BreedID, cascadeDelete: true)
                .Index(t => t.BreedID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            DropTable("dbo.Dogs");
            DropTable("dbo.Breeds");
        }
    }
}
