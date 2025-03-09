using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Infrstrucure.Data.Migrationss
{
    /// <inheritdoc />
    public partial class photoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "ImageName", "ProductId" },
                values: new object[] { 1, "Test", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
