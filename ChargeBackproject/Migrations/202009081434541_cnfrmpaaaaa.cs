namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cnfrmpaaaaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "FirstName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "FirstName", c => c.String(nullable: false));
        }
    }
}
