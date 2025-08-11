namespace Domain.General
{
    public class ExternalServiceResDto<T>
    {
        public T Data { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string Detail { get; set; }

        public string Instance { get; set; }

        public IDictionary<string, object> Extensions { get; }
    }
}
