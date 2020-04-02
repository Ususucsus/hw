namespace ConsoleMovements
{
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Represents a class for store game map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Array to store map.
        /// </summary>
        private readonly char[,] map;

        /// <summary>
        /// Allowed symbols in save file.
        /// </summary>
        private readonly char[] allowedSymbols = {'.', '@', 'x'};

        /// <summary>
        /// Map height.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Map width.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Hero position row.
        /// </summary>
        public int HeroRow { get; set; }

        /// <summary>
        /// Hero position column.
        /// </summary>
        public int HeroColumn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class. Loads map from save file.
        /// </summary>
        /// <param name="filePath">Path to save file. Default - "map.save"</param>
        /// <exception cref="InvalidSaveFileException">Invalid save file format</exception>
        public Map(string filePath="map.save")
        {
            using TextReader saveFile = File.OpenText(filePath);
            
            if (int.TryParse(saveFile.ReadLine(), out var width) == false ||
                int.TryParse(saveFile.ReadLine(), out var height) == false)
                throw new InvalidSaveFileException();

            if (height > 21 || width > 80)
                throw new InvalidSaveFileException();

            this.Height = height;
            this.Width = width;

            map = new char[height, width];

            for (var lineIndex = 0; lineIndex < height; ++lineIndex)
            {
                var line = saveFile.ReadLine();

                if (line == null || line.Length != width)
                    throw new InvalidSaveFileException();

                for (var symbolIndex = 0; symbolIndex < width; ++symbolIndex)
                {
                    var symbol = line[symbolIndex];

                    if (allowedSymbols.Contains(symbol) == false)
                        throw new InvalidSaveFileException();

                    map[lineIndex, symbolIndex] = symbol;

                    if (symbol == '@')
                    {
                        this.HeroRow = lineIndex;
                        this.HeroColumn = symbolIndex;
                    }
                }
            }
        }

        /// <summary>
        /// Indexator for map
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="col">column index</param>
        public char this[int row, int col]
        {
            get => this.map[row, col];
            set => this.map[row, col] = value;
        }

        /// <summary>
        /// Convert map to string
        /// </summary>
        /// <returns>converted map</returns>
        public override string ToString()
        {
            var result = "";

            for (var i = 0; i < this.Height; ++i)
            {
                for (var j = 0; j < this.Width; ++j)
                {
                    result += this.map[i, j];
                }

                result += '\n';
            }

            return result;
        }
    }
}