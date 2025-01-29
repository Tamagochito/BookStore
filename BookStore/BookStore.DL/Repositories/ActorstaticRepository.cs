using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories
{
    //public class WriterStaticRepository : IWriterRepository
    //{
    //    public IEnumerable<Writer> GetWritersByIds(IEnumerable<int> writersIds)
    //    {
    //        var result = new List<Writer>();

    //        foreach (var writersId in writersIds)
    //        {
    //            foreach (var writer in StaticDB.InMemoryDb.Writers)
    //            {
    //                if (writer.Id == writersId)
    //                {
    //                    result.Add(writer);
    //                }
    //            }
    //        }

    //        return result;

    //    }


    //    public Writer? GetById(int id)
    //    {
    //        return StaticDB.InMemoryDb.Writers.
    //            FirstOrDefault(x => x.Id == id);
    //    }
    //}
}
