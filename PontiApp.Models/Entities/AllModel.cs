//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace PontiAppModelsDraft1
//{
//    public class User
//    {
//        public int UserId { get; set; }
//        public string Name { get; set; }
//        public string Surename { get; set; }

//        public string Mail { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Address { get; set; }

//        public string ProfilePictureUri { get; set; }
//        public int AverageRanking { get; set; }
//        public int TotalReviewerCount { get; set; }


//        public bool IsVerifiedUser { get; set; }


//        public ICollection<EventReview> eventReviews { get; set; }


//        public ICollection<UserGuestEvent> UserGuestEvents { get; set; }
//        public ICollection<UserHostEvent> UserHostEvents { get; set; }


//    }


//    public class Event
//    {
//        public int EventId { get; set; }
//        public string Name{ get; set; }
//        public string Description{ get; set; }

//        public DateTime StartTime { get; set; }
//        public DateTime EndTime { get; set; }

//        public string PhoneNumber{ get; set; }
//        public string Address{ get; set; }
//        public string Mail { get; set; }

//        public string TicketBuyUrl { get; set; }

//        public int PlaceId { get; set; }
//        public Place Place { get; set; }


//        public ICollection<PictureUri> PictureUries { get; set; }
//        public int PictureUriId { get; set; }


//        public ICollection<EventReview> EventReviews { get; set; }


//        public ICollection<UserGuestEvent> UserGuestEvents { get; set; }
//        public ICollection<UserHostEvent> UserHostEvents { get; set; }

//    }

//    public class EventReview
//    {
//        public int EventReviewId { get; set; }

//        public int ReviewRanking { get; set; }




//        public Event Event{ get; set; }
//        public int EventId { get; set; }


//        public User User { get; set; }
//        public int UserId { get; set; }




//    }

//    public class PictureUri
//    {
//        public int PictureUriId { get; set; }
//        public string Uri { get; set; }

//       // public string[] pictureUri { get; set; }
//    }

//    public class UserGuestEvent
//    {
//        public int EventId { get; set; }
//        public Event Event { get; set; }

//        public int UserId { get; set; }
//        public User User { get; set; }

//    }

//    public class UserHostEvent
//    {
//        public int EventId { get; set; }
//        public Event Event { get; set; }

//        public int UserId { get; set; }
//        public User User { get; set; }

//    }
//    public enum Daytype {
//        Monday,
//        Tuesday
//    }
//    public class Week {
    
//        public int WeekId { get; set; }
//        public DateTime Start { get; set; }
//        public DateTime End { get; set; }
//        public Daytype Day { get; set; }


//        public int PlaceId { get; set; }
//        public Place Place { get; set; }

//    }
//    public class WeekSchedule
//    {
//        public int WeekScheduleId { get; set; }
//        public DateTime Mondey_Start {get;set; }
//        public DateTime Tuesday_Start { get; set; }
//        public DateTime Wednesday_Start { get; set; }
//        public DateTime Thursday_Start { get; set; }
//        public DateTime Friday_Start { get; set; }
//        public DateTime Saterday_Start { get; set; }
//        public DateTime Sunday_Start { get; set; }



//        public DateTime Mondey_End { get; set; }
//        public DateTime Tuesday_End { get; set; }
//        public DateTime Wednesday_End { get; set; }
//        public DateTime Thursday_End { get; set; }
//        public DateTime Friday_End { get; set; }
//        public DateTime Saterday_End { get; set; }
//        public DateTime Sunday_End { get; set; }


//        public Place Place { get; set; }

//    }
//    public class Place
//    {
//        public int PlaceId { get; set; }


//        public string Name { get; set; }
//        public string Description { get; set; }

        

//        public string PhoneNumber { get; set; }
//        public string Address { get; set; }
//        public string Mail { get; set; }


//        public string TicketBuyUrl { get; set; }

//        public ICollection<Week> WeekSchedule { get; set; } // 7 

//        public int WeekScheduleId { get; set; }


//        public PictureUri PictureUri { get; set; }
//        public int PictureUriId { get; set; }


//        public ICollection<EventReview> EventReviews { get; set; }


//        public ICollection<UserGuestEvent> UserGuestEvents { get; set; }
//        public ICollection<UserHostEvent> UserHostEvents { get; set; }

//    }

//    public class UserGuestEventEntityConfiguration : IEntityTypeConfiguration<UserGuestEvent>
//    {
//        public void Configure(EntityTypeBuilder<UserGuestEvent> builder)
//        {
//            builder.HasKey(ue => new { ue.EventId, ue.UserId });

//            builder
//                .HasOne(ue=> ue.User)
//                .WithMany(user => user.UserGuestEvents)
//                .HasForeignKey(ue=> ue.UserId);

//            builder.HasOne(ue=>ue.Event)
//                .WithMany(e=>e.UserGuestEvents)
//                .HasForeignKey(ue=>ue.EventId);
//        }
//    }

//    public class UserHostEventEntityConfiguration : IEntityTypeConfiguration<UserHostEvent>
//    {
//        public void Configure(EntityTypeBuilder<UserHostEvent> builder)
//        {
//            builder.HasKey(ue => new { ue.EventId, ue.UserId });

//            builder.HasOne(ue => ue.User)
//                .WithMany(user => user.UserHostEvents)
//                .HasForeignKey(ue => ue.UserId);

//            builder.HasOne(ue => ue.Event)
//                .WithMany(e => e.UserHostEvents)
//                .HasForeignKey(ue => ue.EventId);
//        }
//    }


//    public class ApplicationDbContext : DbContext
//    {
//        public DbSet<User> Users { get; set; }
//        public DbSet<Event> Events { get; set; }

//        public DbSet<UserGuestEvent> UserGuestEvents { get; set; }

//        public DbSet<UserHostEvent> UserHostEvents { get; set; }



//        public DbSet<PictureUri> p { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder builder)
//        {
//            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB");
//        }

//        protected override void OnModelCreating(ModelBuilder options)
//        {
//            options.ApplyConfiguration(new AuthorEntityConfiguration());
//            options.ApplyConfiguration(new UserHostEventEntityConfiguration());
//            options.ApplyConfiguration(new UserGuestEventEntityConfiguration());


//        }
//    }

//}
