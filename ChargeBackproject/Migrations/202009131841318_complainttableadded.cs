namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complainttableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        BankAccountNumber = c.Int(nullable: false),
                        BranchName = c.String(nullable: false),
                        Reason = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ComplaintDetails");
        }
    }
}
