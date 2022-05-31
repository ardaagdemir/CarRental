using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    //Projeye yüklenecek dosyalarla ilgili yükleme, silme ve güncelleme işlemlerini bu class' da yapılacak.
    public class FileHelperManager : IFileHelper
    {
        public string Update(IFormFile file, string filePath, string root) //Dosya güncellemek için ise gelen parametreye bakıldığında; güncellenecek yeni dosya,                                                                        eski dosyanın kayıt dizini(filePath) ve yeni bir kayıt dizini(root)
        {
            if (File.Exists(filePath)) //if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);//Eski dosya silindikten sonra yerine geçecek yeni dosya için aşağıdaki 'Upload' metoduna yeni dosya ve kayıt edileceği adres,                          parametre olarak döndürülüyor.
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //file.Length  --> Dosya uzunluğu bayt olarak alır. Burada dosya gönderilmiş mi gönderilmemiş mi diye test işlemi yapılır.
            {
                if (!Directory.Exists(root))//Directory --> System.IO' nun bir class' ıdır. Bu Upload metodunun parametresi olan string root CarManager'dan gelmektedir.
                {
                                            //CarImageManager içerisine girildiğinde burada Add metoduna parametre olarak 'PathConstant.ImagePath' gönderildiği görülür. PatConstants class' ının içerisine girdiğinizde string bir ifadeyle bir dizin adresi vardır.
                                            //Bu adres yüklenecek dosyaların kayıt edileceği adrestir. Burada 'Check if a directory exists ifadesi dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içindeki kodlar dosyanın kayıt edileceği dizini oluşturur.
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName); //Seçmiş olunan dosyanın uzantısı elde edilir.
                string guid = GuidHelper.CreateGuid(); //Core.Utilities.Helpers.GuidHelper klasörünün içindeki GuidManager klasörüne gidilirse burada açıklamalar                                        mevcuttur.
                string filePath = guid + extension; //Dosyanın oluşturulan adı ve uzantısı yan yana getirilir.

                using (FileStream fileStream = File.Create(root + filePath)) //FileStream class'ının bir örneği oluşturuldu.
                {                                                            //File.Create(root + filePath) --> Belirtilen yolda bir dosta oluşturur veya üzerine                                                               yazar.
                                                                             //(root + filePath) --> Oluşturulacak dosyanın yolu ve adı.
                    file.CopyTo(fileStream); //Kopyalanacak dosyanın kopyalanacağı akışı belirtir. Yukarıda gelen IFormFile türündeki file dosyasının nereye                               kopyalanacağını söyler.
                    fileStream.Flush(); //Arabellekten siler.
                    return filePath; //Burada dosyanın tam adı geri göndeilir.Sql server'da dosya eklenirken adı ile eklenmesi için..
                }
            }

            return null;
        }

        public void Delete(string filePath)  //Buradaki string filePath, 'CarImageManager' dan gelen dosyanın kaydedildiği adres ve adı
        {
            if (File.Exists(filePath)) //if kontrolü ile parametre olarak gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }
    }

    //IFormFile projede bir dosya yüklemek için kullanılan yöntemdir. HttpRequest ile gönderilen bir dosyayı temsil eder.
    //FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır.
}
