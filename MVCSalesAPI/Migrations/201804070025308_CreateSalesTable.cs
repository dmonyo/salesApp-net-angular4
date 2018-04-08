namespace MVCSalesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSalesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        FOLIO_NUMBER = c.String(nullable: false, maxLength: 12),
                        SALE_DATE = c.DateTime(nullable: false),
                        SALE_AMOUNT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FOLIO_NUMBER);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
