using FoodDeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FoodDeliverySystem.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<FoodDeliverySystem.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FoodDeliverySystem.Models.ApplicationDbContext context)
        {
            //var random = new Random();

            //var students = new List<Student>
            //{
            //    new Student {  StudentName= "მარიამ ბეჟაშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "გიორგი გაჩეჩილაძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "გიორგი ხინჩაკაძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ანი მარგველაშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ანა ხორგუანი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ნათია დოლიაშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ნინო ფხაკაძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "პაპუნა მიშვიძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "სანდრო შეყლაშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ნოდარ გიკაშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "კონსტანტინე დვალიშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "საბა ხარაბაძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "ირაკლი გუგუშვილი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "სოფიო კოპალიანი", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))},
            //    new Student {  StudentName= "გიორგი ქინქლაძე", DateOfBirth = new DateTime(random.Next(1994, 1996), random.Next(1, 13), random.Next(1, 29))}
            //};

            //foreach (var item in students)
            //{
            //    context.Students.AddOrUpdate(student => student.StudentName, item);
            //}

            //var container = new List<CommentType>()
            //{
            //    new CommentType()
            //    {
            //        ID=1,
            //        Type="მომსახურება"
            //    },

            //    new CommentType()
            //    {
            //        ID=2,
            //        Type="მიტანის დრო"
            //    },

            //    new CommentType()
            //    {
            //        ID=3,
            //        Type="ხარისხი"
            //    },
            //};

            //foreach (var item in container)
            //{
            //    context.CommentTypes.Add(item);
            //}
        }
    }
}