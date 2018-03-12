using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using static System.Console;

namespace HW15
{

    public class CollegeDBEFContext : DbContext
    {


        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Score> Scores { get; set; }

        public CollegeDBEFContext() : base("CollegeDBEF")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CollegeDBEFContext, Migrations.Configuration>());
        }

    }
    

    public class Student
        {
            [Key]
            public int ID { get; set; }
            public string FirstNmae { get; set; }
            public string LastName { get; set; }
            public int SNN { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int Zipcode { get; set; }
            public virtual List<Class> Class_ID { get; set; }


    }
    public class Class
        {
            [Key]
            public int ID { get; set; }
            public string Tilte { get; set; }
            public int Number { get; set; }
            public string Depdepartment { get; set; }
            public virtual List<Score> Score_ID { get; set; }
        }

    public class Score
        {
            [Key] public int ID { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            public DateTime Dateassigned { get; set; }
            public DateTime Datedue { get; set; }
            public DateTime Datesubmitted { get; set; }
            public int PointsEarned { get; set; }
            public int PointsPossible { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            using (var Datab = new CollegeDBEFContext())
            {
                Student Student1 = new Student
                {
                    FirstNmae = "Ahmed",
                    LastName = "Ali",
                    SNN = 1234,
                    Address = "3388 Desota Ave",
                    City = "Cleveland",
                    State = "Ohio",
                    Zipcode = 44124
                };
                Datab.Students.Add(Student1);

                var class1 = new Class
                {
                    Tilte = "Math",
                    Number= 202,
                    Depdepartment = "Eastside"

                };
                List<Class> AhmedClasses = new List<Class>();
                AhmedClasses.Add(class1);
                Student1.Class_ID = AhmedClasses;

                Score score1 = new Score
                {
                    Type = "Home Work",
                    Description = "Solve problem 3 in the book",
                    Dateassigned = DateTime.Parse("03/13/2018"),
                    Datedue = DateTime.Parse("03/16/2018"),
                    Datesubmitted= DateTime.Parse("03/16/2018"),
                    PointsEarned= 80,
                    PointsPossible=100

                };
                List<Score> AhmedScore = new List<Score>();
                AhmedScore.Add(score1);
                class1.Score_ID= AhmedScore;
                Datab.SaveChanges();


            }
        }
    }









}
