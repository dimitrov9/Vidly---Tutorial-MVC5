namespace Vidly___Tutorial_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvaliableInMovieEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvaliable", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvaliable");
        }
    }
}
