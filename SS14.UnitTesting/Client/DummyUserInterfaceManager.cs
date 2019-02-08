using System.Collections.Generic;
using SS14.Client;
using SS14.Client.Graphics;
using SS14.Client.Graphics.Clyde;
using SS14.Client.Input;
using SS14.Client.Interfaces.UserInterface;
using SS14.Client.UserInterface;
using SS14.Client.Utility;

namespace SS14.UnitTesting.Client
{
    internal class DummyUserInterfaceManager : IUserInterfaceManagerInternal
    {
        public UITheme Theme { get; }

        public Control Focused => throw new System.NotImplementedException();

        public Control StateRoot => throw new System.NotImplementedException();

        public Control WindowRoot => throw new System.NotImplementedException();

        public Control RootControl => throw new System.NotImplementedException();

        public IDebugMonitors DebugMonitors => throw new System.NotImplementedException();

        public void DisposeAllComponents()
        {
            throw new System.NotImplementedException();
        }

        public void FocusEntered(Control control)
        {
            throw new System.NotImplementedException();
        }

        public void FocusExited(Control control)
        {
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Popup(string contents, string title = "Alert!")
        {
            throw new System.NotImplementedException();
        }

        public void PreKeyDown(KeyEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void PreKeyUp(KeyEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void Render(IRenderHandle renderHandle)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<(GodotAsset asset, int resourceId), object> GodotResourceInstanceCache { get; } =
            new Dictionary<(GodotAsset asset, int resourceId), object>();

        public void UnhandledKeyDown(KeyEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void UnhandledKeyUp(KeyEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void UnhandledMouseDown(MouseButtonEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void UnhandledMouseUp(MouseButtonEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProcessFrameEventArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}
