namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complainttableaddeddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplaintDetails", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComplaintDetails", "CustomerId");
        }
    }
}
