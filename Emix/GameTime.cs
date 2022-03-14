using SFML.System;

namespace Emix
{
    public class GameTime
    {
        #region Public Properties

        public Time TotalGameTime
        {
            get;
            internal set;
        }

        public Time ElapsedGameTime
        {
            get;
            internal set;
        }

        public bool IsRunningSlowly
        {
            get;
            internal set;
        }

        #endregion

        #region Public Constructors

        public GameTime()
        {
            TotalGameTime = Time.Zero;
            ElapsedGameTime = Time.Zero;
            IsRunningSlowly = false;
        }

        public GameTime(Time totalGameTime, Time elapsedGameTime)
        {
            TotalGameTime = totalGameTime;
            ElapsedGameTime = elapsedGameTime;
            IsRunningSlowly = false;
        }

        public GameTime(Time totalRealTime, Time elapsedRealTime, bool isRunningSlowly)
        {
            TotalGameTime = totalRealTime;
            ElapsedGameTime = elapsedRealTime;
            IsRunningSlowly = isRunningSlowly;
        }

        #endregion
                
    }
}