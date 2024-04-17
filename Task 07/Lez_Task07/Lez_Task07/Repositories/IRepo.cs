namespace Lez_Task07.Repositories
{
    public interface IRepo<T>
    {
        T? GetById(int id);
        T? GetByCode(string? codice);
        List<T> GetAll();
        bool insert(T t);
        bool update(T t);
        bool delete(int id);

    }
}