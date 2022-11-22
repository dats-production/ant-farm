using DataBase;
using ECS.Components;
using ECS.Components.Events;
using ECS.Components.Flags;
using ECS.Core.Utils.ReactiveSystem.Components;
using ECS.Game.Components;
using ECS.Game.Components.Flags;
using Leopotam.Ecs;
using Services.Uid;
using UnityEngine;

namespace ECS.Utils.Extensions
{
    public static class GameExtensions
    {
        public static EcsEntity CreateCamera(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<PositionComponent>();
            entity.Get<RotationComponent>().Value = Quaternion.Euler(new Vector3(47,0,0));
            
            entity.GetAndFire<CameraComponent>();
            entity.GetAndFire<PrefabComponent>().Value = "MainCamera";
            return entity;
        }

        public static EcsEntity CreateGameStage(this EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<UIdComponent>().Value = UidGenerator.Next();
            entity.Get<GameStageComponent>().Value = EGameStage.Pause;
            return entity;
        }

        public static ref T GetAndFire<T>(this ref EcsEntity entity) where T : struct
        {
            entity.Get<T>();
            entity.Get<EventAddComponent<T>>();
            return ref entity.Get<T>();
        }
        
        public static void DelAndFire<T>(this ref EcsEntity entity) where T : struct
        {
            entity.Del<T>();
            entity.Get<EventRemoveComponent<T>>();
        }
        
        public static void SetGatherState(this ref EcsEntity entity, GatherState state)
        {
            entity.Get<ChangeGatherStateComponent>().State = state;
        }
    }
}