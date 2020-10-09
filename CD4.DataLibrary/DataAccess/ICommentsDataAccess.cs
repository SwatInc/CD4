using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface ICommentsDataAccess
    {
        Task<List<CommentsSelectionModel>> GetAllCommentsByTypeId(int commentTypeId);
    }
}