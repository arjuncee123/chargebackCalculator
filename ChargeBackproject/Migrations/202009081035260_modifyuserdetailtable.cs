namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuserdetailtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "ContactNumber", c => c.String(nullable: false));
            AlterColumn("dbo.UserDetails", "UserCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "UserCategory", c => c.Int(nullable: false));
            AlterColumn("dbo.UserDetails", "ContactNumber", c => c.String());
            DropColumn("dbo.UserDetails", "ConfirmPassword");
        }
    }
}
