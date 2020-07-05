using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeControl.DataAccess.Migrations
{
    public partial class DataSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Rooms ON;");
            migrationBuilder.Sql(@"INSERT INTO dbo.Rooms (Id, Name) VALUES (1, 'Wohnzimmer');");
            migrationBuilder.Sql(@"INSERT INTO dbo.Rooms (Id, Name) VALUES (2, 'Flur');");
            migrationBuilder.Sql(@"INSERT INTO dbo.Rooms (Id, Name) VALUES (3, 'Schlafzimmer');");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Rooms OFF;");

            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Devices ON;");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (1, 'Wohnzimmer Deckenleuchte 1', 1);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (2, 'Wohnzimmer Deckenleuchte 2', 1);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (3, 'Wohnzimmer Deckenleuchte 3', 1);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (5, 'Flur Deckenleuchte 1', 2);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (6, 'Flur Deckenleuchte 2', 2);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (7, 'Flur Deckenleuchte 3', 2);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (8, 'Flur Deckenleuchte 4', 2);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (9, 'Schlafzimmer Deckenleuchte', 3);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (10, 'Schlafzimmer Nachttisch', 3);");
            migrationBuilder.Sql(@"INSERT INTO dbo.Devices (Id, Name, RoomId) VALUES (11, 'Schlafzimmer Schreibtisch', 3);");
            migrationBuilder.Sql("SET IDENTITY_INSERT dbo.Devices OFF;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

