using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    //8
    public class BusinessRules
    {
        //params verildiğinde, Run içerisine paramatre olarak istenildiği kadar IRestul verilebilir.
        //Arka planda verilen bütün parametreleri IResult[]' e aktarır.

        public static IResult Run(params IResult[] logics)
        {
            //her bir logics için logic olarak gez
            foreach (var logic in logics)
            {
                //logic başarısız ise logic döndür
                //parametre ile gönderilen iş kurallarından başarısız olanı Business katmanına göndererek haber verir.
                if ((!logic.Success))
                {
                    return logic;
                }
            }

            return null;//Tüm kurallar başarılı ise null döndür.

        }
    }
}
