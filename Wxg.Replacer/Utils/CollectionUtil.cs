using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace Wxg.Utils
{
    public class CollectionUtil
    {
        public static void Combine<TKey,TValue>(Dictionary<TKey, TValue> dicFrom, 
                                                Dictionary<TKey, TValue> dicTo)
        {
            if (dicFrom == null) return;
            if (dicTo == null) return;

            foreach (KeyValuePair<TKey, TValue> kv in dicFrom)
            {
                dicTo[kv.Key] = kv.Value;
            }
        }

        public static TV GetValue<TK, TV>(Dictionary<TK, TV> map, TK key)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            }
            else
            {
                return default(TV);
            }
        }

        public static string ToString(DataRow row)
        {
            StringBuilder sbRow = new StringBuilder();
            sbRow.Append(row.Table.TableName).Append(":");
            foreach (DataColumn col in row.Table.Columns)
            {
                // skip DataRelation.
                if (col.ColumnName.EndsWith("_Id")) continue;

                if (!row.IsNull(col))
                {
                    sbRow.Append(" ");
                    sbRow.Append(col.ColumnName).Append("=");
                    sbRow.Append(row[col].ToString().Trim());
                    sbRow.Append(" ");
                }
                
            }
            return sbRow.ToString();
        }

    }
}
