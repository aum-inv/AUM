using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OM.Lib.Framework.Base
{
    public interface IEntityArray
    {
        /// <summary>
        /// Entity들의 수
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 특정 위치의 Entity를 가져온다.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IEntity GetItem(int index);
        /// <summary>
        /// 엔티티 추가
        /// </summary>
        /// <param name="item"></param>
        void Add(IEntity item);
        /// <summary>
        /// 엔티티 삭제
        /// </summary>
        /// <param name="item"></param>
        void Remove(IEntity item);
        /// <summary>
        /// 특정 위치의 엔티티 삭제
        /// </summary>
        /// <param name="index"></param>
        void RemoveAt(int index);
        /// <summary>
        /// 엔티티 목록 전체 삭제
        /// </summary>
        void Clear();

        string Json
        {
            get;
        }
    }
}
