using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CD4.DataLibrary.DataAccess;
using Dapper;

namespace CD4.DataLibrary.Models
{
    public class RequestSampleAndClinicalDetailsInsertDatabaseModel
    {
        #region Default Constructor
        public RequestSampleAndClinicalDetailsInsertDatabaseModel
            (int patientId, AnalysisRequestDataModel request)
        {
            PatientId = patientId;
            EpisodeNumber = request.EpisodeNumber;
            Age = request.Age;
            Cin = request.Cin;
            SiteId = request.SiteId;
            CollectionDate = request.SampleCollectionDate.ToString("yyyyMMdd");
            ReceivedDate = request.SampleReceivedDate.ToString("yyyyMMdd");
            CommaDelimitedClinicalDetailsIds = GetCsvClinicalDetails(request.ClinicalDetails);
            RequestedTestData = ResultDataAccess.GetTestsTable(request.Tests, request.Cin);
        }

        #endregion

        #region Private Methods

        private string GetCsvClinicalDetails
            (List<ClinicalDetailsSelectionModel> clinicalDetails)
        {
            var returnValue = string.Empty;
            foreach (var item in clinicalDetails)
            {
                if (!item.IsSelected) continue;
                if (string.IsNullOrEmpty(returnValue)) 
                {
                    returnValue = $"{item.Id}";
                    continue;
                }
                returnValue = $"{returnValue},{item.Id}";
            }

            return returnValue;
        }

        #endregion

        public dynamic GetWithoutClinicalDetails()
        {
            var excludingClinicalDetails = new
            {
                PatientId,
                EpisodeNumber,
                Age,
                Cin,
                SiteId,
                CollectionDate,
                ReceivedDate,
                RequestedTestData
            };

            return excludingClinicalDetails;
        }

        #region Public properties

        public int PatientId { get; private set; }
        public string EpisodeNumber { get; private set; }
        public string Age { get; private set; }
        public string Cin { get; private set; }
        public int SiteId { get; private set; }
        public string CollectionDate { get; private set; }
        public string ReceivedDate { get; private set; }
        public string CommaDelimitedClinicalDetailsIds { get; private set; }
        public SqlMapper.ICustomQueryParameter RequestedTestData { get; set; }

        #endregion
    }
}
