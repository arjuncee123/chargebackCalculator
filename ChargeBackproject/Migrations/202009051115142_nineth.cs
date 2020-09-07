namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nineth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "UserCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "UserCategory");
        }
    }
}
