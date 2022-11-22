using System.Collections.Generic;

namespace Services.Uid
{
    public static class UidGenerator
    {
        private static readonly HashSet<DataBase.Uid> HashSet = new HashSet<DataBase.Uid>();
        private static int _current;

        public static void Clear()
        {
            _current = 0;
            HashSet.Clear();
        }

        private static int NextUid
        {
            get
            {
                if (_current == int.MaxValue)
                    _current = 0;
                return _current++;
            }
        }

        public static DataBase.Uid Next()
        {
            DataBase.Uid uid;
            do
            {
                uid = (DataBase.Uid) NextUid;
            } while (HashSet.Contains(uid));

            HashSet.Add(uid);
            return uid;
        }

        public static void Reserve(DataBase.Uid uid) => HashSet.Add(uid);

        public static void Remove(DataBase.Uid uid)
        {
            HashSet.Remove(uid);
        }
    }
}