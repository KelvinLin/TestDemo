using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    public static class DataContextManager
    {
        #region Methods (Public)

        /// <summary>
        /// Gets new instance of data context.
        /// </summary>
        /// <returns></returns>
        public static SFMSEntities GetSFMSDataContext()
        {
            return new SFMSEntities();
        }

        /// <summary>
        /// Set Object Context Command TimeOut
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="timeoutSec"></param>
        public static void SetCommandTimeout(DbContext dbContext, int timeoutSec)
        {
            ((IObjectContextAdapter)dbContext).ObjectContext.CommandTimeout = timeoutSec;
        }

        #endregion
    }
}
