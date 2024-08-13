using Insure.X.Resource.Database.Data;

namespace Insure.X.Domain.Repository;

public abstract class BaseRepository
{
    protected InsureXDatabase _insureXDatabase;

    protected BaseRepository(InsureXDatabase insureXDatabase)
    {
        _insureXDatabase = insureXDatabase;
    }
}
