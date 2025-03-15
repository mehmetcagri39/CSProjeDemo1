using CSProjeDemo1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KutuphaneController : ControllerBase
    {
        private static readonly Kutuphane _kutuphane = new Kutuphane();
        private static bool _isInitialized = false;
        private static readonly object _initLock = new object();


        public KutuphaneController()
        {
            if (!_isInitialized) 
            {
                lock (_initLock)
                {
                    if (!_isInitialized)
                    {
                        InitializeData();
                        _isInitialized = true;
                    }
                }
            }
        }
        private void InitializeData() //Bu methodun amacı kütüphanede halihazırda bulunması istenen 3 kitap ve 1 üyenin eklenmesidir.
        {
            var kitap1 = new KitapBilim
            {
                ISBN = 123456,
                Baslik = "Bilim Kitabı",
                Yazar = "Bilim Adamı",
                YayinYili = 2020,
                KitapTuru = "Bilim"
            };

            var kitap2 = new KitapRoman
            {
                ISBN = 654321,
                Baslik = "Roman Kitabı",
                Yazar = "Roman Yazarı",
                YayinYili = 2019,
                KitapTuru = "Roman"
            };

            var kitap3 = new KitapTarih
            {
                ISBN = 987654,
                Baslik = "Tarih Kitabı",
                Yazar = "Tarihçi",
                YayinYili = 2018,
                KitapTuru = "Tarih"
            };

            _kutuphane.KitapEkle(kitap1);
            _kutuphane.KitapEkle(kitap2);
            _kutuphane.KitapEkle(kitap3);

            var uye1 = _kutuphane.UyeEkle("Cagri", "Celenk");
            _kutuphane.OduncVer(uye1.UyeNo, kitap1.ISBN);
        }

        #region Bug'lı yöntem
        /*public KutuphaneController()
        {

            //bug: Bu yöntemi kullanıp 3 kitap ve 1 üyenin eklenmesi istenirse kitap listesi ne zaman yenilense bu üye ve kitaplar tekrar ekleniyor ve liste giderek büyüyordu.
            //Bu durumdan kurtulmak için singleton pattern kullanılabilirdi.

            var kitap1 = new KitapBilim
            {
                ISBN = 123456,
                Baslik = "Bilim Kitabı",
                Yazar = "Bilim Adamı",
                YayinYili = 2020,
                KitapTuru = "Bilim"
            };

            var kitap2 = new KitapRoman
            {
                ISBN = 654321,
                Baslik = "Roman Kitabı",
                Yazar = "Roman Yazarı",
                YayinYili = 2019,
                KitapTuru = "Roman"
            };

            var kitap3 = new KitapTarih
            {
                ISBN = 987654,
                Baslik = "Tarih Kitabı",
                Yazar = "Tarihçi",
                YayinYili = 2018,
                KitapTuru = "Tarih"
            };

            _kutuphane.KitapEkle(kitap1);
            _kutuphane.KitapEkle(kitap2);
            _kutuphane.KitapEkle(kitap3);


            var uye1 = _kutuphane.UyeEkle("Cagri", "Celenk");

            _kutuphane.OduncVer(uye1.UyeNo, kitap1.ISBN);



        } */
        #endregion

        [HttpPost("kitap")]
        public IActionResult KitapEkle(KitapEkleModel model)
        {
            Kitap kitap;

            //Kitap türünün ilk harfinin büyük olması için
            model.KitapTuru = char.ToUpper(model.KitapTuru[0]) + model.KitapTuru.Substring(1).ToLower();


            //statik yapıda oluşturulmuş kitap türleri
            switch (model.KitapTuru)
            {
                case "Bilim":
                    kitap = new KitapBilim
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Roman":
                    kitap = new KitapRoman
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Tarih":
                    kitap = new KitapTarih
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "DunyaKlasikleri":
                    kitap = new KitapDunyaKlasikleri
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Psikoloji":
                    kitap = new KitapPsikoloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Genclik":
                    kitap = new KitapGenclik
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Gerilim":
                    kitap = new KitapGerilim
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "KisiselGelisim":
                    kitap = new KitapKisiselGelisim
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Felsefe":
                    kitap = new KitapFelsefe
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Siyaset":
                    kitap = new KitapSiyaset
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Fantastik":
                    kitap = new KitapFantastik
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Cocuk":
                    kitap = new KitapCocuk
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Polisiye":
                    kitap = new KitapPolisiye
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Siir":
                    kitap = new KitapSiir
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Macera":
                    kitap = new KitapMacera
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Edebiyat":
                    kitap = new KitapEdebiyat
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "BilimKurgu":
                    kitap = new KitapBilimKurgu
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Hikaye":
                    kitap = new KitapHikaye
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Sosyoloji":
                    kitap = new KitapSosyoloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Biyografi":
                    kitap = new KitapBiyografi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Klasikler":
                    kitap = new KitapKlasikler
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Arastirma":
                    kitap = new KitapArastirma
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Deneme":
                    kitap = new KitapDeneme
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Ekonomi":
                    kitap = new KitapEkonomi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Saglik":
                    kitap = new KitapSaglik
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Mizah":
                    kitap = new KitapMizah
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Mektup":
                    kitap = new KitapMektup
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Masal":
                    kitap = new KitapMasal
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Tiyatro":
                    kitap = new KitapTiyatro
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "CizgiRoman":
                    kitap = new KitapCizgiRoman
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Egitim":
                    kitap = new KitapEgitim
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Mitoloji":
                    kitap = new KitapMitoloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Hukuk":
                    kitap = new KitapHukuk
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Sanat":
                    kitap = new KitapSanat
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Antropoloji":
                    kitap = new KitapAntropoloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Spor":
                    kitap = new KitapSpor
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Gezi":
                    kitap = new KitapGezi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Dergi":
                    kitap = new KitapDergi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Bilgisayar":
                    kitap = new KitapBilgisayar
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Aile":
                    kitap = new KitapAile
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Etimoloji":
                    kitap = new KitapEtimoloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Elestiri":
                    kitap = new KitapElestiri
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Sinema":
                    kitap = new KitapSinema
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Hobi":
                    kitap = new KitapHobi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Yemek":
                    kitap = new KitapYemek
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Senaryo":
                    kitap = new KitapSenaryo
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Roportaj":
                    kitap = new KitapRoportaj
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Medya":
                    kitap = new KitapMedya
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Astroloji":
                    kitap = new KitapAstroloji
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Sozluk":
                    kitap = new KitapSozluk
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Cografya":
                    kitap = new KitapCografya
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                case "Astronomi":
                    kitap = new KitapAstronomi
                    {
                        ISBN = model.ISBN,
                        Baslik = model.Baslik,
                        Yazar = model.Yazar,
                        YayinYili = model.YayinYili,
                        KitapTuru = model.KitapTuru
                    };
                    break;
                default:
                    return BadRequest("Geçersiz kitap türü!");
            }

            _kutuphane.KitapEkle(kitap);
            return Ok(new { message = "Kitap eklenmesi başarılı", kitap });
        }

        [HttpPost("uye")]
        public IActionResult UyeEkle(UyeEkleModel model)
        {
            var uye = _kutuphane.UyeEkle(model.Ad, model.Soyad);
            return Ok(new { message = "Üye eklenmesi başarılı.", uye });
        }

        [HttpPost("odunc")]
        public IActionResult KitapOduncVer(OduncIslemModel model)
        {
            var sonuc = _kutuphane.OduncVer(model.UyeNo, model.ISBN);
            if (sonuc)
            {
                return Ok(new { message = "Kitap ödünç verme işlemi başarılı. Keyifli okumalar!" });
            }
            return BadRequest("Kitap ödünç verilemedi. Üye, kitap veya kitap durumu uygun değil. Lütfen daha sonra tekrar deneyiniz.");
        }

        [HttpPost("iade")]
        public IActionResult KitapIadeEt(OduncIslemModel model)
        {
            var sonuc = _kutuphane.IadeEt(model.UyeNo, model.ISBN);
            if (sonuc)
            {
                return Ok(new { message = "Kitap iade işlemi başarılı." });
            }
            return BadRequest("Kitap iade edilemedi.");
        }

        // Üyenin ödünç aldığı kitapları görme isteği(http)
        [HttpGet("uye/{uyeNo}/kitaplar")]
        public IActionResult UyeninKitaplari(int uyeNo)
        {
            var kitaplar = _kutuphane.GetUyeninOduncAldigiKitaplar(uyeNo);
            return Ok(kitaplar);
        }

        [HttpGet("kitaplar")]
        public IActionResult TumKitaplar()
        {
            var kitaplar = _kutuphane.GetTumKitaplar();
            return Ok(kitaplar);
        }

        [HttpGet("uyeler")]
        public IActionResult TumUyeler()
        {
            var uyeler = _kutuphane.GetTumUyeler();
            return Ok(uyeler);
        }
    }
}
