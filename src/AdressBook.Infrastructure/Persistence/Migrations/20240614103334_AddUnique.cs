using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdressBook.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDefault",
                table: "NumberPhones",
                newName: "IsDefault");

            migrationBuilder.AlterColumn<string>(
                name: "Nick",
                table: "Entries",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_Nick",
                table: "Entries",
                column: "Nick",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entries_Nick",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "NumberPhones",
                newName: "isDefault");

            migrationBuilder.AlterColumn<string>(
                name: "Nick",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
