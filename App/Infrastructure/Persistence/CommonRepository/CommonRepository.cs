using Application.Interfaces.ICommon;
using Application.Interfaces.IService;
using Domain.General;
using Domain.Package;
using Domain.Package.Enum;

namespace Infrastructure.Persistence.CommonRepository
{
    public class CommonRepository : ICommonRepository, ICommonInjection
    {
        public Task<List<GeneralMessage>> GetMessages(List<int> messageCodes)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStaticDetailValue(ConstantParametersEnum parameterCode, ConstantParameterValuesEnum value)
        {
            throw new NotImplementedException();
        }

        public Task<GetStaticDetailValuesResDto> GetStaticDetailValues(ConstantParametersEnum parameterCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetStaticDetailValuesListResDto>> GetStaticDetailValuesList(List<int> parameterCodes)
        {
            throw new NotImplementedException();
        }
    }
}
