namespace FilmEditor.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Barcode = c.Long(nullable: false),
                        Title = c.String(),
                        Year = c.Short(nullable: false),
                        Length = c.Short(nullable: false),
                        HasGermanSubtitles = c.Boolean(nullable: false),
                        IsBluray = c.Boolean(nullable: false),
                        Country_Id = c.Guid(),
                        Location_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmCountry",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilmId = c.Guid(nullable: false),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.FilmPerson",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilmId = c.Guid(nullable: false),
                        PersonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Film", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstMidName = c.String(),
                        LastName = c.String(),
                        BirthdateString = c.String(),
                        ShortBirthdate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmPerson", "PersonId", "dbo.Person");
            DropForeignKey("dbo.FilmPerson", "FilmId", "dbo.Film");
            DropForeignKey("dbo.FilmCountry", "FilmId", "dbo.Film");
            DropForeignKey("dbo.FilmCountry", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Film", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Film", "Country_Id", "dbo.Country");
            DropIndex("dbo.FilmPerson", new[] { "PersonId" });
            DropIndex("dbo.FilmPerson", new[] { "FilmId" });
            DropIndex("dbo.FilmCountry", new[] { "CountryId" });
            DropIndex("dbo.FilmCountry", new[] { "FilmId" });
            DropIndex("dbo.Film", new[] { "Location_Id" });
            DropIndex("dbo.Film", new[] { "Country_Id" });
            DropTable("dbo.Person");
            DropTable("dbo.FilmPerson");
            DropTable("dbo.FilmCountry");
            DropTable("dbo.Location");
            DropTable("dbo.Film");
            DropTable("dbo.Country");
        }
    }
}
