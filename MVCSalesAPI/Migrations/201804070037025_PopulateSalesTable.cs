namespace MVCSalesAPI.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateSalesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sales (FOLIO_NUMBER, SALE_DATE, SALE_AMOUNT) VALUES('484123AA1990', '2017/08/05', 38.000)");
            Sql("INSERT INTO Sales (FOLIO_NUMBER, SALE_DATE, SALE_AMOUNT) VALUES('484123AA0540', '2017/05/04', 54.000)");
            Sql("INSERT INTO Sales (FOLIO_NUMBER, SALE_DATE, SALE_AMOUNT) VALUES('484123AA0780', '2017/11/01', 44.000)");
            Sql("INSERT INTO Sales (FOLIO_NUMBER, SALE_DATE, SALE_AMOUNT) VALUES('484123AA0800', '2017/01/17', 50.000)");


        }

        public override void Down()
        {
            Sql("DELETE FROM Sales WHERE FOLIO_NUMBER IN ('484123AA1990', '484123AA0540', '484123AA0780', '484123AA0800','484123AA0130' )");
        }
    }
}
