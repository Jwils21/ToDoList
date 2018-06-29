namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedlistmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lists", "User_Id", "dbo.Users");
            DropIndex("dbo.Lists", new[] { "User_Id" });
            DropColumn("dbo.Lists", "UserId");
            RenameColumn(table: "dbo.Lists", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Lists", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lists", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Lists", "UserId");
            AddForeignKey("dbo.Lists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lists", "UserId", "dbo.Users");
            DropIndex("dbo.Lists", new[] { "UserId" });
            AlterColumn("dbo.Lists", "UserId", c => c.Int());
            AlterColumn("dbo.Lists", "UserId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Lists", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Lists", "UserId", c => c.String(nullable: false));
            CreateIndex("dbo.Lists", "User_Id");
            AddForeignKey("dbo.Lists", "User_Id", "dbo.Users", "Id");
        }
    }
}
