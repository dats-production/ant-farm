using UnityEngine;

namespace DataBase.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Settings/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private AntConfig antConfig;  
        [SerializeField] private PoolConfig poolConfig;      
        [SerializeField] private AppleConfig appleConfig;      
        [SerializeField] private ChunkConfig chunkConfig;      

        public AntConfig AntConfig => antConfig;
        public PoolConfig PoolConfig => poolConfig;
        public AppleConfig AppleConfig => appleConfig;
        public ChunkConfig ChunkConfig => chunkConfig;
    }
}