using System;

namespace DataBase.Config
{
    [Serializable]
    public struct PoolConfig
    {
        public int countPerAdd;
        public int antCount;
        public int chunkCount;
    }
}