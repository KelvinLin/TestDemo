using System;
using System.Collections.Generic;
using System.Text;

namespace DBFactory
{
    /// <summary>
    /// Base abstract class for all business layer data managers.
    /// </summary>
    public abstract class BaseRepository
    {
        
        internal BaseRepository()
        {
        }

        internal BaseRepository(BLFactory factory)
        {
            this.factory = factory;
        }

        private BLFactory factory;
        private SFMSEntities SFMSContext;


        public BLFactory Factory
        {          
            get
            {
                if (factory == null)
                {
                    factory = new BLFactory();
                }
                return factory;
            }
        }

        public SFMSEntities SFMSEntities
        {
       
            get
            {
                return SFMSContext;
            }
  
            internal set
            {
                SFMSContext = value;
            }
        }
    }
}
