namespace DataBase.Config
{
    public interface IGameConfig
    {
        AntConfig AntConfig { get; }
        PoolConfig PoolConfig { get; }
        AppleConfig AppleConfig { get; }
        ChunkConfig ChunkConfig { get; }
    }
}