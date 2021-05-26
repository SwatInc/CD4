using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class CommentsDataAccess : DataAccessBase, ICommentsDataAccess
    {
        public async Task<List<CommentsSelectionModel>> GetAllCommentsByTypeId(int commentTypeId)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_GetAllCommentsByTypeId]";
                var parameter = new { CommentTypeId = commentTypeId };
                return await LoadDataWithParameterAsync<CommentsSelectionModel, dynamic>
                    (storedProcedure, parameter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task InsertUpdateResultComment
            (int commentListId, int resultId, int userId)
        {

            try
            {
                var storedProcedure = "[dbo].[usp_DecideUpsertResultComment]";
                var parameters = new { CommentListId = commentListId, ResultId = resultId, UserId = userId };
                _= await SelectInsertOrUpdateAsync<dynamic, dynamic>
                                    (storedProcedure, parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<ResultCommentModel>> GetExistingResultComments(int resultId)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_GetResultCommentsByResultId]";
                var parameter = new { ResultId = resultId };
                return await LoadDataWithParameterAsync<ResultCommentModel, dynamic>
                    (storedProcedure, parameter);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public async Task RemoveResultCommentById(int resultId)
        {
            try
            {
                var storedProcedure = "[dbo].[usp_DeleteResultCommentByResultId]";
                var parameter = new { ResultId = resultId };
                _ = await SelectInsertOrUpdateAsync<dynamic, dynamic>
                    (storedProcedure, parameter);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}