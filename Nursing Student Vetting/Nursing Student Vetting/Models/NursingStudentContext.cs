using Nursing_Student_Vetting.Models;

using Microsoft.EntityFrameworkCore;



public class NursingStudentContext : DbContext
{
    public NursingStudentContext(DbContextOptions<NursingStudentContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<StudentTest> StudentTests { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassCategory> ClassCategories { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTest>()
            .HasKey(st => new { st.TestID, st.AttemptNumber, st.StudentID });

        modelBuilder.Entity<StudentClass>()
            .HasKey(sc => new { sc.ClassID, sc.StudentID });

        modelBuilder.Entity<StudentTest>()
            .HasOne(st => st.Test)
            .WithMany(t => t.StudentTests)
            .HasForeignKey(st => st.TestID);

        modelBuilder.Entity<StudentTest>()
            .HasOne(st => st.Student)
            .WithMany(s => s.StudentTests)
            .HasForeignKey(st => st.StudentID);

        modelBuilder.Entity<StudentClass>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentClasses)
            .HasForeignKey(sc => sc.StudentID);

        modelBuilder.Entity<StudentClass>()
            .HasOne(sc => sc.Class)
            .WithMany(c => c.StudentClasses)
            .HasForeignKey(sc => new { sc.ClassID, sc.CategoryID });

        modelBuilder.Entity<Class>()
            .HasKey(c => new { c.ClassID, c.CategoryID });

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Category)
            .WithMany(cc => cc.Classes)
            .HasForeignKey(c => c.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Student>()
            .Property(s => s.StudentID)
            .ValueGeneratedNever();

        // Seed data for ClassCategories
        modelBuilder.Entity<ClassCategory>().HasData(
            new ClassCategory { CategoryID = 1, CategoryName = "Accounting", CategoryPrefix = "ACCT" },
            new ClassCategory { CategoryID = 2, CategoryName = "Agriculture", CategoryPrefix = "AGRI" },
            new ClassCategory { CategoryID = 3, CategoryName = "Agriculture", CategoryPrefix = "AGRM" },
            new ClassCategory { CategoryID = 4, CategoryName = "Anthropology", CategoryPrefix = "ANTH" },
            new ClassCategory { CategoryID = 5, CategoryName = "Art", CategoryPrefix = "ART" },
            new ClassCategory { CategoryID = 6, CategoryName = "Art Performance", CategoryPrefix = "ARTP" },
            new ClassCategory { CategoryID = 7, CategoryName = "Astronomy", CategoryPrefix = "ASTR" },
            new ClassCategory { CategoryID = 8, CategoryName = "Biology", CategoryPrefix = "BIOL" },
            new ClassCategory { CategoryID = 9, CategoryName = "Business", CategoryPrefix = "BUSN" },
            new ClassCategory { CategoryID = 10, CategoryName = "Chemistry", CategoryPrefix = "CHEM" },
            new ClassCategory { CategoryID = 11, CategoryName = "Communications", CategoryPrefix = "COMM" },
            new ClassCategory { CategoryID = 12, CategoryName = "Computer Info Tech", CategoryPrefix = "CITC" },
            new ClassCategory { CategoryID = 13, CategoryName = "Computer Science", CategoryPrefix = "CISP" },
            new ClassCategory { CategoryID = 14, CategoryName = "Criminal Justice", CategoryPrefix = "CRMJ" },
            new ClassCategory { CategoryID = 15, CategoryName = "Culinary Arts", CategoryPrefix = "CULA" },
            new ClassCategory { CategoryID = 16, CategoryName = "Digital Media", CategoryPrefix = "DIGM" },
            new ClassCategory { CategoryID = 17, CategoryName = "Early Childhood Education", CategoryPrefix = "ECED" },
            new ClassCategory { CategoryID = 18, CategoryName = "Economics", CategoryPrefix = "ECON" },
            new ClassCategory { CategoryID = 19, CategoryName = "Education", CategoryPrefix = "EDUC" },
            new ClassCategory { CategoryID = 20, CategoryName = "Electrical Engin Tech", CategoryPrefix = "EETC" },
            new ClassCategory { CategoryID = 21, CategoryName = "Emergency Med Serv Para", CategoryPrefix = "EMSP" },
            new ClassCategory { CategoryID = 22, CategoryName = "Emergency Med Service", CategoryPrefix = "EMSA" },
            new ClassCategory { CategoryID = 23, CategoryName = "Emergency Med Service", CategoryPrefix = "EMSB" },
            new ClassCategory { CategoryID = 24, CategoryName = "Engineering", CategoryPrefix = "ENGR" },
            new ClassCategory { CategoryID = 25, CategoryName = "Engineering Systems Tech", CategoryPrefix = "ENST" },
            new ClassCategory { CategoryID = 26, CategoryName = "Engineering Technology", CategoryPrefix = "EGRT" },
            new ClassCategory { CategoryID = 27, CategoryName = "English", CategoryPrefix = "ENGL" },
            new ClassCategory { CategoryID = 28, CategoryName = "Fire Science", CategoryPrefix = "FIRE" },
            new ClassCategory { CategoryID = 29, CategoryName = "French", CategoryPrefix = "FREN" },
            new ClassCategory { CategoryID = 30, CategoryName = "Geography", CategoryPrefix = "GEOG" },
            new ClassCategory { CategoryID = 31, CategoryName = "Geology", CategoryPrefix = "GEOL" },
            new ClassCategory { CategoryID = 32, CategoryName = "Health", CategoryPrefix = "HLTH" },
            new ClassCategory { CategoryID = 33, CategoryName = "Health Information Management", CategoryPrefix = "HIMT" },
            new ClassCategory { CategoryID = 34, CategoryName = "History", CategoryPrefix = "HIST" },
            new ClassCategory { CategoryID = 35, CategoryName = "Hospitality Management", CategoryPrefix = "HGMT" },
            new ClassCategory { CategoryID = 36, CategoryName = "Humanities", CategoryPrefix = "HUM" },
            new ClassCategory { CategoryID = 37, CategoryName = "Information Systems", CategoryPrefix = "INFS" },
            new ClassCategory { CategoryID = 38, CategoryName = "Mathematics", CategoryPrefix = "MATH" },
            new ClassCategory { CategoryID = 39, CategoryName = "Music", CategoryPrefix = "MUS" },
            new ClassCategory { CategoryID = 40, CategoryName = "Nursing", CategoryPrefix = "NRSG" },
            new ClassCategory { CategoryID = 41, CategoryName = "Occupational Thrpy Asst", CategoryPrefix = "OTAP" },
            new ClassCategory { CategoryID = 42, CategoryName = "Paralegal", CategoryPrefix = "LEGL" },
            new ClassCategory { CategoryID = 43, CategoryName = "Pharmacy Technician", CategoryPrefix = "PHRX" },
            new ClassCategory { CategoryID = 44, CategoryName = "Philosophy", CategoryPrefix = "PHIL" },
            new ClassCategory { CategoryID = 45, CategoryName = "Physical Education", CategoryPrefix = "PHED" },
            new ClassCategory { CategoryID = 46, CategoryName = "Physical Science", CategoryPrefix = "PSCI" },
            new ClassCategory { CategoryID = 47, CategoryName = "Physical Therapist Asst", CategoryPrefix = "PTAT" },
            new ClassCategory { CategoryID = 48, CategoryName = "Physics", CategoryPrefix = "PHYS" },
            new ClassCategory { CategoryID = 49, CategoryName = "Political Science", CategoryPrefix = "POLS" },
            new ClassCategory { CategoryID = 50, CategoryName = "Psychology", CategoryPrefix = "PSYC" },
            new ClassCategory { CategoryID = 51, CategoryName = "Reading", CategoryPrefix = "READ" },
            new ClassCategory { CategoryID = 52, CategoryName = "Religion", CategoryPrefix = "RELS" },
            new ClassCategory { CategoryID = 53, CategoryName = "Respiratory Care", CategoryPrefix = "RESP" },
            new ClassCategory { CategoryID = 54, CategoryName = "Social Work", CategoryPrefix = "SWRK" },
            new ClassCategory { CategoryID = 55, CategoryName = "Sociology", CategoryPrefix = "SOCI" },
            new ClassCategory { CategoryID = 56, CategoryName = "Spanish", CategoryPrefix = "SPAN" },
            new ClassCategory { CategoryID = 57, CategoryName = "Special Education", CategoryPrefix = "SPED" },
            new ClassCategory { CategoryID = 58, CategoryName = "Surgical Technology", CategoryPrefix = "SURG" },
            new ClassCategory { CategoryID = 59, CategoryName = "Theatre", CategoryPrefix = "THEA" },
            new ClassCategory { CategoryID = 60, CategoryName = "Women/Gender Studies", CategoryPrefix = "WGST" }
        );

        // Seed data for Classes
        modelBuilder.Entity<Class>().HasData(
            new Class { ClassID = 2010, ClassName = "Human Anatomy and Physiology I", CreditHours = 3, CategoryID = 8, IsRequired = true },
            new Class { ClassID = 1010, ClassName = "Principles of Accounting I", CreditHours = 3, CategoryID = 1, IsRequired = false }
        );

        // Seed data for Students
        modelBuilder.Entity<Student>().HasData(
            new Student { StudentID = 00001001, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Address = "123 Example St", DateOfBirth = new DateTime(2000, 1, 1), Gender = "Male", StartDate = new DateTime(2020, 8, 1), GraduationDate = new DateTime(2024, 5, 15) },
            new Student { StudentID = 00001002, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Address = "456 Example Ave", DateOfBirth = new DateTime(1999, 5, 15), Gender = "Female", StartDate = new DateTime(2021, 1, 5) }
        );

        // Seed data for Tests
        modelBuilder.Entity<Test>().HasData(
            new Test { TestID = 1, TestName = "ACT", GradingScale = 36 },
            new Test { TestID = 2, TestName = "Designated Test", GradingScale = 100 }
        );

        // Seed data for StudentTests
        modelBuilder.Entity<StudentTest>().HasData(
            new StudentTest { Test_ID = 1, attemptNumber = 1, StudentID = 00001001, Score = 22 },
            new StudentTest { Test_ID = 2, attemptNumber = 1, StudentID = 00001001, Score = 74},
            new StudentTest { Test_ID = 2, attemptNumber = 2, StudentID = 00001001, Score = 94 },
            new StudentTest { Test_ID = 2, attemptNumber = 1, StudentID = 00001002, Score = 92 }
        );

        // Seed data for StudentClasses
        modelBuilder.Entity<StudentClass>().HasData(
            new StudentClass { ClassID = 2010, StudentID = 00001001, CategoryID = 8, LetterGrade = "B" },
            new StudentClass { ClassID = 1010, StudentID = 00001002, CategoryID = 1, LetterGrade = "A" },
            new StudentClass { ClassID = 2010, StudentID = 00001002, CategoryID = 8, LetterGrade = "C" },
            new StudentClass { ClassID = 1010, StudentID = 00001001, CategoryID = 1, LetterGrade = "A" }
        );
    }
}

