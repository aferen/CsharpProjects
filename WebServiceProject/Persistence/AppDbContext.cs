using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceProject.Models;

namespace WebServiceProject.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory1> SubCategories1s { get; set; }
        public DbSet<SubCategory2> SubCategories2s { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //for mssql server
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DTBB8SC;Initial Catalog=DirencNetDB;User ID=sa; Password=12345; Trusted_Connection=True;");

                //for sqlite server
                //optionsBuilder.UseSqlite("Data Source=blogging.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Entity<MainCategory>().ToTable("MainCategories");
            builder.Entity<MainCategory>().HasKey(p => p.Id);
            builder.Entity<MainCategory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MainCategory>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<MainCategory>().Property(p => p.IsActive).IsRequired();
            builder.Entity<MainCategory>().HasMany(p => p.SubCategory1List).WithOne(p => p.MainCategory).HasForeignKey(p => p.MainCategoryId);

            builder.Entity<MainCategory>().HasData
            (
                new MainCategory { Id = 1, Name = "Mikrodenetleyiciler", IsActive = true },
                new MainCategory { Id = 2, Name = "Entegreler", IsActive = true },
                new MainCategory { Id = 3, Name = "Yarı İletkenler", IsActive = true },
                new MainCategory { Id = 4, Name = "Arduino", IsActive = true },
                new MainCategory { Id = 5, Name = "Raspberry Pi", IsActive = true },
                new MainCategory { Id = 6, Name = "Geliştirme Kartları", IsActive = true },
                new MainCategory { Id = 7, Name = "Lcd ve Display", IsActive = true },
                new MainCategory { Id = 8, Name = "Sensör ve Modüller", IsActive = true },
                new MainCategory { Id = 9, Name = "Kablosuz Haberleşme", IsActive = true },
                new MainCategory { Id = 10, Name = "3D Printer ve CNC", IsActive = true }


            );


            builder.Entity<SubCategory1>().ToTable("SubCategories1");
            builder.Entity<SubCategory1>().HasKey(p => p.Id);
            builder.Entity<SubCategory1>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SubCategory1>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<SubCategory1>().Property(p => p.IsActive).IsRequired();
            builder.Entity<SubCategory1>().Property(p => p.MainCategoryId).IsRequired();
            builder.Entity<SubCategory1>().HasMany(p => p.SubCategory2List).WithOne(p => p.SubCategory1).HasForeignKey(p => p.SubCategory1Id);

            builder.Entity<SubCategory1>().HasData
            (

                new SubCategory1 { Id = 1, Name = "Orijinal Arduino", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 2, Name = "Arduino Ana Board", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 3, Name = "Arduino Eğitim Setleri", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 4, Name = "Arduino Shield", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 5, Name = "Arduino Sensör ve Modüller", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 6, Name = "Arduino Röle Kartları", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 7, Name = "Arduino Gsm ve Gps", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 8, Name = "Arduino Kitap", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 9, Name = "Arduino Aksesuarları", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 10, Name = "Arduino Lilypard", MainCategoryId = 4, IsActive = true },
                new SubCategory1 { Id = 11, Name = "Arduino Lcd Display", MainCategoryId = 4, IsActive = true }
            );


            builder.Entity<SubCategory2>().ToTable("SubCategories2");
            builder.Entity<SubCategory2>().HasKey(p => p.Id);
            builder.Entity<SubCategory2>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SubCategory2>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<SubCategory2>().Property(p => p.IsActive).IsRequired();
            builder.Entity<SubCategory2>().Property(p => p.SubCategory1Id).IsRequired();
            builder.Entity<SubCategory2>().HasData
            (

                new SubCategory2 { Id = 1, Name = "Arduino Modüller", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 2, Name = "Kablosuz Haberleşme", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 3, Name = "Su Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 4, Name = "Sıcaklık ve Nem Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 5, Name = "Gaz ve Basınç Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 6, Name = "Mesafe ve Hareket Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 7, Name = "Eğim / İvme /Gyro Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 8, Name = "Medikal Sensörler", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 9, Name = "Renk ve Işık Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 10, Name = "Akım ve Voltaj Sensörleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 11, Name = "Lazer ve Lazerli Sensörler", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 12, Name = "RTC - Gerçek Zamanlı Saat Modülleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 13, Name = "Ses ve Amfi Modülleri", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 14, Name = "Ph Sensörler", SubCategory1Id = 5, IsActive = true },
                new SubCategory2 { Id = 15, Name = "Arduino Sensör Ve Modüller (Tümü)", SubCategory1Id = 5, IsActive = true }
            );



            builder.Entity<Slider>().ToTable("Slider");
            builder.Entity<Slider>().HasKey(p => p.Id);
            builder.Entity<Slider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Slider>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Slider>().Property(p => p.IsActive).IsRequired();
            builder.Entity<Slider>().Property(p => p.ImagePath).IsRequired();
            builder.Entity<Slider>().HasData
            (
                new Slider { Id = 1, Name = "slider 1", ImagePath = "slider1.jpg", IsActive = true },
                new Slider { Id = 2, Name = "slider 2", ImagePath = "slider2.jpg", IsActive = true },
                new Slider { Id = 3, Name = "slider 3", ImagePath = "slider3.jpg", IsActive = true },
                new Slider { Id = 4, Name = "slider 4", ImagePath = "slider4.jpg", IsActive = true },
                new Slider { Id = 5, Name = "slider 5", ImagePath = "slider5.jpg", IsActive = true },
                new Slider { Id = 6, Name = "slider 6", ImagePath = "slider6.jpg", IsActive = true },
                new Slider { Id = 7, Name = "slider 7", ImagePath = "slider7.jpg", IsActive = true },
                new Slider { Id = 8, Name = "slider 8", ImagePath = "slider8.jpg", IsActive = true }
            );

            builder.Entity<Currency>().ToTable("Currency");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Currency>().Property(p => p.Value).IsRequired();
            builder.Entity<Currency>().HasData
            (
                new Currency { Id = 1, Name = "TL", Value = 1, IsActive = true },
                new Currency { Id = 2, Name = "USD", Value = 6.10, IsActive = true },
                new Currency { Id = 3, Name = "EURO", Value = 6.61, IsActive = true }
            );


            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Price).IsRequired();
            builder.Entity<Product>().Property(p => p.Title).IsRequired();
            builder.Entity<Product>().Property(p => p.Origin).IsRequired();
            builder.Entity<Product>().Property(p => p.Description).IsRequired();
            builder.Entity<Product>().Property(p => p.Property);
            builder.Entity<Product>().Property(p => p.CategoryId).IsRequired();
            builder.Entity<Product>().Property(p => p.SubCategory1Id).IsRequired();
            builder.Entity<Product>().Property(p => p.SubCategory2Id).IsRequired();
            builder.Entity<Product>().Property(p => p.StockCode).IsRequired();
            builder.Entity<Product>().Property(p => p.IsShowcaseProduct).IsRequired();
            builder.Entity<Product>().Property(p => p.Image).IsRequired();
            builder.Entity<Product>().HasData
            (

                // vitrin ürünleri .......

                new Product { Id = 1, Name = "Klon Arduino Uno R3 SMD", Price = 17.11, Title = "Arduino Uno R3 SMD CH340 Chip - Klon (USB Kablo Dahil)", Origin = "China", StockCode = "DSTK0703", Description = "Arduino'nun alışageldiğimiz standart boardlarından olan Arduino Uno R3 SMD CH340 Chip'in bu klonundaki temel farklılığı kullandığı programlama entegresinin (USB-Serial dönüştürücü) CH340 olması. Orjinal Arduino'dan birkaç küçük farkı olmasına rağmen kullanımı, yazılımı ve genişletme kartlarının uyumluluğu bakımından hiçbir fark bulunmamaktadır. Bu üründe ve daha birçok elektronik üründe daha da popüler olarak kullanılmaya başlanan CH340 USB - Serial dönüştürücü için, Windows 7 ve Mac OS X kullanıyorsanız driver yüklemeniz gerekmektedir.Windows 7 ve Mac OS X için gereken bu sürücüyü aşağıdaki doküman kısmında bulabilirsiniz.Linux, Windows 8 ve üstü için herhangi bir driver gerekli değildir.Arduino Uno R3 CH340 SMD ile Arduino Uno Dip arasındaki fark mikrodenetleyinin SMD veya DIP olarak ayrılmasının yanı sıra DIP türünün değiştirilebilir olmasıdır.", IsShowcaseProduct = true, CategoryId = 4, SubCategory1Id = 10, Image = "img1.jpg", IsActive = true },
                new Product { Id = 2, Name = "Raspberry Pi", Price = 448.56, Title = "Raspberry Pi 4 4GB - Model B", Origin = "Raspberry Pi", StockCode = "14655", Description = "Raspberry Pi 4 28nm tabanlı 1.5G Dört Çekirdekli CPU ve 4Gb DRR4 RAM içeren küçük bir DIY bilgisayardır. PC benzeri yetenekler elde etmek için Raspberry Pi 4, 4K Mikro HDMI, USB 3.0, BLE Bluetooth 5.0, çift-bantlı 2.4/5.0 GHz Wireless LAN, USB-C güç girişi ve PoE ile uyumlu True Gigabit Ethernet'e sahiptir.Raspberry Pi 4'ün ana yönü daha iyi performanstır; daha iyi VideoCoreVI Graphics ile 1,5 GHz Dört Çekirdekli ARM Cortex-A72 CPU'ya sahiptir. Pi 4, bir 4K 60fps HEVC videosunu bir Micro-HDMI portu üzerinden görüntüleyebilir ve aynı anda iki adet 4K ekrana ancak 30fps yenileme hızıyla bağlanabilir. 1000Mbps True Gigabit Ethernet ve dört USB portu vardır, ancak ikisi USB 2.0 aktarma hızının on katı olan USB 3.0 portlarıdır. Ek olarak, Raspberry Pi 4 yeni bir 5V / 3A güç kaynağı kullanıyor ve daha iyi bir dayanıklılığa sahip olan ve her iki tarafta da çalışabilen bir USB Tip C portu üzerinden bağlanıyor.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 2, Image = "img2.jpg", IsActive = true },
                new Product { Id = 3, Name = "Esp8266", Price = 10.59, Title = "Esp8266 Seri Wifi Modül", Origin = "Espressif", StockCode = " DSTK2404", Description = "ESP8266, yeni bağlantılı dünya ihtiyaçları için tasarlanmış oldukça entegre bir çiptir. Uygulamayı barındırabilmesine veya tüm Wi-Fi ağ işlevlerini başka bir uygulama işlemcisinden yönlendirebilmesine olanak tanıyan eksiksiz ve kendine yeten bir Wi-Fi ağ çözümü sunar.ESP8266,çalıştırma süresince minimal ön yükleme ve minimal yükleme ile GPIO'ları aracılığıyla sensörler ve diğer uygulama özellikli cihazlarla entegre olmasını sağlayan güçlü dahili işleme ve depolama yeteneklerine sahiptir. Yüksek derecede on-chip entegrasyonu minimal dış devreye imkan tanır ve ön uç modülü de dahil olmak üzere tüm çözüm minimum PCB alanını alacak şekilde tasarlanmıştır.", IsShowcaseProduct = true, CategoryId = 9, SubCategory1Id = 1, Image = "img3.jpg", IsActive = true },
                new Product { Id = 4, Name = "Breadboard", Price = 4.98, Title = "Tekli Breadboard", Origin = "China", StockCode = " DSTK3861", Description = "Tekli Breadboard, Devre kurmak için en pratik parçalardan olan breadboard ile kolayca prototipleme ve deney yapmak için uygundur. Atlama(jumper) kablolarıyla uyumluluk sağlamaktadır.", IsShowcaseProduct = true, CategoryId = 16, SubCategory1Id = 2, Image = "img4.jpg", IsActive = true },
                new Product { Id = 5, Name = "LattePanda", Price = 1009.00, Title = "LattePanda Windows 10 Lisanssız 4G/64GB", Origin = "LattePanda", StockCode = " DFR0419", Description = "LattePanda 4G/64GB,  Windows 10  işletim sistemi kullanan bir mini bilgisayar ve geliştirme kartıdır. Arduino kartları ile uyumludur. Türkiye'de en uygun fiyatlarla Direnc.net'te bulabileceğiniz mini bilgisayarda dahili 4GB Ram ve 64GB Harddisk vardır.", IsShowcaseProduct = true, CategoryId = 6, SubCategory1Id = 1, Image = "img5.jpg", IsActive = true },
                new Product { Id = 6, Name = "Anycubic 4MAX Pro", Price = 3843.00, Title = "Anycubic 4MAX Pro 3D Printer / 3D Yazıcı - Monteli - Beyaz Renk", Origin = "Anycubic", StockCode = "11152", Description = "Anycubic 4Max Pro tamamen kapalı kasalı, FDM Fused Deposition Modeling yani eriyik yığma modelleme teknolojisine sahip kullanıcı dostu, ısıtma tablalı bir 3D yazıcıdır. 270mm x 205mm x 205 geniş çalışma alanına sahip bu 3 boyutlu yazıcı kullanıcılara otomatik devam özelliği sunmaktadır. Bu sayede güç kesilmesi gibi nedenlerle yarım kalan baskıyı, kaldığı yerden devam ettirebilirsiniz.Otomatik kapanma fonksiyonu ile baskı bittiğinde ürünün otomatik kapanmasını sağlayabilirsiniz.Ayrıca filament sensörü filament bittiğinde yada kırıldığında sizi uyarmaktadır.Anycubic 4Max Pro, ayrı bir kuruluma gerek duymayan,tak çalıştır özellikte,yüksek performanslı bir 3 boyutlu yazıcıdır.", IsShowcaseProduct = true, CategoryId = 10, SubCategory1Id = 1, Image = "img6.jpg", IsActive = true },
                new Product { Id = 7, Name = "Monitör", Price = 1375.00, Title = "15.6 inç Evrensel Taşınabilir Dokunmatik Full HD, IPS, HDMI LCD", Origin = "WaveShare", StockCode = " 16549", Description = "Tip C ve HDMI bağlantısı, 1920 × 1080 piksel, sertleştirilmiş cam kapasitif dokunmatik panel ve güçlü 10000mAh pil içeren evrensel bir taşınabilir dokunmatik monitördür.Raspberry Pi için mükemmel uyumludur ayrıca Jetson Nano gibi diğer popüler mini PC'leri de destekler. Masaüstü bilgisayar, dizüstü bilgisayar, cep telefonu veya oyun konsolu gibi ana cihazlarla basit bir monitör olarak çalışır. C Tipi veya HDMI bağlantısıyla bir saniyede HD büyük ekrana geçebilirsiniz.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 4, Image = "img7.jpg", IsActive = true },
                new Product { Id = 8, Name = "Lcd Ekran", Price = 124.37, Title = "2.8 Inch Nextion HMI Dokunmatik TFT Lcd Ekran - 4MB Dahili Hafıza", Origin = "Nextion", StockCode = " NX3224T028", Description = "Nextion, insan ve proses, makina, uygulama ya da cihaz arasında kontrol ve görselleştirme arabirimi olarak görev yapan bir Seamless Human Machine Interface (HMI) çözümüdür. Geleneksel LCD ve LED Nixie tübünün yerini almak için tasarlanmış en iyi çözümdür.", IsShowcaseProduct = true, CategoryId = 7, SubCategory1Id = 1, Image = "img8.jpg", IsActive = true },
                new Product { Id = 9, Name = "ATMEGA128A-AU", Price = 14.06, Title = "ATMEGA128A-AU SMD TQFP-64 8-Bit 16 MHz Mikrodenetleyici", Origin = "Atmel", StockCode = " DSTK3408", Description = "Atmel ATMEGA128A AU TQFP-64 8 bit 16 MHz Mikrodenetleyici ürünü TQFP-64 kılıfta olup 16 MHz frekansı ile çalışan 8 bit değerinde Mikrodenetleyici Çeşitlerindendir. Üzerinde bulunan 64 pinin 53 adedi I/O yani Giriş Çıkış pinidir.Bellek tipi FLASH olan bu mikrodenetleyiciler 5.5V ile 2.7V besleme aralığında,-40 C° ile + 85 C° sıcaklıkları aralığında çalışmaktadır.", IsShowcaseProduct = true, CategoryId = 1, SubCategory1Id = 2, Image = "img9.jpg", IsActive = true },
                new Product { Id = 10, Name = "RS232", Price = 90.63, Title = "RS232 Bluetooth Seri Adaptör", Origin = "China", StockCode = " DSTK2359", Description = "Bu ürün, bluetooth iletişim protokolü içinde gömülüdür, sürücüyü yüklemenize gerek yoktur, Windows sistemlerinde kullanılabilir, dos, linux ve diğer grafiksel olmayan işletim sistemlerini de kullanabilirsiniz.Bluetooth adaptörü, masaüstü bilgisayarları,avuçiçi bluetooth pda ve bluetooth gps cihazı ile donatılmış bluetooth özellikli bir dizüstü bilgisayar ile bluetooth seri port profillerini(spp) destekler.Bluetooth spp servis bağlantılarını ve iletişimi desteklerReset tuşu ile kaydedilen eşleştirilmiş cihaz bilgilerini kaldırabilir ve yeni Bluetooth ile eşleştirebilirsiniz.Blue chip bluetooth 2.1 standardını kabul eder.Geliştirilmiş ber hata oranı performansı ve otomatik frekans atlamalı teknoloji etkin ve güvenli iletişim sağlayabilir ve iletişimin kararlılığını ve güvenilirliğini sağlamak için daha güçlü bir anti - karışma kabiliyetine sahiptir.Kullanıcı, 1200bps nm toplam 12 farklı baud hızından(varsayılan 9600, n, 8, 1) at komutu kullanarak ayarlayabilir,ayrıca cihaz için daha kişiselleştirilmiş Bluetooth adı ayarlayabilir.Transmitted güç bluetooth class2 standart, dahili yüksek hassasiyetli PCB basılı anten, istikrarlı iletişim mesafesi 15m kadar uyumlu olabilir ile uyumludur", IsShowcaseProduct = true, CategoryId = 9, SubCategory1Id = 3, Image = "img10.jpg", IsActive = true },
                new Product { Id = 11, Name = "mBot V1.1", Price = 529.28, Title = "mBot V1.1 - Blue - Bluetooth Versiyonu STEM Eğitim Robotu", Origin = "MakeBlock", StockCode = "90053", Description = "mBot Blue Bluetooth Versiyonu Eğitim Robotu IR Uzaktan Kumanda Hediyeli olarak gelmektedir. mBot'un varsayılan programı optimize edilmiştir. mBot'un çalışma durumu yerleşik düğme ile kontrol edilebilir.", IsShowcaseProduct = true, CategoryId = 18, SubCategory1Id = 1, Image = "img11.jpg", IsActive = true },
                new Product { Id = 12, Name = "YH862D", Price = 406.25, Title = "YH862D Dijital İstasyonlu Havya", Origin = "TT-Technich", StockCode = "DSTK1985", Description = "YH 862D Dijital Ayarlı Havya İstasyonu, SMD cihazları tamir eden tamircilerin en çok tercih ettiği havya seti.", IsShowcaseProduct = true, CategoryId = 27, SubCategory1Id = 3, Image = "img12.jpg", IsActive = true },
                new Product { Id = 13, Name = "BBC Micro", Price = 130.00, Title = "BBC Micro:Bit Geliştirme Kartı", Origin = "micro:bit", StockCode = " 9673", Description = "BBC micro:bit, 32 bit ARM Cortex-M0 işlemciyi temel alarak, ivmeölçer ve pusula sensörlerine, Bluetooth Düşük Enerji ve USB bağlantısına, 25 LED'li ekrandan ve iki programlanabilir tuştan oluşur ve USB ya da harici bir pil takımı ile çalıştırılabilir.Cihaz giriş ve çıkışları,21 pinli kenar konnektörünün parçası olan beş halkalı konektör içinden geçmektedir.", IsShowcaseProduct = true, CategoryId = 6, SubCategory1Id = 6, Image = "img13.jpg", IsActive = true },
                new Product { Id = 14, Name = "Arduino ve Raspberry Pi Uyumlu", Price = 18.44, Title = "SSR-25DA (25A) Solid State Röle (Geliştirme Kartlarıyla Uyumlu)", Origin = "Fotek", StockCode = "DSTK4227", Description = "SSR-25DA Solid State Röle 25 A değerine kadar kontrol sağlayabilir. Giriş yani tetikleme DC gerilim olmalıdır. Çıkış yani yük AC gerilim olmalıdır. Solid State Rölerin en büyük avantajlarından biri normal röleler gibi mekanik kontaklara sahip olmamasıdır. Bunun yerine Triac kullanır. Ayrıca, optik yalıtımlı ekstra güvenlik sunar.", IsShowcaseProduct = true, CategoryId = 15, SubCategory1Id = 8, Image = "img14.jpg", IsActive = true },
                new Product { Id = 15, Name = "Arduino LED", Price = 4.06, Title = "Arduino LED Trafik Lambası Modülü", Origin = "China", StockCode = "14114", Description = "Bu bir mini trafik lambası modülüdür. Yüksek parlaklık ve kompakt tasarımı ile trafik lamba sistemi için uygun bir Arduino modülüdür. 3 adet pini ve bir ground pini bulunmaktadır. Her ışığın pinine 5V vererek ledleri sıra ile yakabilirsiniz.", IsShowcaseProduct = true, CategoryId = 4, SubCategory1Id = 5, SubCategory2Id = 1, Image = "img15.png", IsActive = true },
                new Product { Id = 16, Name = "55V, 5.3mohm", Price = 4.98, Title = "IRF1405 N Kanal Power Mosfet TO-220", Origin = "IR / FAIRCHILD", StockCode = "DSTK4773", Description = "IRF1405, N Kanal Mosfet Çeşitlerinden olup TO-220 kılıftadır. IRF1405, N Kanal Power Mosfet türündedir. IRF1405 55Vluk bir Gate-Source gerilimine sahip olup 169A sürekli çıkış akımına sahiptir.", IsShowcaseProduct = true, CategoryId = 3, SubCategory1Id = 2, Image = "img16.jpg", IsActive = true },
                new Product { Id = 17, Name = "RFID", Price = 12.50, Title = "Rc522 RFID Okuyucu 13.56 Mhz", Origin = "China", StockCode = "DSTK2449", Description = "RC522 RFID Okuyucu Kartı, NFC frekansı olan 13,56 MHz frekansında çalışan tagler üzerinde okuma ve yazma işlemeni yapabilen, düşük güç tüketimli, ufak boyutlu bir karttır.Arduino başta olmak üzere bir çok mikrodenetleyeci platformu ile beraber rahatlıkla kullanılabilir. 424 kbit / s haberleşme hızına sahiptir.RFID üzerinde farklı şifreleme türlerini desteklemektedir.Desteklediği kart türleri mifare1 S50,mifare1 S70 mifare ultralight,mifare pro ve  mifare desfire'dir. Not: 125 KHz frekansında çalışan RFID kartlarını desteklememektedir.Yalnızca 13,56 MHz frekansında çalışan kartları desteklemektedir.NFC modülleri bu frekansta çalıştığı için NFC kartları ile beraber kullanılabilir.", IsShowcaseProduct = true, CategoryId = 1, SubCategory1Id = 5, Image = "img17.jpg", IsActive = true },
                new Product { Id = 18, Name = "Konnektör", Price = 12.15, Title = "3-Pin Su Geçirmez Mike Konnektör GX-16", Origin = "China", StockCode = "15633", Description = "Su Geçirmez Mike Konnektör GX-16 3 pinlidir. Veri sistemleri, bilgisayar, otomasyon, ölçüm-kontrol sistemleri, mekanik ekipmanlarda, ses/video, iletişim, otomotiv ve daha birçok sektörlerde kullanılan Mike Konnektörler, su geçirmez şekilde tasarlanmıştır.", IsShowcaseProduct = true, CategoryId = 23, SubCategory1Id = 5, Image = "img18.png", IsActive = true },
                new Product { Id = 19, Name = "RAK2245 Pi", Price = 1074.00, Title = "RAK2245 Pi HAT Sürümü 868 Mhz", Origin = "China", StockCode = "15878", Description = "RAK2245 Pi HAT Sürümü RAK2245 ailesinin en büyüğüdür ancak Raspberry Pi 40pin başlığı ile tam uyumluluk sunar. Ürünün frekans değeri 868 Mhz'dir. Böylece Raspberry Pi'yi özünde kullanan bir DIY ağ geçidi için mükemmel bir çözümdür. Bu, düşük maliyetli ve istikrarlı bir performansla LoRaWAN çözümünün hızlı bir şekilde kullanılmasını sağlar.RAK2245 hattındaki diğer modüllerde olduğu gibi, Semtech 1301 ve çift SX1257 / 58 ön uç yongalarına dayanıyor.Bu ürünün son nesli(RAK831) üzerinde bir takım iyileştirmeler içeren tam teşekküllü bir 8 kanallı LoRa Konsantratörüdür.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 2, Image = "img19.jpg", IsActive = true },
                new Product { Id = 20, Name = "Arduino Shield", Price = 88.22, Title = "Neo-7m Arduino Shield Mini Gps Modülü", Origin = "China", StockCode = "15638", Description = "Neo-7m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir. ", IsShowcaseProduct = true, CategoryId = 4, SubCategory1Id = 4, Image = "img20.jpg", IsActive = true },


                // Arduino Shield Ürünleri .......
                new Product { Id = 21, Name = "Arduino Shield", Price = 14.33, Title = "Arduino Lcd Shield", Origin = "China", StockCode = "DSTK2124", Description = "LCD Shield en çok kullanılan Arduino shield çeşitlerindendir. Kart üzerinde 2x16 LCD ekran, 5 adet programlanabilir buton ve bir adet reset butonu vardır. Arduino ile ekranı açıp kapatabilir ve arka ışığı kontrol edebilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img21.jpg", IsActive = true },
                new Product { Id = 22, Name = "Motor Shield", Price = 11.84, Title = "Arduino Motor Shield - L293D", Origin = "China", StockCode = "DSTK2135", Description = "Motor Shield en çok kullanılan Arduino shield çeşitlerindendir. Kart ile 4 adet DC motor, 2 adet step motor veya 2 adet servo motor kontrol edebilirsiniz. 4.5-36V arası motorlar için kullanılabilir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img22.jpg", IsActive = true },
                new Product { Id = 23, Name = "Sensör Shield", Price = 9.03, Title = "Arduino Uno Sensör Shield V4.0", Origin = "China", StockCode = "DSTK2143", Description = "Arduino Uno Sensör Shield, Arduino kartları ile birlikte kullanabileceğiniz, kart üzerine birçok giriş çıkışa sahip kullanışlı bir modüldür. Arduino UNO R3 modeli için tasarlanmış olup benzer pin yapısına sahip olan Leonardo veya farklı kartlarla birlikte kullanılabilir.Arduino'nun tüm giriş çıkış pinleri DATA, VCC ve GND sırası ile 3 pin halindedir.Ürüne UART,I2C portları kart üzerinde ayrı olarak yer verilmiştir. Communication Port konektörüyle I2C veya UART olarak ayarlanabilir.Arduino Uno Sensör Shield, Arduino Uno, Leonardo ve Mega modelleriyle kullanılabilir.Ancak bu modellerdeki I2C ve SPI portu farklı pinler üzerinde olduğu için sadece bu portlar kullanılamaz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img23.jpg", IsActive = true },
                new Product { Id = 24, Name = "Ethernet Shield", Price = 34.27, Title = "Arduino Ethernet Shield", Origin = "China", StockCode = "DSTK2084", Description = "Arduino Ethernet Shield Arduino ile internete bağlanmanıza olanak sağlar.Sunucu veya istemci olarak kullanılabilir. Lehimlemeye gerek duymadan kolaylıkla Arduino'ya bağlayabilirsiniz. Arduino ethernet kütüphanesi ile uyumludur. SD kart takıp karttaki bilgilere internet üzerinden ulaşabilirsiniz. Arduino Uno ile tam uyumludur. Benzer pin yapısına sahip diğer Arduino modelleri ile de kullanılabilir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img24.jpg", IsActive = true },
                new Product { Id = 25, Name = "Nano Sensör", Price = 13.71, Title = "Arduino Nano Sensör Shield", Origin = "China", StockCode = "9763", Description = "Sensör Shield Arduino Nano için özel olarak tasarlanmış olup benzer pin yapısına sahip diğer Arduino'larla da kullanılabilir. Nano ve geliştirme kartlarını yeni kullanmaya başlayanlar için ideal bir Shield kartıdır. Lehimlemeye gerek duymadan kolayca bağlantı yapabilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img25.jpg", IsActive = true },
                new Product { Id = 26, Name = "Mega Sensör", Price = 21.18, Title = "Arduino Mega Sensör Shield", Origin = "China", StockCode = "9762", Description = "Arduino Mega Sensör Shield Kartı ürünü Arduino Mega için tasarlanmıştır. Ancak benzer pin yapısına sahip DUE veya diğer kartlar ile kullanılabilir. Shield kartları projelerinizi geliştirirken yaşadığınız I/O eksikliği sorununu çözmek için üretilmiştir. Bu ürün ile sensör servo, röle vb. elemanları kolayca devreye bağlayabilirsiniz. Arduino Mega Sensör Shield kartı ile kompleks devreleriniz daha toplu ve daha profesyonel görünecektir. Ayrıca siz de devre takibini daha kolay yapabilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img26.jpg", IsActive = true },
                new Product { Id = 27, Name = "Bluetooth Audio", Price = 22.12, Title = "VHM-314 Bluetooth Audio Alıcı - Kablosuz Stereo Müzik Modülü", Origin = "China", StockCode = "14105", Description = "VHM-314, Bluetooth 4.1 teknolojisine kullanan bir Audio modülüdür. Usb girişli, 3.7v lityum pil uyumlu led indikatörlü 3.5 mm stereo jak, kulaklık desteği amfi desteği sağlayan bu modül ile ses projelerinizi rahatlıkla gerçekleştirebilirsiniz.Güç verildiğinde mavi indikatör yanar ve bluetooth moduna girer ve eşleşme için bekler.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img27.jpg", IsActive = true },
                new Product { Id = 28, Name = "Touch Shield", Price = 37.38, Title = "Arduino Touch Shield - X", Origin = "China", StockCode = "DSTK2093", Description = "Arduino Touch Shield kartında kullanılan MPR121 entegresi(Proximity Kapasitif Dokunma Sensorü Denetleyici) kapasitif dokunma arayüzlerinin oluşturulmasında mükemmel bir seçenektir ve Touch Shield üzerinde kullanımıyla Arduino projelerinde HMI (human-machine interface) çözümleri için oldukça uygundur. Touch Shield 12 kapsitif touch 'pad'e sahiptir. Bu shield kartı ile toplamda 12 hassas dokunmatik butona sahip olursunuz.Touch Shield üzerindeki lojik seviye dönüştürücü (logic level converter), shield'ın hem 5V hem de 3.3V 'luk Arduino kartlarla çalışmasını sağlar.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img28.jpg", IsActive = true },
                new Product { Id = 29, Name = "Screw Shield", Price = 34.27, Title = "Arduino Screw Shield Genişleme Kartı", Origin = "China", StockCode = "DSTK2088", Description = "Klemensli Genişletme Kartı Arduino Uno ile tam uyumludur. Benzer pin yapısına sahip diğer Arduino'larla da kullanılabilir. Bağlantıları daha sağlam yapmak için kabloları lehimlemek yerine sökülüp takılabilir şekilde vidali klemans kullanabilmeniz için tasarlanan bu kartta çeşitli sensör ve motorları bağlayabilmeniz için ek terminaller bulunmaktadır.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img29.jpg", IsActive = true },
                new Product { Id = 30, Name = "Neo-6m", Price = 56.07, Title = "Neo-6m Arduino Shield Mini Gps Modülü", Origin = "China", StockCode = "15637", Description = "Neo-6m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img30.jpg", IsActive = true },
                new Product { Id = 31, Name = "Neo-7m", Price = 74.76, Title = "Neo-7m Arduino Shield Mini Gps Modülü", Origin = "China", StockCode = "15638", Description = "Neo-7m Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img31.jpg", IsActive = true },
                new Product { Id = 32, Name = "Neo-m8n", Price = 93.45, Title = "Neo-m8n Arduino Shield Mini Gps Modülü", Origin = "China", StockCode = "15639", Description = "Neo-m8n Mini Gps Modülü Arduino ile uyumlu çalışmaktadır. Bilindiği üzere GPS (Global Positioning System) bir Küresel Konumlama Sistemi'dir. Dünya üzerinde herhangi bir görüş hattında, 4 veya daha fazla uydusu ile her türlü hava koşullarında yer ve zaman bilgilerini sağlayan uzay tabanlı uydu navigasyon sistemidir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img32.jpg", IsActive = true },
                new Product { Id = 33, Name = "Esp-32", Price = 155.75, Title = "Esp-32 Audio Kit - Ses Geliştirme Kartı", Origin = "China", StockCode = "14104", Description = "ESP-32 Ses kiti ESP-32-A1S tabanlı küçük bir audio geliştirme kartıdır. TF kart girişi, kulaklık çıkışı, 2 mikrafon girişi ve 2 hoparlör çıkışı kartın üzerinde mevcuttur. Hızlı geliştirme için uygun olan bu kart akıllı IOT projelerinde, ev sistemlerinde, akıllı hoparlör çözümleri gibi projelerinde kullanılabilir. ", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img33.png", IsActive = true },
                new Product { Id = 34, Name = "ESP13", Price = 76.01, Title = "ESP13 Wifi Shield", Origin = "China", StockCode = "9764", Description = "ESP13 Wifi Shield Kartı ürünü ile Arduino'nuzu kolayca internete bağlayabilir ve web sunucusu oluşturabilirsiniz. Arduino Uno ve Arduino Mega modelleriyle uyumludur. Ürünün kullanımı hakkında daha detaylı bilgi için dökümanlar kısmındaki kullanma kılavuzunu okuyabilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img34.jpg", IsActive = true },
                new Product { Id = 35, Name = "SIM808 Arduino", Price = 235.24, Title = "SIM808 Arduino - Raspberry Pi GSM - GPS - GPRS Geliştirme Modülü (IMEI No Kayıtlıdır)", Origin = "Türkiye", StockCode = "DSTK0956", Description = "Bu GSM - GPS - GPRS Geliştirme Modülünü Arduino ve Raspberry Pi  ile kullanabilirsiniz.Türkiye’de yasal IMEI kaydı bulunan bu modül ile basit Telefon, SMS işlevli uygulamalardan,araç takibi,M2M uygulamaları ve aklınıza gelebilecek tüm GSM / GPS / GPRS işlemleri geliştirebilirsiniz.Üzerindeki 3 ayrı girişten,besleme yapılabilmektedir: DC044 girişinden 5 - 26V ile, 3.7 - 4.2V Lipo / Lion pil ile, Vin girişinden 5 - 26V ile besleme yapılabilmektedir.Yapılacak beslemenin 2A güce sahip olmasına dikkat ediniz.Modül SIM808,AT komutları kullanılarak programlanır.Power düğmesi modülün gücünü açıp kapatır.Power ON durumuna getirilince Power Led yanar.Ayrıca modülü başlatmak için modülün yan tarafındaki butona 2 saniye kadar basılarak aktif hale getirilir ve diğer 3 LED yanar ve bu ledlerden birisi yanıp sönmeye başlar bu da SIM808 çalışmaya başladığı anlamına gelir.SIM yuvası Modülün altında yer almaktadır.GSM, GPS antenleri ve SIM kartı düzgün takıldığı taktirde LED 3 saniyede bir yanıp sönecektir.Bu da Modülün şebekeye bağlandığının işaretidir.Böylece bir çağrı yaptırabilir veya diğer işlemler yaptırabilirsiniz.Titreşim motoru da bulunduran modül 5V ile çalışmakta olup modülün sağ üst köşesinde bulunan pim ile kontrol edilir.Üzerinde Bluetooth da bulunduran SIM808, AT komutları ile kontrol edilir.SIM8080 modülü Arduino ve Raspberry pi ile Rx - Tx ve GND pimleri kullanılarak haberleşme yapılır.Burada dikkat edilecek konu; işlemci sisteminiz 1.25V / 3.3V / 5V kullanıyor ise VMCU pimini bu sistemin 1.25V / 3.3V veya 5V beslemesine bağlamanız gerekir. Zira SIM808 modülü üzerindeki seviye çevirici VMCU ile Rx / Tx pimlerinin bu seviyede çalışmasını sağlar.USB soketi sadece Firmware güncellenmesi için kullanılmaktadır.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img35.jpg", IsActive = true },
                new Product { Id = 36, Name = "Mini GSM/GPRS", Price = 60.43, Title = "Mini GSM/GPRS Modülü - SIM800L (IMEI Kayıtlı Değildir)", Origin = "China", StockCode = "13664", Description = "Mini GSM Modülü Ardino gibi geliştirme kartlarıyla ya da özel projelerinizde kolaylıkla kullanabilmeniz için header çıkışlara sahiptir. Minimal boyutlarıyla bir çok projeye kolayca entegre edilebilir. Diğer modüllere göre daha ucuz olduğu için sıklıkla tercih edilir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img36.jpg", IsActive = true },
                new Product { Id = 37, Name = "Arduino GSM-GPS", Price = 654.15, Title = "Arduino GSM-GPS Shield / Genişletme Kartı (SIM800 - SIM28 - IMEI Kayıtlıdır)", Origin = "Türkiye", StockCode = "10433", Description = "GGS01 GSM/GPS Arduino genişletme kartı, üzerindeki Simcom SIM800 GSM, SIM28 GPS Modülü ve Push-Push Simkart yuvası ile birlikte GPRS&GSM şebekesine Arduino ile birlikte bağlatı kurmanızı sağlar.Ürün IMEI numarası Türkiye’de kayıtlı olup, takacağınız SIM kartınız ile internete bağlanmaya,SMS atmaya & almaya,veri ve ses transferi yapmaya hazır bir Arduino genişletme kartıdır.GGS01 GSM / GPS Modül ile GSM uygulamaları ile birlikte konum bilgisi edinme,araç takip uygulamaları,insan - nesne - cihaz takip uygulamaları yapabilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img37.jpg", IsActive = true },
                new Product { Id = 38, Name = "Atmega32U4", Price = 90.34, Title = "Arduino Atmega32U4 Mini Kontrol Modülü", Origin = "China", StockCode = "12694", Description = "Mini Konrol Modülüanalog ve dijital çıkışıyla ultrasonik sensör ve servo motor kontrol edebileceğiniz bir shield kartıdır. Ayrıca I2C girişine LED barı bağlayarak güç girişini izleyebilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img38.jpg", IsActive = true },
                new Product { Id = 39, Name = "SIM900 GSM/GPRS", Price = 161.98, Title = "SIM900 GSM/GPRS Geliştirme Modülü - Arduino(IMEI Kayıtlı Değildir", Origin = "China", StockCode = "13665", Description = "GPRS Shiled Simcom'un SIM900 modülünü kullanır. GSM cep telefonu ağını kullanarak iletişim kurmanın pratik bir yoludur. Shield, AT komutları (GSM 07.05, 07.07 ve SIMCOM AT komutları) göndererek UART üzerinden SMS, MMS, GPRS ve ses elde etmenizi sağlar. Kart ayrıca 12 GPIO, 2 PWM, SIM900 modülü ve bir ADC(2V8 logic)'ye sahiptir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img39.jpg", IsActive = true },
                new Product { Id = 40, Name = "Müzik Shield", Price = 61.37, Title = "Arduino Müzik Shield / MP3 Modülü (VS1053B)", Origin = "China", StockCode = "DSTK7030", Description = "Bu Arduino Müzik Shield / MP3 Modülü, üzerinde bulunan VS1053B entegresi sayesinde çeşitli müzik formatlarını oynatabilir. Ogg Vorbis/MP3/AAC/WMA/MID formatlarını destekleyen bu entegre SD kartınızda bulunan tüm müzikleri çalabilir. Üzerinde bulunan mikrofondan yada ses giriş kanalından bağlanıp kayıt alabilirsiniz.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 4, Image = "img40.jpg", IsActive = true }


                );

            builder.Entity<Comment>().ToTable("Comment");
            builder.Entity<Comment>().HasKey(p => p.Id);
            builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(p => p.ProductId).IsRequired().HasMaxLength(50);
            builder.Entity<Comment>().Property(p => p.Star).IsRequired();
            builder.Entity<Comment>().Property(p => p.YesCount).IsRequired();
            builder.Entity<Comment>().Property(p => p.NoCount).IsRequired();
            builder.Entity<Comment>().Property(p => p.Description).IsRequired();
            builder.Entity<Comment>().Property(p => p.Title);
            builder.Entity<Comment>().HasData
            (

                //vitrin ürünlerinin yorumları
                new Comment { Id = 1, ProductId = 1, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 2, ProductId = 1, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün çok güzel tavsiye ederim", Title = " Kalite" },
                new Comment { Id = 3, ProductId = 1, Star = 4, YesCount = 5, NoCount = 2, Description = "Çok beğendim satıcı ilgili ve hızlı geldi eksiksiz geldi yorumlara bakarak aldım ve pişman olmadım. Yorum yaparak insanlara yardımcı olmak lazım ", Title = "Ürün" },
                new Comment { Id = 4, ProductId = 2, Star = 5, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 5, ProductId = 2, Star = 3, YesCount = 4, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 6, ProductId = 3, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 7, ProductId = 3, Star = 4, YesCount = 4, NoCount = 2, Description = "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", Title = " Hizmet" },
                new Comment { Id = 8, ProductId = 3, Star = 3, YesCount = 1, NoCount = 6, Description = "Ürün çok kötü paketlenmiş kutusu ezik geldi", Title = "Kargo" },
                new Comment { Id = 9, ProductId = 4, Star = 4, YesCount = 8, NoCount = 3, Description = "Ürün için biraz çekincelerim vardı ama ürün gayet güzel!!", Title = "Kalite" },
                new Comment { Id = 10, ProductId = 4, Star = 4, YesCount = 8, NoCount = 3, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 11, ProductId = 4, Star = 4, YesCount = 2, NoCount = 10, Description = "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", Title = "Ürün" },
                new Comment { Id = 12, ProductId = 6, Star = 5, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 13, ProductId = 6, Star = 3, YesCount = 4, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 14, ProductId = 8, Star = 4, YesCount = 4, NoCount = 2, Description = "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", Title = " Hizmet" },
                new Comment { Id = 15, ProductId = 3, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 16, ProductId = 8, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 17, ProductId = 10, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 18, ProductId = 10, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün çok güzel tavsiye ederim", Title = " Kalite" },
                new Comment { Id = 19, ProductId = 10, Star = 2, YesCount = 5, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 20, ProductId = 13, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 21, ProductId = 13, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 22, ProductId = 13, Star = 5, YesCount = 1, NoCount = 10, Description = "ürün çok kötü sakın almayın ", Title = " Kalite" },
                new Comment { Id = 23, ProductId = 16, Star = 2, YesCount = 2, NoCount = 10, Description = "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", Title = "Ürün" },
                new Comment { Id = 24, ProductId = 16, Star = 3, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 25, ProductId = 18, Star = 5, YesCount = 12, NoCount = 4, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 26, ProductId = 18, Star = 5, YesCount = 2, NoCount = 5, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 27, ProductId = 18, Star = 5, YesCount = 8, NoCount = 3, Description = "ürün çok kötü sakın almayın  ", Title = "Hizmet " },



                //ardunio shield ürünlerinin yorumları

                new Comment { Id = 28, ProductId = 21, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 29, ProductId = 21, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün çok güzel tavsiye ederim", Title = " Kalite" },
                new Comment { Id = 30, ProductId = 21, Star = 4, YesCount = 5, NoCount = 2, Description = "Çok beğendim satıcı ilgili ve hızlı geldi eksiksiz geldi yorumlara bakarak aldım ve pişman olmadım. Yorum yaparak insanlara yardımcı olmak lazım ", Title = "Ürün" },
                new Comment { Id = 31, ProductId = 22, Star = 5, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 32, ProductId = 22, Star = 3, YesCount = 4, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 33, ProductId = 23, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 34, ProductId = 23, Star = 4, YesCount = 4, NoCount = 2, Description = "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", Title = " Hizmet" },
                new Comment { Id = 35, ProductId = 23, Star = 3, YesCount = 1, NoCount = 6, Description = "Ürün çok kötü paketlenmiş kutusu ezik geldi", Title = "Kargo" },
                new Comment { Id = 36, ProductId = 24, Star = 4, YesCount = 8, NoCount = 3, Description = "Ürün için biraz çekincelerim vardı ama ürün gayet güzel!!", Title = "Kalite" },
                new Comment { Id = 37, ProductId = 24, Star = 4, YesCount = 8, NoCount = 3, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 38, ProductId = 24, Star = 4, YesCount = 2, NoCount = 10, Description = "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", Title = "Ürün" },
                new Comment { Id = 39, ProductId = 26, Star = 5, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 40, ProductId = 26, Star = 3, YesCount = 4, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 41, ProductId = 28, Star = 4, YesCount = 4, NoCount = 2, Description = "Ürüne olumsuz yorum yapanlar tekrar baksın ürün gayet sıkıntısı ve hızlı geldi teşekkürler", Title = " Hizmet" },
                new Comment { Id = 42, ProductId = 28, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 43, ProductId = 30, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 44, ProductId = 30, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 45, ProductId = 32, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün çok güzel tavsiye ederim", Title = " Kalite" },
                new Comment { Id = 46, ProductId = 32, Star = 2, YesCount = 5, NoCount = 1, Description = "fiyatina gore iyi bir cihaz. tavsiye ederim", Title = "Kalite " },
                new Comment { Id = 47, ProductId = 32, Star = 5, YesCount = 8, NoCount = 3, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 48, ProductId = 36, Star = 5, YesCount = 3, NoCount = 2, Description = "Çok hızlı ve güvenilir sipariş teşekkürler direnc.net", Title = "KODLAMA" },
                new Comment { Id = 49, ProductId = 36, Star = 5, YesCount = 1, NoCount = 10, Description = "ürün çok kötü sakın almayın ", Title = " Kalite" },
                new Comment { Id = 50, ProductId = 36, Star = 2, YesCount = 2, NoCount = 10, Description = "Ürün fotoğraftaki gibi gelmedi almanızı tavsiye etmem ", Title = "Ürün" },
                new Comment { Id = 51, ProductId = 38, Star = 3, YesCount = 8, NoCount = 3, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 52, ProductId = 38, Star = 5, YesCount = 12, NoCount = 4, Description = "Ürün gayet güzel mağazanın hizmeti mükemmel anında hızlı Kargo yapıldı bir gün sonra ürün elime ulaştı paketi de gayet özenliydi teşekkür ederim ", Title = " KAliteli Hızlı Hizmet" },
                new Comment { Id = 53, ProductId = 40, Star = 5, YesCount = 2, NoCount = 5, Description = "Cok tereddüt ederek sipariş verdim.Satıcı çok ilgili, ürünün aciliyetini bildirdim, 24 saat dolmadan,eksiksiz ve hızlı bir sekile ulaştı, ürün de gayet ideal, çok beğendim,tesekkürler.. ", Title = "Hizmet " },
                new Comment { Id = 54, ProductId = 40, Star = 1, YesCount = 1, NoCount = 8, Description = "ürün çok kötü sakın almayın", Title = "Hizmet " }
            );

        }
    }
}
