using Application.Interfaces.IService;
using Domain.General;
using Domain.Package;
using Domain.Package.Enum;

namespace Application.Interfaces.ICommon
{
    public interface ICommonRepository : ICommonInjection
    {
        Task<string> GetStaticDetailValue(ConstantParametersEnum parameterCode, ConstantParameterValuesEnum value);
        Task<GetStaticDetailValuesResDto> GetStaticDetailValues(ConstantParametersEnum parameterCode);
        Task<List<GeneralMessage>> GetMessages(List<int> messageCodes);
        Task<List<GetStaticDetailValuesListResDto>> GetStaticDetailValuesList(List<int> parameterCodes);
    }
}

