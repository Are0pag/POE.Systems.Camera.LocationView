using Scripts.Tools.Interpolation;

namespace Scripts.Systems.Camera.GridView
{
    public interface IFreeViewHandler : IExternalGridViewEventHandler
    {
        void ViewLocation(ShowMapArgs args, IAsyncOperationHandlerInitialized asyncOperationHandler);
    }
}