namespace QueryInspector.Parsing {
	public class CharacterScanner {
		private readonly string _input;
		private int _position;

		public CharacterScanner(string input) {
			_input = input;
		}

		public bool CharacterIsAvailable => _position < _input.Length;

		public char Read() {
			return _input[_position++];
		}

		public void Rewind() {
			_position--;
		}
	}
}