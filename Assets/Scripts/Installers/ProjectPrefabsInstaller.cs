using DataBase.Objects;
using DataBase.Objects.Impl;
using UnityEngine;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Runtime.Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectPrefabsInstaller", fileName = "ProjectPrefabsInstaller")]
    public class ProjectPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PrefabsBase prefabBase;
        
        public override void InstallBindings()
        {
            Container.Bind<IPrefabsBase>().FromSubstitute(prefabBase).AsSingle();       
        }     
    }
}