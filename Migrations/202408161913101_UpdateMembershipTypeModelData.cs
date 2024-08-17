namespace Movie_Rental_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeModelData : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE DiscountRate = 0;");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DiscountRate = 10;");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE DiscountRate = 15;");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE DiscountRate = 20;");
        }
        
        public override void Down()
        {
        }
    }
}
