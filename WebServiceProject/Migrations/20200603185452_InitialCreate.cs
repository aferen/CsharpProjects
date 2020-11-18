using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServiceProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(maxLength: 50, nullable: false),
                    Star = table.Column<int>(nullable: false),
                    YesCount = table.Column<int>(nullable: false),
                    NoCount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Origin = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Property = table.Column<string>(nullable: true),
                    StockCode = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    SubCategory1Id = table.Column<int>(nullable: false),
                    SubCategory2Id = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsShowcaseProduct = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MainCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories1_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    SubCategory1Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories2_SubCategories1_SubCategory1Id",
                        column: x => x.SubCategory1Id,
                        principalTable: "SubCategories1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Description", "NoCount", "ProductId", "Star", "Title", "YesCount" },
                values: new object[,]
                {
                    { 1, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 1, 5, "KODLAMA", 3 },
                    { 30, "Çok beğendim satıcı ilgili ve hızlı geldi eksiksiz geldi yorumlara bakarak aldım ve pişman olmadım. Yorum yaparak insanlara yardımcı olmak lazım ", 2, 21, 4, "Ürün", 5 },
                    { 32, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 22, 3, "Kalite ", 4 },
                    { 33, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 23, 5, " KAliteli Hızlı Hizmet", 8 },
                    { 34, "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", 2, 23, 4, " Hizmet", 4 },
                    { 35, "Ürün çok kötü paketlenmiş kutusu ezik geldi", 6, 23, 3, "Kargo", 1 },
                    { 36, "Ürün için biraz çekincelerim vardı ama ürün gayet güzel!!", 3, 24, 4, "Kalite", 8 },
                    { 37, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 3, 24, 4, "KODLAMA", 8 },
                    { 38, "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", 10, 24, 4, "Ürün", 2 },
                    { 39, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 26, 5, "Hizmet ", 8 },
                    { 40, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 26, 3, "Kalite ", 4 },
                    { 41, "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", 2, 28, 4, " Hizmet", 4 },
                    { 29, "Ürün çok güzel tavsiye ederim", 3, 21, 5, " Kalite", 8 },
                    { 42, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 28, 5, " KAliteli Hızlı Hizmet", 8 },
                    { 44, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 30, 5, "KODLAMA", 3 },
                    { 45, "Ürün çok güzel tavsiye ederim", 3, 32, 5, " Kalite", 8 },
                    { 46, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 32, 2, "Kalite ", 5 },
                    { 47, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 32, 5, " KAliteli Hızlı Hizmet", 8 },
                    { 48, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 36, 5, "KODLAMA", 3 },
                    { 49, "ürün çok kötü sakın almayın ", 10, 36, 5, " Kalite", 1 },
                    { 50, "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", 10, 36, 2, "Ürün", 2 },
                    { 51, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 38, 3, "Hizmet ", 8 },
                    { 52, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 4, 38, 5, " KAliteli Hızlı Hizmet", 12 },
                    { 53, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 5, 40, 5, "Hizmet ", 2 },
                    { 54, "ürün çok kötü sakın almayın", 8, 40, 1, "Hizmet ", 1 },
                    { 43, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 30, 5, "KODLAMA", 3 },
                    { 28, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 21, 5, "KODLAMA", 3 },
                    { 31, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 22, 5, "Hizmet ", 8 },
                    { 26, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 5, 18, 5, "Hizmet ", 2 },
                    { 2, "Ürün çok güzel tavsiye ederim", 3, 1, 5, " Kalite", 8 },
                    { 3, "Çok beğendim satıcı ilgili ve hızlı geldi eksiksiz geldi yorumlara bakarak aldım ve pişman olmadım. Yorum yaparak insanlara yardımcı olmak lazım ", 2, 1, 4, "Ürün", 5 },
                    { 4, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 2, 5, "Hizmet ", 8 },
                    { 5, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 2, 3, "Kalite ", 4 },
                    { 6, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 3, 5, " KAliteli Hızlı Hizmet", 8 },
                    { 7, "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", 2, 3, 4, " Hizmet", 4 },
                    { 8, "Ürün çok kötü paketlenmiş kutusu ezik geldi", 6, 3, 3, "Kargo", 1 },
                    { 9, "Ürün için biraz çekincelerim vardı ama ürün gayet güzel!!", 3, 4, 4, "Kalite", 8 },
                    { 10, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 3, 4, 4, "KODLAMA", 8 },
                    { 27, "ürün çok kötü sakın almayın  ", 3, 18, 5, "Hizmet ", 8 },
                    { 12, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 6, 5, "Hizmet ", 8 },
                    { 13, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 6, 3, "Kalite ", 4 },
                    { 11, "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", 10, 4, 4, "Ürün", 2 },
                    { 15, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 3, 5, " KAliteli Hızlı Hizmet", 8 },
                    { 25, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 4, 18, 5, " KAliteli Hızlı Hizmet", 12 },
                    { 14, "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", 2, 8, 4, " Hizmet", 4 },
                    { 23, "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", 10, 16, 2, "Ürün", 2 },
                    { 22, "ürün çok kötü sakın almayın ", 10, 13, 5, " Kalite", 1 },
                    { 21, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 13, 5, "KODLAMA", 3 },
                    { 24, "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", 3, 16, 3, "Hizmet ", 8 },
                    { 19, "fiyatina gore iyi bir cihaz. tavsiye ederim", 1, 10, 2, "Kalite ", 5 },
                    { 18, "Ürün çok güzel tavsiye ederim", 3, 10, 5, " Kalite", 8 },
                    { 17, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 10, 5, "KODLAMA", 3 },
                    { 16, "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", 2, 8, 5, "KODLAMA", 3 },
                    { 20, "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", 3, 13, 5, " KAliteli Hızlı Hizmet", 8 }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "IsActive", "Name", "Value" },
                values: new object[,]
                {
                    { 1, true, "TL", 1.0 },
                    { 2, true, "USD", 6.0999999999999996 },
                    { 3, true, "EURO", 6.6100000000000003 }
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 7, true, "Lcd ve Display" },
                    { 10, true, "3D Printer ve CNC" },
                    { 9, true, "Kablosuz Haberleşme" },
                    { 8, true, "Sensör ve Modüller" },
                    { 6, true, "Geliştirme Kartları" },
                    { 1, true, "Mikrodenetleyiciler" },
                    { 4, true, "Arduino" },
                    { 3, true, "Yarı İletkenler" },
                    { 2, true, "Entegreler" },
                    { 5, true, "Raspberry Pi" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsActive", "IsShowcaseProduct", "Name", "Origin", "Price", "Property", "StockCode", "SubCategory1Id", "SubCategory2Id", "Title" },
                values: new object[,]
                {
                    { 23, 4, "Arduino Uno Sensör Shield, Arduino kartları ile birlikte kullanabileceğiniz, kart üzerine birçok giriş çıkışa sahip kullanışlı bir modüldür. Arduino UNO R3 modeli için tasarlanmış olup benzer pin yapısına sahip olan Leonardo veya farklı kartlarla birlikte kullanılabilir.Arduino'nun tüm giriş çıkış pinleri DATA, VCC ve GND sırası ile 3 pin halindedir.Ürüne UART,I2C portları kart üzerinde ayrı olarak yer verilmiştir. Communication Port konektörüyle I2C veya UART olarak ayarlanabilir.Arduino Uno Sensör Shield, Arduino Uno, Leonardo ve Mega modelleriyle kullanılabilir.Ancak bu modellerdeki I2C ve SPI portu farklı pinler üzerinde olduğu için sadece bu portlar kullanılamaz.", "img23.jpg", true, false, "Sensör Shield", "China", 9.0299999999999994, null, "DSTK2143", 4, 0, "Arduino Uno Sensör Shield V4.0" },
                    { 24, 4, "Arduino Ethernet Shield Arduino ile internete bağlanmanıza olanak sağlar.Sunucu veya istemci olarak kullanılabilir. Lehimlemeye gerek duymadan kolaylıkla Arduino'ya bağlayabilirsiniz. Arduino ethernet kütüphanesi ile uyumludur. SD kart takıp karttaki bilgilere internet üzerinden ulaşabilirsiniz. Arduino Uno ile tam uyumludur. Benzer pin yapısına sahip diğer Arduino modelleri ile de kullanılabilir.", "img24.jpg", true, false, "Ethernet Shield", "China", 34.270000000000003, null, "DSTK2084", 4, 0, "Arduino Ethernet Shield" },
                    { 25, 4, "Sensör Shield Arduino Nano için özel olarak tasarlanmış olup benzer pin yapısına sahip diğer Arduino'larla da kullanılabilir. Nano ve geliştirme kartlarını yeni kullanmaya başlayanlar için ideal bir Shield kartıdır. Lehimlemeye gerek duymadan kolayca bağlantı yapabilirsiniz.", "img25.jpg", true, false, "Nano Sensör", "China", 13.710000000000001, null, "9763", 4, 0, "Arduino Nano Sensör Shield" },
                    { 26, 4, "Arduino Mega Sensör Shield Kartı ürünü Arduino Mega için tasarlanmıştır. Ancak benzer pin yapısına sahip DUE veya diğer kartlar ile kullanılabilir. Shield kartları projelerinizi geliştirirken yaşadığınız I/O eksikliği sorununu çözmek için üretilmiştir. Bu ürün ile sensör servo, röle vb. elemanları kolayca devreye bağlayabilirsiniz. Arduino Mega Sensör Shield kartı ile kompleks devreleriniz daha toplu ve daha profesyonel görünecektir. Ayrıca siz de devre takibini daha kolay yapabilirsiniz.", "img26.jpg", true, false, "Mega Sensör", "China", 21.18, null, "9762", 4, 0, "Arduino Mega Sensör Shield" },
                    { 27, 4, "VHM-314, Bluetooth 4.1 teknolojisine kullanan bir Audio modülüdür. Usb girişli, 3.7v lityum pil uyumlu led indikatörlü 3.5 mm stereo jak, kulaklık desteği amfi desteği sağlayan bu modül ile ses projelerinizi rahatlıkla gerçekleştirebilirsiniz.Güç verildiğinde mavi indikatör yanar ve bluetooth moduna girer ve eşleşme için bekler.", "img27.jpg", true, false, "Bluetooth Audio", "China", 22.120000000000001, null, "14105", 4, 0, "VHM-314 Bluetooth Audio Alıcı - Kablosuz Stereo Müzik Modülü" },
                    { 28, 4, "Arduino Touch Shield kartında kullanılan MPR121 entegresi(Proximity Kapasitif Dokunma Sensorü Denetleyici) kapasitif dokunma arayüzlerinin oluşturulmasında mükemmel bir seçenektir ve Touch Shield üzerinde kullanımıyla Arduino projelerinde HMI (human-machine interface) çözümleri için oldukça uygundur. Touch Shield 12 kapsitif touch 'pad'e sahiptir. Bu shield kartı ile toplamda 12 hassas dokunmatik butona sahip olursunuz.Touch Shield üzerindeki lojik seviye dönüştürücü (logic level converter), shield'ın hem 5V hem de 3.3V 'luk Arduino kartlarla çalışmasını sağlar.", "img28.jpg", true, false, "Touch Shield", "China", 37.380000000000003, null, "DSTK2093", 4, 0, "Arduino Touch Shield - X" },
                    { 29, 4, "Klemensli Genişletme Kartı Arduino Uno ile tam uyumludur. Benzer pin yapısına sahip diğer Arduino'larla da kullanılabilir. Bağlantıları daha sağlam yapmak için kabloları lehimlemek yerine sökülüp takılabilir şekilde vidali klemans kullanabilmeniz için tasarlanan bu kartta çeşitli sensör ve motorları bağlayabilmeniz için ek terminaller bulunmaktadır.", "img29.jpg", true, false, "Screw Shield", "China", 34.270000000000003, null, "DSTK2088", 4, 0, "Arduino Screw Shield Genişleme Kartı" },
                    { 30, 4, "Neo-6m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", "img30.jpg", true, false, "Neo-6m", "China", 56.07, null, "15637", 4, 0, "Neo-6m Arduino Shield Mini Gps Modülü" },
                    { 32, 4, "Neo-m8n Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", "img32.jpg", true, false, "Neo-m8n", "China", 93.450000000000003, null, "15639", 4, 0, "Neo-m8n Arduino Shield Mini Gps Modülü" },
                    { 33, 4, "ESP-32 Ses kiti ESP-32-A1S tabanlı küçük bir audio geliştirme kartıdır. TF kart girişi, kulaklık çıkışı, 2 mikrafon girişi ve 2 hoparlör çıkışı kartın üzerinde mevcuttur. Hızlı geliştirme için uygun olan bu kart akıllı IOT projelerinde, ev sistemlerinde, akıllı hoparlör çözümleri gibi projelerinde kullanılabilir. ", "img33.png", true, false, "Esp-32", "China", 155.75, null, "14104", 4, 0, "Esp-32 Audio Kit - Ses Geliştirme Kartı" },
                    { 34, 4, "ESP13 Wifi Shield Kartı ürünü ile Arduino'nuzu kolayca internete bağlayabilir ve web sunucusu oluşturabilirsiniz. Arduino Uno ve Arduino Mega modelleriyle uyumludur. Ürünün kullanımı hakkında daha detaylı bilgi için dökümanlar kısmındaki kullanma kılavuzunu okuyabilirsiniz.", "img34.jpg", true, false, "ESP13", "China", 76.010000000000005, null, "9764", 4, 0, "ESP13 Wifi Shield" },
                    { 35, 4, "Bu GSM - GPS - GPRS Geliştirme Modülünü Arduino ve Raspberry Pi  ile kullanabilirsiniz.Türkiye’de yasal IMEI kaydı bulunan bu modül ile basit Telefon, SMS işlevli uygulamalardan,araç takibi,M2M uygulamaları ve aklınıza gelebilecek tüm GSM / GPS / GPRS işlemleri geliştirebilirsiniz.Üzerindeki 3 ayrı girişten,besleme yapılabilmektedir: DC044 girişinden 5 - 26V ile, 3.7 - 4.2V Lipo / Lion pil ile, Vin girişinden 5 - 26V ile besleme yapılabilmektedir.Yapılacak beslemenin 2A güce sahip olmasına dikkat ediniz.Modül SIM808,AT komutları kullanılarak programlanır.Power düğmesi modülün gücünü açıp kapatır.Power ON durumuna getirilince Power Led yanar.Ayrıca modülü başlatmak için modülün yan tarafındaki butona 2 saniye kadar basılarak aktif hale getirilir ve diğer 3 LED yanar ve bu ledlerden birisi yanıp sönmeye başlar bu da SIM808 çalışmaya başladığı anlamına gelir.SIM yuvası Modülün altında yer almaktadır.GSM, GPS antenleri ve SIM kartı düzgün takıldığı taktirde LED 3 saniyede bir yanıp sönecektir.Bu da Modülün şebekeye bağlandığının işaretidir.Böylece bir çağrı yaptırabilir veya diğer işlemler yaptırabilirsiniz.Titreşim motoru da bulunduran modül 5V ile çalışmakta olup modülün sağ üst köşesinde bulunan pim ile kontrol edilir.Üzerinde Bluetooth da bulunduran SIM808, AT komutları ile kontrol edilir.SIM8080 modülü Arduino ve Raspberry pi ile Rx - Tx ve GND pimleri kullanılarak haberleşme yapılır.Burada dikkat edilecek konu; işlemci sisteminiz 1.25V / 3.3V / 5V kullanıyor ise VMCU pimini bu sistemin 1.25V / 3.3V veya 5V beslemesine bağlamanız gerekir. Zira SIM808 modülü üzerindeki seviye çevirici VMCU ile Rx / Tx pimlerinin bu seviyede çalışmasını sağlar.USB soketi sadece Firmware güncellenmesi için kullanılmaktadır.", "img35.jpg", true, false, "SIM808 Arduino", "Türkiye", 235.24000000000001, null, "DSTK0956", 4, 0, "SIM808 Arduino - Raspberry Pi GSM - GPS - GPRS Geliştirme Modülü (IMEI No Kayıtlıdır)" },
                    { 36, 4, "Mini GSM Modülü Ardino gibi geliştirme kartlarıyla ya da özel projelerinizde kolaylıkla kullanabilmeniz için header çıkışlara sahiptir. Minimal boyutlarıyla bir çok projeye kolayca entegre edilebilir. Diğer modüllere göre daha ucuz olduğu için sıklıkla tercih edilir.", "img36.jpg", true, false, "Mini GSM/GPRS", "China", 60.43, null, "13664", 4, 0, "Mini GSM/GPRS Modülü - SIM800L (IMEI Kayıtlı Değildir)" },
                    { 37, 4, "GGS01 GSM/GPS Arduino genişletme kartı, üzerindeki Simcom SIM800 GSM, SIM28 GPS Modülü ve Push-Push Simkart yuvası ile birlikte GPRS&GSM şebekesine Arduino ile birlikte bağlatı kurmanızı sağlar.Ürün IMEI numarası Türkiye’de kayıtlı olup, takacağınız SIM kartınız ile internete bağlanmaya,SMS atmaya & almaya,veri ve ses transferi yapmaya hazır bir Arduino genişletme kartıdır.GGS01 GSM / GPS Modül ile GSM uygulamaları ile birlikte konum bilgisi edinme,araç takip uygulamaları,insan - nesne - cihaz takip uygulamaları yapabilirsiniz.", "img37.jpg", true, false, "Arduino GSM-GPS", "Türkiye", 654.14999999999998, null, "10433", 4, 0, "Arduino GSM-GPS Shield / Genişletme Kartı (SIM800 - SIM28 - IMEI Kayıtlıdır)" },
                    { 38, 4, "Mini Konrol Modülüanalog ve dijital çıkışıyla ultrasonik sensör ve servo motor kontrol edebileceğiniz bir shield kartıdır. Ayrıca I2C girişine LED barı bağlayarak güç girişini izleyebilirsiniz.", "img38.jpg", true, false, "Atmega32U4", "China", 90.340000000000003, null, "12694", 4, 0, "Arduino Atmega32U4 Mini Kontrol Modülü" },
                    { 39, 4, "GPRS Shiled Simcom'un SIM900 modülünü kullanır. GSM cep telefonu ağını kullanarak iletişim kurmanın pratik bir yoludur. Shield, AT komutları (GSM 07.05, 07.07 ve SIMCOM AT komutları) göndererek UART üzerinden SMS, MMS, GPRS ve ses elde etmenizi sağlar. Kart ayrıca 12 GPIO, 2 PWM, SIM900 modülü ve bir ADC(2V8 logic)'ye sahiptir.", "img39.jpg", true, false, "SIM900 GSM/GPRS", "China", 161.97999999999999, null, "13665", 4, 0, "SIM900 GSM/GPRS Geliştirme Modülü - Arduino(IMEI Kayıtlı Değildir" },
                    { 40, 4, "Bu Arduino Müzik Shield / MP3 Modülü, üzerinde bulunan VS1053B entegresi sayesinde çeşitli müzik formatlarını oynatabilir. Ogg Vorbis/MP3/AAC/WMA/MID formatlarını destekleyen bu entegre SD kartınızda bulunan tüm müzikleri çalabilir. Üzerinde bulunan mikrofondan yada ses giriş kanalından bağlanıp kayıt alabilirsiniz.", "img40.jpg", true, false, "Müzik Shield", "China", 61.369999999999997, null, "DSTK7030", 4, 0, "Arduino Müzik Shield / MP3 Modülü (VS1053B)" },
                    { 31, 4, "Neo-7m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", "img31.jpg", true, false, "Neo-7m", "China", 74.760000000000005, null, "15638", 4, 0, "Neo-7m Arduino Shield Mini Gps Modülü" },
                    { 21, 4, "LCD Shield en çok kullanılan Arduino shield çeşitlerindendir. Kart üzerinde 2x16 LCD ekran, 5 adet programlanabilir buton ve bir adet reset butonu vardır. Arduino ile ekranı açıp kapatabilir ve arka ışığı kontrol edebilirsiniz.", "img21.jpg", true, false, "Arduino Shield", "China", 14.33, null, "DSTK2124", 4, 0, "Arduino Lcd Shield" },
                    { 22, 4, "Motor Shield en çok kullanılan Arduino shield çeşitlerindendir. Kart ile 4 adet DC motor, 2 adet step motor veya 2 adet servo motor kontrol edebilirsiniz. 4.5-36V arası motorlar için kullanılabilir.", "img22.jpg", true, false, "Motor Shield", "China", 11.84, null, "DSTK2135", 4, 0, "Arduino Motor Shield - L293D" },
                    { 19, 5, "RAK2245 Pi HAT Sürümü RAK2245 ailesinin en büyüğüdür ancak Raspberry Pi 40pin başlığı ile tam uyumluluk sunar. Ürünün frekans değeri 868 Mhz'dir. Böylece Raspberry Pi'yi özünde kullanan bir DIY ağ geçidi için mükemmel bir çözümdür. Bu, düşük maliyetli ve istikrarlı bir performansla LoRaWAN çözümünün hızlı bir şekilde kullanılmasını sağlar.RAK2245 hattındaki diğer modüllerde olduğu gibi, Semtech 1301 ve çift SX1257 / 58 ön uç yongalarına dayanıyor.Bu ürünün son nesli(RAK831) üzerinde bir takım iyileştirmeler içeren tam teşekküllü bir 8 kanallı LoRa Konsantratörüdür.", "img19.jpg", true, true, "RAK2245 Pi", "China", 1074.0, null, "15878", 2, 0, "RAK2245 Pi HAT Sürümü 868 Mhz" },
                    { 1, 4, "Arduino'nun alışageldiğimiz standart boardlarından olan Arduino Uno R3 SMD CH340 Chip'in bu klonundaki temel farklılığı kullandığı programlama entegresinin (USB-Serial dönüştürücü) CH340 olması. Orjinal Arduino'dan birkaç küçük farkı olmasına rağmen kullanımı, yazılımı ve genişletme kartlarının uyumluluğu bakımından hiçbir fark bulunmamaktadır. Bu üründe ve daha birçok elektronik üründe daha da popüler olarak kullanılmaya başlanan CH340 USB - Serial dönüştürücü için, Windows 7 ve Mac OS X kullanıyorsanız driver yüklemeniz gerekmektedir.Windows 7 ve Mac OS X için gereken bu sürücüyü aşağıdaki doküman kısmında bulabilirsiniz.Linux, Windows 8 ve üstü için herhangi bir driver gerekli değildir.Arduino Uno R3 CH340 SMD ile Arduino Uno Dip arasındaki fark mikrodenetleyinin SMD veya DIP olarak ayrılmasının yanı sıra DIP türünün değiştirilebilir olmasıdır.", "img1.jpg", true, true, "Klon Arduino Uno R3 SMD", "China", 17.109999999999999, null, "DSTK0703", 10, 0, "Arduino Uno R3 SMD CH340 Chip - Klon (USB Kablo Dahil)" },
                    { 2, 5, "Raspberry Pi 4 28nm tabanlı 1.5G Dört Çekirdekli CPU ve 4Gb DRR4 RAM içeren küçük bir DIY bilgisayardır. PC benzeri yetenekler elde etmek için Raspberry Pi 4, 4K Mikro HDMI, USB 3.0, BLE Bluetooth 5.0, çift-bantlı 2.4/5.0 GHz Wireless LAN, USB-C güç girişi ve PoE ile uyumlu True Gigabit Ethernet'e sahiptir.Raspberry Pi 4'ün ana yönü daha iyi performanstır; daha iyi VideoCoreVI Graphics ile 1,5 GHz Dört Çekirdekli ARM Cortex-A72 CPU'ya sahiptir. Pi 4, bir 4K 60fps HEVC videosunu bir Micro-HDMI portu üzerinden görüntüleyebilir ve aynı anda iki adet 4K ekrana ancak 30fps yenileme hızıyla bağlanabilir. 1000Mbps True Gigabit Ethernet ve dört USB portu vardır, ancak ikisi USB 2.0 aktarma hızının on katı olan USB 3.0 portlarıdır. Ek olarak, Raspberry Pi 4 yeni bir 5V / 3A güç kaynağı kullanıyor ve daha iyi bir dayanıklılığa sahip olan ve her iki tarafta da çalışabilen bir USB Tip C portu üzerinden bağlanıyor.", "img2.jpg", true, true, "Raspberry Pi", "Raspberry Pi", 448.56, null, "14655", 2, 0, "Raspberry Pi 4 4GB - Model B" },
                    { 3, 9, "ESP8266, yeni bağlantılı dünya ihtiyaçları için tasarlanmış oldukça entegre bir çiptir. Uygulamayı barındırabilmesine veya tüm Wi-Fi ağ işlevlerini başka bir uygulama işlemcisinden yönlendirebilmesine olanak tanıyan eksiksiz ve kendine yeten bir Wi-Fi ağ çözümü sunar.ESP8266,çalıştırma süresince minimal ön yükleme ve minimal yükleme ile GPIO'ları aracılığıyla sensörler ve diğer uygulama özellikli cihazlarla entegre olmasını sağlayan güçlü dahili işleme ve depolama yeteneklerine sahiptir. Yüksek derecede on-chip entegrasyonu minimal dış devreye imkan tanır ve ön uç modülü de dahil olmak üzere tüm çözüm minimum PCB alanını alacak şekilde tasarlanmıştır.", "img3.jpg", true, true, "Esp8266", "Espressif", 10.59, null, " DSTK2404", 1, 0, "Esp8266 Seri Wifi Modül" },
                    { 4, 16, "Tekli Breadboard, Devre kurmak için en pratik parçalardan olan breadboard ile kolayca prototipleme ve deney yapmak için uygundur. Atlama(jumper) kablolarıyla uyumluluk sağlamaktadır.", "img4.jpg", true, true, "Breadboard", "China", 4.9800000000000004, null, " DSTK3861", 2, 0, "Tekli Breadboard" },
                    { 5, 6, "LattePanda 4G/64GB,  Windows 10  işletim sistemi kullanan bir mini bilgisayar ve geliştirme kartıdır. Arduino kartları ile uyumludur. Türkiye'de en uygun fiyatlarla Direnc.net'te bulabileceğiniz mini bilgisayarda dahili 4GB Ram ve 64GB Harddisk vardır.", "img5.jpg", true, true, "LattePanda", "LattePanda", 1009.0, null, " DFR0419", 1, 0, "LattePanda Windows 10 Lisanssız 4G/64GB" },
                    { 20, 4, "Neo-7m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir. ", "img20.jpg", true, true, "Arduino Shield", "China", 88.219999999999999, null, "15638", 4, 0, "Neo-7m Arduino Shield Mini Gps Modülü" },
                    { 7, 5, "Tip C ve HDMI bağlantısı, 1920 × 1080 piksel, sertleştirilmiş cam kapasitif dokunmatik panel ve güçlü 10000mAh pil içeren evrensel bir taşınabilir dokunmatik monitördür.Raspberry Pi için mükemmel uyumludur ayrıca Jetson Nano gibi diğer popüler mini PC'leri de destekler. Masaüstü bilgisayar, dizüstü bilgisayar, cep telefonu veya oyun konsolu gibi ana cihazlarla basit bir monitör olarak çalışır. C Tipi veya HDMI bağlantısıyla bir saniyede HD büyük ekrana geçebilirsiniz.", "img7.jpg", true, true, "Monitör", "WaveShare", 1375.0, null, " 16549", 4, 0, "15.6 inç Evrensel Taşınabilir Dokunmatik Full HD, IPS, HDMI LCD" },
                    { 8, 7, "Nextion, insan ve proses, makina, uygulama ya da cihaz arasında kontrol ve görselleştirme arabirimi olarak görev yapan bir Seamless Human Machine Interface (HMI) çözümüdür. Geleneksel LCD ve LED Nixie tübünün yerini almak için tasarlanmış en iyi çözümdür.", "img8.jpg", true, true, "Lcd Ekran", "Nextion", 124.37, null, " NX3224T028", 1, 0, "2.8 Inch Nextion HMI Dokunmatik TFT Lcd Ekran - 4MB Dahili Hafıza" },
                    { 9, 1, "Atmel ATMEGA128A AU TQFP-64 8 bit 16 MHz Mikrodenetleyici ürünü TQFP-64 kılıfta olup 16 MHz frekansı ile çalışan 8 bit değerinde Mikrodenetleyici Çeşitlerindendir. Üzerinde bulunan 64 pinin 53 adedi I/O yani Giriş Çıkış pinidir.Bellek tipi FLASH olan bu mikrodenetleyiciler 5.5V ile 2.7V besleme aralığında,-40 C° ile + 85 C° sıcaklıkları aralığında çalışmaktadır.", "img9.jpg", true, true, "ATMEGA128A-AU", "Atmel", 14.06, null, " DSTK3408", 2, 0, "ATMEGA128A-AU SMD TQFP-64 8-Bit 16 MHz Mikrodenetleyici" },
                    { 6, 10, "Anycubic 4Max Pro tamamen kapalı kasalı, FDM Fused Deposition Modeling yani eriyik yığma modelleme teknolojisine sahip kullanıcı dostu, ısıtma tablalı bir 3D yazıcıdır. 270mm x 205mm x 205 geniş çalışma alanına sahip bu 3 boyutlu yazıcı kullanıcılara otomatik devam özelliği sunmaktadır. Bu sayede güç kesilmesi gibi nedenlerle yarım kalan baskıyı, kaldığı yerden devam ettirebilirsiniz.Otomatik kapanma fonksiyonu ile baskı bittiğinde ürünün otomatik kapanmasını sağlayabilirsiniz.Ayrıca filament sensörü filament bittiğinde yada kırıldığında sizi uyarmaktadır.Anycubic 4Max Pro, ayrı bir kuruluma gerek duymayan,tak çalıştır özellikte,yüksek performanslı bir 3 boyutlu yazıcıdır.", "img6.jpg", true, true, "Anycubic 4MAX Pro", "Anycubic", 3843.0, null, "11152", 1, 0, "Anycubic 4MAX Pro 3D Printer / 3D Yazıcı - Monteli - Beyaz Renk" },
                    { 11, 18, "mBot Blue Bluetooth Versiyonu Eğitim Robotu IR Uzaktan Kumanda Hediyeli olarak gelmektedir. mBot'un varsayılan programı optimize edilmiştir. mBot'un çalışma durumu yerleşik düğme ile kontrol edilebilir.", "img11.jpg", true, true, "mBot V1.1", "MakeBlock", 529.27999999999997, null, "90053", 1, 0, "mBot V1.1 - Blue - Bluetooth Versiyonu STEM Eğitim Robotu" },
                    { 12, 27, "YH 862D Dijital Ayarlı Havya İstasyonu, SMD cihazları tamir eden tamircilerin en çok tercih ettiği havya seti.", "img12.jpg", true, true, "YH862D", "TT-Technich", 406.25, null, "DSTK1985", 3, 0, "YH862D Dijital İstasyonlu Havya" },
                    { 13, 6, "BBC micro:bit, 32 bit ARM Cortex-M0 işlemciyi temel alarak, ivmeölçer ve pusula sensörlerine, Bluetooth Düşük Enerji ve USB bağlantısına, 25 LED'li ekrandan ve iki programlanabilir tuştan oluşur ve USB ya da harici bir pil takımı ile çalıştırılabilir.Cihaz giriş ve çıkışları,21 pinli kenar konnektörünün parçası olan beş halkalı konektör içinden geçmektedir.", "img13.jpg", true, true, "BBC Micro", "micro:bit", 130.0, null, " 9673", 6, 0, "BBC Micro:Bit Geliştirme Kartı" },
                    { 14, 15, "SSR-25DA Solid State Röle 25 A değerine kadar kontrol sağlayabilir. Giriş yani tetikleme DC gerilim olmalıdır. Çıkış yani yük AC gerilim olmalıdır. Solid State Rölerin en büyük avantajlarından biri normal röleler gibi mekanik kontaklara sahip olmamasıdır. Bunun yerine Triac kullanır. Ayrıca, optik yalıtımlı ekstra güvenlik sunar.", "img14.jpg", true, true, "Arduino ve Raspberry Pi Uyumlu", "Fotek", 18.440000000000001, null, "DSTK4227", 8, 0, "SSR-25DA (25A) Solid State Röle (Geliştirme Kartlarıyla Uyumlu)" },
                    { 15, 4, "Bu bir mini trafik lambası modülüdür. Yüksek parlaklık ve kompakt tasarımı ile trafik lamba sistemi için uygun bir Arduino modülüdür. 3 adet pini ve bir ground pini bulunmaktadır. Her ışığın pinine 5V vererek ledleri sıra ile yakabilirsiniz.", "img15.png", true, true, "Arduino LED", "China", 4.0599999999999996, null, "14114", 5, 1, "Arduino LED Trafik Lambası Modülü" },
                    { 16, 3, "IRF1405, N Kanal Mosfet Çeşitlerinden olup TO-220 kılıftadır. IRF1405, N Kanal Power Mosfet türündedir. IRF1405 55Vluk bir Gate-Source gerilimine sahip olup 169A sürekli çıkış akımına sahiptir.", "img16.jpg", true, true, "55V, 5.3mohm", "IR / FAIRCHILD", 4.9800000000000004, null, "DSTK4773", 2, 0, "IRF1405 N Kanal Power Mosfet TO-220" },
                    { 17, 1, "RC522 RFID Okuyucu Kartı, NFC frekansı olan 13,56 MHz frekansında çalışan tagler üzerinde okuma ve yazma işlemeni yapabilen, düşük güç tüketimli, ufak boyutlu bir karttır.Arduino başta olmak üzere bir çok mikrodenetleyeci platformu ile beraber rahatlıkla kullanılabilir. 424 kbit / s haberleşme hızına sahiptir.RFID üzerinde farklı şifreleme türlerini desteklemektedir.Desteklediği kart türleri mifare1 S50,mifare1 S70 mifare ultralight,mifare pro ve  mifare desfire'dir. Not: 125 KHz frekansında çalışan RFID kartlarını desteklememektedir.Yalnızca 13,56 MHz frekansında çalışan kartları desteklemektedir.NFC modülleri bu frekansta çalıştığı için NFC kartları ile beraber kullanılabilir.", "img17.jpg", true, true, "RFID", "China", 12.5, null, "DSTK2449", 5, 0, "Rc522 RFID Okuyucu 13.56 Mhz" },
                    { 18, 23, "Su Geçirmez Mike Konnektör GX-16 3 pinlidir. Veri sistemleri, bilgisayar, otomasyon, ölçüm-kontrol sistemleri, mekanik ekipmanlarda, ses/video, iletişim, otomotiv ve daha birçok sektörlerde kullanılan Mike Konnektörler, su geçirmez şekilde tasarlanmıştır.", "img18.png", true, true, "Konnektör", "China", 12.15, null, "15633", 5, 0, "3-Pin Su Geçirmez Mike Konnektör GX-16" },
                    { 10, 9, "Bu ürün, bluetooth iletişim protokolü içinde gömülüdür, sürücüyü yüklemenize gerek yoktur, Windows sistemlerinde kullanılabilir, dos, linux ve diğer grafiksel olmayan işletim sistemlerini de kullanabilirsiniz.Bluetooth adaptörü, masaüstü bilgisayarları,avuçiçi bluetooth pda ve bluetooth gps cihazı ile donatılmış bluetooth özellikli bir dizüstü bilgisayar ile bluetooth seri port profillerini(spp) destekler.Bluetooth spp servis bağlantılarını ve iletişimi desteklerReset tuşu ile kaydedilen eşleştirilmiş cihaz bilgilerini kaldırabilir ve yeni Bluetooth ile eşleştirebilirsiniz.Blue chip bluetooth 2.1 standardını kabul eder.Geliştirilmiş ber hata oranı performansı ve otomatik frekans atlamalı teknoloji etkin ve güvenli iletişim sağlayabilir ve iletişimin kararlılığını ve güvenilirliğini sağlamak için daha güçlü bir anti - karışma kabiliyetine sahiptir.Kullanıcı, 1200bps nm toplam 12 farklı baud hızından(varsayılan 9600, n, 8, 1) at komutu kullanarak ayarlayabilir,ayrıca cihaz için daha kişiselleştirilmiş Bluetooth adı ayarlayabilir.Transmitted güç bluetooth class2 standart, dahili yüksek hassasiyetli PCB basılı anten, istikrarlı iletişim mesafesi 15m kadar uyumlu olabilir ile uyumludur", "img10.jpg", true, true, "RS232", "China", 90.629999999999995, null, " DSTK2359", 3, 0, "RS232 Bluetooth Seri Adaptör" }
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "ImagePath", "IsActive", "Name" },
                values: new object[,]
                {
                    { 6, "slider6.jpg", true, "slider 6" },
                    { 5, "slider5.jpg", true, "slider 5" },
                    { 4, "slider4.jpg", true, "slider 4" },
                    { 7, "slider7.jpg", true, "slider 7" },
                    { 2, "slider2.jpg", true, "slider 2" },
                    { 1, "slider1.jpg", true, "slider 1" },
                    { 3, "slider3.jpg", true, "slider 3" },
                    { 8, "slider8.jpg", true, "slider 8" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories1",
                columns: new[] { "Id", "IsActive", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, true, 4, "Orijinal Arduino" },
                    { 2, true, 4, "Arduino Ana Board" },
                    { 3, true, 4, "Arduino Eğitim Setleri" },
                    { 4, true, 4, "Arduino Shield" },
                    { 5, true, 4, "Arduino Sensör ve Modüller" },
                    { 6, true, 4, "Arduino Röle Kartları" },
                    { 7, true, 4, "Arduino Gsm ve Gps" },
                    { 8, true, 4, "Arduino Kitap" },
                    { 9, true, 4, "Arduino Aksesuarları" },
                    { 10, true, 4, "Arduino Lilypard" },
                    { 11, true, 4, "Arduino Lcd Display" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories2",
                columns: new[] { "Id", "IsActive", "Name", "SubCategory1Id" },
                values: new object[,]
                {
                    { 1, true, "Arduino Modüller", 5 },
                    { 2, true, "Kablosuz Haberleşme", 5 },
                    { 3, true, "Su Sensörleri", 5 },
                    { 4, true, "Sıcaklık ve Nem Sensörleri", 5 },
                    { 5, true, "Gaz ve Basınç Sensörleri", 5 },
                    { 6, true, "Mesafe ve Hareket Sensörleri", 5 },
                    { 7, true, "Eğim / İvme /Gyro Sensörleri", 5 },
                    { 8, true, "Medikal Sensörler", 5 },
                    { 9, true, "Renk ve Işık Sensörleri", 5 },
                    { 10, true, "Akım ve Voltaj Sensörleri", 5 },
                    { 11, true, "Lazer ve Lazerli Sensörler", 5 },
                    { 12, true, "RTC - Gerçek Zamanlı Saat Modülleri", 5 },
                    { 13, true, "Ses ve Amfi Modülleri", 5 },
                    { 14, true, "Ph Sensörler", 5 },
                    { 15, true, "Arduino Sensör Ve Modüller (Tümü)", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories1_MainCategoryId",
                table: "SubCategories1",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories2_SubCategory1Id",
                table: "SubCategories2",
                column: "SubCategory1Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "SubCategories2");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "SubCategories1");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}
