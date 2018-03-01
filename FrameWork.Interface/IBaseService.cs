using System;
using PetaPoco;

namespace FrameWork.Interface
{
    /// <summary>
    /// 接口基类
    /// <remarks>创建：2015.08.13</remarks>
    /// </summary>
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        Object Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        int Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        int Delete(T entity);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="paramsList">参数列表</param>
        /// <returns></returns>
        dynamic GetData(string sql,  object paramsList);

        /// <summary>
        /// 获取对象
        /// </summary>
        Database GetDatabase();
    }
}
