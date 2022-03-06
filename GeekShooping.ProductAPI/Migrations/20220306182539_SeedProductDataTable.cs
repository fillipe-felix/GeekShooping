using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShooping.ProductAPI.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { new Guid("3eb84da2-120a-4ab6-9578-cfb8a6af0a72"), "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true", "Star Wars The Black Series Hasbro - Stormtrooper Imperial", 189.99m },
                    { new Guid("63080952-4e2c-4396-a1c6-3d8fe47e3899"), "Sweatshirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true", "Moletom Com Capuz Cobra Kai", 159.9m },
                    { new Guid("7ba5febb-8302-47af-bb40-3522570f742a"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true", "Camiseta Gamer", 69.99m },
                    { new Guid("82689ea8-ca3e-46df-b5fc-083f361bc8b6"), "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true", "Star Wars Mission Fleet Han Solo Nave Milennium Falcon", 359.99m },
                    { new Guid("83b1c96a-a8fe-425e-bf34-74de5fa18d92"), "Book", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true", "Livro Star Talk – Neil DeGrasse Tyson", 49.9m },
                    { new Guid("96e3c13e-e723-46ae-a361-c28a0a2eceec"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true", "Camiseta SpaceX", 49.99m },
                    { new Guid("a284b192-be4c-4d85-aece-5bd93d392f82"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true", "Camiseta Feminina Coffee Benefits", 69.9m },
                    { new Guid("a71f8e23-70e2-4a53-bcee-7144013f9ee0"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true", "Camiseta Elon Musk Spacex Marte Occupy Mars", 59.99m },
                    { new Guid("ab860503-48cb-4502-8d9c-27a8f4dd4ce8"), "Action Figure", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true", "Capacete Darth Vader Star Wars Black Series", 999.99m },
                    { new Guid("ca1412e8-07db-4718-9444-444106b17ee4"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true", "Camiseta GNU Linux Programador Masculina", 59.99m },
                    { new Guid("df8dce36-69a8-4dc9-abde-df544d8e1e54"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg", "Camiseta Goku Fases", 59.99m },
                    { new Guid("e015d8b6-cd40-442c-bf0b-2f4037bb1371"), "T-shirt", "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.", "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/2_no_internet.jpg?raw=true", "Camiseta No Internet", 69.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("3eb84da2-120a-4ab6-9578-cfb8a6af0a72"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("63080952-4e2c-4396-a1c6-3d8fe47e3899"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("7ba5febb-8302-47af-bb40-3522570f742a"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("82689ea8-ca3e-46df-b5fc-083f361bc8b6"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("83b1c96a-a8fe-425e-bf34-74de5fa18d92"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("96e3c13e-e723-46ae-a361-c28a0a2eceec"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("a284b192-be4c-4d85-aece-5bd93d392f82"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("a71f8e23-70e2-4a53-bcee-7144013f9ee0"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("ab860503-48cb-4502-8d9c-27a8f4dd4ce8"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("ca1412e8-07db-4718-9444-444106b17ee4"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("df8dce36-69a8-4dc9-abde-df544d8e1e54"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("e015d8b6-cd40-442c-bf0b-2f4037bb1371"));
        }
    }
}
