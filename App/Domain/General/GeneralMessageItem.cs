namespace Domain.General
{
    public class GeneralMessageItem
    {
        public int MessageCode { get; set; }

        public List<string> FormatParameters { get; set; } = new List<string>();


        public GeneralMessageItem(int messageCode)
        {
            MessageCode = messageCode;
        }

        public GeneralMessageItem(int messageCode, string formatParamter)
        {
            MessageCode = messageCode;
            FormatParameters.Add(formatParamter);
        }

        public GeneralMessageItem(int messageCode, List<string> formatParamters)
        {
            MessageCode = messageCode;
            FormatParameters.AddRange(formatParamters);
        }
    }
}
