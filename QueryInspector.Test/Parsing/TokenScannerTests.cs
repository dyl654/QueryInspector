using FluentAssertions;
using NUnit.Framework;
using QueryInspector.Parsing;

namespace QueryInspector.Test.Parsing {
	[TestFixture]
	public class TokenScannerTests {
		[Test]
		public void TokenScannerReturnsOneTokenAtATime() {
			var scanner = new TokenScanner("select * from [users]");
			scanner.Read().Should().Be("select");
			scanner.Read().Should().Be(" ");
			scanner.Read().Should().Be("*");
			scanner.Read().Should().Be(" ");
			scanner.Read().Should().Be("from");
			scanner.Read().Should().Be(" ");
			scanner.Read().Should().Be("[");
			scanner.Read().Should().Be("users");
			scanner.Read().Should().Be("]");
		}

		[Test]
		public void MultipleWhitespaceCharactersAreGrouped() {
			var scanner = new TokenScanner("hello \tworld");
			scanner.Read();
			scanner.Read().Should().Be(" \t");
		}

		[Test]
		public void AbleToDetectIfThereIsStillATokenAvailable() {
			var scanner = new TokenScanner("hello");
			scanner.TokenIsAvailable.Should().BeTrue();
			scanner.Read();
			scanner.TokenIsAvailable.Should().BeFalse();
		}
	}
}