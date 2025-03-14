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

        // Kitap ekleme
        [HttpPost("kitap")]
        public IActionResult KitapEkle(KitapEkleModel model)
        {
            Kitap kitap;

            model.KitapTuru = char.ToUpper(model.KitapTuru[0]) + model.KitapTuru.Substring(1).ToLower();


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
            return Ok(new { message = "Kitap başarıyla eklendi.", kitap });
        }

        // Üye ekleme
        [HttpPost("uye")]
        public IActionResult UyeEkle(UyeEkleModel model)
        {
            var uye = _kutuphane.UyeEkle(model.Ad, model.Soyad);
            return Ok(new { message = "Üye başarıyla eklendi.", uye });
        }

        // Kitap ödünç verme
        [HttpPost("odunc")]
        public IActionResult KitapOduncVer(OduncIslemModel model)
        {
            var sonuc = _kutuphane.OduncVer(model.UyeNo, model.ISBN);
            if (sonuc)
            {
                return Ok(new { message = "Kitap başarıyla ödünç verildi." });
            }
            return BadRequest("Kitap ödünç verilemedi. Üye, kitap veya kitap durumu uygun değil.");
        }

        // Kitap iade etme
        [HttpPost("iade")]
        public IActionResult KitapIadeEt(OduncIslemModel model)
        {
            var sonuc = _kutuphane.IadeEt(model.UyeNo, model.ISBN);
            if (sonuc)
            {
                return Ok(new { message = "Kitap başarıyla iade edildi." });
            }
            return BadRequest("Kitap iade edilemedi. Üye, kitap veya kitap durumu uygun değil.");
        }

        // Üyenin ödünç aldığı kitapları görme
        [HttpGet("uye/{uyeNo}/kitaplar")]
        public IActionResult UyeninKitaplari(int uyeNo)
        {
            var kitaplar = _kutuphane.GetUyeninOduncAldigiKitaplar(uyeNo);
            return Ok(kitaplar);
        }

        // Kütüphanedeki kitapları görme
        [HttpGet("kitaplar")]
        public IActionResult TumKitaplar()
        {
            var kitaplar = _kutuphane.GetTumKitaplar();
            return Ok(kitaplar);
        }

        // Üyeleri görüntüleme
        [HttpGet("uyeler")]
        public IActionResult TumUyeler()
        {
            var uyeler = _kutuphane.GetTumUyeler();
            return Ok(uyeler);
        }
    }
}
