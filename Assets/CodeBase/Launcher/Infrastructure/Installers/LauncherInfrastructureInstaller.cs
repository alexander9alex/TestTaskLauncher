using CodeBase.Game;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.Services;
using CodeBase.Launcher.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Launcher.Infrastructure.Installers
{
   public class LauncherInfrastructureInstaller : MonoInstaller
   {
      private const string CoroutineRunnerName = "CoroutineRunner";

      [SerializeField] private Curtain _curtain;

      public override void InstallBindings()
      {
         BindCurtain();
         BindServices();
         BindFactories();
      }

      private void BindServices()
      {
         Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
         Container.BindInterfacesAndSelfTo<LauncherStaticDataService>().AsSingle();
         BindCoroutineRunner();
      }

      private void BindFactories()
      {
         Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<LauncherUiFactory>().AsSingle();
         Container.BindInterfacesAndSelfTo<GameStateMachineFactory>().AsSingle();
      }

      private void BindCurtain() =>
         Container.BindInterfacesAndSelfTo<ICurtain>().FromInstance(_curtain);

      private void BindCoroutineRunner()
      {
         CoroutineRunner coroutineRunner = new GameObject(CoroutineRunnerName).AddComponent<CoroutineRunner>();
         DontDestroyOnLoad(coroutineRunner.gameObject);
         Container.BindInterfacesAndSelfTo<ICoroutineRunner>().FromInstance(coroutineRunner);
      }
   }
}