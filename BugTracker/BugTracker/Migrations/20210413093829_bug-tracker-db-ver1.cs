using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class bugtrackerdbver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ProjectUserRequests_CommenterUserAssignedId_CommenterProjectId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProjectUserRequests_ReporterUserAssignedId_ReporterProjectId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReporterUserAssignedId_ReporterProjectId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUserRequests",
                table: "ProjectUserRequests");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommenterUserAssignedId_CommenterProjectId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ReporterProjectId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CommenterProjectId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "ReporterUserAssignedId",
                table: "Tickets",
                newName: "ReporterId");

            migrationBuilder.RenameColumn(
                name: "CommenterUserAssignedId",
                table: "Comment",
                newName: "CommenterId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProjectUserRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUserRequests",
                table: "ProjectUserRequests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectUserForTicket",
                columns: table => new
                {
                    ProjectUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUserForTicket", x => new { x.ProjectUserId, x.TicketId });
                    table.ForeignKey(
                        name: "FK_ProjectUserForTicket_ProjectUserRequests_ProjectUserId",
                        column: x => x.ProjectUserId,
                        principalTable: "ProjectUserRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUserForTicket_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReporterId",
                table: "Tickets",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserRequests_UserAssignedId_ProjectId",
                table: "ProjectUserRequests",
                columns: new[] { "UserAssignedId", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommenterId",
                table: "Comment",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUserForTicket_TicketId",
                table: "ProjectUserForTicket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ProjectUserRequests_CommenterId",
                table: "Comment",
                column: "CommenterId",
                principalTable: "ProjectUserRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProjectUserRequests_ReporterId",
                table: "Tickets",
                column: "ReporterId",
                principalTable: "ProjectUserRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ProjectUserRequests_CommenterId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ProjectUserRequests_ReporterId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ProjectUserForTicket");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReporterId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectUserRequests",
                table: "ProjectUserRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUserRequests_UserAssignedId_ProjectId",
                table: "ProjectUserRequests");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommenterId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectUserRequests");

            migrationBuilder.RenameColumn(
                name: "ReporterId",
                table: "Tickets",
                newName: "ReporterUserAssignedId");

            migrationBuilder.RenameColumn(
                name: "CommenterId",
                table: "Comment",
                newName: "CommenterUserAssignedId");

            migrationBuilder.AddColumn<Guid>(
                name: "ReporterProjectId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CommenterProjectId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectUserRequests",
                table: "ProjectUserRequests",
                columns: new[] { "UserAssignedId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReporterUserAssignedId_ReporterProjectId",
                table: "Tickets",
                columns: new[] { "ReporterUserAssignedId", "ReporterProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommenterUserAssignedId_CommenterProjectId",
                table: "Comment",
                columns: new[] { "CommenterUserAssignedId", "CommenterProjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ProjectUserRequests_CommenterUserAssignedId_CommenterProjectId",
                table: "Comment",
                columns: new[] { "CommenterUserAssignedId", "CommenterProjectId" },
                principalTable: "ProjectUserRequests",
                principalColumns: new[] { "UserAssignedId", "ProjectId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ProjectUserRequests_ReporterUserAssignedId_ReporterProjectId",
                table: "Tickets",
                columns: new[] { "ReporterUserAssignedId", "ReporterProjectId" },
                principalTable: "ProjectUserRequests",
                principalColumns: new[] { "UserAssignedId", "ProjectId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
