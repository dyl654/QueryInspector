using System.Linq;
using QueryInspector.Models;

namespace QueryInspector
{
    public class ColumnCollector : IColumn
    {
        private readonly string _column;

        public ColumnCollector(string column)
        {
            _column = column;
            Table = GetTableNameFromColumn();
            Name = GetColumnName();
        }

        public string Name { get; }
        public string Alias { get; } = null;
        public ITable Table { get; }

        private string GetColumnName()
        {
            if (!_column.Contains('.')) return _column;
            var columnParts = _column.Split('.');
            return columnParts[1];
        }

        private ITable GetTableNameFromColumn()
        {
            if (!_column.Contains('.')) return null;
            var columnParts = _column.Split('.');
            return new Table
            {
                Name = columnParts[0]
            };
        }
    }
}