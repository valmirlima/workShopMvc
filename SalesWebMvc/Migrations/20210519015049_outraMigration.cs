using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class outraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendedors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    SalarioBase = table.Column<double>(nullable: false),
                    departamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendedors_Departamento_departamentoId",
                        column: x => x.departamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "totalVendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    total = table.Column<double>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    VendedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totalVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_totalVendas_totalVendas_StatusId",
                        column: x => x.StatusId,
                        principalTable: "totalVendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totalVendas_vendedors_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "vendedors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_totalVendas_StatusId",
                table: "totalVendas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_totalVendas_VendedorId",
                table: "totalVendas",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_vendedors_departamentoId",
                table: "vendedors",
                column: "departamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "totalVendas");

            migrationBuilder.DropTable(
                name: "vendedors");
        }
    }
}
