using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class CommentsDataAccess : DataAccessBase, ICommentsDataAccess
    {
        public async Task<List<CommentsSelectionModel>> GetAllCommentsByTypeId(int commentTypeId)
        {
            var storedProcedure = "[dbo].[usp_GetAllCommentsByTypeId]";
            var parameter = new { CommentTypeId = commentTypeId };
            return await LoadDataWithParameterAsync<CommentsSelectionModel, dynamic>
                (storedProcedure, parameter);
        }
    }
}
