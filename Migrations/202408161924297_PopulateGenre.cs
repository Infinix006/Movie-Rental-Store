﻿namespace Movie_Rental_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id , Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id , Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id , Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id , Name) VALUES (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
