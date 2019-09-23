namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        CategoryId = c.Int(),
                        LevelId = c.Int(nullable: false),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .Index(t => t.CategoryId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Age = c.Int(),
                        Address = c.String(maxLength: 250),
                        Phone = c.String(maxLength: 50),
                        RoleId = c.Int(),
                        AccountId = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(),
                        IP = c.String(maxLength: 50, unicode: false),
                        Func = c.String(maxLength: 50),
                        Action = c.String(maxLength: 50),
                        Time = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Desctiption = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Function",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleFuntion",
                c => new
                    {
                        FuncId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncId, t.RoleId })
                .ForeignKey("dbo.Function", t => t.FuncId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.FuncId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserTest",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestId, t.UserId })
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuestionTest",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.TestId })
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Test", t => t.TestId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.QuestionAnswer",
                c => new
                    {
                        AnswerId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnswerId, t.QuestionId })
                .ForeignKey("dbo.Answer", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.AnswerId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionAnswer", "AnswerId", "dbo.Answer");
            DropForeignKey("dbo.QuestionTest", "TestId", "dbo.Test");
            DropForeignKey("dbo.QuestionTest", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.UserTest", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTest", "TestId", "dbo.Test");
            DropForeignKey("dbo.User", "Id", "dbo.Role");
            DropForeignKey("dbo.RoleFuntion", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleFuntion", "FuncId", "dbo.Function");
            DropForeignKey("dbo.Log", "UserId", "dbo.User");
            DropForeignKey("dbo.Question", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Question", "CategoryId", "dbo.Category");
            DropIndex("dbo.QuestionAnswer", new[] { "QuestionId" });
            DropIndex("dbo.QuestionAnswer", new[] { "AnswerId" });
            DropIndex("dbo.QuestionTest", new[] { "TestId" });
            DropIndex("dbo.QuestionTest", new[] { "QuestionId" });
            DropIndex("dbo.UserTest", new[] { "UserId" });
            DropIndex("dbo.UserTest", new[] { "TestId" });
            DropIndex("dbo.RoleFuntion", new[] { "RoleId" });
            DropIndex("dbo.RoleFuntion", new[] { "FuncId" });
            DropIndex("dbo.Log", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "Id" });
            DropIndex("dbo.Question", new[] { "LevelId" });
            DropIndex("dbo.Question", new[] { "CategoryId" });
            DropTable("dbo.QuestionAnswer");
            DropTable("dbo.QuestionTest");
            DropTable("dbo.UserTest");
            DropTable("dbo.RoleFuntion");
            DropTable("dbo.Function");
            DropTable("dbo.Role");
            DropTable("dbo.Log");
            DropTable("dbo.User");
            DropTable("dbo.Test");
            DropTable("dbo.Level");
            DropTable("dbo.Category");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
