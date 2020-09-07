namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
