using System.Linq;

namespace QueryInspector.Parsing {
	public class TokenScanner {
		protected readonly CharacterScanner Scanner;
		public TokenScanner(string input) {
			Scanner = new CharacterScanner(input);
		}

		public virtual Token Read() {
			var current = Scanner.Read().ToString();
			while (Scanner.CharacterIsAvailable) {
				var next = Scanner.Read();
				if (ShouldAdd(current, next)) {
					current += next;
				}
				else {
					Scanner.Rewind();
					return new Token(current);
				}
			}
			return new Token(current);
		}

		protected virtual bool ShouldAdd(string current, char next) {
			var previous = current.Last();
			if (char.IsLetter(previous)) return char.IsLetter(next);
			if (char.IsWhiteSpace(previous)) return char.IsWhiteSpace(next);
			return false;
		}

		public bool TokenIsAvailable => Scanner.CharacterIsAvailable;
	}
}