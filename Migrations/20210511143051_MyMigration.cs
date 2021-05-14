using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project334.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobilePhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DangerousCase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasVaccine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerousCase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DangerousCase_Person_ID",
                        column: x => x.ID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HadVirus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_Person_ID",
                        column: x => x.ID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DangerousCaseID = table.Column<int>(type: "int", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_DangerousCase_DangerousCaseID",
                        column: x => x.DangerousCaseID,
                        principalTable: "DangerousCase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAppointment",
                columns: table => new
                {
                    BookAppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInstitutionID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    EligibilityToVaccine = table.Column<bool>(type: "bit", nullable: false),
                    Medicare = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAppointment", x => x.BookAppointmentID);
                    table.ForeignKey(
                        name: "FK_BookAppointment_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    VaccineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.VaccineID);
                    table.ForeignKey(
                        name: "FK_Vaccine_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyAddressID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ABN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessID);
                    table.ForeignKey(
                        name: "FK_Business_Address_CompanyAddressID",
                        column: x => x.CompanyAddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalInstitution",
                columns: table => new
                {
                    MedicalInstitutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalAddressID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalInstitution", x => x.MedicalInstitutionID);
                    table.ForeignKey(
                        name: "FK_MedicalInstitution_Address_MedicalAddressID",
                        column: x => x.MedicalAddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessActivity",
                columns: table => new
                {
                    BusinessActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    WorkingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessActivity", x => x.BusinessActivityID);
                    table.ForeignKey(
                        name: "FK_BusinessActivity_Business_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Business",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalInstitutionID = table.Column<int>(type: "int", nullable: false),
                    BookAppointmentID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VaccineID = table.Column<int>(type: "int", nullable: true),
                    EligibilityToVaccine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointment_BookAppointment_BookAppointmentID",
                        column: x => x.BookAppointmentID,
                        principalTable: "BookAppointment",
                        principalColumn: "BookAppointmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_MedicalInstitution_MedicalInstitutionID",
                        column: x => x.MedicalInstitutionID,
                        principalTable: "MedicalInstitution",
                        principalColumn: "MedicalInstitutionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Vaccine_VaccineID",
                        column: x => x.VaccineID,
                        principalTable: "Vaccine",
                        principalColumn: "VaccineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitorCheckIn",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BusinessActivityID = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorCheckIn", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VisitorCheckIn_BusinessActivity_BusinessActivityID",
                        column: x => x.BusinessActivityID,
                        principalTable: "BusinessActivity",
                        principalColumn: "BusinessActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorCheckIn_Person_ID",
                        column: x => x.ID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitorCheckOut",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BusinessActivityID = table.Column<int>(type: "int", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorCheckOut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VisitorCheckOut_BusinessActivity_BusinessActivityID",
                        column: x => x.BusinessActivityID,
                        principalTable: "BusinessActivity",
                        principalColumn: "BusinessActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitorCheckOut_Person_ID",
                        column: x => x.ID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_DangerousCaseID",
                table: "Address",
                column: "DangerousCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_BookAppointmentID",
                table: "Appointment",
                column: "BookAppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalInstitutionID",
                table: "Appointment",
                column: "MedicalInstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_VaccineID",
                table: "Appointment",
                column: "VaccineID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAppointment_PatientID",
                table: "BookAppointment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CompanyAddressID",
                table: "Business",
                column: "CompanyAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessActivity_BusinessID",
                table: "BusinessActivity",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalInstitution_MedicalAddressID",
                table: "MedicalInstitution",
                column: "MedicalAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_PatientID",
                table: "Vaccine",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCheckIn_BusinessActivityID",
                table: "VisitorCheckIn",
                column: "BusinessActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCheckOut_BusinessActivityID",
                table: "VisitorCheckOut",
                column: "BusinessActivityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "VisitorCheckIn");

            migrationBuilder.DropTable(
                name: "VisitorCheckOut");

            migrationBuilder.DropTable(
                name: "BookAppointment");

            migrationBuilder.DropTable(
                name: "MedicalInstitution");

            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "BusinessActivity");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DangerousCase");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
