using System;
using System.Linq;

namespace QueryInspector.Parsing {
	public class Token {
		public string Contents { get; }

		public bool IsWhitespace => Contents.All(char.IsWhiteSpace);

		public Token(string contents) {
			Contents = contents;
		}

		public override string ToString() => Contents;

		public bool LooksLike(string comparison) => Equals(comparison);
		protected bool Equals(Token other) => Equals(other.Contents);
		protected bool Equals(string other) {
			return string.Equals(Contents, other, StringComparison.InvariantCultureIgnoreCase);
		}

		#region Equals

		public override bool Equals(object obj) {
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj is string s) return Equals(s);
			return obj.GetType() == GetType() && Equals((Token) obj);
		}

		public override int GetHashCode() {
			return (Contents != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(Contents) : 0);
		}

		public static bool operator ==(Token left, Token right) {
			return Equals(left, right);
		}

		public static bool operator !=(Token left, Token right) {
			return !Equals(left, right);
		}

		#endregion
	}
}