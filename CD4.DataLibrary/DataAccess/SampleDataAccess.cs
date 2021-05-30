using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class SampleDataAccess : DataAccessBase, ISampleDataAccess
    {
        public async Task<bool> UpdateSample(SampleUpdateDatabaseModel sample, int loggedInUserId)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleWithCin]";
            sample.UserId = loggedInUserId;
            return await SelectInsertOrUpdateAsync<bool, SampleUpdateDatabaseModel>(storedProcedure, sample);
        }

        public async Task<List<AuditTrailModel>> GetAuditTrailByCinAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetAuditTrailByCin]";
            var parameter = new { Cin = cin };
            return await LoadDataWithParameterAsync<AuditTrailModel, dynamic>(storedProcedure, parameter);
        }

        public async Task<SampleAndResultStatusAndResultModel> RejectSampleAsync(string cin, int commentListId, int userId)
        {
            var storedProcedure = "[dbo].[usp_RejectSampleByCin]";
            var parameter = new { Cin = cin, CommentListId = commentListId, UserId = userId };
            try
            {
                var output = await QueryMultiple_GetModelAndListWithParameterAsync<StatusUpdatedSampleModel, UpdatedResultAndStatusModel, dynamic>
                    (storedProcedure, parameter);

                return new SampleAndResultStatusAndResultModel()
                {
                    SampleData = output.T1,
                    ResultStatus = output.U1
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SampleWithTestIdModel>> GetAllTestIdsForAllSpecifiedSamples(List<string> cins)
        {
            var storedProcedure = "[dbo].[usp_GetAllAssociatedTestIdsForSamples]";
            var parameters = new { SampleCins = GetCinTable(cins) };

            try
            {
                return await LoadDataWithParameterAsync<SampleWithTestIdModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SampleAndResultStatusAndResultModel> CancelSampleRejectionByCinAsync(string cin, int userId)
        {
            var storedProcedure = "[dbo].[usp_CancelSampleRejectionByCin]";
            var parameter = new { Cin = cin, UserId = userId };
            try
            {
                var output = await QueryMultiple_GetModelAndListWithParameterAsync<StatusUpdatedSampleModel, UpdatedResultAndStatusModel, dynamic>
                    (storedProcedure, parameter);

                return new SampleAndResultStatusAndResultModel()
                {
                    SampleData = output.T1,
                    ResultStatus = output.U1
                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<int> GetSampleStatusAsync(string cin)
        {
            var storedProcedure = "usp_GetSampleStatus";
            var parameter = new { Cin = cin };

            try
            {
                return await SelectInsertOrUpdateAsync<int, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetNotesCountAsync(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetNotesCountForSample]";
            var parameter = new { Cin = cin };

            try
            {
                return await SelectInsertOrUpdateAsync<int, dynamic>(storedProcedure, parameter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SampleNotesModel>> GetSampleNotesByCin(string cin)
        {
            var storedProcedure = "[dbo].[usp_GetSampleNotesByCin]";
            var parameters = new { Cin = cin };
            try
            {
                return await LoadDataWithParameterAsync<SampleNotesModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SampleNotesModel> InsertSampleNote(SampleNotesModel sampleNotes)
        {
            var storedProcedure = "[dbo].[usp_InsertSampleNoteByCin]";
            var parameters = new { Cin = sampleNotes.CIN, Note = sampleNotes.Note, UserId = sampleNotes.UserId };

            try
            {
                return await SelectInsertOrUpdateAsync<SampleNotesModel, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateSampleNoteAttendedStatus(int noteId, bool isAttended)
        {
            var storedProcedure = "[dbo].[usp_UpdateSampleNoteAttendedStatus]";
            var parameters = new { NoteId = noteId, IsAttended = isAttended };

            try
            {
                _ = await SelectInsertOrUpdateAsync<dynamic, dynamic>(storedProcedure, parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// returns a list of sample numbers for the provided episode number
        /// </summary>
        /// <param name="episodeNumber"> episode number used to fetch SIDs</param>
        /// <returns>List of string SIDs</returns>
        public async Task<List<string>> GetCinsByEpisodeNumberAsync(int episodeNumber)
        {
            var storedProcedure = "[dbo].[usp_GetCinsByEpisodeNumber]";
            var parameters = new { EpisodeNumber = episodeNumber };
            try
            {
                var output = await LoadDataWithParameterAsync<string, dynamic>(storedProcedure, parameters);
                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
