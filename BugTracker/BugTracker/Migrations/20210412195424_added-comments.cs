using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class addedcomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", maxLength: 350, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommenterUserAssignedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommenterProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_ProjectUserRequests_CommenterUserAssignedId_CommenterProjectId",
                        columns: x => new { x.CommenterUserAssignedId, x.CommenterProjectId },
                        principalTable: "ProjectUserRequests",
                        principalColumns: new[] { "UserAssignedId", "ProjectId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommenterUserAssignedId_CommenterProjectId",
                table: "Comment",
                columns: new[] { "CommenterUserAssignedId", "CommenterProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TicketId",
                table: "Comment",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
