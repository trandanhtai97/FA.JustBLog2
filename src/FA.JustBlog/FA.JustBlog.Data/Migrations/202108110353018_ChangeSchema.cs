namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Posts", newSchema: "common");
            MoveTable(name: "dbo.Comments", newSchema: "common");
            MoveTable(name: "dbo.Tags", newSchema: "common");
        }
        
        public override void Down()
        {
            MoveTable(name: "common.Tags", newSchema: "dbo");
            MoveTable(name: "common.Comments", newSchema: "dbo");
            MoveTable(name: "common.Posts", newSchema: "dbo");
        }
    }
}
