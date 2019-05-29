using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using OM.Lib.Framework.Base;

namespace OM.Lib.Framework.Db
{
    [Serializable]
    public class Entities :  IEntityArray, IEnumerable
    {
        public System.Collections.Generic.List<IEntity> items;

        /// <summary>
        /// 생성자
        /// </summary>
        public Entities()
        {
            this.items = new List<IEntity>();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="capacity"></param>
        public Entities(int capacity)
        {
            this.items = new List<IEntity>(capacity);
        }



        /// <summary>
        /// 콜렉션에 담긴 객체의 수를 반환한다.
        /// </summary>
        public int Count
        {
            get
            {
                return this.items != null ? items.Count : 0;
            }
        }
        /// <summary>
        /// 콜렉션에서 해당 인덱스에 있는 객체를 리턴합니다.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IEntity GetItem(int index)
        {
            if (this.items.Count >= index - 1)
                return this.items[index];
            else
                return null;
        }

        /// <summary>
        /// 콜렉션에 객체를 추가합니다.
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int index, IEntity item)
        {
            if (item != null)
                this.items.Insert(index, item);
        }

        /// <summary>
        /// 콜렉션에 객체를 추가합니다.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IEntity item)
        {
            if (item != null)
                this.items.Add(item);
        }

        /// <summary>
        /// 콜렉션에서 객체를 제거합니다.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(IEntity item)
        {
            this.items.Remove(item);
        }

        /// <summary>
        /// 콜렉션에세 해당 인덱스에 있는 객체를 제거합니다.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (this.items.Count >= index - 1)
                this.items.RemoveAt(index);
        }

        public List<IEntity> ToList
        {
            get { return items; }
        }
      
        /// <summary>
        /// 콜렉션 내부를 초기화합니다.
        /// </summary>
        public void Clear()
        {
            this.items.Clear();
        }

        #region IEnumerable 멤버

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (IEntity item in items)
            {
                yield return item;
            }
        }

        #endregion

        #region Json
        public string Json
        {
            get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("[");
                    foreach (var m in items)
                    {
                        sb.Append(m.Json);
                        sb.Append(",");
                    }
                    //sb.Append("\"\":\"\"");
                    if(sb.Length > 1)
                        sb.Remove(sb.Length - 1, 1);

                    sb.Append("]");
                    return sb.ToString();
                }
                catch (System.Exception ex) {
                    string err = ex.Message;
                    return "";
                }
            }
        }

        public static string EntitiesToJson<T>(List<T> list)
        {

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("[");
                foreach (var n in list)
                {
                    IEntity m = (IEntity)n;

                    sb.Append(m.Json);
                    sb.Append(",");
                }
                //sb.Append("\"\":\"\"");
                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);

                sb.Append("]");
                return sb.ToString();
            }
            catch (System.Exception ex)
            {
                string err = ex.Message;
                return "";
            }
        }

        public static Entities ListToEntities<T>(List<T> list)
        {

            try
            {
                Entities entities = new Entities(list.Count);
                foreach (var m in list)
                {
                    var iett = m as IEntity;
                    entities.Add(iett);
                }

                return entities;
            }
            catch (System.Exception ex)
            {
                return null;
                throw ex;
            }
        }
        #endregion
    }
}
