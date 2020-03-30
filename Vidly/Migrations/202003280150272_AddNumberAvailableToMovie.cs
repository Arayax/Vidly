namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNumberAvailableToMovie : DbMigration
    {
        public override void Up()
        {


            AddColumn("dbo.Movies", "NumberAvaiable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies set NumberAvailable = NumberInStock");
        }


        public override void Down()
        {

        }
    }
}
