using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OM.Lib.Framework.Db.Helper
{
    public class DBHelper
    {
        #region IDBHelper Members

        public int ExecuteNonQuery(IDbCommand comm)
        {
            try
            {
                if (comm == null) return 0;

                int val = comm.ExecuteNonQuery();
                // comm.Parameters.Clear();
                return val;
            }
            catch
            {
                if (comm.Transaction == null)
                    comm.Connection.Close();
                throw;
            }
        }

        public IDataReader ExecuteReader(IDbCommand comm)
        {
            try
            {
                IDataReader rdr = comm.ExecuteReader();

                //comm.Parameters.Clear();

                return rdr;
            }
            catch
            {
                if (comm.Transaction == null)
                    comm.Connection.Close();
                throw;
            }
        }

        public object ExecuteScalar(IDbCommand comm)
        {
            try
            {
                object val = comm.ExecuteScalar();
                //comm.Parameters.Clear();
                return val;
            }
            catch
            {
                if (comm.Transaction == null)
                    comm.Connection.Close();
                throw;
            }
        }

        public DataTable ExecuteDataTable(IDbCommand comm)
        {
            try
            {
                using (IDataReader rdr = ExecuteReader(comm))
                {
                    DataTable dt = new DataTable();

                    dt.Load(rdr);

                    if (!rdr.IsClosed) rdr.Close();

                    //comm.Parameters.Clear();
                    return dt;
                }
            }
            catch
            {
                if (comm.Transaction == null)
                    comm.Connection.Close();
                throw;
            }
        }

        public DataSet ExecuteDataSet(IDbCommand comm, params string[] tables)
        {
            try
            {
                using (IDataReader rdr = ExecuteReader(comm))
                {
                    DataSet ds = new DataSet();

                    ds.Load(rdr, LoadOption.OverwriteChanges, tables);

                    if (!rdr.IsClosed)
                        rdr.Close();

                    //comm.Parameters.Clear();
                    return ds;
                }
            }
            catch
            {
                if (comm.Transaction == null)
                    comm.Connection.Close();
                throw;
            }
        }
        #endregion

        #region UTIL
        private void LogSpName(IDbCommand comm)
        {
            System.Collections.Generic.List<string> spList = new List<string>();

            if (comm.CommandType != CommandType.StoredProcedure)
                return;

            using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\spLog.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    spList.Add(line);
                }
                reader.Close();
            }

            foreach (string spName in spList)
            {
                if (spName == comm.CommandText)
                    return;
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\spLog.txt", true))
            {
                writer.WriteLine(comm.CommandText);
                writer.Close();
            }
        }

        #endregion
    }
}
