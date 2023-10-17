using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescAccion = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Formatos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFormato = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formatos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HiloRespuestaNotificacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiloRespuestaNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulosMaestros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosMaestros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisosGenericos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePermiso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosGenericos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radicados",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radicados", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubModulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubModulo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModulos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoNotificaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNotificaciones", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoRequerimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRequerimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolVsMaestro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    IdMaestro = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolVsMaestro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_ModulosMaestros_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaestrosVsSubModulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<long>(type: "bigint", nullable: false),
                    IdSubmodulo = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestrosVsSubModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestrosVsSubModulos_ModulosMaestros_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModulosMaestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestrosVsSubModulos_SubModulos_IdSubmodulo",
                        column: x => x.IdSubmodulo,
                        principalTable: "SubModulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BlockChain",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTipoNotificacion = table.Column<long>(type: "bigint", nullable: false),
                    IdHiloRespuesta = table.Column<long>(type: "bigint", nullable: false),
                    IdAuditoria = table.Column<long>(type: "bigint", nullable: false),
                    HashGenerado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockChain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockChain_Auditoria_IdAuditoria",
                        column: x => x.IdAuditoria,
                        principalTable: "Auditoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockChain_HiloRespuestaNotificacion_IdHiloRespuesta",
                        column: x => x.IdHiloRespuesta,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockChain_TipoNotificaciones_IdTipoNotificacion",
                        column: x => x.IdTipoNotificacion,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModuloNotificaciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AsuntoNotificacion = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoNotificacion = table.Column<long>(type: "bigint", nullable: false),
                    TipoNotificacionesId = table.Column<long>(type: "bigint", nullable: true),
                    IdRadicado = table.Column<long>(type: "bigint", nullable: false),
                    IdEstadoNotificacion = table.Column<long>(type: "bigint", nullable: false),
                    IdHiloRespuesta = table.Column<long>(type: "bigint", nullable: false),
                    IdFormato = table.Column<long>(type: "bigint", nullable: false),
                    IdRequerimiento = table.Column<long>(type: "bigint", nullable: false),
                    TextoNotificacion = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloNotificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_EstadoNotificacion_IdEstadoNotificacion",
                        column: x => x.IdEstadoNotificacion,
                        principalTable: "EstadoNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_Formatos_IdFormato",
                        column: x => x.IdFormato,
                        principalTable: "Formatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_HiloRespuestaNotificacion_IdHiloRespues~",
                        column: x => x.IdHiloRespuesta,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_Radicados_IdRadicado",
                        column: x => x.IdRadicado,
                        principalTable: "Radicados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_TipoNotificaciones_TipoNotificacionesId",
                        column: x => x.TipoNotificacionesId,
                        principalTable: "TipoNotificaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModuloNotificaciones_TipoRequerimiento_IdRequerimiento",
                        column: x => x.IdRequerimiento,
                        principalTable: "TipoRequerimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenericosVsSubModulos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdGenericos = table.Column<long>(type: "bigint", nullable: false),
                    IdSubModulos = table.Column<long>(type: "bigint", nullable: false),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaModificacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericosVsSubModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubModulos_MaestrosVsSubModulos_IdSubModulos",
                        column: x => x.IdSubModulos,
                        principalTable: "MaestrosVsSubModulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubModulos_PermisosGenericos_IdGenericos",
                        column: x => x.IdGenericos,
                        principalTable: "PermisosGenericos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubModulos_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdAuditoria",
                table: "BlockChain",
                column: "IdAuditoria");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdHiloRespuesta",
                table: "BlockChain",
                column: "IdHiloRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_BlockChain_IdTipoNotificacion",
                table: "BlockChain",
                column: "IdTipoNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubModulos_IdGenericos",
                table: "GenericosVsSubModulos",
                column: "IdGenericos");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubModulos_IdRol",
                table: "GenericosVsSubModulos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubModulos_IdSubModulos",
                table: "GenericosVsSubModulos",
                column: "IdSubModulos");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosVsSubModulos_IdMaestro",
                table: "MaestrosVsSubModulos",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosVsSubModulos_IdSubmodulo",
                table: "MaestrosVsSubModulos",
                column: "IdSubmodulo");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_IdEstadoNotificacion",
                table: "ModuloNotificaciones",
                column: "IdEstadoNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_IdFormato",
                table: "ModuloNotificaciones",
                column: "IdFormato");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_IdHiloRespuesta",
                table: "ModuloNotificaciones",
                column: "IdHiloRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_IdRadicado",
                table: "ModuloNotificaciones",
                column: "IdRadicado");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_IdRequerimiento",
                table: "ModuloNotificaciones",
                column: "IdRequerimiento");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificaciones_TipoNotificacionesId",
                table: "ModuloNotificaciones",
                column: "TipoNotificacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdMaestro",
                table: "RolVsMaestro",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdRol",
                table: "RolVsMaestro",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockChain");

            migrationBuilder.DropTable(
                name: "GenericosVsSubModulos");

            migrationBuilder.DropTable(
                name: "ModuloNotificaciones");

            migrationBuilder.DropTable(
                name: "RolVsMaestro");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "MaestrosVsSubModulos");

            migrationBuilder.DropTable(
                name: "PermisosGenericos");

            migrationBuilder.DropTable(
                name: "EstadoNotificacion");

            migrationBuilder.DropTable(
                name: "Formatos");

            migrationBuilder.DropTable(
                name: "HiloRespuestaNotificacion");

            migrationBuilder.DropTable(
                name: "Radicados");

            migrationBuilder.DropTable(
                name: "TipoNotificaciones");

            migrationBuilder.DropTable(
                name: "TipoRequerimiento");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "ModulosMaestros");

            migrationBuilder.DropTable(
                name: "SubModulos");
        }
    }
}
