namespace Dashboard.Domain.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public String Message {  get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
