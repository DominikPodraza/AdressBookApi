using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdressBook.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Entries");

            migrationBuilder.CreateTable(
                name: "NumberPhones",
                columns: table => new
                {
                    NumberPhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDefault = table.Column<bool>(type: "bit", nullable: false),
                    EntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberPhones", x => x.NumberPhoneId);
                    table.ForeignKey(
                        name: "FK_NumberPhones_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumberPhones_EntryId",
                table: "NumberPhones",
                column: "EntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberPhones");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Entries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
