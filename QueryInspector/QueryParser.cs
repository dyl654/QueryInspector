using System;
using System.Collections.Generic;
using QueryInspector.QueryFactories;

namespace QueryInspector {
	public class QueryParser {
		protected readonly List<IQueryFactory> QueryFactories = new List<IQueryFactory>();
		public QueryParser() {
			QueryFactories.Add(new SelectQueryFactory());
		}
		
		public virtual ISelectQuery Parse(string sql) {
			foreach (var factory in QueryFactories) {
				if (factory.CanParseQuery(sql)) return factory.ParseQuery(sql);
			}
			throw new NotImplementedException();
		}
	}
}