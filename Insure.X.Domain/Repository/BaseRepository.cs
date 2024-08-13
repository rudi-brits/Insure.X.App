using Insure.X.Resource.Database.Data;

namespace Insure.X.Domain.Repository;

public abstract class BaseRepository
{
    protected string[]? _filterFields;

    protected InsureXDatabase _insureXDatabase;

    protected BaseRepository(InsureXDatabase insureXDatabase)
    {
        _insureXDatabase = insureXDatabase;
    }

    protected void SetFilterFields(string[] filterFields)
        => _filterFields = filterFields;
}
