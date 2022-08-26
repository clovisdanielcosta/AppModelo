using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CD.UI.Site.Migrations
{
    public partial class AdicionadoIdadeemAlunos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Alunos");
        }
    }
}
