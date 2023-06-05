using YtBookStore.Models.Domain;

namespace YtBookStore.Repositories.Abstract
{
    public interface ITakeBookService
    {
        bool Add(TakeBook model);
        object FirstOrDefault(Func<object, bool> value);
        IEnumerable<TakeBook> GetAll();
        bool Update(TakeBook model);
        TakeBook FindById(int id);
        bool Delete(int id);
    }
}
