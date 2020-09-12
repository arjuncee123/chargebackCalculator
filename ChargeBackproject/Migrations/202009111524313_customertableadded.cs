namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customertableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerDetails",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        UserId = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BankAccountNumber = c.Int(nullable: false),
                        BankAddress = c.String(),
                        BranchName = c.String(),
                        AvailableBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.UserDetails", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.UserDetails", "BankAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.UserDetails", "BankAddress", c => c.String());
            AddColumn("dbo.UserDetails", "BranchName", c => c.String());
            AddColumn("dbo.UserDetails", "AvailableBalance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "AvailableBalance");
            DropColumn("dbo.UserDetails", "BranchName");
            DropColumn("dbo.UserDetails", "BankAddress");
            DropColumn("dbo.UserDetails", "BankAccountNumber");
            DropColumn("dbo.UserDetails", "CustomerId");
            DropTable("dbo.CustomerDetails");
        }
    }
}
