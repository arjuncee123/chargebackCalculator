namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactiondetailtableaddednew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransactionDetails", "PaymentDate", c => c.String());
            AlterColumn("dbo.TransactionDetails", "DueDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionDetails", "DueDate", c => c.DateTime());
            AlterColumn("dbo.TransactionDetails", "PaymentDate", c => c.DateTime());
        }
    }
}
