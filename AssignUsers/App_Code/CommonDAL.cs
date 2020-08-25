using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

/*
 * Author Name     : NES
 * Create Date     : 20200318 
 * Modified Date   : 
 * Modified Reason : 
 * Modified By     : 
 * Description     : This DAL class will have properties for tables
 */

namespace NesExamLogin
{
    public static class CommonDAL
    {
        #region Properties
        private static int intSiteId
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("SiteId"));
            }
        }
        private static int intCompanyId
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("CompanyId"));
            }
        }
        private static int intDepartmentId
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("DepartmentId"));
            }
        }
        #endregion


        
        static string strConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();
        private static string EnableCaching
        {
            get
            {
                return ConfigurationManager.AppSettings["EnableCaching"];
            }
        }
        private static string CacheDatabase
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("CacheDatabase");
            }
        }

      

        public static List<ListDTO> ConvertToList<ListDTO>(List<DataRow> rows)
        {
            List<ListDTO> lst = null;
            try
            {
                if (rows != null)
                {
                    lst = new List<ListDTO>();
                    foreach (DataRow row in rows)
                    {
                        ListDTO item = CreateItem<ListDTO>(row);
                        lst.Add(item);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ListDTO CreateItem<ListDTO>(DataRow row)
        {
            ListDTO obj = default(ListDTO);
            try
            {
                if (row != null)
                {
                    obj = Activator.CreateInstance<ListDTO>();
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        FieldInfo prop = obj.GetType().GetField(column.ColumnName);
                        if (prop != null)
                        {
                            //PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                            try
                            {
                                object value = row[column.ColumnName];

                                if (value.ToString().Trim() != string.Empty)
                                {
                                    prop.SetValue(obj, value);
                                }
                            }
                            catch (Exception ex)
                            {
                                // WriteException(ex);
                                throw ex;
                            }
                        }
                        else
                        {
                            PropertyInfo objprop = obj.GetType().GetProperty(column.ColumnName);
                            if (objprop != null)
                            {
                                try
                                {
                                    object value = row[column.ColumnName];

                                    if (value.ToString().Trim() != string.Empty)
                                    {
                                        objprop.SetValue(obj, value, null);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // WriteException(ex);
                                    throw ex;
                                }
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
       
    }
}

