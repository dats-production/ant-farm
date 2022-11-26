using ECS.Components;
using ECS.Components.Flags;
using ECS.Components.Resources;
using ECS.Core.Utils.SystemInterfaces;
using ECS.Game.Components.Listeners.Impl;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Services.Uid;

public class AddPoolMembersSystem : IEcsUpdateSystem
{
    private EcsFilter<AntComponent, IsAvailableComponent> _ants;
    private EcsFilter<ChunkComponent, IsAvailableComponent> _chunks;

    private readonly EcsFilter<GameStageComponent> _gameStage;
    private readonly EcsWorld _world;

    private int startAntCount = 5;
    private int startChunkCount = 300;

    private int countPerAdd = 10;

    public void Run()
    {
        //if (_gameStage.Get1(0).Value != EGameStage.Play) return;
        if (_ants.GetEntitiesCount() < countPerAdd)
            AddPoolMember<AntComponent>("Ant", startAntCount);
        if (_chunks.GetEntitiesCount() < countPerAdd)
            AddPoolMember<ChunkComponent>("Chunk", startChunkCount);
    }

    private void AddPoolMember<T>(string name, int countPerAdd) where T : struct
    {
        for (int i = 0; i < countPerAdd; i++)
        {
            var entity = _world.NewEntity();
            entity.Get<T>();
            entity.Get<UidComponent>().Value = UidGenerator.Next();
            entity.Get<IsAvailableListenerComponent>();
            entity.GetAndFire<PrefabComponent>().Value = name;
            entity.GetAndFire<IsAvailableComponent>();
        }
        //Debug.Log($"ADDED {name}. Available: {_world.GetFilter(typeof(EcsFilter<T, IsAvailableComponent>)).GetEntitiesCount()}. All: {_world.GetFilter(typeof(EcsFilter<T>)).GetEntitiesCount()}");
    }
}