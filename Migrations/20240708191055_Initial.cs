using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarroCompras",
                columns: table => new
                {
                    idCarroCompra = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    totalCompra = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarroCompras", x => x.idCarroCompra);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rolDescripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCarros",
                columns: table => new
                {
                    idDetalleCarro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarroCompraId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCarros", x => x.idDetalleCarro);
                    table.ForeignKey(
                        name: "FK_DetalleCarros_CarroCompras_CarroCompraId",
                        column: x => x.CarroCompraId,
                        principalTable: "CarroCompras",
                        principalColumn: "idCarroCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombreUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    passUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    rolUsuarioidRol = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_rolUsuarioidRol",
                        column: x => x.rolUsuarioidRol,
                        principalTable: "Roles",
                        principalColumn: "idRol");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    precio = table.Column<int>(type: "INTEGER", nullable: false),
                    imgPath = table.Column<string>(type: "TEXT", nullable: false),
                    DetalleCarroidDetalleCarro = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_Productos_DetalleCarros_DetalleCarroidDetalleCarro",
                        column: x => x.DetalleCarroidDetalleCarro,
                        principalTable: "DetalleCarros",
                        principalColumn: "idDetalleCarro");
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    idStock = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productoidProducto = table.Column<int>(type: "INTEGER", nullable: true),
                    stockDisponible = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.idStock);
                    table.ForeignKey(
                        name: "FK_Stocks_Productos_productoidProducto",
                        column: x => x.productoidProducto,
                        principalTable: "Productos",
                        principalColumn: "idProducto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarros_CarroCompraId",
                table: "DetalleCarros",
                column: "CarroCompraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleCarroidDetalleCarro",
                table: "Productos",
                column: "DetalleCarroidDetalleCarro");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_productoidProducto",
                table: "Stocks",
                column: "productoidProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_rolUsuarioidRol",
                table: "Usuarios",
                column: "rolUsuarioidRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "DetalleCarros");

            migrationBuilder.DropTable(
                name: "CarroCompras");
        }
    }
}
