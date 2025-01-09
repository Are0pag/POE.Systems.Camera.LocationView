using UnityEngine;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal sealed class GridViewInstaller : MonoInstaller
    {
        [SerializeField] private Config _config;
        [SerializeField] private SceneSettings _sceneSettings;
        
        public override void InstallBindings() {
            
            // Entities
            Container.BindInterfacesAndSelfTo<Swapper>().AsSingle().WithArguments(_sceneSettings.Camera, _config.SwapSettings);
            Container.BindInterfacesAndSelfTo<Zoom>().AsSingle().WithArguments(_sceneSettings.Camera, _config);
            Container.BindInterfacesAndSelfTo<LocationViewer>().AsSingle().WithArguments(_sceneSettings.Camera, _config.ViewLocationSettings);
            
            Container.Bind<IFocusCatcher>().To<FocusCatcher>().AsSingle().WithArguments(_sceneSettings.Camera, _config);
            Container.Bind<IFocusable>().To<FocusFollower>().AsSingle().WithArguments(_sceneSettings.Camera);

            Container.BindInterfacesAndSelfTo<LocationViewController>().AsSingle();

            // View States
            Container.Bind<FocusState>().AsSingle();
            Container.Bind<SwapState>().AsSingle();
            Container.Bind<NonUpdatedState>().AsSingle();

            // Interface
            Container.Bind<ViewModule>().AsSingle();
            
            //Utilities
            Container.Bind<LocationViewDataAdapter>().AsSingle();
        }
    }
}