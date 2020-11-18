using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServiceProject.Models;
using WebServiceProject.Persistence;
using WebServiceProject.Repository;
using Xunit;

namespace TestProject.Repository
{
    public class ProductRepositoryTests
    {
        private AppDbContext _context;
        private ProductRepository _productRepository;
        private List<Product> list1; 

        public ProductRepositoryTests()
        {
            SetupMocks();
            _productRepository = new ProductRepository(_context);
        }
        private void SetupMocks()
        {
            list1 = new List<Product>();
            list1.Add(new Product { Id = 1, Name = "Klon Arduino Uno R3 SMD", Price = 17.11, Title = "Arduino Uno R3 SMD CH340 Chip - Klon (USB Kablo Dahil)", Origin = "China", StockCode = "DSTK0703", Description = "Arduino'nun alışageldiğimiz standart boardlarından olan Arduino Uno R3 SMD CH340 Chip'in bu klonundaki temel farklılığı kullandığı programlama entegresinin (USB-Serial dönüştürücü) CH340 olması. Orjinal Arduino'dan birkaç küçük farkı olmasına rağmen kullanımı, yazılımı ve genişletme kartlarının uyumluluğu bakımından hiçbir fark bulunmamaktadır. Bu üründe ve daha birçok elektronik üründe daha da popüler olarak kullanılmaya başlanan CH340 USB - Serial dönüştürücü için, Windows 7 ve Mac OS X kullanıyorsanız driver yüklemeniz gerekmektedir.Windows 7 ve Mac OS X için gereken bu sürücüyü aşağıdaki doküman kısmında bulabilirsiniz.Linux, Windows 8 ve üstü için herhangi bir driver gerekli değildir.Arduino Uno R3 CH340 SMD ile Arduino Uno Dip arasındaki fark mikrodenetleyinin SMD veya DIP olarak ayrılmasının yanı sıra DIP türünün değiştirilebilir olmasıdır.", IsShowcaseProduct = true, CategoryId = 4, SubCategory1Id = 10, Image = "img1.jpg", IsActive = true });
            list1.Add(new Product { Id = 2, Name = "Raspberry Pi", Price = 448.56, Title = "Raspberry Pi 4 4GB - Model B", Origin = "Raspberry Pi", StockCode = "14655", Description = "Raspberry Pi 4 28nm tabanlı 1.5G Dört Çekirdekli CPU ve 4Gb DRR4 RAM içeren küçük bir DIY bilgisayardır. PC benzeri yetenekler elde etmek için Raspberry Pi 4, 4K Mikro HDMI, USB 3.0, BLE Bluetooth 5.0, çift-bantlı 2.4/5.0 GHz Wireless LAN, USB-C güç girişi ve PoE ile uyumlu True Gigabit Ethernet'e sahiptir.Raspberry Pi 4'ün ana yönü daha iyi performanstır; daha iyi VideoCoreVI Graphics ile 1,5 GHz Dört Çekirdekli ARM Cortex-A72 CPU'ya sahiptir. Pi 4, bir 4K 60fps HEVC videosunu bir Micro-HDMI portu üzerinden görüntüleyebilir ve aynı anda iki adet 4K ekrana ancak 30fps yenileme hızıyla bağlanabilir. 1000Mbps True Gigabit Ethernet ve dört USB portu vardır, ancak ikisi USB 2.0 aktarma hızının on katı olan USB 3.0 portlarıdır. Ek olarak, Raspberry Pi 4 yeni bir 5V / 3A güç kaynağı kullanıyor ve daha iyi bir dayanıklılığa sahip olan ve her iki tarafta da çalışabilen bir USB Tip C portu üzerinden bağlanıyor.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 2, Image = "img2.jpg", IsActive = true });
            list1.Add(new Product { Id = 3, Name = "Esp8266", Price = 10.59, Title = "Esp8266 Seri Wifi Modül", Origin = "Espressif", StockCode = " DSTK2404", Description = "ESP8266, yeni bağlantılı dünya ihtiyaçları için tasarlanmış oldukça entegre bir çiptir. Uygulamayı barındırabilmesine veya tüm Wi-Fi ağ işlevlerini başka bir uygulama işlemcisinden yönlendirebilmesine olanak tanıyan eksiksiz ve kendine yeten bir Wi-Fi ağ çözümü sunar.ESP8266,çalıştırma süresince minimal ön yükleme ve minimal yükleme ile GPIO'ları aracılığıyla sensörler ve diğer uygulama özellikli cihazlarla entegre olmasını sağlayan güçlü dahili işleme ve depolama yeteneklerine sahiptir. Yüksek derecede on-chip entegrasyonu minimal dış devreye imkan tanır ve ön uç modülü de dahil olmak üzere tüm çözüm minimum PCB alanını alacak şekilde tasarlanmıştır.", IsShowcaseProduct = true, CategoryId = 9, SubCategory1Id = 1, Image = "img3.jpg", IsActive = true });
            list1.Add(new Product { Id = 4, Name = "Breadboard", Price = 4.98, Title = "Tekli Breadboard", Origin = "China", StockCode = " DSTK3861", Description = "Tekli Breadboard, Devre kurmak için en pratik parçalardan olan breadboard ile kolayca prototipleme ve deney yapmak için uygundur. Atlama(jumper) kablolarıyla uyumluluk sağlamaktadır.", IsShowcaseProduct = true, CategoryId = 16, SubCategory1Id = 2, Image = "img4.jpg", IsActive = true });
            list1.Add(new Product { Id = 5, Name = "RFID", Price = 12.50, Title = "Rc522 RFID Okuyucu 13.56 Mhz", Origin = "China", StockCode = "DSTK2449", Description = "RC522 RFID Okuyucu Kartı, NFC frekansı olan 13,56 MHz frekansında çalışan tagler üzerinde okuma ve yazma işlemeni yapabilen, düşük güç tüketimli, ufak boyutlu bir karttır.Arduino başta olmak üzere bir çok mikrodenetleyeci platformu ile beraber rahatlıkla kullanılabilir. 424 kbit / s haberleşme hızına sahiptir.RFID üzerinde farklı şifreleme türlerini desteklemektedir.Desteklediği kart türleri mifare1 S50,mifare1 S70 mifare ultralight,mifare pro ve  mifare desfire'dir. Not: 125 KHz frekansında çalışan RFID kartlarını desteklememektedir.Yalnızca 13,56 MHz frekansında çalışan kartları desteklemektedir.NFC modülleri bu frekansta çalıştığı için NFC kartları ile beraber kullanılabilir.", IsShowcaseProduct = true, CategoryId = 1, SubCategory1Id = 5, Image = "img17.jpg", IsActive = true });
            list1.Add(new Product { Id = 6, Name = "ATMEGA128A-AU", Price = 14.06, Title = "ATMEGA128A-AU SMD TQFP-64 8-Bit 16 MHz Mikrodenetleyici", Origin = "Atmel", StockCode = " DSTK3408", Description = "Atmel ATMEGA128A AU TQFP-64 8 bit 16 MHz Mikrodenetleyici ürünü TQFP-64 kılıfta olup 16 MHz frekansı ile çalışan 8 bit değerinde Mikrodenetleyici Çeşitlerindendir. Üzerinde bulunan 64 pinin 53 adedi I/O yani Giriş Çıkış pinidir.Bellek tipi FLASH olan bu mikrodenetleyiciler 5.5V ile 2.7V besleme aralığında,-40 C° ile + 85 C° sıcaklıkları aralığında çalışmaktadır.", IsShowcaseProduct = true, CategoryId = 1, SubCategory1Id = 2, Image = "img9.jpg", IsActive = true });
            list1.Add(new Product { Id = 7, Name = "Raspberry Pi", Price = 448.56, Title = "Raspberry Pi 4 4GB - Model B", Origin = "Raspberry Pi", StockCode = "14655", Description = "Raspberry Pi 4 28nm tabanlı 1.5G Dört Çekirdekli CPU ve 4Gb DRR4 RAM içeren küçük bir DIY bilgisayardır. PC benzeri yetenekler elde etmek için Raspberry Pi 4, 4K Mikro HDMI, USB 3.0, BLE Bluetooth 5.0, çift-bantlı 2.4/5.0 GHz Wireless LAN, USB-C güç girişi ve PoE ile uyumlu True Gigabit Ethernet'e sahiptir.Raspberry Pi 4'ün ana yönü daha iyi performanstır; daha iyi VideoCoreVI Graphics ile 1,5 GHz Dört Çekirdekli ARM Cortex-A72 CPU'ya sahiptir. Pi 4, bir 4K 60fps HEVC videosunu bir Micro-HDMI portu üzerinden görüntüleyebilir ve aynı anda iki adet 4K ekrana ancak 30fps yenileme hızıyla bağlanabilir. 1000Mbps True Gigabit Ethernet ve dört USB portu vardır, ancak ikisi USB 2.0 aktarma hızının on katı olan USB 3.0 portlarıdır. Ek olarak, Raspberry Pi 4 yeni bir 5V / 3A güç kaynağı kullanıyor ve daha iyi bir dayanıklılığa sahip olan ve her iki tarafta da çalışabilen bir USB Tip C portu üzerinden bağlanıyor.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 2, Image = "img2.jpg", IsActive = true });
            list1.Add(new Product { Id = 8, Name = "RAK2245 Pi", Price = 1074.00, Title = "RAK2245 Pi HAT Sürümü 868 Mhz", Origin = "China", StockCode = "15878", Description = "RAK2245 Pi HAT Sürümü RAK2245 ailesinin en büyüğüdür ancak Raspberry Pi 40pin başlığı ile tam uyumluluk sunar. Ürünün frekans değeri 868 Mhz'dir. Böylece Raspberry Pi'yi özünde kullanan bir DIY ağ geçidi için mükemmel bir çözümdür. Bu, düşük maliyetli ve istikrarlı bir performansla LoRaWAN çözümünün hızlı bir şekilde kullanılmasını sağlar.RAK2245 hattındaki diğer modüllerde olduğu gibi, Semtech 1301 ve çift SX1257 / 58 ön uç yongalarına dayanıyor.Bu ürünün son nesli(RAK831) üzerinde bir takım iyileştirmeler içeren tam teşekküllü bir 8 kanallı LoRa Konsantratörüdür.", IsShowcaseProduct = true, CategoryId = 5, SubCategory1Id = 2, Image = "img19.jpg", IsActive = true });
            list1.Add(new Product { Id = 9, Name = "Arduino LED", Price = 4.06, Title = "Arduino LED Trafik Lambası Modülü", Origin = "China", StockCode = "14114", Description = "Bu bir mini trafik lambası modülüdür. Yüksek parlaklık ve kompakt tasarımı ile trafik lamba sistemi için uygun bir Arduino modülüdür. 3 adet pini ve bir ground pini bulunmaktadır. Her ışığın pinine 5V vererek ledleri sıra ile yakabilirsiniz.", IsShowcaseProduct = true, CategoryId = 4, SubCategory1Id = 5, SubCategory2Id = 1, Image = "img15.png", IsActive = true });
            list1.Add(new Product { Id = 10, Name = "Motor Shield", Price = 11.84, Title = "Arduino Motor Shield - L293D", Origin = "China", StockCode = "DSTK2135", Description = "Motor Shield en çok kullanılan Arduino shield çeşitlerindendir. Kart ile 4 adet DC motor, 2 adet step motor veya 2 adet servo motor kontrol edebilirsiniz. 4.5-36V arası motorlar için kullanılabilir.", IsShowcaseProduct = false, CategoryId = 4, SubCategory1Id = 5, SubCategory2Id = 1, Image = "img22.jpg", IsActive = true });
            list1.Add(new Product { Id = 11, Name = "LattePanda", Price = 1009.00, Title = "LattePanda Windows 10 Lisanssız 4G/64GB", Origin = "LattePanda", StockCode = " DFR0419", Description = "LattePanda 4G/64GB,  Windows 10  işletim sistemi kullanan bir mini bilgisayar ve geliştirme kartıdır. Arduino kartları ile uyumludur. Türkiye'de en uygun fiyatlarla Direnc.net'te bulabileceğiniz mini bilgisayarda dahili 4GB Ram ve 64GB Harddisk vardır.", IsShowcaseProduct = true, CategoryId = 6, SubCategory1Id = 1, Image = "img5.jpg", IsActive = true });


            var options = new DbContextOptionsBuilder<AppDbContext>()
               .UseInMemoryDatabase(databaseName: "Test")
               .Options;

            _context = new AppDbContext(options);
            if (_context.Products.ToListAsync().Result.Count == 0)
            {
                _context.Products.AddRange(list1);
                _context.SaveChanges();
            }
        }

        [Fact]
        public async Task Should_Return_All_Products()
        {
            var response = await _productRepository.ListAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Should_Return_Product_For_ProductId()
        {
            var response = await _productRepository.GetAsync(11);
            Assert.NotNull(response);
            Assert.Equal(response.Id, list1[10].Id);
            Assert.Equal(response.Description, list1[10].Description);
        }

        [Fact]
        public async Task Should_Not_Return_Product_For_Non_Existing_ProductId()
        {
            var response = await _productRepository.GetAsync(50);
            Assert.Null(response);
        }

        [Fact]
        public async Task Should_Return_Product_For_MainCategoryId()
        {
            var response = await _productRepository.ListAsync(1);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Should_Return_Product_For_MainCategoryId_And_Sub1CategoryId()
        {
            var response = await _productRepository.ListAsync(5, 2);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Should_Return_Product_For_MainCategoryId_And_Sub1CategoryId_And_Sub2CategoryId()
        {
            var response = await _productRepository.ListAsync(4, 5, 1);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task Should_Return_All_ShowCaseProducts()
        {
            var response = await _productRepository.ListAsync();
            Assert.NotNull(response);
        }
    }
}
