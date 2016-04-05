namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPersonModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_Id" });
            CreateTable(
                "dbo.BasicInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Fax = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessionalInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastDegreeEarned = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        ExpectedSalary_Min = c.Int(nullable: false),
                        ExpectedSalary_Max = c.Int(nullable: false),
                        CurrentSalary = c.Int(nullable: false),
                        CurrentJobTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "Country", c => c.String());
            AddColumn("dbo.Addresses", "County", c => c.String());
            AddColumn("dbo.Addresses", "City", c => c.String());
            AddColumn("dbo.Addresses", "StreetAddress", c => c.String());
            AddColumn("dbo.People", "CandidateStatus", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Auth_Username", c => c.String());
            AddColumn("dbo.People", "Auth_Password", c => c.String());
            AddColumn("dbo.People", "BasicInfo_Id", c => c.Int());
            AddColumn("dbo.People", "ContactInfo_Id", c => c.Int());
            AddColumn("dbo.People", "ProfessionalInfo_Id", c => c.Int());
            CreateIndex("dbo.People", "BasicInfo_Id");
            CreateIndex("dbo.People", "ContactInfo_Id");
            CreateIndex("dbo.People", "ProfessionalInfo_Id");
            AddForeignKey("dbo.People", "BasicInfo_Id", "dbo.BasicInfoes", "Id");
            AddForeignKey("dbo.People", "ContactInfo_Id", "dbo.ContactInfoes", "Id");
            AddForeignKey("dbo.People", "ProfessionalInfo_Id", "dbo.ProfessionalInfoes", "Id");
            DropColumn("dbo.Addresses", "StreeAddress");
            DropColumn("dbo.Addresses", "HouseNumber");
            DropColumn("dbo.Addresses", "AppartmentNumber");
            DropColumn("dbo.Addresses", "Type");
            DropColumn("dbo.People", "Firstname");
            DropColumn("dbo.People", "Lastname");
            DropColumn("dbo.People", "Address_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Address_Id", c => c.Int());
            AddColumn("dbo.People", "Lastname", c => c.String());
            AddColumn("dbo.People", "Firstname", c => c.String());
            AddColumn("dbo.Addresses", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "AppartmentNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "StreeAddress", c => c.String());
            DropForeignKey("dbo.People", "ProfessionalInfo_Id", "dbo.ProfessionalInfoes");
            DropForeignKey("dbo.People", "ContactInfo_Id", "dbo.ContactInfoes");
            DropForeignKey("dbo.People", "BasicInfo_Id", "dbo.BasicInfoes");
            DropIndex("dbo.People", new[] { "ProfessionalInfo_Id" });
            DropIndex("dbo.People", new[] { "ContactInfo_Id" });
            DropIndex("dbo.People", new[] { "BasicInfo_Id" });
            DropColumn("dbo.People", "ProfessionalInfo_Id");
            DropColumn("dbo.People", "ContactInfo_Id");
            DropColumn("dbo.People", "BasicInfo_Id");
            DropColumn("dbo.People", "Auth_Password");
            DropColumn("dbo.People", "Auth_Username");
            DropColumn("dbo.People", "CandidateStatus");
            DropColumn("dbo.Addresses", "StreetAddress");
            DropColumn("dbo.Addresses", "City");
            DropColumn("dbo.Addresses", "County");
            DropColumn("dbo.Addresses", "Country");
            DropTable("dbo.SocialMedias");
            DropTable("dbo.ProfessionalInfoes");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.BasicInfoes");
            CreateIndex("dbo.People", "Address_Id");
            AddForeignKey("dbo.People", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
