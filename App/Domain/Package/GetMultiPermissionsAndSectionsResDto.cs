using Domain.Package.Enum;

namespace Domain.Package
{
    public class GetMultiPermissionsAndSectionsResDto
    {
        public List<int> PermissionsCodes { get; set; }

        public Dictionary<SectionPermissionEnum, List<int>> SectionsCodes { get; set; }
    }
}
