using DBFactory.Interfaces;
using DBFactory.Repository;
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
        public ICwbDataRepository CwbDataRepository
        {
            [DebuggerStepThrough]
            get
            {
                if (cwbDataRepository == null)
                {
                    cwbDataRepository = new CwbDataRepository(this) { SFMSDataContext = SFMSDataContext };
                }
                return cwbDataRepository;
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
