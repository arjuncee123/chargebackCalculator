namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latefeeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionDetails", "LateFee", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionDetails", "LateFee");
        }
    }
}
