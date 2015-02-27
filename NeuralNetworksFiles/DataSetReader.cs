using System;
using System.Collections.Generic;
using System.IO;

namespace NeuralNetworks
{
	class DataSetReader
	{
		public readonly DataSetType type;
		public readonly int classes;
		public readonly int features;
		public readonly int samples;	//Number of samples per class.
		public readonly int maxValue;

		public readonly List<double[]>[] data;

		public DataSetReader(string path, DataSetType type)
		{
			this.type = type;

			switch(type){
			case DataSetType.IRIS:
				this.classes = 3;
				this.features = 4;
				this.samples = 50;
				this.maxValue = 8;
				break;
			}

			//Initialize data container:
			data = new List<double[]>[classes];
			for(int i=0; i<classes; i++)
					data[i] = new List<double[]>();

			readData(path);
		}

		private void readData(string path)
		{
			StreamReader file = new StreamReader(path); //Alternative: File.ReadAllLines(path).

			string line;
			string[] lineSplitted;
			for(int i=0; (line = file.ReadLine()) != null; i++)
			{
				switch(type){
				case DataSetType.IRIS:
					lineSplitted = line.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
					if(lineSplitted.Length == 5) appendToIrisData(lineSplitted);
					break;
				}
			}

			file.Close();
		}

		private void appendToIrisData(string[] line)
		{
			int c = getIrisClassIndex(line[4]);
			string[] newLine = new string[features];
			Array.Copy(line, newLine, features);
			data[c].Add( Array.ConvertAll(newLine,Double.Parse) );
		}

		private int getIrisClassIndex(string name)
		{
			switch(name){
			case("Iris-setosa"):
				return 0;
			case("Iris-versicolor"):
				return 1;
			case("Iris-virginica"):
				return 2;
			default:
				throw new FormatException();
			}
		}
	}
}
