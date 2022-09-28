using VisitorManagementStudent2022.Data;
using VisitorManagementStudent2022.Models;

namespace VisitorManagementStudent2022.Services
{
    public class DBCalls : IDBCalls
    {

        private readonly ApplicationDbContext _context;
        public DBCalls(ApplicationDbContext context)
        {
            _context = context;
        }

        //          from[identifier] in [data source]
        //          let[expression]
        //          where[boolean expression]
        //          order by[[expression] (ascending/descending)], [optionally repeat]
        //          select[expression]
        //          group[expression] by[expression] into[expression]


        public IEnumerable<Visitors> WhereQuery()
        {
            var query = from v in _context.Visitors
                        where v.FirstName == "John"
                        select v;

            return query;

        }

        public IEnumerable<StaffNames> WhereMethodSyntax()
        {

            var query = _context.StaffNames.Where(v => v.Name.Contains("l")).Select(a => new StaffNames { Name = a.Name, VisitorCount = a.VisitorCount });

            return query;

        }

        public IEnumerable<StaffNames> OrderBy()
        {

            var query = _context.StaffNames.OrderByDescending(s => s.VisitorCount).Take(5);

            return query;

        }






        public IEnumerable<StaffNames> UniqueVisitorCount()
        {

            return _context.StaffNames.DistinctBy(v => v.VisitorCount);
        }



    }




}
