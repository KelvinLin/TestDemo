using DBFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DBFactory
{
    public class BLFactory : IDisposable
    {
        #region .ctors

        /// <summary>
        /// Public .ctor.
        /// </summary>
        [DebuggerStepThrough]
        public BLFactory()
            : this(true)
        {
        }

        /// <summary>
        /// Public .ctor.
        /// </summary>
        /// <param name="shareDataContexts"></param>
        [DebuggerStepThrough]
        public BLFactory(bool shareDataContexts)
        {
            this.shareDataContexts = shareDataContexts;
        }

        #endregion .ctors

        #region Fields

        private bool shareDataContexts;
        private ICwbDataRepository cwbDataRepository;
        #endregion Fields

        #region Properties
        private SFMSEntities SFMSContext;


        public SFMSEntities SFMSDataContext
        {
            [DebuggerStepThrough]
            get
            {
                if (SFMSContext == null || !shareDataContexts)
                {
                    SFMSContext = DataContextManager.GetSFMSDataContext();
                }
                return SFMSContext;
            }
            [DebuggerStepThrough]
            set
            {
                SFMSContext = value;
            }
        }


        #endregion

        #region IDisposable Members
      
        public void Dispose()
        {
            if (SFMSContext != null)
            {
                SFMSContext.Dispose();
            }
        }

        #endregion
    }
}
