using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CSProjeDemo1
{
    public abstract class Kitap
    {
        public int ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public DateTime YayinYili { get; set; }
        public KitapDurum Durum { get; set; } = KitapDurum.OduncAlinabilir;
        public string KitapTuru { get; set; }

    }

    public enum KitapDurum
    {
        OduncAlinabilir,
        OduncVerildi,
        MevcutDegil
    }

    public class KitapBilim : Kitap
    {

    }

    public class KitapRoman : Kitap
    {

    }

    public class KitapTarih : Kitap
    {

    }

    public class KitapDunyaKlasikleri : Kitap
    {

    }

    public class KitapPsikoloji : Kitap
    {

    }

    public class KitapGenclik : Kitap
    {

    }

    public class KitapGerilim : Kitap
    {

    }

    public class KitapKisiselGelisim : Kitap
    {

    }

    public class KitapFelsefe : Kitap
    {

    }

    public class KitapSiyaset : Kitap
    {

    }

    public class KitapFantastik : Kitap
    {

    }

    public class KitapCocuk : Kitap
    {

    }

    public class KitapPolisiye : Kitap
    {

    }

    public class KitapSiir : Kitap
    {

    }

    public class KitapMacera : Kitap
    {

    }

    public class KitapEdebiyat : Kitap
    {

    }

    public class KitapBilimKurgu : Kitap
    {

    }

    public class KitapHikaye : Kitap
    {

    }

    public class KitapSosyoloji : Kitap
    {

    }

    public class KitapBiyografi : Kitap
    {

    }

    public class KitapKlasikler : Kitap
    {

    }

    public class KitapArastirma : Kitap
    {

    }

    public class KitapDeneme : Kitap
    {

    }

    public class KitapEkonomi : Kitap
    {

    }

    public class KitapSaglik : Kitap
    {

    }

    public class KitapMizah : Kitap
    {

    }

    public class KitapMektup : Kitap
    {

    }

    public class KitapMasal : Kitap
    {

    }

    public class KitapTiyatro : Kitap
    {

    }

    public class KitapCizgiRoman : Kitap
    {

    }

    public class KitapEgitim : Kitap
    {

    }

    public class KitapMitoloji : Kitap
    {

    }

    public class KitapHukuk : Kitap
    {

    }

    public class KitapSanat : Kitap
    {

    }

    public class KitapAntropoloji : Kitap
    {

    }

    public class KitapSpor : Kitap
    {

    }

    public class KitapGezi : Kitap
    {

    }

    public class KitapDergi : Kitap
    {

    }

    public class KitapBilgisayar : Kitap
    {

    }

    public class KitapAile : Kitap
    {

    }

    public class KitapEtimoloji : Kitap
    {

    }

    public class KitapElestiri : Kitap
    {

    }

    public class KitapSinema : Kitap
    {

    }

    public class KitapHobi : Kitap
    {

    }

    public class KitapYemek : Kitap
    {

    }

    public class KitapSenaryo : Kitap
    {

    }

    public class KitapRoportaj : Kitap
    {

    }

    public class KitapMedya : Kitap
    {

    }

    public class KitapAstroloji : Kitap
    {

    }

    public class KitapSozluk : Kitap
    {

    }

    public class KitapCografya : Kitap
    {

    }

    public class KitapAstronomi : Kitap
    {

    }

    public interface IUye
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int UyeNo { get; set; }
        List<int> OduncAlinanKitaplar { get; }
        void KitapOduncAl(int isbn);
        void KitapIadeEt(int isbn);
    }

    public class Uye : IUye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UyeNo { get; set; }
        public List<int> OduncAlinanKitaplar { get; private set; } = new List<int>();

        public void KitapOduncAl(int isbn)
        {
            if (!OduncAlinanKitaplar.Contains(isbn))
            {
                OduncAlinanKitaplar.Add(isbn);
            }
        }

        public void KitapIadeEt(int isbn)
        {
            OduncAlinanKitaplar.Remove(isbn);
        }
    }

    //Metodları içeren Kütüphane sınıfı
    public class Kutuphane
    {
        private List<Kitap> _kitaplar = new List<Kitap>();
        private List<Uye> _uyeler = new List<Uye>();

        public void KitapEkle(Kitap kitap)
        {
            _kitaplar.Add(kitap);
        }

        public Uye UyeEkle(string ad, string soyad)
        {
            var uyeNo = _uyeler.Count + 1;
            var uye = new Uye { Ad = ad, Soyad = soyad, UyeNo = uyeNo };
            _uyeler.Add(uye);
            return uye;
        }

        public bool OduncVer(int uyeNo, int isbn)
        {
            var uye = _uyeler.FirstOrDefault(u => u.UyeNo == uyeNo);
            var kitap = _kitaplar.FirstOrDefault(k => k.ISBN == isbn);

            if (uye == null || kitap == null || kitap.Durum != KitapDurum.OduncAlinabilir)
            {
                return false;
            }

            uye.KitapOduncAl(isbn);
            kitap.Durum = KitapDurum.OduncVerildi;
            return true;
        }

        public bool IadeEt(int uyeNo, int isbn)
        {
            var uye = _uyeler.FirstOrDefault(u => u.UyeNo == uyeNo);
            var kitap = _kitaplar.FirstOrDefault(k => k.ISBN == isbn);

            if (uye == null || kitap == null || kitap.Durum != KitapDurum.OduncVerildi || !uye.OduncAlinanKitaplar.Contains(isbn))
            {
                return false;
            }

            uye.KitapIadeEt(isbn);
            kitap.Durum = KitapDurum.OduncAlinabilir;
            return true;
        }

        public List<Kitap> GetTumKitaplar()
        {
            return _kitaplar;
        }

        public Kitap GetKitapByISBN(int isbn)
        {
            return _kitaplar.FirstOrDefault(k => k.ISBN == isbn);
        }

        public List<Kitap> GetUyeninOduncAldigiKitaplar(int uyeNo)
        {
            var uye = _uyeler.FirstOrDefault(u => u.UyeNo == uyeNo);
            if (uye == null)
            {
                return new List<Kitap>();
            }

            return _kitaplar.Where(k => uye.OduncAlinanKitaplar.Contains(k.ISBN)).ToList();
        }

        public Uye GetUyeByUyeNo(int uyeNo)
        {
            return _uyeler.FirstOrDefault(u => u.UyeNo == uyeNo);
        }

        public List<Uye> GetTumUyeler()
        {
            return _uyeler;
        }
    }

    //Modeller
    public class KitapEkleModel
    {
        public int ISBN { get; set; }
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public DateTime YayinYili { get; set; }
        public string KitapTuru { get; set; }
    }

    public class UyeEkleModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }

    public class OduncIslemModel
    {
        public int UyeNo { get; set; }
        public int ISBN { get; set; }
    }

}