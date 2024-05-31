using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoJwt.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Conf_Usuario",
                schema: "dbo",
                columns: table => new
                {
                    Identificador = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DescripcionUsuario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RequiereActualizacionContraseña = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_Usuario", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Conf_SeguridadUsuario",
                schema: "dbo",
                columns: table => new
                {
                    Identificador = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentidicadorUsuario = table.Column<long>(type: "bigint", nullable: false),
                    ContraseñaUsuario = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    ExpiracionContraseña = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conf_SeguridadUsuario", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Conf_SeguridadUsuario_Conf_Usuario_IdentidicadorUsuario",
                        column: x => x.IdentidicadorUsuario,
                        principalSchema: "dbo",
                        principalTable: "Conf_Usuario",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conf_SeguridadUsuario_IdentidicadorUsuario",
                schema: "dbo",
                table: "Conf_SeguridadUsuario",
                column: "IdentidicadorUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conf_SeguridadUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Conf_Usuario",
                schema: "dbo");
        }
    }
}
