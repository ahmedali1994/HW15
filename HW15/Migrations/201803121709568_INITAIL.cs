namespace HW15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITAIL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tilte = c.String(),
                        Number = c.Int(nullable: false),
                        Depdepartment = c.String(),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Dateassigned = c.DateTime(nullable: false),
                        Datedue = c.DateTime(nullable: false),
                        Datesubmitted = c.DateTime(nullable: false),
                        PointsEarned = c.Int(nullable: false),
                        PointsPossible = c.Int(nullable: false),
                        Class_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.Class_ID)
                .Index(t => t.Class_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstNmae = c.String(),
                        LastName = c.String(),
                        SNN = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Scores", "Class_ID", "dbo.Classes");
            DropIndex("dbo.Scores", new[] { "Class_ID" });
            DropIndex("dbo.Classes", new[] { "Student_ID" });
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.Classes");
        }
    }
}
