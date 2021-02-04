using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface IScriptDataAccess
    {
        Task<string> LoadScriptByName(string analyserName);
    }
}