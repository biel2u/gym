namespace Gym.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExerciseUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercises", "Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Exercises", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Name", c => c.String());
            DropColumn("dbo.Exercises", "Weight");
        }
    }
}
