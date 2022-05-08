using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //new'lememek için static kullandık
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarListed = "Araba listesi görüntülendi";
        public static string CarIdInvalid = "Geçersiz CarId ";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarDailyPriceInvalid = "Fiyat geçersiz";

        public static string BrandAdded = "Model Eklendi";
        public static string BrandListed = "Modeller Listelendi";
        public static string BrandDeleted = "Model Silindi";
        public static string BrandUpdated = "Model Güncellendi";
        public static string BrandNameInvalid = "Ürün Model İsmi Geçersiz";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorListed = "Renk Listelendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorNameInvalid = "Ürün Renk İsmi Geçersiz";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdeted = "Kullanıcı bilgileri güncellendi"; 
        public static string UserListed = "Kullanıcı bilgileri listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalListed = "Kiralık arabalar listelendi";
        public static string RentalDeleted = "Kirlaık araba silindi";
        public static string RentalUpdated = "Kiralık araba bilgileri güncellendi";
        public static string RentalIdInvalid = " ";
        public static string TheCarHasNotBeenDeliveredYet = "The Car Has Not Been Delivered Yet";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string ErorAdded = "Araba Henüz Teslim Edilmedi.";
        public static string SuccesRanted = "Araba Kiralandı";


    }
}
