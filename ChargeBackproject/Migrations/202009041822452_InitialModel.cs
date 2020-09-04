namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirstName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetails");
        }
    }
}
