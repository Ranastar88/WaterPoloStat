using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WaterPoloStat.Domain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "imp");

            migrationBuilder.EnsureSchema(
                name: "wps");

            migrationBuilder.EnsureSchema(
                name: "lkp");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "imp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "imp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LicenzaId = table.Column<string>(maxLength: 450, nullable: false),
                    Nome = table.Column<string>(maxLength: 250, nullable: true),
                    Cognome = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruoli",
                schema: "lkp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruoli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Giocatori",
                schema: "wps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenzaId = table.Column<string>(nullable: false),
                    CreatoDa = table.Column<string>(nullable: false),
                    ModificatoDa = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(nullable: true),
                    CancellatoDa = table.Column<string>(nullable: true),
                    Cancellato = table.Column<bool>(nullable: false),
                    DataCancellazione = table.Column<DateTime>(nullable: true),
                    Nominativo = table.Column<string>(nullable: false),
                    DataDiNascita = table.Column<DateTime>(nullable: true),
                    Nazionalita = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giocatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squadre",
                schema: "wps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenzaId = table.Column<string>(nullable: false),
                    CreatoDa = table.Column<string>(nullable: false),
                    ModificatoDa = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(nullable: true),
                    CancellatoDa = table.Column<string>(nullable: true),
                    Cancellato = table.Column<bool>(nullable: false),
                    DataCancellazione = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squadre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "imp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "imp",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "imp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "imp",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "imp",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "imp",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "imp",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "imp",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "imp",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "imp",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "imp",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partite",
                schema: "wps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenzaId = table.Column<string>(nullable: false),
                    CreatoDa = table.Column<string>(nullable: false),
                    ModificatoDa = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(nullable: true),
                    CancellatoDa = table.Column<string>(nullable: true),
                    Cancellato = table.Column<bool>(nullable: false),
                    DataCancellazione = table.Column<DateTime>(nullable: true),
                    Luogo = table.Column<string>(nullable: true),
                    Campionato = table.Column<string>(nullable: true),
                    Citta = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: true),
                    Orario = table.Column<string>(nullable: true),
                    SquadraCasaId = table.Column<int>(nullable: false),
                    SquadraOspitiId = table.Column<int>(nullable: false),
                    GoalCasa = table.Column<int>(nullable: false),
                    GoalOspiti = table.Column<int>(nullable: false),
                    Iniziata = table.Column<bool>(nullable: false),
                    Terminata = table.Column<bool>(nullable: false),
                    CondividiLive = table.Column<bool>(nullable: false),
                    Minuti = table.Column<int>(nullable: false),
                    Secondi = table.Column<int>(nullable: false),
                    Tempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partite_Squadre_SquadraCasaId",
                        column: x => x.SquadraCasaId,
                        principalSchema: "wps",
                        principalTable: "Squadre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partite_Squadre_SquadraOspitiId",
                        column: x => x.SquadraOspitiId,
                        principalSchema: "wps",
                        principalTable: "Squadre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lineups",
                schema: "wps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenzaId = table.Column<string>(nullable: false),
                    CreatoDa = table.Column<string>(nullable: false),
                    ModificatoDa = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(nullable: true),
                    CancellatoDa = table.Column<string>(nullable: true),
                    Cancellato = table.Column<bool>(nullable: false),
                    DataCancellazione = table.Column<DateTime>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    SquadraId = table.Column<int>(nullable: false),
                    GiocatoreId = table.Column<int>(nullable: false),
                    RuoloId = table.Column<int>(nullable: false),
                    PartitaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineups_Giocatori_GiocatoreId",
                        column: x => x.GiocatoreId,
                        principalSchema: "wps",
                        principalTable: "Giocatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineups_Partite_PartitaId",
                        column: x => x.PartitaId,
                        principalSchema: "wps",
                        principalTable: "Partite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineups_Ruoli_RuoloId",
                        column: x => x.RuoloId,
                        principalSchema: "lkp",
                        principalTable: "Ruoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineups_Squadre_SquadraId",
                        column: x => x.SquadraId,
                        principalSchema: "wps",
                        principalTable: "Squadre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventi",
                schema: "wps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenzaId = table.Column<string>(nullable: false),
                    CreatoDa = table.Column<string>(nullable: false),
                    ModificatoDa = table.Column<string>(nullable: true),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    DataUltimaModifica = table.Column<DateTime>(nullable: true),
                    CancellatoDa = table.Column<string>(nullable: true),
                    Cancellato = table.Column<bool>(nullable: false),
                    DataCancellazione = table.Column<DateTime>(nullable: true),
                    PartitaId = table.Column<int>(nullable: false),
                    DataInserimento = table.Column<DateTime>(nullable: false),
                    Minuti = table.Column<int>(nullable: false),
                    Secondi = table.Column<int>(nullable: false),
                    Tempo = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Lineup1Id = table.Column<int>(nullable: false),
                    Lineup2Id = table.Column<int>(nullable: true),
                    Lineup3Id = table.Column<int>(nullable: true),
                    EsitoTiro = table.Column<int>(nullable: true),
                    XPosizione = table.Column<double>(nullable: true),
                    YPosizione = table.Column<double>(nullable: true),
                    XTiro = table.Column<double>(nullable: true),
                    YTiro = table.Column<double>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventi_Lineups_Lineup1Id",
                        column: x => x.Lineup1Id,
                        principalSchema: "wps",
                        principalTable: "Lineups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventi_Lineups_Lineup2Id",
                        column: x => x.Lineup2Id,
                        principalSchema: "wps",
                        principalTable: "Lineups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventi_Lineups_Lineup3Id",
                        column: x => x.Lineup3Id,
                        principalSchema: "wps",
                        principalTable: "Lineups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventi_Partite_PartitaId",
                        column: x => x.PartitaId,
                        principalSchema: "wps",
                        principalTable: "Partite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "imp",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "imp",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "imp",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "imp",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "imp",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "imp",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "imp",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_Lineup1Id",
                schema: "wps",
                table: "Eventi",
                column: "Lineup1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_Lineup2Id",
                schema: "wps",
                table: "Eventi",
                column: "Lineup2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_Lineup3Id",
                schema: "wps",
                table: "Eventi",
                column: "Lineup3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_PartitaId",
                schema: "wps",
                table: "Eventi",
                column: "PartitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_GiocatoreId",
                schema: "wps",
                table: "Lineups",
                column: "GiocatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_PartitaId",
                schema: "wps",
                table: "Lineups",
                column: "PartitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_RuoloId",
                schema: "wps",
                table: "Lineups",
                column: "RuoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_SquadraId",
                schema: "wps",
                table: "Lineups",
                column: "SquadraId");

            migrationBuilder.CreateIndex(
                name: "IX_Partite_SquadraCasaId",
                schema: "wps",
                table: "Partite",
                column: "SquadraCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partite_SquadraOspitiId",
                schema: "wps",
                table: "Partite",
                column: "SquadraOspitiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "Eventi",
                schema: "wps");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "imp");

            migrationBuilder.DropTable(
                name: "Lineups",
                schema: "wps");

            migrationBuilder.DropTable(
                name: "Giocatori",
                schema: "wps");

            migrationBuilder.DropTable(
                name: "Partite",
                schema: "wps");

            migrationBuilder.DropTable(
                name: "Ruoli",
                schema: "lkp");

            migrationBuilder.DropTable(
                name: "Squadre",
                schema: "wps");
        }
    }
}
