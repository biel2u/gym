namespace Gym.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentTraining : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
