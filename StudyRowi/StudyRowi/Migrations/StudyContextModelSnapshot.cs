// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyRowi.Models;

namespace StudyRowi.Migrations
{
    [DbContext(typeof(StudyContext))]
    partial class StudyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyRowi.Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("StudyRowi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateReceipt")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormStudy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudyRowi.Models.StudyJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("StudyPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudyPlanId");

                    b.ToTable("StudyJournals");
                });

            modelBuilder.Entity("StudyRowi.Models.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discipline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormExam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestr")
                        .HasColumnType("int");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StudyPlans");
                });

            modelBuilder.Entity("StudyRowi.Models.Student", b =>
                {
                    b.HasOne("StudyRowi.Models.Groupe", "Groupe")
                        .WithMany("Students")
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("StudyRowi.Models.StudyJournal", b =>
                {
                    b.HasOne("StudyRowi.Models.Student", "Students")
                        .WithMany("StudyJournal")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyRowi.Models.StudyPlan", "StudyPlans")
                        .WithMany("StudyJournal")
                        .HasForeignKey("StudyPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Students");

                    b.Navigation("StudyPlans");
                });

            modelBuilder.Entity("StudyRowi.Models.Groupe", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StudyRowi.Models.Student", b =>
                {
                    b.Navigation("StudyJournal");
                });

            modelBuilder.Entity("StudyRowi.Models.StudyPlan", b =>
                {
                    b.Navigation("StudyJournal");
                });
#pragma warning restore 612, 618
        }
    }
}
