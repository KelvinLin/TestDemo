using DBFactory.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBFactory.Repository
{
    class CwbDataRepository : BaseRepository, ICwbDataRepository
    {
        internal SFMSEntities SFMSDataContext;
        #region .ctors

        /// <summary>
        /// Prevents objects of this type from being created without using factory.
        /// </summary>
        internal CwbDataRepository(BLFactory factory)
            : base(factory)
        {
        }

        #endregion .ctors       

        public DataLayerMessage AddWeatherInfos(List<tblWeatherInfo> entities)
        {
            DataLayerMessage msg = new DataLayerMessage();
            msg.Valid = false;
            try
            {
                SFMSDataContext.tblWeatherInfo.AddRange(entities);
                msg.Rows = SFMSDataContext.SaveChanges();
                msg.Valid = true;
            }
            catch (Exception ex)
            {

                msg.Message = ex.Message;
            }
            return msg;
        }
    }
}
