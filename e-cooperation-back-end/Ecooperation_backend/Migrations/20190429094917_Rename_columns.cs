using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecooperation_backend.Migrations
{
    public partial class Rename_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_creatorid",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Projects_Projectid",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_Projectid",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "token",
                table: "Users",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Projectid",
                table: "Users",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Projectid",
                table: "Users",
                newName: "IX_Users_ProjectId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Projectid",
                table: "Tags",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Projectid",
                table: "Tags",
                newName: "IX_Tags_ProjectId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Projects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Projects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "creatorid",
                table: "Projects",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Projects",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_creatorid",
                table: "Projects",
                newName: "IX_Projects_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Projects_ProjectId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Projects_ProjectId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "token");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Users",
                newName: "Projectid");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "birthDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ProjectId",
                table: "Users",
                newName: "IX_Users_Projectid");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Tags",
                newName: "Projectid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tags",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ProjectId",
                table: "Tags",
                newName: "IX_Tags_Projectid");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projects",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Projects",
                newName: "creatorid");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Projects",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                newName: "IX_Projects_creatorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_creatorid",
                table: "Projects",
                column: "creatorid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Projects_Projectid",
                table: "Tags",
                column: "Projectid",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Projects_Projectid",
                table: "Users",
                column: "Projectid",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
