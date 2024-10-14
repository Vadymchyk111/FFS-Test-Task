using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelManager>().To<LevelManager>().AsSingle();
        Container.Bind<ISaveSystem>().To<PlayerPrefsSaveSystem>().AsSingle();
        Container.Bind<IHintSystem>().To<HintSystem>().AsSingle();
        Container.Bind<MoneyManager>().AsSingle().NonLazy();
        Container.Bind<LevelSelectController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ShopController>().FromComponentInHierarchy().AsSingle();
    }
}