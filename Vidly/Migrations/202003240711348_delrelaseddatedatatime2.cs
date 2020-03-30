namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class delrelaseddatedatatime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
