using Domain.General;
using Domain.Package;
using Domain.Package.Enum;

namespace Application.Interfaces.IService
{
    public interface IService : ICommonInjection
    {
        Task<List<GeneralMessage>> ReadExceptionMessages();
        Task<string> GetFileBase64Format(string fileUrl);
        Task<List<int>> UserPermissionsControl(int userId, List<int> permissionCodes);
        Task<UserAllPermissionsControlResDto> UserAllPermissionsControl(int userId, List<int> permissionCodes, SectionPermissionEnum section);
        Task<GetMultiPermissionsAndSectionsResDto> GetMultiPermissionsAndSections(int userId, List<int> permissionCodes, List<SectionPermissionEnum> section);
    }
}
