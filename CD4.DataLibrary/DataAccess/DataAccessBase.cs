﻿using CD4.DataLibrary.Helpers;
using CD4.DataLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.DataLibrary.DataAccess
{
    public class DataAccessBase
    {
        internal readonly SqlDataAccessHelper helper;

        public DataAccessBase()
        {
            this.helper = new SqlDataAccessHelper();
        }

        internal async Task<List<T>> LoadDataAsync<T>(string storedProcedure)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = await connection.QueryAsync<T>(storedProcedure, CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        internal async Task<List<T>> LoadDataWithParameterAsync<T,U>
            (string storedProcedure, U parameter)
        {

            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                results = await connection.QueryAsync<T>
                    (storedProcedure, parameter, commandType: CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        /// <summary>
        /// NOTE: T should be the first type of data set returned by the query / procedure
        /// NOTE: U should be the second type of data set returned by the query / procedure
        /// MEANS that the generic classes should be passed in the order that is expected to be returned by the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <returns>returns a class with List<T> AND List<U> as public properties</returns>
        internal async Task<GenericTwoListModel> LoadStaticDataTwoSetsAsync<T, U>
            (string storedProcedure)
        {
            var genericTwoList = new GenericTwoListModel();
            var returnData = genericTwoList.GetLists<T, U>();

            List<T> ListT = null;
            List<U> ListU = null;

            using (IDbConnection connection = new SqlConnection(helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, CommandType.StoredProcedure))
                {
                    ListT = lists.Read<T>().ToList();
                    ListU = lists.Read<U>().ToList();
                }
            }

            returnData.T1 = ListT;
            returnData.U1 = ListU;
            return returnData;
        }

    }
}