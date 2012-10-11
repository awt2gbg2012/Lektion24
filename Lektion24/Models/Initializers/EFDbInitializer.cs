using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lektion24.Models.Contexts;
using Lektion24.Models.Entities;

namespace Lektion24.Models.DBInitializers
{
    public class EFDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var user1 = new User { ID = new Guid("8B1A6E4F-BBF2-442D-8420-71C2A4175DEC"), UserName = "User1", FirstName = "FirstName1", LastName = "LastName1", Email = "email1@test.com", PasswordHash = @"$2a$10$yYk7IHL5ti0JT78TzkedVeAdj0UZsoiJgQwvr1LvUkH.miMKAnQC.", Salt = @"$2a$10$yYk7IHL5ti0JT78TzkedVe", Role = (int)UserRoles.User };
            var user2 = new User { ID = new Guid("D9D2B26E-E159-4B52-AE4E-58576302E4D1"), UserName = "User2", FirstName = "FirstName2", LastName = "LastName2", Email = "email2@test.com", PasswordHash = @"$2a$10$qYm0PhMU0hXsRb/ZDxRfy.ZaotnWQp7YUf6sYPS70yJgOm0..c9Ly", Salt = @"$2a$10$qYm0PhMU0hXsRb/ZDxRfy.", Role = (int)UserRoles.User };
            var user3 = new User { ID = new Guid("E24D78A9-139C-42DF-9E8B-ECAD03F6B0E1"), UserName = "User3", FirstName = "FirstName3", LastName = "LastName3", Email = "email3@test.com", PasswordHash = @"$2a$10$o8N.M4gtOep4aRkY2MRxv.DCMUfdaIcBW3m/y0kwHWAJe5hT5NJUS", Salt = @"$2a$10$o8N.M4gtOep4aRkY2MRxv.", Role = (int)UserRoles.User };
            var userList = new List<User> { user1, user2, user3 };
            userList.ForEach(u => context.User.Add(u));
            context.SaveChanges();

            var cat1 = new Category { ID = new Guid("16F30A9B-F699-4C84-AB18-95F4B5A80E38"), Name = "TestCat 1" };
            var cat2 = new Category { ID = new Guid("1EC0F86D-4D88-44FE-946D-AAB26D491ACA"), Name = "TestCat 2" };
            var cat3 = new Category { ID = new Guid("CC0D43AC-5C3E-4F00-9AE8-B1EAB92FD402"), Name = "TestCat 3" };
            var cat4 = new Category { ID = new Guid("3B7D5B96-4FB7-49FE-8FC7-F16787E8CED1"), Name = "TestCat 4" };
            var cat5 = new Category { ID = new Guid("6D67050A-9402-4DCC-9EE6-921C8D73CB33"), Name = "TestCat 5" };
            var cat6 = new Category { ID = new Guid("46660809-8AA9-4605-BC67-4097AD6ED2B3"), Name = "TestCat 6" };
            var catList = new List<Category> { cat1, cat2, cat3, cat4, cat5, cat6 };
            catList.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var tag1 = new Tag { ID = new Guid("CA820046-7B9E-4FDE-8B07-0CB0444938F8"), Name = "Tag 1" };
            var tag2 = new Tag { ID = new Guid("5AC3242E-538D-416E-8A8C-7C61312EA104"), Name = "Tag 2" };
            var tag3 = new Tag { ID = new Guid("9B0160C1-AC84-44F4-8CBB-6BCA7FC0E103"), Name = "Tag 3" };
            var tag4 = new Tag { ID = new Guid("C63B47B8-EE70-4F57-89C9-BF908CDDF7F6"), Name = "Tag 4" };
            var tag5 = new Tag { ID = new Guid("6D905CEB-8BAB-48E4-BD69-022F83D57C03"), Name = "Tag 5" };
            var tag6 = new Tag { ID = new Guid("E2D8A875-9EB5-49C1-96C6-17811A45C776"), Name = "Tag 6" };
            var tagList = new List<Tag> { tag1, tag2, tag3, tag4, tag5, tag6 };
            tagList.ForEach(t => context.Tags.Add(t));
            context.SaveChanges();

            var news1 = new News { ID = new Guid("E558ABF4-44BB-49B1-AF94-C97108C91F41"), Title = "News Title 1", Body = "News Body 1", CategoryID = cat1.ID, PostedBy = user1 };
            var news2 = new News { ID = new Guid("6E2202AF-749F-4D84-936F-2E1CD8ADB165"), Title = "News Title 2", Body = "News Body 2", CategoryID = cat2.ID, PostedBy = user2 };
            var news3 = new News { ID = new Guid("6141D2B0-EADB-4520-B347-170BEDBBE5F1"), Title = "News Title 3", Body = "News Body 3", CategoryID = cat3.ID, PostedBy = user3 };
            var news4 = new News { ID = new Guid("C257E711-B0C5-4CE9-A8B1-E61FA0F15637"), Title = "News Title 4", Body = "News Body 4", CategoryID = cat4.ID, PostedBy = user1 };
            var news5 = new News { ID = new Guid("3CC2BB6E-2670-496B-96B6-C77699AA9C9F"), Title = "News Title 5", Body = "News Body 5", CategoryID = cat5.ID, PostedBy = user2 };
            var news6 = new News { ID = new Guid("22A115BA-7F8A-4FE0-A5B7-3F655DE9AF9C"), Title = "News Title 6", Body = "News Body 6", CategoryID = cat6.ID, PostedBy = user3 };
            var news7 = new News { ID = new Guid("8D77E964-F72D-456B-814E-ABF6965CC41F"), Title = "News Title 7", Body = "News Body 7", CategoryID = cat1.ID, PostedBy = user1 };
            var news8 = new News { ID = new Guid("88C19659-F3F7-400A-BF61-6733A3564832"), Title = "News Title 8", Body = "News Body 8", CategoryID = cat2.ID, PostedBy = user2 };
            var news9 = new News { ID = new Guid("E20F0CF0-AF11-4B69-AF63-B6A95FF7904E"), Title = "News Title 9", Body = "News Body 9", CategoryID = cat3.ID, PostedBy = user3 };
            var news10 = new News { ID = new Guid("2E0E70C7-6E61-4502-9CA9-36120F209176"), Title = "News Title 10", Body = "News Body 10", CategoryID = cat4.ID, PostedBy = user1 };
            var news11 = new News { ID = new Guid("1E155D80-4B57-4EC2-A325-AE49A6990589"), Title = "News Title 11", Body = "News Body 11", CategoryID = cat5.ID, PostedBy = user2 };
            var news12 = new News { ID = new Guid("C2AFF3C3-AD7F-479E-847C-7A97B866030E"), Title = "News Title 12", Body = "News Body 12", CategoryID = cat6.ID, PostedBy = user3 };
            news1.Tags = new List<Tag>(); news1.Tags.Add(tag1); news1.Tags.Add(tag2);
            news2.Tags = new List<Tag>(); news2.Tags.Add(tag1);
            news3.Tags = new List<Tag>(); news3.Tags.Add(tag2);
            news4.Tags = new List<Tag>(); news4.Tags.Add(tag3); news4.Tags.Add(tag4);
            news5.Tags = new List<Tag>(); news5.Tags.Add(tag5);
            news6.Tags = new List<Tag>(); news6.Tags.Add(tag6);
            news7.Tags = new List<Tag>(); news7.Tags.Add(tag1); news7.Tags.Add(tag2);
            news8.Tags = new List<Tag>(); news8.Tags.Add(tag1);
            news9.Tags = new List<Tag>(); news9.Tags.Add(tag2);
            news10.Tags = new List<Tag>(); news10.Tags.Add(tag3); news10.Tags.Add(tag4);
            news11.Tags = new List<Tag>(); news11.Tags.Add(tag5);
            news12.Tags = new List<Tag>(); news12.Tags.Add(tag6);
            var newsList = new List<News> { news1, news2, news3, news4, news5, news6, news7, news8, news9, news10, news11, news12 };
            newsList.ForEach(n => context.News.Add(n));
            context.SaveChanges();

            var newsCaption1 = new NewsCaption { ID = news1.ID, Caption = "News Caption 1" };
            var newsCaption2 = new NewsCaption { ID = news2.ID, Caption = "News Caption 2" };
            var newsCaption3 = new NewsCaption { ID = news3.ID, Caption = "News Caption 3" };
            var newsCaption4 = new NewsCaption { ID = news4.ID, Caption = "News Caption 4" };
            var newsCaption5 = new NewsCaption { ID = news5.ID, Caption = "News Caption 5" };
            var newsCaption6 = new NewsCaption { ID = news6.ID, Caption = "News Caption 6" };
            var newsCaption7 = new NewsCaption { ID = news7.ID, Caption = "News Caption 7" };
            var newsCaption8 = new NewsCaption { ID = news8.ID, Caption = "News Caption 8" };
            var newsCaption9 = new NewsCaption { ID = news9.ID, Caption = "News Caption 9" };
            var newsCaption10 = new NewsCaption { ID = news10.ID, Caption = "News Caption 10" };
            var newsCaption11 = new NewsCaption { ID = news11.ID, Caption = "News Caption 11" };
            var newsCaption12 = new NewsCaption { ID = news12.ID, Caption = "News Caption 12" };
            var captionList = new List<NewsCaption> { newsCaption1, newsCaption2, newsCaption3, newsCaption4, newsCaption5, newsCaption6, newsCaption7, newsCaption8, newsCaption9, newsCaption10, newsCaption11, newsCaption12 };
            captionList.ForEach(nc => context.NewsCaptions.Add(nc));
            context.SaveChanges();
        }
    }
}