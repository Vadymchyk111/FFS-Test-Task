using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle();
        Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().AsSingle();
        Container.Bind<IHintSystem>().To<HintSystem>().AsSingle();
        Container.Bind<LevelSelectController>().FromComponentInHierarchy().AsSingle();
    }
}