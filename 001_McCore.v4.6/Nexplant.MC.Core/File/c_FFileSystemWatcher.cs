/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2013 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFileSystemWatcher.cs
--  Creator         : byjeon
--  Create Date     : 2014.11.06
--  Description     : FAMate Core FaCommon FileSystemWatcher Class
--  History         : Created by byjeon at 2014.11.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nexplant.MC.Core.FaCommon
{
    public class FFileSystemWatcher : FileSystemWatcher, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        public new event FileSystemEventHandler Changed;
        public new event FileSystemEventHandler Created;
        public new event FileSystemEventHandler Deleted;
        public new event RenamedEventHandler Renamed;

        // -- 

        private bool m_disposed = false;
        // --
        private bool m_enableRecentEventsFilter = false;
        private TimeSpan m_eventFilterTimeSpan;
        private Dictionary<string, DateTime> m_lastFileEvent = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFileSystemWatcher(
            ) : base()
        {
            init();
        }
               
        //------------------------------------------------------------------------------------------------------------------------

        public FFileSystemWatcher(
            string path,
            bool autoStart = false,
            bool enableRecentEventsFilter = true,
            int eventsFilterInterval = 500
            ) : base(path)
        {
            init(autoStart, enableRecentEventsFilter, eventsFilterInterval);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFileSystemWatcher(
            string path,
            string filter,
            bool autoStart = false,
            bool enableRecentEventsFilter = true,
            int eventsFilterInterval = 500
            ) : base(path, filter)
        {
            init(autoStart, enableRecentEventsFilter, eventsFilterInterval);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFileSystemWatcher(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    stop();                    
                }

                base.Dispose();

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public new void Dispose(
            )
        {
            myDispose(true);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int eventsFilterInterval
        {
            get
            {
                try
                {
                    return (int)m_eventFilterTimeSpan.TotalMilliseconds;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_eventFilterTimeSpan = new TimeSpan(0, 0, 0, 0, value);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enableRecentEventsFilter
        {
            get
            {
                try
                {
                    return m_enableRecentEventsFilter;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enableRecentEventsFilter = value;
                    if (eventsFilterInterval == 0)
                    {
                        eventsFilterInterval = 500;
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            bool autoStart = false,
            bool enableRecentEventsFilter = true,
            int eventsFilterInterval = 500
            )
        {
            try
            {
                this.enableRecentEventsFilter = enableRecentEventsFilter;
                this.eventsFilterInterval = eventsFilterInterval;

                // -- 

                if (autoStart)
                {
                    start();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void start(
            )
        {
            try
            {
                m_lastFileEvent = new Dictionary<string, DateTime>();

                // -- 

                base.Created += new FileSystemEventHandler(FFileSystemWatcher_Created);
                base.Changed += new FileSystemEventHandler(FFileSystemWatcher_Changed);
                base.Deleted += new FileSystemEventHandler(FFileSystemWatcher_Deleted);
                base.Renamed += new RenamedEventHandler(FFileSystemWatcher_Renamed);

                // -- 

                this.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void stop(
            )
        {
            try
            {
                this.EnableRaisingEvents = false;

                // --

                base.Created -= new FileSystemEventHandler(FFileSystemWatcher_Created);
                base.Changed -= new FileSystemEventHandler(FFileSystemWatcher_Changed);
                base.Deleted -= new FileSystemEventHandler(FFileSystemWatcher_Deleted);
                base.Renamed -= new RenamedEventHandler(FFileSystemWatcher_Renamed);

                // -- 

                m_lastFileEvent = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool hasOccuredAnotherEvent(
            string filename
            )
        {
            bool retVal = false;
            DateTime now = DateTime.Now;

            try
            {
                if (enableRecentEventsFilter)
                {
                    deleteTimeOverEventsFilter(now);
                    if (m_lastFileEvent.ContainsKey(filename))
                    {
                        m_lastFileEvent[filename] = now;
                        retVal = true;
                    }
                    else
                    {
                        m_lastFileEvent.Add(filename, now);
                    }
                }
                return retVal;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;            
        }


        //------------------------------------------------------------------------------------------------------------------------

        private void deleteTimeOverEventsFilter(
            DateTime now
            )
        {
            TimeSpan eventSpan;
            List<string> deletingFiles = null;

            try
            {
                // ***
                // Selecting OverTime File
                // ***
                deletingFiles = new List<string>();
                foreach (KeyValuePair<string, DateTime> fileEvent in m_lastFileEvent)
                {
                    eventSpan = now - fileEvent.Value;
                    if (eventSpan >= m_eventFilterTimeSpan)
                    {
                        deletingFiles.Add(fileEvent.Key);
                    }
                }

                // --

                // ***
                // Deleting Selected Items
                // ***
                foreach (string file in deletingFiles)
                {
                    m_lastFileEvent.Remove(file);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                deletingFiles = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FileSystemWatcher Event Handler

        private void FFileSystemWatcher_Created(
            object sender,
            FileSystemEventArgs e
            )
        {
            if(!hasOccuredAnotherEvent(e.FullPath))
            {
                onCreated(e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FFileSystemWatcher_Changed(
            object sender,
            FileSystemEventArgs e
            )
        {
            if (!hasOccuredAnotherEvent(e.FullPath))
            {
                onChanged(e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FFileSystemWatcher_Deleted(
            object sender,
            FileSystemEventArgs e
            )
        {
            if (!hasOccuredAnotherEvent(e.FullPath))
            {
                onDeleted(e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FFileSystemWatcher_Renamed(
            object sender,
            RenamedEventArgs e
            )
        {
            if (!hasOccuredAnotherEvent(e.FullPath))
            {
                onRenamed(e);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FileSystemWatch Event Methods

        protected virtual void onCreated(
            FileSystemEventArgs e
            )
        {
            if (Created != null)
            {
                Created(this, e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void onChanged(
            FileSystemEventArgs e
            )
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void onDeleted(
            FileSystemEventArgs e
            )
        {
            if (Deleted != null)
            {
                Deleted(this, e);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void onRenamed(
            RenamedEventArgs e
            )
        {
            if (Renamed != null)
            {
                Renamed(this, e);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end