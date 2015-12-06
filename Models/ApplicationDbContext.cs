using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;

namespace WalkUpAdvertisingShellWeb.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyDB", throwIfV1Schema: false)
        {
            System.Data.Entity.Database.SetInitializer(new EntitiesContextInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Device> Devices { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

    }

    public class Device
    {
        [Key]
        public string Id { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }


        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public bool IsDeviceRegistered { get { return !string.IsNullOrEmpty(ApplicationUserId); } }
    }

    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var appUser = new ApplicationUser();

            //appUser.Id = Guid.NewGuid().ToString();

            //appUser.PhoneNumber = "940235454";
            //appUser.PhoneNumberConfirmed = false;
            //appUser.TwoFactorEnabled = false;

            //appUser.LockoutEnabled = true;
            //appUser.AccessFailedCount = 0;
            //appUser.UserName = "me_1986au@hotmail.com";

            //appUser.PasswordHash = "ANtUN7jEFNzDNzxDQuYjnH9PO/WWVGEYEzLgQ2+4oN3N9Sbk++dbz6C577t9I3Pduw==";
            //appUser.SecurityStamp = "e99fd978-c92a-4ea7-a7c7-e2379c3acc6f";
            //appUser.Email = "me_1986au@hotmail.com";
            //appUser.EmailConfirmed = false;


            //context.Users.Add(appUser);

            var device = new Device();
            device.Id = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
            device.PasswordSalt = Crypto.GenerateSalt();

            device.PasswordHash = Crypto.Hash(String.Format("Smike1986{0}", device.PasswordSalt));

            context.Devices.Add(device);

            context.SaveChanges();

        }
    }
}