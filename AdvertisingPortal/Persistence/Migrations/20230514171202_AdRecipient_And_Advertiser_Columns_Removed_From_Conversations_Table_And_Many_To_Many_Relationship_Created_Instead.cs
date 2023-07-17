using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisingPortal.Persistence.Migrations
{
    public partial class AdRecipient_And_Advertiser_Columns_Removed_From_Conversations_Table_And_Many_To_Many_Relationship_Created_Instead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_AspNetUsers_AdRecipientId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_AspNetUsers_AdvertiserId",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_AdRecipientId",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_AdvertiserId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "AdRecipientId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "AdvertiserId",
                table: "Conversations");

            migrationBuilder.CreateTable(
                name: "UserConversations",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConversations", x => new { x.UserId, x.ConversationId });
                    table.ForeignKey(
                        name: "FK_UserConversations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConversations_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserConversations_ConversationId",
                table: "UserConversations",
                column: "ConversationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserConversations");

            migrationBuilder.AddColumn<string>(
                name: "AdRecipientId",
                table: "Conversations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvertiserId",
                table: "Conversations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_AdRecipientId",
                table: "Conversations",
                column: "AdRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_AdvertiserId",
                table: "Conversations",
                column: "AdvertiserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_AspNetUsers_AdRecipientId",
                table: "Conversations",
                column: "AdRecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_AspNetUsers_AdvertiserId",
                table: "Conversations",
                column: "AdvertiserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
