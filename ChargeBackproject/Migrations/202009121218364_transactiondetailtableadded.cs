namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactiondetailtableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Debit = c.Int(nullable: false),
                        Credit = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionDetails");
        }
    }
}
