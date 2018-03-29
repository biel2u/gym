namespace Gym.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "Category", c => c.String());
        }
    }
}
