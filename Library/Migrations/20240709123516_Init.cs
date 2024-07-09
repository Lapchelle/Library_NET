using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrows_BorrowId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "total_Copies",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Phone_number");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CopyId",
                table: "Borrows",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookCopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Count_Free = table.Column<int>(type: "integer", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCopies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reserveTime = table.Column<DateOnly>(type: "date", nullable: false),
                    endOfReserveTime = table.Column<DateOnly>(type: "date", nullable: false),
                    BookCopyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_BookCopies_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "BookCopies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_CopyId",
                table: "Borrows",
                column: "CopyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopies_BookId",
                table: "BookCopies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_BookCopyId",
                table: "Reserves",
                column: "BookCopyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_BookCopies_CopyId",
                table: "Borrows",
                column: "CopyId",
                principalTable: "BookCopies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_BookCopies_CopyId",
                table: "Borrows");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "BookCopies");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_CopyId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "CopyId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Phone_number",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Books",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "total_Copies",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowId",
                table: "Books",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrows_BorrowId",
                table: "Books",
                column: "BorrowId",
                principalTable: "Borrows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
