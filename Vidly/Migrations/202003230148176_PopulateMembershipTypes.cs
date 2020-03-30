namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id,Name,SignUpFee, DurationInMonths, DiscountRate) values(1,'Pay as You Go',0,0,0)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SignUpFee, DurationInMonths, DiscountRate) values(2,'Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SignUpFee, DurationInMonths, DiscountRate) values(3,'Quarterly',90,3,15)");
            Sql("INSERT INTO MembershipTypes (Id,Name,SignUpFee, DurationInMonths, DiscountRate) values(4,'Annualy',300,12,30)");
        }

        public override void Down()
        {
        }
    }
}
