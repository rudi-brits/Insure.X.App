using Insure.X.Resource.Database.Data;

namespace Insure.X.Domain.Repository;

/// <summary>
/// BaseRepository
/// </summary>
public abstract class BaseRepository
{
    /// <summary>
    /// _filterFields
    /// </summary>
    protected string[]? _filterFields;
    /// <summary>
    /// InsureXDatabase field
    /// </summary>
    protected InsureXDatabase _insureXDatabase;

    /// <summary>
    /// BaseRepository constructor
    /// </summary>
    /// <param name="insureXDatabase"></param>
    protected BaseRepository(InsureXDatabase insureXDatabase)
    {
        _insureXDatabase = insureXDatabase;
    }

    /// <summary>
    /// SetFilterFields
    /// </summary>
    /// <param name="filterFields"></param>
    protected void SetFilterFields(string[] filterFields)
        => _filterFields = filterFields;
}
