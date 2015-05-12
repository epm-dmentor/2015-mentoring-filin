namespace Hash_Table
{
    internal interface IHashTable
    {
        object this[object key] { get; set; }
        bool Contains(object key);
        void Add(object key, object value);
        bool TryGet(object key, out object value);
    }
}