using System;
using System.Data;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
// using NpgsqlDriverExtended;

namespace SP_Lab_5
{
    public class StringArrayType //: IUserType
    {
        public virtual object NullSafeGet(IDataReader resultSet, string[] names, object owner)
        {
            int index = resultSet.GetOrdinal(names[0]);
            if (resultSet.IsDBNull(index))
            {
                return null;
            }

            string[] res = resultSet.GetValue(index) as string[];
            if (res != null)
            {
                return res;
            }

            throw new NotImplementedException();
        }
        
        public virtual void NullSafeSet(IDbCommand cmd, object value, int index) 
        {
            IDbDataParameter parameter = ((IDbDataParameter)cmd.Parameters[index]);
            if (value == null)
            {
                if (parameter != null) parameter.Value = DBNull.Value;
            } else
            {
                string[] list = (string[])value;
                if (parameter != null) parameter.Value = list;
            }
        }
        
        public virtual Type ReturnedType {
            get { return typeof(string[]); }
        }
        
        // public SqlType[] SqlTypes {
        //     get { return new SqlType[] { new NpgsqlExtendedSqlType(DbType.Object, 
        //         NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text) }; }
        // }
        
    }
}