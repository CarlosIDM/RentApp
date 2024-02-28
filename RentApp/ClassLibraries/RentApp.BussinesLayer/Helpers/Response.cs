namespace RentApp.BussinesLayer.Helpers
{
    public class Response<T>
    {
        public T Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
    }
}
