namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostedOn", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Posts", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Comments", "CommentTime", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
        }
    }
}
