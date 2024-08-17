namespace Movie_Rental_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4ccc3c3f-6f93-4c7c-9760-1321d2ccdff7', N'admin@gmail.com', 0, N'AKq9YqZ5mq25dCZhoe+ACdXuXKtvc30+Ws4S9VoAlMCOE3CZ5c6LG4/D66sLNdehuA==', N'f8fe1a56-daaf-4f6b-9b5d-894ee735a3b7', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'abff96c3-a0f3-4388-aa49-beb040fcc8d5', N'guest@gmail.com', 0, N'ABEAgvbNgvuNhOclkq26lwRI6gTWztmLfB52NiSroETCVuqG5Dhv2wwrZq+n5ZfQIA==', N'03d4ec69-4c61-4488-bf9f-0b9d2a6ed272', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'435d3670-7706-4b77-aa0f-cfcb6a6614ad', N'CanManageMovie')
                    
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ccc3c3f-6f93-4c7c-9760-1321d2ccdff7', N'435d3670-7706-4b77-aa0f-cfcb6a6614ad')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
