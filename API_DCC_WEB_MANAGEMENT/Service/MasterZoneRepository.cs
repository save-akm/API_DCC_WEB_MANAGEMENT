using API_DCC_WEB_MANAGEMENT.Models;
using IBM.Data.DB2.iSeries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API_DCC_WEB_MANAGEMENT.Service
{
    public class MasterZoneRepository
    {
        private string AppConnectionPCB = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["DevPCB"];
        private string AppConnectionAYT = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["DevAYT"];

        private string db = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("WebAPI")["BaseUrl"];


        public iDB2Connection ConnectionPCB
        {
            get
            {
                return new iDB2Connection(AppConnectionPCB);
            }
        }
        public iDB2Connection ConnectionAYT
        {
            get
            {
                return new iDB2Connection(AppConnectionAYT);
            }
        }
        public bool UpdateFlgPCB(MonitorModel monitorModel)
        {
            string message = "";
            try
            {
                using (iDB2Connection dB2Connection = ConnectionPCB)
                {

                    iDB2Command cmd = dB2Connection.CreateCommand();
                    string procName = $"{db}.UPD_MNTFLG";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Parameters.Add(new iDB2Parameter("#PIKFLG", iDB2DbType.iDB2Integer)).Value = monitorModel.PIKFLG;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVFLG", iDB2DbType.iDB2Integer)).Value = monitorModel.DLVFLG;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVMNT", iDB2DbType.iDB2VarChar,20)).Value = monitorModel.DLVMNT;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVZNE", iDB2DbType.iDB2VarChar,5)).Value = monitorModel.DLVZNE;

                    dB2Connection.Open();
                    cmd.ExecuteNonQuery();
                    dB2Connection.Close();
                    message = "Success";
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL Server-specific exceptions
                Console.WriteLine("SQL Server Exception: " + ex.Message);
                message = "Error";
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An exception occurred: " + ex.Message);
                message = "Error";
                return false;
            }

            return true;
        }
        public bool UpdateFlgAYT(MonitorModel monitorModel)
        {
            string message = "";
            try
            {
                using (iDB2Connection dB2Connection = ConnectionAYT)
                {

                    iDB2Command cmd = dB2Connection.CreateCommand();
                    string procName = $"{db}.UPD_MNTFLG";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procName;
                    cmd.Parameters.Add(new iDB2Parameter("#PIKFLG", iDB2DbType.iDB2Integer)).Value = monitorModel.PIKFLG;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVFLG", iDB2DbType.iDB2Integer)).Value = monitorModel.DLVFLG;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVMNT", iDB2DbType.iDB2VarChar, 20)).Value = monitorModel.DLVMNT;
                    cmd.Parameters.Add(new iDB2Parameter("#DLVZNE", iDB2DbType.iDB2VarChar, 5)).Value = monitorModel.DLVZNE;

                    dB2Connection.Open();
                    cmd.ExecuteNonQuery();
                    dB2Connection.Close();
                    message = "Success";
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL Server-specific exceptions
                Console.WriteLine("SQL Server Exception: " + ex.Message);
                message = "Error";
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An exception occurred: " + ex.Message);
                message = "Error";
                return false;
            }

            return true;
        }
    }
}
