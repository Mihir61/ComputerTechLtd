namespace ComputerTechLtd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderItems", "ProductId");
            AddForeignKey("dbo.OrderItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
        }
    }
}
