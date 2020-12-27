using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Systematics.Task.Web.Migrations
{
    public partial class seedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ID", "Status" },
                values: new object[] { 1, "Success" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ID", "Status" },
                values: new object[] { 2, "Failed" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
