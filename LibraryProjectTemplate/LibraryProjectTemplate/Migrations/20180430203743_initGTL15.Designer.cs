﻿// <auto-generated />
using LibraryProjectTemplate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace LibraryProjectTemplate.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180430203743_initGTL15")]
    partial class initGTL15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryProjectTemplate.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Century");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.AuthorBook", b =>
                {
                    b.Property<int>("AuthorId");

                    b.Property<int>("BookISBN");

                    b.HasKey("AuthorId", "BookISBN");

                    b.HasIndex("BookISBN");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Book", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Binding");

                    b.Property<bool>("CanBeLoaned");

                    b.Property<int>("CopiesAvailable");

                    b.Property<int>("Edition");

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<int>("LibraryCode");

                    b.Property<int?>("LoanId");

                    b.Property<int>("NoPages");

                    b.Property<bool>("OnLoan");

                    b.Property<int>("Stock");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("ISBN");

                    b.HasIndex("LoanId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Librarian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Librarians");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LibrarianLoans", b =>
                {
                    b.Property<int>("LoanId");

                    b.Property<int>("LibrarianId");

                    b.HasKey("LoanId", "LibrarianId");

                    b.HasIndex("LibrarianId");

                    b.ToTable("LibrarianLoans");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("IssuedDate");

                    b.Property<int?>("LibrarianId");

                    b.Property<int>("MemberId");

                    b.Property<string>("photo");

                    b.HasKey("Id");

                    b.HasIndex("LibrarianId");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("GracePeriod");

                    b.Property<int>("MemberSSN");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LoanMembers", b =>
                {
                    b.Property<int>("LoanId");

                    b.Property<int>("MemberId");

                    b.HasKey("LoanId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("LoanMembers");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Member", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ActiveMember");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int?>("LibraryCardForeignKey");

                    b.Property<int>("NoBooksLoaned");

                    b.Property<int>("NoofLoans");

                    b.Property<string>("Type");

                    b.HasKey("SSN");

                    b.HasIndex("LibraryCardForeignKey");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.AuthorBook", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryProjectTemplate.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookISBN")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Book", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.Loan")
                        .WithMany("LoanBooks")
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LibrarianLoans", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.Librarian", "Librarian")
                        .WithMany()
                        .HasForeignKey("LibrarianId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryProjectTemplate.Models.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LibraryCard", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.Librarian")
                        .WithMany("LibraryCards")
                        .HasForeignKey("LibrarianId");
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.LoanMembers", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryProjectTemplate.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryProjectTemplate.Models.Member", b =>
                {
                    b.HasOne("LibraryProjectTemplate.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardForeignKey");
                });
#pragma warning restore 612, 618
        }
    }
}
