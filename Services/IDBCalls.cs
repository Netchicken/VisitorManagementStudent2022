using VisitorManagementStudent2022.Models;

namespace VisitorManagementStudent2022.Services
{
    public interface IDBCalls
    {
        IEnumerable<Visitors> WhereQuery();
        IEnumerable<StaffNames> OrderBy();
        IEnumerable<StaffNames> WhereMethodSyntax();
        IEnumerable<StaffNames> UniqueVisitorCount();
    }
}