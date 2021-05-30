using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class DepartamentoForegnKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendedors_Departamento_departamentoId",
                table: "vendedors");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "vendedors",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_vendedors_departamentoId",
                table: "vendedors",
                newName: "IX_vendedors_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "vendedors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vendedors_Departamento_DepartamentoId",
                table: "vendedors",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vendedors_Departamento_DepartamentoId",
                table: "vendedors");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "vendedors",
                newName: "departamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_vendedors_DepartamentoId",
                table: "vendedors",
                newName: "IX_vendedors_departamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "departamentoId",
                table: "vendedors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_vendedors_Departamento_departamentoId",
                table: "vendedors",
                column: "departamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
