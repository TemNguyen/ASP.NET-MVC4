namespace ASP_MVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            Sql("update MembershipTypes set Name = 'Pay as You Go' where Id = 1");
            Sql("update MembershipTypes set Name = 'Monthly' where Id = 2");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
