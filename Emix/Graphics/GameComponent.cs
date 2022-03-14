using System;

namespace Emix.Graphics
{
    public class GameComponent : IGameComponent, IDisposable, IComparable<GameComponent>
    {
        
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        
        public void Initialize()
        {
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int CompareTo(GameComponent? other)
        {
            //throw new NotImplementedException();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }
    }
}