namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) values(1,'Action')");
            Sql("INSERT INTO Genres (Id,Name) values(2,'Family')");
            Sql("INSERT INTO Genres (Id,Name) values(3,'Romance')");
            Sql("INSERT INTO Genres (Id,Name) values(4,'Thriller')");
        }

        public override void Down()
        {
        }
    }
}
