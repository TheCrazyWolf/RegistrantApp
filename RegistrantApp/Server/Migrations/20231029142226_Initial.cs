﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrantApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<long>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    IsEmployee = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSpecialLoginUI = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    AutoID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AutoNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerAutoAccountID = table.Column<long>(type: "INTEGER", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeLastUsed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.AutoID);
                    table.ForeignKey(
                        name: "FK_Autos_Accounts_OwnerAutoAccountID",
                        column: x => x.OwnerAutoAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contragents",
                columns: table => new
                {
                    ContragentID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeLastUsed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorAccountID = table.Column<long>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contragents", x => x.ContragentID);
                    table.ForeignKey(
                        name: "FK_Contragents_Accounts_AuthorAccountID",
                        column: x => x.AuthorAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTimeEvent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OwnerEventAccountID = table.Column<long>(type: "INTEGER", nullable: false),
                    Object = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: true),
                    Property = table.Column<string>(type: "TEXT", nullable: true),
                    ValueAfter = table.Column<string>(type: "TEXT", nullable: true),
                    ValueBefore = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Accounts_OwnerEventAccountID",
                        column: x => x.OwnerEventAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumRealese = table.Column<string>(type: "TEXT", nullable: true),
                    CountPodons = table.Column<string>(type: "TEXT", nullable: true),
                    PacketDocuments = table.Column<string>(type: "TEXT", nullable: true),
                    TochkaLoad = table.Column<string>(type: "TEXT", nullable: true),
                    Nomenclature = table.Column<string>(type: "TEXT", nullable: true),
                    Size = table.Column<string>(type: "TEXT", nullable: true),
                    Destination = table.Column<string>(type: "TEXT", nullable: true),
                    TypeLoad = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StoreKeeperAccountAccountID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Accounts_StoreKeeperAccountAccountID",
                        column: x => x.StoreKeeperAccountAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenID = table.Column<string>(type: "TEXT", nullable: false),
                    DateTimeSessionStarted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeSessionExpired = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IPv4 = table.Column<string>(type: "TEXT", nullable: true),
                    FingerPrint = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerTokenAccountID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Tokens_Accounts_OwnerTokenAccountID",
                        column: x => x.OwnerTokenAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContragentID = table.Column<long>(type: "INTEGER", nullable: true),
                    AccountID = table.Column<long>(type: "INTEGER", nullable: true),
                    AutoID = table.Column<long>(type: "INTEGER", nullable: true),
                    DateTimePlannedArrive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeRegistration = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTimeArrived = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTimeStartOrder = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTimeEndOrder = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTimeLeft = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeLastUsed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderDetailID = table.Column<long>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Orders_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "AutoID");
                    table.ForeignKey(
                        name: "FK_Orders_Contragents_ContragentID",
                        column: x => x.ContragentID,
                        principalTable: "Contragents",
                        principalColumn: "ContragentID");
                    table.ForeignKey(
                        name: "FK_Orders_OrderDetails_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    Bytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    DateTimeUpload = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OwnerFileAccountID = table.Column<long>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrderID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Files_Accounts_OwnerFileAccountID",
                        column: x => x.OwnerFileAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_OwnerAutoAccountID",
                table: "Autos",
                column: "OwnerAutoAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_AuthorAccountID",
                table: "Contragents",
                column: "AuthorAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OwnerEventAccountID",
                table: "Events",
                column: "OwnerEventAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OrderID",
                table: "Files",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerFileAccountID",
                table: "Files",
                column: "OwnerFileAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_StoreKeeperAccountAccountID",
                table: "OrderDetails",
                column: "StoreKeeperAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountID",
                table: "Orders",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AutoID",
                table: "Orders",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContragentID",
                table: "Orders",
                column: "ContragentID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailID",
                table: "Orders",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_OwnerTokenAccountID",
                table: "Tokens",
                column: "OwnerTokenAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Contragents");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
