using System.Linq;
using QueryInspector.Models;

namespace QueryInspector
{
    public class ColumnCollector : IColumn
    {
        public ColumnCollector(string column)
        {
            if (column.Contains('.'))
            {
                var columnParts = column.Split('.');
                Table = new Table
                {
                    Name = columnParts[0]
                };
                Name = columnParts[1];
            }
            else
            {
                Name = column;
            }
        }

        public string Name { get; } = null;
        public string Alias { get; } = null;
        public ITable Table { get; } = null;
    }
}