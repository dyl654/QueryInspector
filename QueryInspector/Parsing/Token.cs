using System;

namespace QueryInspector.Parsing {
	public class Token {
		private readonly string _contents;

		public Token(string contents) {
			_contents = contents;
		}

		public override string ToString() {
			return _contents;
		}

		public bool LooksLike(string comparison) {
			return string.Equals(_contents, comparison, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}