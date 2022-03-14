using System;
using System.Collections.Generic;
using System.Diagnostics;
using Emix.Graphics;
using Emix.Windowing;
using SFML.Graphics;
using SFML.Window;
using Drawable = Emix.Graphics.Drawable;

namespace Emix
{
    public class EmixScene : IDisposable    
    {

        #region Public Properties
        public GameComponentCollection Components
        {
            get;
            private set;
        }
        
        public GameWindow Window
        {
            get;
            private set;
        } 
       

        #endregion
        
        #region Private Variables
        
        private bool isDisposed;
        private List<Drawable> drawableComponents;
        private bool hasInitialized;
        private bool suppressDraw;
        private readonly GameTime gameTime;
        
        #endregion
        
        
        #region Events

        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> Exiting;

        #endregion
        
        #region Internal Variables

        internal bool RunApplication;

        #endregion

        #region Public Constructor
        
        public EmixScene()
        {
            RunApplication = true;
            Window = (GameWindow) new RenderWindow(
	            new VideoMode((uint) Window.ClientBounds.Size.X, (uint) Window.ClientBounds.Size.Y), 
	            Window.Title);
        }
        
        #endregion

        #region Destructor

        ~EmixScene()
        {
            Dispose(false);
        }
        
        #endregion
        
        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // Dispose loaded game components.
                    for (int i = 0; i < Components.Count; i += 1)
                    {
                        IDisposable disposable = Components[i] as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }

                    if (Window != null)
                    {
                        EmixManager.DisposeWindow(Window);
                    }
                    
                }

                AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;

                isDisposed = true;
            }
        }

        [DebuggerNonUserCode]
        private void AssertNotDisposed()
        {
            if (isDisposed)
            {
                string name = GetType().Name;
                throw new ObjectDisposedException(
                    name,
                    string.Format(
                        "The {0} object was used after being Disposed.",
                        name
                    )
                );
            }
        }

        #endregion
        
        #region Protected Methods
        
		protected virtual void Initialize()
		{
			Components = new GameComponentCollection();
			
			for (int i = 0; i < Components.Count; i += 1)
			{
				Components[i].Initialize();
			}
			
		}
		
		protected virtual void Update(GameTime gameTime)
		{
			
			Window.Clear();
			Update(gameTime);
			Window.Display();
		}

		protected virtual void OnExiting(object sender, EventArgs args)
		{
			if (Exiting != null)
			{
				Exiting(this, args);
			}
		}

		protected virtual void OnActivated(object sender, EventArgs args)
		{
			AssertNotDisposed();
			if (Activated != null)
			{
				Activated(this, args);
			}
		}

		protected virtual void OnDeactivated(object sender, EventArgs args)
		{
			AssertNotDisposed();
			if (Deactivated != null)
			{
				Deactivated(this, args);
			}
		}
		
		public void Run()
		{
			AssertNotDisposed();

			if (!hasInitialized)
			{
				Initialize();
				hasInitialized = true;
			}
			
			RunLoop();
			
			
		}

		#endregion
		
        
        private void OnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs args
        ) {
			if (args.ExceptionObject is Exception)
			{
				Exception e = (Exception)args.ExceptionObject;
				EmixManager.ShowRuntimeError(e.Message);
				EmixManager.ShowRuntimeError(e.StackTrace);
			}
        }
        
        
        
        private void RunLoop()
        {
	        while (RunApplication)
	        {
		        
		        Update(gameTime);
		       
	        }
	        OnExiting(this, EventArgs.Empty);
        }



    }
}