namespace TravelTripProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoordinatesToBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Blogs", "Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Longitude");
            DropColumn("dbo.Blogs", "Latitude");
        }
    }
}
