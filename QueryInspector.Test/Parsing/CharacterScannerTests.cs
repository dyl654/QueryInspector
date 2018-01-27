using FluentAssertions;
using NUnit.Framework;
using QueryInspector.Parsing;

namespace QueryInspector.Test.Parsing {
	[TestFixture]
	public class CharacterScannerTests {
		[Test]
		public void CharacterScannerReturnsOneCharacterAtATime() {
			var scanner = new CharacterScanner("abc123");
			scanner.Read().Should().Be('a');
			scanner.Read().Should().Be('b');
			scanner.Read().Should().Be('c');
			scanner.Read().Should().Be('1');
			scanner.Read().Should().Be('2');
			scanner.Read().Should().Be('3');
		}

		[Test]
		public void WhenWeRewind_ThePreviousCharacterIsReturned() {
			var scanner = new CharacterScanner("ab");
			scanner.Read();
			scanner.Rewind();
			scanner.Read().Should().Be('a');
		}

		[Test]
		public void AbleToDetectWhenACharacterIsAvailable() {
			var scanner = new CharacterScanner("a");
			scanner.CharacterIsAvailable.Should().BeTrue();
			scanner.Read();
			scanner.CharacterIsAvailable.Should().BeFalse();
		}

		[Test]
		public void PeekGivesYouTheNextCharacter() {
			var scanner = new CharacterScanner("b");
			scanner.Peek().Should().Be('b');
		}
	}
}