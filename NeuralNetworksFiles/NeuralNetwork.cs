using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
	public abstract class NeuralNetwork
	{
		/*
		 * FIELDS
		 */
		protected double[] target;
		protected double[] weight;
		protected double eta;
		protected List<double[]>[] data;
		protected int samples;
		protected double[] featureMask;
		protected double[] classMask;


		/*
		 * CONSTRUCTORS
		 */
		public NeuralNetwork(DataSetReader dataSet, double[] target, double eta)
		{
			this.target = target;
			this.data = dataSet.data;
			this.featureMask = VectorTools.sequence(dataSet.features);
			this.classMask = VectorTools.sequence(dataSet.classes);
			this.weight = VectorTools.ones(this.featureMask.Length);
			this.samples = dataSet.samples;
			this.eta = eta;
		}

		public NeuralNetwork(DataSetReader dataSet, double[] target, double eta, double[] featureMask, double[] classMask){
			if(featureMask.Length > dataSet.features || featureMask.Length < 1)
				throw new ArgumentOutOfRangeException("Number of features specified is not applicable");

			this.target = target;
			this.data = dataSet.data;
			this.featureMask = featureMask;
			this.classMask = classMask;
			this.weight = VectorTools.ones(this.featureMask.Length);
			this.samples = dataSet.samples;
			this.eta = eta;
		}

		public NeuralNetwork(DataSetReader dataSet, double[] target, double[] weight, double eta)
		{
			this.target = target;
			this.data = dataSet.data;
			this.featureMask = VectorTools.sequence(dataSet.features);
			this.classMask = VectorTools.sequence(dataSet.classes);
			this.samples = dataSet.samples;
			this.weight = weight;
			this.eta = eta;
		}


		/*
		 * ABSTRACTS
		 */
		public abstract void train(int trainCount);
		public abstract int[,] test(int testCount);
		public abstract double classify(double[] input);
	}
}
