﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkuBook.DataAccess.Migrations
{
    public partial class CompanyToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_companies",
                table: "companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companies",
                table: "companies");

            migrationBuilder.RenameTable(
                name: "companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
