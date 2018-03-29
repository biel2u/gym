namespace Gym.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentExercise : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "Name", c => c.String(nullable: false));
        }
    }
}
