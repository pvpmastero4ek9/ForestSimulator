using Unity.AI.Navigation;
using UnityEngine;
using Zenject;

namespace Core.NavMesh
{
    public class NavMeshSurfaceInstaller : MonoInstaller
    {
        [field: SerializeField] private NavMeshSurface _navMeshSurface;
        public override void InstallBindings()
        {
            
            Container
                .Bind<NavMeshSurface>()
                .FromInstance(_navMeshSurface)
                .AsSingle();
        }
    }
}
