using System;
using System.IO;

namespace WordVectors
{/// <summary>
/// This is a float vector of a specified dimension
/// </summary>
    public class DimVector
    {
        private float[] elements;
        private int dimension;
        public int Dimension
        {
            get => dimension;
        }

        public float[] Elements
        {
            get => elements;
            set => elements = value;
        }

        public double Magnitude
        {
            get
            {
                double _sum = 0;
                for (int i = 0; i < dimension; i++)
                {
                    _sum +=  Math.Pow(Elements[i],2);
                }
                return Math.Sqrt(_sum);
            }
        }

        public DimVector(int dimension)
        {
            this.dimension = dimension;
            elements = new float[dimension];
            for (int i = 0; i < dimension; i++) elements[i] = 0;
        }

        public DimVector()
        {
            this.dimension = 0;
            elements = new float[0];
        }

        /// <summary>
        /// Adds two dimvectors together and returns the result
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DimVector Add(DimVector first, DimVector second)
        {
            if (first.Dimension <= second.Dimension)
            {
                int d = first.Dimension;
                DimVector newVector = new DimVector(d);

                for (int i = 0; i < d;i++)
                {
                    newVector.Elements[i] = first.elements[i] + second.elements[i];
                }
                return newVector;
            }
            else
            {
                return DimVector.Add(second, first);
            }
            
        }

        public static double Dot(DimVector first, DimVector second)
        {
            if (first.Dimension != second.Dimension) return double.MaxValue;

            double _dot = 0;
            for (int i = 0; i < first.Dimension; i++) {
                _dot += ((double) first.Elements[i] * (double) second.Elements[i]);
            }

            return _dot;
        }
        /// <summary>
        /// returns the cosine similiarity of two Vectors
        /// </summary>
        public static double CSim(DimVector first, DimVector second)
        {
            if (first.Dimension != second.Dimension) return double.MaxValue;

            double _csim = Dot(first, second);
            _csim /= (first.Magnitude * second.Magnitude);
            return _csim;
        }

        public override string ToString()
        {
            string _s = "(  ";
            for (int i = 0; i < dimension; i++)
            {
                _s += elements[i].ToString()+"  ";
            }
            _s += ")";
            return _s;
        }
    }
}
