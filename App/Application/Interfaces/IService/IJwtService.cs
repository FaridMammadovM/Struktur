using Domain.General;

namespace Application.Interfaces.IService
{
    public interface IJwtService
    {
        int GetHospitalId();

        int? GetSubHospitalId();

        int GetLng();

        int GetUserId();

        string GetUniqueName();

        string GetServiceName();

        string GetToken();

        List<GeneralMessageItem> GetMessages();

        void AddMessage(int messageCode, params string[] formatParameters);

        void ThrowException(int messageCode, params string[] formatParameters);
    }
}
