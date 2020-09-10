namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addagainconfirm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "ConfirmPassword");
        }
    }
}
