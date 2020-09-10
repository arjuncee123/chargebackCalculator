namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userroleadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoginDetails", "RoleOfUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoginDetails", "RoleOfUser");
        }
    }
}
