using brandlessBar.Data.Models;

namespace brandlessBar.Data.Repositories;

public interface IAlternativeRepository
{
    public Task<Alternative?> Get(int id);
    public Task<Alternative?> Get(Ingredient ingredient);

    public Task<List<Alternative>> GetAll();

    public bool Create(Alternative alternative);
    public bool Update(Alternative alternative);
    public bool Delete(Alternative alternative);

}