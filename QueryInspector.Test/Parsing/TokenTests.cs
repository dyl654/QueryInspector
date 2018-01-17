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
	}
}