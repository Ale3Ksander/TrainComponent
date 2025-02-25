using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainComponent.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UniqueNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponents_UniqueNumber",
                table: "TrainComponents",
                column: "UniqueNumber",
                unique: true);

            migrationBuilder.Sql(@"
                INSERT INTO TrainComponents (Name, UniqueNumber, CanAssignQuantity, Quantity) VALUES
                ('Engine', 'ENG123', 0, NULL),
                ('Passenger Car', 'PAS456', 0, NULL),
                ('Freight Car', 'FRT789', 0, NULL),
                ('Wheel', 'WHL101', 1, 100),
                ('Seat', 'STS234', 1, 50),
                ('Window', 'WIN567', 1, 30),
                ('Door', 'DR123', 1, 20),
                ('Control Panel', 'CTL987', 1, 10),
                ('Light', 'LGT456', 1, 200),
                ('Brake', 'BRK789', 1, 50),
                ('Bolt', 'BLT321', 1, 500),
                ('Nut', 'NUT654', 1, 500),
                ('Engine Hood', 'EH789', 0, NULL),
                ('Axle', 'AX456', 0, NULL),
                ('Piston', 'PST789', 0, NULL),
                ('Handrail', 'HND234', 1, 40),
                ('Step', 'STP567', 1, 25),
                ('Roof', 'RF123', 0, NULL),
                ('Air Conditioner', 'AC789', 0, NULL),
                ('Flooring', 'FLR456', 0, NULL),
                ('Mirror', 'MRR789', 1, 15),
                ('Horn', 'HRN321', 0, NULL),
                ('Coupler', 'CPL654', 0, NULL),
                ('Hinge', 'HNG987', 1, 50),
                ('Ladder', 'LDR456', 1, 10),
                ('Paint', 'PNT789', 0, NULL),
                ('Decal', 'DCL321', 1, 60),
                ('Gauge', 'GGS654', 1, 30),
                ('Battery', 'BTR987', 0, NULL),
                ('Radiator', 'RDR456', 0, NULL);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponents");
        }
    }
}
