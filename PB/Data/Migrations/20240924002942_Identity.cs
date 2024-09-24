using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Noitificacoes",
                table: "Noitificacoes");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Noitificacoes",
                newName: "Notificacoes");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Avaliacoes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notificacoes",
                table: "Notificacoes");

            migrationBuilder.RenameTable(
                name: "Notificacoes",
                newName: "Noitificacoes");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Avaliacoes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Noitificacoes",
                table: "Noitificacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
