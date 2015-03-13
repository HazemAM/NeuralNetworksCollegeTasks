using System;
using System.Collections.Generic;
using System.IO;

namespace NeuralNetworks
{
	public class DataSetReader
	{
		public readonly DataSetType type;
		public readonly int classes;	//Number of classes in the data set.
		public readonly int samples;	//Number of samples per class.
		public readonly int features;	//Number of features per sample.
		public readonly int maxValue;	//The maximum value found in the data set.

		public readonly List<double[]>[] data;	//Format: data[class][sample][feature].
		public readonly List<double[]>[] dataNorm;

		//Normalization data:
		public readonly bool normalized;
		private double[] mean;
		private double[] max;

		public DataSetReader(string path, DataSetType type, bool normalizeData)
		{
			this.type = type;
			this.normalized = normalizeData;

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

			//Read the data:
			readData(path);

			//Normalize?
			if(normalizeData){
				dataNorm = new List<double[]>[classes];
				normalize();
			}
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

		private void normalize()
		{
			this.mean = new double[this.features];
			this.max = new double[this.features];

			for(int j = 0; j < this.features; j++)
				for(int k = 0; k < this.classes; k++)
					for(int i = 0; i < this.samples; i++){
						this.mean[j] += this.data[k][i][j];
						if(this.data[k][i][j] > this.max[j])
							this.max[j] = this.data[k][i][j];
					}

			for(int i = 0; i < this.classes; i++)
				this.mean[i] /= (this.classes * this.samples);

			for(int i = 0; i < this.classes; i++){
				this.dataNorm[i] = new List<double[]>();
				for(int j = 0; j < this.samples; j++){
					this.dataNorm[i].Add(new double[this.data[i][j].Length]);
					for(int k = 0; k < this.features; k++)
						this.dataNorm[i][j][k] = (this.data[i][j][k] - this.mean[k]) / this.max[k];
				}
			}
		}
	}
}
