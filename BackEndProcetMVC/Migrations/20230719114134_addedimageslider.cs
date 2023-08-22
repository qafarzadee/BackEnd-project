using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndProcetMVC.Migrations
{
    public partial class addedimageslider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "sliders");
        }
    }
}
