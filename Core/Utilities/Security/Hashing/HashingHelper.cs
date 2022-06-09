using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //1
    //Static bir classtır. Kalıtım almasına gerek yoktur.
    public class HashingHelper
    {
        //PasswordHash oluşturmak
        //Verilen password' ün Hash' ini ve Salt' ını oluşturacak
        //Out keyword' ü, veri boş bile olsa gönderilen değerleri doldurup geri göndermeye yarar.
        //Out dışarıya verilecek değer olarak düşünülebilir, aynı zamanda birden fazla veriyi döndürmek için de kullanılır.
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //.Net' in kriptografi sınıflarında yararlanacağız.
            //Bu işlem Desposeble Patter ile yapılacak
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //Buradaki algoritmadan yararlanarak bir Hash ve Salt oluşturucağız.
            {
                //Burada out keyword' ü ile verdiğimiz için passwordHash ve passworSalt kullanıldığında aynı zamanda da döndürülmüş olur.
                passwordSalt = hmac.Key;//Her kullanıcı için bir key oluşturulur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Burada verilecek olan password değerinin bir byte[] tipinde olması gerekir.
                                                                                        //O yüzden Encoding sınıfından yararlanıyoruz.

                //Yukarıdaki kodlar verilen bir password değerinin salt ve hash değerini oluşturmaya yarar.
            }
        }

        //Sonradan sisteme girmek isteyen kullanıcının verdiği password' ün bizim veri kaynağımızdaki hash (passwordHash) ile ilgili salt' a (passwordSalt) göre eşleşip eşleşmediğinin
        //kontrol edildiği yer VerifyPasswordHash' tir.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //Burada out olmamalıdır çünkü bu değerler kullanıcı tarafından verilecektir.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //Burada doğrulama yapılacağı için metot bizden bir key(passwordSalt) değeri istemektedir.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Burada bir hash değeri oluşturuldu. Password hash'lendiğinde oluşacak değerin karşılaştırılması                                                                                   gerekir. Ve bunun için passwordSalt kullanılır.
                //İki array' in (computedHash ve passwordSalt) değelerinin karşılaştırılması gerektiği için for döngüsü yazılmalıdır.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
