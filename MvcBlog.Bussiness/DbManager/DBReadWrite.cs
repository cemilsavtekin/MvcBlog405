using MvcBlog.DataAccess.Concrete;
using MvcBlog.DataAccess.Concrete.EntitiyFramework;
using MvcBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcBlog.Bussiness.DbManager
{
    public class DBReadWrite<TEntity> where TEntity : class, IEntity, new()
    {
        static Repository<TEntity, BlogContext> db = new Repository<TEntity, BlogContext>();

        public static void Add(TEntity entity)
        {
            db.Add(entity);
        }

        public static void Update(TEntity entity)
        {
            BlogContext blogContext = new BlogContext();
            //blogContext.Set<TEntity>().Find()
            db.Update(entity);
        }

        public static void Delete(TEntity entity)
        {
            db.Delete(entity);
        }

        public static List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return db.GetAll(filter);
        }
        public static TEntity GetEntity(Expression<Func<TEntity, bool>> filter)
        {
            return db.GetEntity(filter);
        }


        //aşağıdaki kod db first kullanılırsa daha sağlıklı olur aşağıdaki kod
        public static List<TEntity> ExecuteSP(string SPName, params object[] parameterValue)
        {
            BlogContext context = new BlogContext();

            string query = $"exec {SPName}";

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            if (parameterValue != null)
            {
                for (int i = 0; i < parameterValue.Length; i++)
                {
                    query += $"@param{i.ToString()}";
                    sqlParams.Add(new SqlParameter(i.ToString(), (parameterValue[i] ?? DBNull.Value)));
                    if (i < parameterValue.Length - 1)
                    {
                        query += ",";
                    }
                }
            }

            var result = context.Database.SqlQuery<TEntity>(query, sqlParams.ToArray());

            return result.Cast<TEntity>().ToList();
        }

    }
}
