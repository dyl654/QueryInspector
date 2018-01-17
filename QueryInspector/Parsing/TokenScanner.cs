using System.Linq;

namespace QueryInspector.Parsing {
	public class TokenScanner {
		private readonly CharacterScanner _scanner;
		public TokenScanner(string input) {
			_scanner = new CharacterScanner(input);
		}

		public string Read() {
			var current = _scanner.Read().ToString();
			while (_scanner.CharacterIsAvailable) {
				var next = _scanner.Read();
				if (ShouldAdd(current, next)) {
					current += next;
				}
				else {
					_scanner.Rewind();
					return current;
				}
			}
			return current;
		}

		public bool ShouldAdd(string current, char next) {
			var previous = current.Last();
			if (char.IsLetter(previous)) return char.IsLetter(next);
			if (char.IsWhiteSpace(previous)) return char.IsWhiteSpace(next);
			return false;
		}
	}
}