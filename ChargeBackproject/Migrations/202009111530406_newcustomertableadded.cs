namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcustomertableadded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserDetails", "CustomerId");
            DropColumn("dbo.UserDetails", "BankAccountNumber");
            DropColumn("dbo.UserDetails", "BankAddress");
            DropColumn("dbo.UserDetails", "BranchName");
            DropColumn("dbo.UserDetails", "AvailableBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "AvailableBalance", c => c.Int(nullable: false));
            AddColumn("dbo.UserDetails", "BranchName", c => c.String());
            AddColumn("dbo.UserDetails", "BankAddress", c => c.String());
            AddColumn("dbo.UserDetails", "BankAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.UserDetails", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
