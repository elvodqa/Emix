using System;

namespace Emix.Graphics
{
    public class GameComponentCollectionEventArgs : EventArgs
    {
        #region Public Properties

        public IGameComponent GameComponent
        {
            get;
            private set;
        }

        #endregion

        #region Public Constructors

        public GameComponentCollectionEventArgs(IGameComponent gameComponent)
        {
            GameComponent = gameComponent;
        }

        #endregion
    }
}