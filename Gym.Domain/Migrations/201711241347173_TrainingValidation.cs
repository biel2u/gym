namespace Gym.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainingValidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Name");
        }
    }
}
