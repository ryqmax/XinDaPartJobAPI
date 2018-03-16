using System;
using FrameWork.Common.ReadSql;
using FrameWork.Interface;
using PetaPoco;

namespace FrameWork.ServiceImp
{
    /// <summary>
    /// 服务基类
    /// <remarks>创建：2015.08.13</remarks>
    /// </summary>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected Database DbQuestionBank = new Database(CachedConfigContext.Current.DaoConfig.QuestionBank);

        public BaseService() { }
        public BaseService(Database currDb)
        {
            //db = currDb;
        }
        public object Add(T entity) { return DbQuestionBank.Insert(entity); }

        public int Update(T entity) { return DbQuestionBank.Update(entity); }

        public int Delete(T entity) { return DbQuestionBank.Delete(entity); }
        public dynamic GetData(string sql, object paramsList)
        {
            try
            {
                return DbQuestionBank.Fetch<T>(sql, paramsList);
            }
            catch (Exception ex)
            {
                // ignored
            }

            return null;
        }

        public Database GetDatabase()
        {
            return DbQuestionBank;
        }
    }
}
