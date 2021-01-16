using System;
using System.Collections.Generic;
using System.Text;

namespace Wxg.Utils
{
    public class CollectionUtil
    {
        public static void Combine<TKey,TValue>(Dictionary<TKey, TValue> dicFrom, Dictionary<TKey, TValue> dicTo)
        {
            if (dicFrom == null) return;
            if (dicTo == null) return;
            foreach (KeyValuePair<TKey, TValue> kv in dicFrom)
            {
                dicTo[kv.Key] = kv.Value;
            }
        }
        /// <summary>
        /// 辞書を探して、内容を返す。辞書に見つからない場合、Keyをそのまま返す。
        /// </summary>
        /// <param name="map">参照リスト</param>
        /// <param name="key">参照キー</param>
        /// <returns>参照結果</returns>
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
    }
}
