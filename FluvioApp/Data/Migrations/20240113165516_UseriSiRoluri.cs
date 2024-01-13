using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluvioApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UseriSiRoluri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Assignments_AssignmentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Assignments_AssignmentId",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaFile",
                table: "MediaFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "MediaFile",
                newName: "MediaFiles");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_TeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFile_AssignmentId",
                table: "MediaFiles",
                newName: "IX_MediaFiles_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AssignmentId",
                table: "Comments",
                newName: "IX_Comments_AssignmentId");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Teams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TeamMembers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "MediaFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MediaFiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaFiles",
                table: "MediaFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserId",
                table: "Teams",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_UserId",
                table: "MediaFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Assignments_AssignmentId",
                table: "Comments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_AspNetUsers_UserId",
                table: "MediaFiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Assignments_AssignmentId",
                table: "MediaFiles",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId",
                table: "TeamMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Assignments_AssignmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_AspNetUsers_UserId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Assignments_AssignmentId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_AspNetUsers_UserId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_UserId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaFiles",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_UserId",
                table: "MediaFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MediaFiles");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMember");

            migrationBuilder.RenameTable(
                name: "MediaFiles",
                newName: "MediaFile");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMember",
                newName: "IX_TeamMember_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFiles_AssignmentId",
                table: "MediaFile",
                newName: "IX_MediaFile_AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AssignmentId",
                table: "Comment",
                newName: "IX_Comment_AssignmentId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TeamMember",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamMember",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "TeamMember",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "MediaFile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "MediaFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskId",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaFile",
                table: "MediaFile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Assignments_AssignmentId",
                table: "Comment",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Assignments_AssignmentId",
                table: "MediaFile",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_Teams_TeamId",
                table: "TeamMember",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
