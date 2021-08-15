namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "TotalRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "TotalRate");
            DropColumn("dbo.Posts", "RateCount");
            DropColumn("dbo.Posts", "ViewCount");
        }
    }
}
