namespace FestivalSales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        public DataModel()
          : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

    }

    public class UserInfo
    {
        [Key]
        public int Id { get; set; }


        public string AccountId { get; set; }

        public UserRole userRole { get; set; }

        public string name { get; set; }

        public string Orgname { get; set; }

        public string address { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Service> Services { get; set; }



    }

    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string role { get; set; }



    }

    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }
        public bool is_approved { get; set; }
        public DateTime from { get; set; }

        public DateTime to { get; set; }

    }

    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }

        public bool is_approved { get; set; }

        public DateTime from { get; set; }

        public DateTime to { get; set; }

    }



    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }
        public bool is_approved { get; set; }
        public DateTime from { get; set; }

        public DateTime to { get; set; }

    }

    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string info { get; set; }
    }
}