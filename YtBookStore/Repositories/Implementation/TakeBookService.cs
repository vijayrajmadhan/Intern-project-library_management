using YtBookStore.Models.Domain;
using YtBookStore.Repositories.Abstract;

namespace YtBookStore.Repositories.Implementation
{
    public class TakeBookService : ITakeBookService
    {
        private readonly DatabaseContext context;
        public TakeBookService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(TakeBook model)
        {
            try
            {
                context.TakeBook.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TakeBook FindById(int id)
        {
                return context.TakeBook.Find(id);
        }

        public bool Update(TakeBook model)
        {
            try
            {
                context.TakeBook.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TakeBook> GetAll()
        {
            var data = (from TakeBook in context.TakeBook
                       select new TakeBook
                       {
                            Id = TakeBook.Id,
                            UserName = TakeBook.UserName,
                            Age = TakeBook.Age,
                            Mobile = TakeBook.Mobile,
                            AadharNo = TakeBook.AadharNo,
                            BookTitle = TakeBook.BookTitle,
                            BookCode = TakeBook.BookCode, 
                            Approval = TakeBook.Approval,
                            Date1 = TakeBook.Date1,
                            Date2 = TakeBook.Date2,
                       }
                        ).ToList();
            return data;
        }
        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.TakeBook.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
