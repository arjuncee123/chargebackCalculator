namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenth : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserDetails");
            AddColumn("dbo.UserDetails", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserDetails", "FirstName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserDetails", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserDetails");
            AlterColumn("dbo.UserDetails", "FirstName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserDetails", "Id");
            AddPrimaryKey("dbo.UserDetails", "FirstName");
        }
    }
}
