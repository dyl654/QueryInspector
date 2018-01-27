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
				if (!ShouldAddAnotherCharacter(current)) break;
				current += Scanner.Read();
			}
			return new Token(current);
		}

		protected virtual bool ShouldAddAnotherCharacter(string current) {
			var previous = current.Last();
			var next = Scanner.Peek();
			return CharacterTypeMatches(previous, next);
		}

		protected virtual bool CharacterTypeMatches(char previous, char next) {
			if (char.IsLetter(previous)) return char.IsLetter(next);
			if (char.IsWhiteSpace(previous)) return char.IsWhiteSpace(next);
			return false;
		}

		public bool TokenIsAvailable => Scanner.CharacterIsAvailable;
	}
}