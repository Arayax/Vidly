namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'793e0cd7-669e-4a89-8a16-1a05a1986f43', N'guest@vidly.com', 0, N'AF0AjEfE0+N9Qr7IH0anJV4TQ685TwT1vhwqD3pvdmpvrwA/HLgxPzyP78dKxU6q7w==', N'dda23bf4-3b62-45ab-91e6-b94e3da974b2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ba754ee7-77f2-455c-8cf5-5a53a6eda9b5', N'admin@vidly.com', 0, N'AKuGz9vZhCZ7zhYGXCgloJ+G4qE5oYKiyKiI13yhibe79igHPghH1VYzYfaNgSkOgg==', N'e0a867b0-7dc1-44ae-b895-898374d5ee20', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3ff37980-8c6f-4844-b426-0e763a3c0ba5', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ba754ee7-77f2-455c-8cf5-5a53a6eda9b5', N'3ff37980-8c6f-4844-b426-0e763a3c0ba5')

");

        }

        public override void Down()
        {
        }
    }
}
