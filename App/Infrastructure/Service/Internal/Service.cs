using Application.Common.Config;
using Application.Common.Extension;
using Application.Interfaces.ICommon;
using Application.Interfaces.IService;
using Domain.General;
using Domain.Package;
using Domain.Package.Enum;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace Infrastructure.Service.Internal
{
    public class Service : IService
    {
        private readonly CommonConfig _commonConfig;
        private readonly IJwtService _jwtService;
        private AccessManagementConfig _accessManagementConfig;
        private readonly ICommonRepository _commonRepository;

        public Service(
            IOptions<CommonConfig> commonConfig,
            IOptions<AccessManagementConfig> accessManagementConfig,
            IJwtService jwtService,
            ICommonRepository commonRepository)
        {
            _commonConfig = commonConfig.Value;
            _jwtService = jwtService;
            _accessManagementConfig = accessManagementConfig.Value;
            _commonRepository = commonRepository;
        }

        public async Task<List<GeneralMessage>> ReadExceptionMessages()
        {
            List<GeneralMessageItem> messagesItems = _jwtService.GetMessages();

            if (messagesItems?.Any() ?? false)
            {
                List<int> messageCodes = messagesItems.Select(mi => mi.MessageCode).ToList();

                List<GeneralMessage> messages = await _commonRepository.GetMessages(messageCodes);

                foreach (var item in messages)
                {
                    List<string> formatParameters = messagesItems
                        .FirstOrDefault(mi => mi.MessageCode == item.Code).FormatParameters;

                    if (formatParameters.Any())
                        item.Message = string.Format(item.Message, formatParameters.ToArray());
                }

                return messages;
            }

            return new List<GeneralMessage>();
        }

        public async Task<string> GetFileBase64Format(string fileUrl)
        {
            string url = string.Format(_commonConfig.GetFileBase64Format, fileUrl);

            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add(HeaderNames.Authorization, _jwtService.GetToken());

            ExternalServiceResDto<string> response = await HttpExtension
                .RequestAsync<ExternalServiceResDto<string>>(url, Http.Get, headers: headers);

            return response.Data;
        }

        public async Task<List<int>> UserPermissionsControl(int userId, List<int> permissionCodes)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add(HeaderNames.Authorization, _jwtService.GetToken());

            dynamic request = new
            {
                UserId = userId,
                PermissionCodes = permissionCodes
            };

            ExternalServiceResDto<List<int>> response = await HttpExtension
                .RequestAsync<ExternalServiceResDto<List<int>>>(_accessManagementConfig.UserPermissionsControl, Http.Post, data: request, headers: headers);

            return response.Data;
        }

        public async Task<UserAllPermissionsControlResDto> UserAllPermissionsControl(int userId, List<int> permissionCodes, SectionPermissionEnum section)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add(HeaderNames.Authorization, _jwtService.GetToken());

            dynamic request = new
            {
                UserId = userId,
                PermissionCodes = permissionCodes,
                Section = section
            };

            ExternalServiceResDto<UserAllPermissionsControlResDto> response = await HttpExtension
                .RequestAsync<ExternalServiceResDto<UserAllPermissionsControlResDto>>(_accessManagementConfig.UserAllPermissionsControl, Http.Post, data: request, headers: headers);

            return response.Data;
        }

        public async Task<GetMultiPermissionsAndSectionsResDto> GetMultiPermissionsAndSections(int userId, List<int> permissionCodes, List<SectionPermissionEnum> section)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            headers.Add(HeaderNames.Authorization, _jwtService.GetToken());

            dynamic request = new
            {
                UserId = userId,
                PermissionsCodes = permissionCodes,
                SectionsCodes = section
            };

            ExternalServiceResDto<GetMultiPermissionsAndSectionsResDto> response = await HttpExtension
                .RequestAsync<ExternalServiceResDto<GetMultiPermissionsAndSectionsResDto>>(_accessManagementConfig.GetMultiPermissionsAndSections, Http.Post, data: request, headers: headers);

            return response.Data;
        }
    }
}

