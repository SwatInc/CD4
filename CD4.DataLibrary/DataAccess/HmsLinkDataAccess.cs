using CD4.DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class HmsLinkDataAccess : DataAccessBase, IHmsLinkDataAccess
    {
        public async Task<List<HmsLinkDataModel>>
            GetAnalysisRequestDataByEpisodeNumber(int episodeNumber, string query)
        {
            var ConnectionStringName = "HMSLink";
            var Parameters = new { EpisodeNumber = episodeNumber.ToString() };

            try
            {
                var output = await LoadDataWithQueryAndParametersAsync<HmsLinkDataModel, dynamic>
                    (query, Parameters, ConnectionStringName);
                return output;
            }
            catch (Exception)
            {
                throw;
            }

            throw new NotImplementedException();
        }

        public async Task<List<HmsLinkDataModel>>
            GetAnalysisRequestDataByEpisodeNumberMock(int episodeNumber, string query)
        {
            var mockData = new List<HmsLinkDataModel>()
            {
                new HmsLinkDataModel()
                {
                    EpisodeNumber = episodeNumber,
                    PatientId = "123456",
                    NidPp = "A256253",
                    FullName = "Ibrahim Hussain",
                    Gender = "M",
                    RegAtollId = 1,
                    RegIslandId = 1,
                    Birthdate = DateTime.Today,
                    Address = "Some Address",
                    BillDate = DateTime.Today.AddDays(-1),

                    BillItemDetailEntryId = 1,
                    ItemCode = 2322,
                    ItemDescription = "Test1",
                },
                new HmsLinkDataModel()
                {
                    EpisodeNumber = episodeNumber,
                    PatientId = "123456",
                    NidPp = "A256253",
                    FullName = "Ibrahim Hussain",
                    Gender = "M",
                    RegAtollId = 1,
                    RegIslandId = 1,
                    Birthdate = DateTime.Today,
                    Address = "Some Address",
                    BillDate = DateTime.Today.AddDays(-1),

                    BillItemDetailEntryId = 2,
                    ItemCode = 1321,
                    ItemDescription = "Test2",
                }
            };

            await Task.Delay(100);
            return mockData;
        }
    }
}