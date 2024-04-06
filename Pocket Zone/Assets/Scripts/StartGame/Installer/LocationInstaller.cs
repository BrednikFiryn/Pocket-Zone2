using UnityEngine;
using Zenject;

namespace ZenjectName
{
    public partial class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private BindBullet bindBullet;
        [SerializeField] private SettingsPlayer settingsPlayer;

        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            bindbullethero();
            BindSoldier();
        }

        private void BindSoldier()
        {
            MoveAbility _moveAbility = Container
          .InstantiatePrefabForComponent<MoveAbility>(settingsPlayer.hero, startPoint.position, Quaternion.identity, null);

            Container
                .Bind<MoveAbility>()
                .FromInstance(_moveAbility)
                .AsSingle()
                .NonLazy();
        }

        private void bindbullethero()
        {
            Container
                 .Bind<BindBullet>().FromInstance(bindBullet)
                .AsSingle()
                .NonLazy();
        }

        private void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<LocationInstaller>()
                .FromInstance(this)
                .AsSingle()
                .NonLazy();
        }
    }
}