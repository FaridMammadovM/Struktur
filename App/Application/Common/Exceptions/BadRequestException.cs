namespace Application.Common.Exceptions
{
    [Serializable]
    public class BadRequestException : BaseException
    {
        public virtual int StatusCode => 400;
    }
}
