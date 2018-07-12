namespace Vidly___Tutorial_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddBirthdateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(storeType: "date", nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
