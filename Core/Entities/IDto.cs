namespace Core.Entities
{
    //DTO = Data Transformation Object
    //Veritabanı nesnelerini ilişkilendirmeye yarar.
    //Car class' ında bulunan "Id" ile Brand class'ında bulunan "BrandName" i bir arada göstermeye yarayan bir kod bloğudur.
    public interface IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}