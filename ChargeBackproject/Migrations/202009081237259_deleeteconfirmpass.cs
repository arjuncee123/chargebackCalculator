namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleeteconfirmpass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserDetails", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "ConfirmPassword", c => c.String(nullable: false));
        }
    }
}
