using Task1WebService.Models;

namespace Task1WebService.Storage
{
    public static class ItemStore
    {
        private static readonly List<Item> Items = new();
        private static int _nextId = 1;

        public static List<Item> GetAll() => Items;

        public static Item GetById(int id) =>
            Items.FirstOrDefault(x => x.Id == id);

        public static Item Add(Item item)
        {
            item.Id = _nextId++;
            Items.Add(item);
            return item;
        }
    }
}