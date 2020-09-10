namespace ChargeBackproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ertertert1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "UserCategory", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "UserCategory", c => c.String(nullable: false));
        }
    }
}
