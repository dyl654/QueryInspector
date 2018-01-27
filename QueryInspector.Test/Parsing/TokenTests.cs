using FluentAssertions;
using NUnit.Framework;
using QueryInspector.Parsing;

namespace QueryInspector.Test.Parsing {
	[TestFixture]
	public class TokenTests {
		[Test]
		public void LookLikeIgnoresCaseSensitivity() {
			var token = new Token("Hello");
			token.LooksLike("hellO").Should().BeTrue();
		}

		[Test]
		public void DifferentStringsDoNotMatch() {
			var token = new Token("ten");
			token.LooksLike("10").Should().BeFalse();
		}

		[Test]
		public void TokenCanBeComparedToAString() {
			var token = new Token("abc");
			token.Should().Be("abc");
		}

		[Test]
		public void ATokenContainingOnlyWhitespaceShouldReturnTrueWhenPollingIsWhitespace() {
			var token = new Token("\r\n \t");
			token.IsWhitespace.Should().BeTrue();
		}

		[Test]
		public void ATokenContainingSomeWhitespaceShouldReturnFalseWhenPollingIsWhitespace() {
			var token = new Token("hello world");
			token.IsWhitespace.Should().BeFalse();
		}

		[Test]
		public void ATokenContainingOnlyCharactersReturnsFalseWhenPollingIsWhitespace() {
			var token = new Token("12a");
			token.IsWhitespace.Should().BeFalse();
		}
	}
}