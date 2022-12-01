using Components.Interfaces;
using Controllers.Interfaces;
using Entities;
using GameContext.Interfaces;
using Services.Interfaces;
using System;
using UnityEngine;

namespace Controllers
{
    [Serializable]
    public sealed class EnemyDesc
    {
        public GameObject enemyPrefab;
        public bool isRecount;
        public int count;
    }

    public sealed class EnemyController : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private Transform zoneTopLeft;
        [SerializeField]
        private Transform zoneBottomRight;
        [SerializeField]
        private GameObject parentObject;
        [SerializeField]
        private EnemyDesc[] enemyPrefabList;
        [SerializeField]
        private float distanceFromPlayerToCreateEnemy = 40f;

        private IEntity player;
        private IGameContext context;
        private IGetPositionComponent position;
        private ICollisionObserver collisionObserver;


        public void Create()
        {
            for(int i = 0; i < enemyPrefabList.Length; i++)
            {
                for(int j = 0; j < enemyPrefabList[i].count; j++)
                {
                    CreateEnemy(enemyPrefabList[i].enemyPrefab, enemyPrefabList[i].isRecount);
                }
            }
        }


        public void CreateEnemy(GameObject prefab, bool isRecount)
        {
            if(position is null) return;

            var xmin = position.GetPosition().z + distanceFromPlayerToCreateEnemy;
            var x = UnityEngine.Random.Range(zoneTopLeft.position.x, zoneBottomRight.position.x);
            var y = UnityEngine.Random.Range(zoneBottomRight.position.y, zoneTopLeft.position.y);
            var z = UnityEngine.Random.Range(xmin, zoneTopLeft.position.z);
            var obj = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity, parentObject.transform);

            if(obj.TryGetComponent(out IEntity entity))
            {
                entity.TryGet(out ITriggerTwoColliderEventsComponent triger);
                if(triger != null)
                    collisionObserver.AttachObject(triger);
                else Debug.LogError($"NOT ColliderTriger in ENTITY {obj.name}");
                if(isRecount)
                {
                    entity.TryGet(out IOnDeathSubscriptionComponent subsc);
                    if(subsc != null)
                        subsc.OnDeath += onEnemyDeath;
                    else Debug.LogError($"NOT IOnDeathSubscriptionComponent in ENTITY {obj.name}");
                }
            }
            else
            {
                Debug.LogError($"NOT ENTITY {obj.name}");
            }
        }

        public void onEnemyDeath(IEntity entity)
        {
            entity.TryGet(out IOnDeathSubscriptionComponent subsc);
            if(subsc != null) subsc.OnDeath -= onEnemyDeath;

            for(int i = 0; i < enemyPrefabList.Length; i++)
            {
                if(enemyPrefabList[i].isRecount)
                {
                    CreateEnemy(enemyPrefabList[i].enemyPrefab, enemyPrefabList[i].isRecount);
                    return;
                }
            }

        }

        public void OnStartGame()
        {
            enabled = false;
            player = context.GetService<ICharacterService>().GetCharacter();
            position = player.Get<IGetPositionComponent>();
            collisionObserver = context.GetService<CollisionObserver>();
            Create();
        }

        public void Construct(IGameContext context)
        {
            this.context = context;
        }

        public void OnFinishGame()
        {
            player = null;
            position = null;
            enabled = false;
        }

    }
}
