using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Geçersiz";
        public static string MaintenanceTime = "Zaman dışı";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError="Bir kategori de en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde ürün mevcut";
        public static string CategoryLimitExceded="Category limiti aşıldığu için yeni ürün eklenemiyor..";
        public static string? AuthorizationDenied="Yetkin Yok";
        public static string UserRegistered="Kullanıcı kayır oldu";
        public static string UserNotFound ="kullanıcı hatası";
        public static string PasswordError="Şifre hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı mevcut ";
        public static string AccessTokenCreated="Token oluşturulduu";
        internal static string ProductUpdated="Ürün güncellendi..";
    }
}
