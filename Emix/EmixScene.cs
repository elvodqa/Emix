using System;
using System.Collections.Generic;
using System.Diagnostics;
using Emix.Graphics;
using Emix.Graphics.GUI;
using Emix.Windowing;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Drawable = Emix.Graphics.Drawable;

namespace Emix
{
    public class EmixScene : IDisposable
    {
        #region Internal Variables
        
        internal bool RunApplication;
        internal DialogBox _dialogBox;
        private int CurrentDialogIndex = 0;
        
        #endregion

        #region Destructor

        ~EmixScene()
        {
            Dispose(false);
        }

        #endregion

        private void OnUnhandledException(
            object sender,
            UnhandledExceptionEventArgs args
        )
        {
            if (args.ExceptionObject is Exception)
            {
                var e = (Exception) args.ExceptionObject;
                EmixManager.ShowRuntimeError(e.Message);
                EmixManager.ShowRuntimeError(e.StackTrace);
            }
        }


        private void RunLoop()
        {
            Window.SetVisible(true);
            while (RunApplication)
            {
                Window.DispatchEvents();
                Window.Clear();
                Update();
                Window.Display();
            }

            OnExiting(this, EventArgs.Empty);
        }

        #region Public Properties

        public GameWindow Window;
        public GameTime GameTime;
        public bool DebugInfo = false;

        #endregion

        #region Private Variables

        private bool isDisposed;
        private List<Drawable> drawableComponents;
        private bool hasInitialized;
        private bool suppressDraw;
        private readonly GameTime gameTime;
        private readonly Clock clock;
        private float lastTime;
        private readonly Font font = new("Resources/arial.ttf");
        private Text cursorPositionText;

        #endregion

        public static void SetActiveSpeaker(Character character)
        {
            Global.ActiveSpeaker = character;
            Global.ActiveSpeaker = character;
            Global.ActiveSpeaker = character;
        }
        public static void AddDialog(string context)
        {
            Global.Dialogs.Add(new Dialog(context));
        }

        #region Events

        public event EventHandler<EventArgs> Activated;
        public event EventHandler<EventArgs> Deactivated;
        public event EventHandler<EventArgs> Disposed;
        public event EventHandler<EventArgs> Exiting;

        #endregion

        #region Public Constructor

        public EmixScene()
        {
            Window = Global.Window;
            RunApplication = true;
            clock = new Clock();
            GameTime = new GameTime(Time.Zero, Time.Zero);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            RunApplication = false;
            Window.Close();
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            if (Disposed != null) Disposed(this, EventArgs.Empty);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                    // Dispose loaded game components.
                    /*
                        for (int i = 0; i < Components.Count; i += 1)
                        {
                            IDisposable disposable = Components[i] as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        } */

                    if (Window != null)
                        EmixManager.DisposeWindow(Window);

                AppDomain.CurrentDomain.UnhandledException -= OnUnhandledException;

                isDisposed = true;
            }
        }

        [DebuggerNonUserCode]
        private void AssertNotDisposed()
        {
            if (isDisposed)
            {
                var name = GetType().Name;
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

        protected virtual void Setup(){}
        private void Initialize()
        {
            cursorPositionText = new Text($"{Mouse.GetPosition(Window).X}:{Mouse.GetPosition(Window).Y}",
                font, 12);
            cursorPositionText.Position = new Vector2f(0,
                Window.Size.Y - cursorPositionText.GetLocalBounds().Height * 2);
            Window.SetVerticalSyncEnabled(true);
            Window.SetFramerateLimit(60);
            Window.SetKeyRepeatEnabled(false);
            var icon = new Image("Resources/icon.png");
            Window.SetIcon(icon.Size.X, icon.Size.Y, icon.Pixels);
            _dialogBox = new DialogBox();
            _dialogBox.ChangeText("");
            Window.KeyPressed += (sender, args) =>
            {
                if (args.Code == Keyboard.Key.Space && CurrentDialogIndex < Global.Dialogs.Count)
                {
                    _dialogBox.Name.DisplayedString = Global.Dialogs[CurrentDialogIndex].Speaker;
                   _dialogBox.ChangeText(Global.Dialogs[CurrentDialogIndex].Context);
                   CurrentDialogIndex += 1;
                }
                else
                {
                    EmixManager.ShowRuntimeError("Error switching to next dialog", "Probably end of dialogs");
                }
            };
        }
        
        private void Update()
        {
            if (DebugInfo)
            {
                var currentTime = clock.Restart().AsSeconds();
                var fps = 1.0f / currentTime;
                lastTime = currentTime;
                cursorPositionText.DisplayedString =
                    $"{Mouse.GetPosition(Window).X}:{Mouse.GetPosition(Window).Y}";
                Window.Draw(new Text($"{(int) fps}", font, 12));
                Window.Draw(cursorPositionText);
            }
            
            _dialogBox.Draw();
            
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            if (Exiting != null) Exiting(this, args);
        }

        protected virtual void OnActivated(object sender, EventArgs args)
        {
            AssertNotDisposed();
            if (Activated != null) Activated(this, args);
        }

        protected virtual void OnDeactivated(object sender, EventArgs args)
        {
            AssertNotDisposed();
            if (Deactivated != null) Deactivated(this, args);
        }

        public void Run()
        {
            AssertNotDisposed();

            if (!hasInitialized)
            {
                Setup();
                Initialize();
                hasInitialized = true;
                Window.Closed += OnClosed;
            }


            RunLoop();
        }

        #endregion
    }
}