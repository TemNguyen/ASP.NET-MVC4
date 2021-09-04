namespace ASP_MVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            Sql("update Customers set Birthday = '1/1/1990' where Id = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthday");
        }
    }
}
