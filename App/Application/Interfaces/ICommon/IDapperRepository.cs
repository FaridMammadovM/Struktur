using Application.Interfaces.IService;
using Dapper;
using System.Data;

namespace Application.Interfaces.ICommon
{
    internal interface IDapperRepository : ICommonInjection
    {
        public DynamicParameters GetDefaultParameters();

        Task<dynamic> InsertReturnId<T>(T model, IDbTransaction tran = null, int? commandTimeout = null);

        Task<T> GetFirstOrDefaultPostgreFunctionData<T>(string functionNameByParamName, object param = null, IDbTransaction tran = null, int? commandTimeout = null);

        Task<IEnumerable<T>> GetAllPostgreTableValuedFunctionData<T>(string functionNameByParamName, object param = null, IDbTransaction tran = null, int? commandTimeout = null);

        Task<List<T>> QueryAsync<T>(string query, object param = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null);

        Task ExecuteAsync(string query, object param = null);
    }
}

