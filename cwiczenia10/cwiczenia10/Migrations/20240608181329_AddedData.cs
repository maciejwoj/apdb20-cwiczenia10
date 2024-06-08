using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cwiczenia10.Migrations
{
    /// <inheritdoc />
    public partial class AddedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jankowalski@gmail.com", "Jan", "Kowalski" },
                    { 2, "nowakowalski@gmail.com", "Marek", "Nowowalski" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "cosam m,,..,", "apap", "fever" },
                    { 2, "cosdftm m,,..,", "fgdhjnp", "fer" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateOnly(2001, 6, 1), "olek", "kowal" },
                    { 2, new DateOnly(2000, 6, 8), "Alek", "Mokwowal" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 5, 28), new DateOnly(2024, 6, 28), 1, 1 },
                    { 2, new DateOnly(2024, 5, 29), new DateOnly(2024, 6, 29), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Take once a day after meal.", 1 },
                    { 2, 2, "Take twice a day before meal.", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);
        }
    }
}
