using CD4.DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public interface ICommentsDataAccess
    {
        Task<List<CommentsSelectionModel>> GetAllCommentsByTypeId(int commentTypeId);
        Task<List<ResultCommentModel>> GetExistingResultComments(int resultId);
        Task InsertUpdateResultComment(int commentListId, int resultId, int userId);
        Task RemoveResultCommentById(int resultId);
    }
}