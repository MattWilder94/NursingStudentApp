using Microsoft.EntityFrameworkCore;


public class NursingStudentContext : DbContext
{
    public NursingStudentContext(DbContextOptions<StudentContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<StudentTest> StudentTests { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<ClassCategory> ClassCategories { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTest>()
            .HasKey(st => new { st.test_ID, st.attemptNumber, st.student_ID });

        modelBuilder.Entity<StudentClass>()
            .HasKey(sc => new { sc.class_ID, sc.student_ID });

        modelBuilder.Entity<StudentTest>()
            .HasOne(st => st.Test)
            .WithMany(t => t.StudentTests)
            .HasForeignKey(st => st.test_ID);

        modelBuilder.Entity<StudentTest>()
            .HasOne(st => st.Student)
            .WithMany(s => s.StudentTests)
            .HasForeignKey(st => st.student_ID);

        modelBuilder.Entity<StudentClass>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentClasses)
            .HasForeignKey(sc => sc.student_ID);

        modelBuilder.Entity<StudentClass>()
            .HasOne(sc => sc.Class)
            .WithMany(c => c.StudentClasses)
            .HasForeignKey(sc => sc.class_ID);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Category)
            .WithMany(cc => cc.Classes)
            .HasForeignKey(c => c.Category_ID);

        modelBuilder.Entity<Student>()
            .Property(s => s.student_ID)
            .ValueGeneratedNever();

        // Seed data for ClassCategories
        modelBuilder.Entity<ClassCategory>().HasData(
            new ClassCategory { category_ID = 1, categoryName = "Agriculture", categoryPrefix = "AGRM" },
            new ClassCategory { category_ID = 2, categoryName = "Anthropology", categoryPrefix = "ANTH" },
            new ClassCategory { category_ID = 3, categoryName = "Accounting", categoryPrefix = "ACCT" },
            new ClassCategory { category_ID = 4, categoryName = "Agriculture", categoryPrefix = "AGRI" },
            new ClassCategory { category_ID = 5, categoryName = "Art", categoryPrefix = "ART" },
            new ClassCategory { category_ID = 6, categoryName = "Art Performance", categoryPrefix = "ARTP" },
            new ClassCategory { category_ID = 7, categoryName = "Astronomy", categoryPrefix = "ASTR" },
            new ClassCategory { category_ID = 8, categoryName = "Biology", categoryPrefix = "BIOL" },
            new ClassCategory { category_ID = 9, categoryName = "Business", categoryPrefix = "BUSN" },
            new ClassCategory { category_ID = 10, categoryName = "Chemistry", categoryPrefix = "CHEM" },
            new ClassCategory { category_ID = 11, categoryName = "Communications", categoryPrefix = "COMM" },
            new ClassCategory { category_ID = 12, categoryName = "Computer Info Tech", categoryPrefix = "CITC" },
            new ClassCategory { category_ID = 13, categoryName = "Computer Science", categoryPrefix = "CISP" },
            new ClassCategory { category_ID = 14, categoryName = "Criminal Justice", categoryPrefix = "CRMJ" },
            new ClassCategory { category_ID = 15, categoryName = "Culinary Arts", categoryPrefix = "CULA" },
            new ClassCategory { category_ID = 16, categoryName = "Digital Media", categoryPrefix = "DIGM" },
            new ClassCategory { category_ID = 17, categoryName = "Early Childhood Education", categoryPrefix = "ECED" },
            new ClassCategory { category_ID = 18, categoryName = "Economics", categoryPrefix = "ECON" },
            new ClassCategory { category_ID = 19, categoryName = "Education", categoryPrefix = "EDUC" },
            new ClassCategory { category_ID = 20, categoryName = "Electrical Engin Tech", categoryPrefix = "EETC" },
            new ClassCategory { category_ID = 21, categoryName = "Emergency Med Serv Para", categoryPrefix = "EMSP" },
            new ClassCategory { category_ID = 22, categoryName = "Emergency Med Service", categoryPrefix = "EMSA" },
            new ClassCategory { category_ID = 23, categoryName = "Emergency Med Service", categoryPrefix = "EMSB" },
            new ClassCategory { category_ID = 24, categoryName = "Engineering", categoryPrefix = "ENGR" },
            new ClassCategory { category_ID = 25, categoryName = "Engineering Systems Tech", categoryPrefix = "ENST" },
            new ClassCategory { category_ID = 26, categoryName = "Engineering Technology", categoryPrefix = "EGRT" },
            new ClassCategory { category_ID = 27, categoryName = "English", categoryPrefix = "ENGL" },
            new ClassCategory { category_ID = 28, categoryName = "Fire Science", categoryPrefix = "FIRE" },
            new ClassCategory { category_ID = 29, categoryName = "French", categoryPrefix = "FREN" },
            new ClassCategory { category_ID = 30, categoryName = "Geography", categoryPrefix = "GEOG" },
            new ClassCategory { category_ID = 31, categoryName = "Geology", categoryPrefix = "GEOL" },
            new ClassCategory { category_ID = 32, categoryName = "Health", categoryPrefix = "HLTH" },
            new ClassCategory { category_ID = 33, categoryName = "Health Information Management", categoryPrefix = "HIMT" },
            new ClassCategory { category_ID = 34, categoryName = "History", categoryPrefix = "HIST" },
            new ClassCategory { category_ID = 35, categoryName = "Hospitality Management", categoryPrefix = "HGMT" },
            new ClassCategory { category_ID = 36, categoryName = "Humanities", categoryPrefix = "HUM" },
            new ClassCategory { category_ID = 37, categoryName = "Information Systems", categoryPrefix = "INFS" },
            new ClassCategory { category_ID = 38, categoryName = "Mathematics", categoryPrefix = "MATH" },
            new ClassCategory { category_ID = 39, categoryName = "Music", categoryPrefix = "MUS" },
            new ClassCategory { category_ID = 40, categoryName = "Nursing", categoryPrefix = "NRSG" },
            new ClassCategory { category_ID = 41, categoryName = "Occupational Thrpy Asst", categoryPrefix = "OTAP" },
            new ClassCategory { category_ID = 42, categoryName = "Paralegal", categoryPrefix = "LEGL" },
            new ClassCategory { category_ID = 43, categoryName = "Pharmacy Technician", categoryPrefix = "PHRX" },
            new ClassCategory { category_ID = 44, categoryName = "Philosophy", categoryPrefix = "PHIL" },
            new ClassCategory { category_ID = 45, categoryName = "Physical Education", categoryPrefix = "PHED" },
            new ClassCategory { category_ID = 46, categoryName = "Physical Science", categoryPrefix = "PSCI" },
            new ClassCategory { category_ID = 47, categoryName = "Physical Therapist Asst", categoryPrefix = "PTAT" },
            new ClassCategory { category_ID = 48, categoryName = "Physics", categoryPrefix = "PHYS" },
            new ClassCategory { category_ID = 49, categoryName = "Political Science", categoryPrefix = "POLS" },
            new ClassCategory { category_ID = 50, categoryName = "Psychology", categoryPrefix = "PSYC" },
            new ClassCategory { category_ID = 51, categoryName = "Reading", categoryPrefix = "READ" },
            new ClassCategory { category_ID = 52, categoryName = "Religion", categoryPrefix = "RELS" },
            new ClassCategory { category_ID = 53, categoryName = "Respiratory Care", categoryPrefix = "RESP" },
            new ClassCategory { category_ID = 54, categoryName = "Social Work", categoryPrefix = "SWRK" },
            new ClassCategory { category_ID = 55, categoryName = "Sociology", categoryPrefix = "SOCI" },
            new ClassCategory { category_ID = 56, categoryName = "Spanish", categoryPrefix = "SPAN" },
            new ClassCategory { category_ID = 57, categoryName = "Special Education", categoryPrefix = "SPED" },
            new ClassCategory { category_ID = 58, categoryName = "Surgical Technology", categoryPrefix = "SURG" },
            new ClassCategory { category_ID = 59, categoryName = "Theatre", categoryPrefix = "THEA" },
            new ClassCategory { category_ID = 60, categoryName = "Women/Gender Studies", categoryPrefix = "WGST" }
        );
    }
}

