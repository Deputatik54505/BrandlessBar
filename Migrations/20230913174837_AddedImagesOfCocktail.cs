using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace brandlessBar.Migrations
{
    /// <inheritdoc />
    public partial class AddedImagesOfCocktail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Cocktails",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Cocktails");
        }
    }
}
