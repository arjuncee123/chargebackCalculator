namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.UserDetails", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "Password");
            DropColumn("dbo.UserDetails", "UserId");
        }
    }
}
