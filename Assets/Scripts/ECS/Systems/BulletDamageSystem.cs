using ECS.Core.Utils.SystemInterfaces;
using Leopotam.Ecs;

public class CheckDistanseSystem : IEcsUpdateSystem
{
    private readonly EcsWorld _world;

    public void Run()
    {
        // if (_gameStage.Get1(0).Value != EGameStage.Play) return;
        //
        // foreach (var b in _bullets)
        // {
        //     var bulletView = _bullets.Get1(b).Get<BulletView>();
        //     foreach (var e in _enemies)
        //     {
        //         var enemyView = _enemies.Get1(e).View as EnemyView;
        //         if(Vector3.Distance(bulletView.Transform.position, enemyView.Center.position) 
        //            > enemyView.GetTriggerDistance()+ bulletView.GetTriggerDistance()) continue;
        //         
        //         if(enemyView)
        //         {
        //             var damageAdd = _w1.GetEntity(0).Get<DamageComponent>().Value;
        //             _enemies.GetEntity(e).Get<DamageUIEventComponent>().position = enemyView.Transform.position;
        //             _enemies.GetEntity(e).Get<DamageUIEventComponent>().damage = bulletView.Damage + damageAdd;
        //             bulletView.DealDamage(enemyView, damageAdd);
        //         }
        //         _bullets.GetEntity(b).DelAndFire<IsAvailableComponent>();
        //     }
        // }
    }
}


