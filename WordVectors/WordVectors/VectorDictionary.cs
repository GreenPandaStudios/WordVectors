using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVectors
{
    /// <summary>
    /// Creates a dictionary from a textfile and nDimensional vectors
    /// </summary>
    public class VectorDictionary
    {
        private int dimension;
        public int Dimension
        {
            get => dimension;
        }
        public Dictionary<string, DimVector> wordVectors;

        public VectorDictionary()
        {
            wordVectors = new Dictionary<string, DimVector>();
            dimension = 0;
        }
        /// <summary>
        /// Creates a new vector dictionary from a text file of vectors of the specified dimension
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dimension"></param>
        public VectorDictionary(string filePath, int dimension)
        {
            this.dimension = dimension;
            wordVectors = new Dictionary<string, DimVector>();
            string line;
            FileStream file = File.OpenRead(filePath);
            StreamReader stream = new StreamReader(file);
                while (!stream.EndOfStream)
                {
                
                    Console.WriteLine("\nReading Line....");
                    line = stream.ReadLine();
                    Console.WriteLine("\n...Parsing Data...");
                    string[] _parsed = line.Split(' ');


                    string _key = _parsed[0];
                    Console.WriteLine("\n...Generating Vectors for..." + _key + "...");
                    //now create a new DimensionalVector to the dictionary
                    DimVector _value = new DimVector(dimension);
                    for (int i = 0; i < dimension; i++)
                    {
                        _value.Elements[i] = float.Parse(_parsed[i + 1]);
                    }
                    //add this to the dictionary
                    Console.WriteLine("\n...adding to dictionary...");
                    wordVectors.Add(_key, _value);
                    Console.WriteLine("\n...Done");
               
                 }

            stream.Close();
            file.Close();
        }

        public DimVector SentenceVector(string[] words)
        {
            int d = words.Length;
            if (d <= 0) return null;

            DimVector _sentence = new DimVector(Dimension);
            for (int i = 0; i <d; i++)
            {
                if (wordVectors.ContainsKey(words[i]))
                {
                    _sentence = DimVector.Add(_sentence, wordVectors[words[i]]);
                }
               
            }
            return _sentence;
        }
    }
}
