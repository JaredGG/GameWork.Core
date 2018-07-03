using System.IO;

namespace GameWork.Core.IO.Readers
{
	public class CSVReader
	{
        private const char Delimiter = ',';
        
        private readonly StreamReader _reader;

		public CSVReader(Stream stream)
		{
			_reader = new StreamReader(stream);
		}  	

		public string[] ReadRow()
		{	
			var line = _reader.ReadLine();
			var cells = line.Split(Delimiter);
			return cells;
		}

		public int Peek()
		{
			return _reader.Peek();
		}
	}
}