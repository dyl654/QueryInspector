using QueryInspector.Models;

namespace QueryInspector {
	public interface IQueryFactory {
		bool CanParseQuery(string sql);
		ISelectQuery ParseQuery(string sql);
	}
}