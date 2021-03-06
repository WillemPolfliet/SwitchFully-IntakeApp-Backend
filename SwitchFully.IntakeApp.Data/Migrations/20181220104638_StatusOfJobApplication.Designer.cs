﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwitchFully.IntakeApp.Data;

namespace SwitchFully.IntakeApp.Data.Migrations
{
    [DbContext(typeof(SwitchFullyIntakeAppContext))]
    [Migration("20181220104638_StatusOfJobApplication")]
    partial class StatusOfJobApplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.Campaigns.Campaign", b =>
                {
                    b.Property<Guid>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Client");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("CampaignId");

                    b.ToTable("Campaign");

                    b.HasData(
                        new { CampaignId = new Guid("6d3f8129-7dfe-4107-ab38-cbf28de9ec7b"), Client = "CM", EndDate = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "asp.net", StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CampaignId = new Guid("0327279f-e8ce-4a09-9c5d-906d19b13a83"), Client = "Cegeka", EndDate = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "java", StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { CampaignId = new Guid("ccd53f93-098b-4a27-a8e4-fd95cc922f8d"), Client = "OZ", EndDate = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "asp.net", StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.Candidates.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LinkedIn");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.FileManagement.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<string>("FileName");

                    b.Property<int>("Type");

                    b.Property<byte[]>("UploadedFile");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CampaignId");

                    b.Property<Guid>("CandidateId");

                    b.Property<Guid>("CvId");

                    b.Property<Guid>("MotivationId");

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CvId");

                    b.HasIndex("MotivationId");

                    b.HasIndex("StatusId");

                    b.ToTable("JobApplication");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening", b =>
                {
                    b.Property<Guid>("JobApplicationId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("AuditDateTime");

                    b.Property<string>("AuditUser");

                    b.Property<string>("Comment");

                    b.Property<string>("NextScreeningType");

                    b.Property<bool>("Status");

                    b.Property<string>("screeningType")
                        .IsRequired();

                    b.HasKey("JobApplicationId", "Name");

                    b.ToTable("Screening");

                    b.HasDiscriminator<string>("screeningType").HasValue("Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new { Id = 1, Description = "Inactive" },
                        new { Id = 2, Description = "Active" },
                        new { Id = 3, Description = "Rejected" },
                        new { Id = 4, Description = "Accepted" }
                    );
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<DateTime?>("LastLogon");

                    b.Property<string>("LastName");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.CV_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("CV_Screening");

                    b.HasDiscriminator().HasValue("CV_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.FinalDecision_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("FinalDecision_Screening");

                    b.HasDiscriminator().HasValue("FinalDecision_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.FirstInterview_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("FirstInterview_Screening");

                    b.HasDiscriminator().HasValue("FirstInterview_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.GroupInterview_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("GroupInterview_Screening");

                    b.HasDiscriminator().HasValue("GroupInterview_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Phone_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("Phone_Screening");

                    b.HasDiscriminator().HasValue("Phone_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.TestResults_Screening", b =>
                {
                    b.HasBaseType("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening");


                    b.ToTable("TestResults_Screening");

                    b.HasDiscriminator().HasValue("TestResults_Screening");
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.Candidates.Candidate", b =>
                {
                    b.OwnsOne("System.Net.Mail.MailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("CandidateId");

                            b1.Property<string>("Address")
                                .HasColumnName("Email");

                            b1.ToTable("Candidates");

                            b1.HasOne("SwitchFully.IntakeApp.Domain.Candidates.Candidate")
                                .WithOne("Email")
                                .HasForeignKey("System.Net.Mail.MailAddress", "CandidateId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.JobApplication", b =>
                {
                    b.HasOne("SwitchFully.IntakeApp.Domain.Campaigns.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SwitchFully.IntakeApp.Domain.Candidates.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SwitchFully.IntakeApp.Domain.FileManagement.File", "CV")
                        .WithMany()
                        .HasForeignKey("CvId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SwitchFully.IntakeApp.Domain.FileManagement.File", "Motivation")
                        .WithMany()
                        .HasForeignKey("MotivationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SwitchFully.IntakeApp.Domain.JobApplications.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.JobApplications.SelectionProcess.Screening", b =>
                {
                    b.HasOne("SwitchFully.IntakeApp.Domain.JobApplications.JobApplication", "JobApplication")
                        .WithMany("Screening")
                        .HasForeignKey("JobApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SwitchFully.IntakeApp.Domain.Users.User", b =>
                {
                    b.OwnsOne("SwitchFully.IntakeApp.Domain.Users.UserSecurity", "SecurePassword", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("PasswordHash")
                                .HasColumnName("PassWord");

                            b1.Property<string>("Salt")
                                .HasColumnName("SecPass");

                            b1.ToTable("Users");

                            b1.HasOne("SwitchFully.IntakeApp.Domain.Users.User")
                                .WithOne("SecurePassword")
                                .HasForeignKey("SwitchFully.IntakeApp.Domain.Users.UserSecurity", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("System.Net.Mail.MailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("Address")
                                .HasColumnName("Email");

                            b1.ToTable("Users");

                            b1.HasOne("SwitchFully.IntakeApp.Domain.Users.User")
                                .WithOne("Email")
                                .HasForeignKey("System.Net.Mail.MailAddress", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
