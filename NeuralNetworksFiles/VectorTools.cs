using System;

namespace NeuralNetworks
{
	static class VectorTools
	{
		/*
		 * MULTIPLICATIONS
		 */
		public static double multiply(double[] arrOne, double[] arrTwo)
		{
			if(arrOne.Length != arrTwo.Length)
				throw new ArgumentException("The two vectors are not of the same length");
			
			double result = 0;
			for(int i=0; i<arrOne.Length; i++)
				result += arrOne[i] * arrTwo[i];

			return result;
		}

		public static double[] multiply(double[] arr, double value)
		{
			double[] result = new double[arr.Length];
			for(int i=0; i<arr.Length; i++)
				result[i] = arr[i] * value;

			return result;
		}


		/*
		 * SUMMATIONS
		 */
		public static double[] sum(double[] arrOne, double[] arrTwo)
		{
			if(arrOne.Length != arrTwo.Length)
				throw new ArgumentException("The two vectors are not of the same length");
			
			double[] result = new double[arrOne.Length];
			for(int i=0; i<arrOne.Length; i++)
				result[i] = arrOne[i] + arrTwo[i];

			return result;
		}

		/*
		 * OTHERS
		 */
		public static double[] trim(double[] arr, double[] mask)
		{
			if(arr.Length == mask.Length)
				return arr;
			else if(mask.Length > arr.Length)
				throw new ArgumentOutOfRangeException("Trimming length is bigger than the vector length");

			double[] newArr = new double[mask.Length];

			int index;
			for(int i=0; i<newArr.Length; i++){
				if(mask[i] > arr.Length) throw new FormatException("Bad mask index");
				index = (int)mask[i] - 1;
				newArr[i] = arr[index];
			}

			return newArr;
		}

		public static double[] ones(int length)
		{
			double[] result = new double[length];
			for(int i=0; i < result.Length; i++)
				result[i] = 1;

			return result;
		}

		public static double[] sequence(int length)
		{
			double[] result = new double[length];
			for(int i=0; i < result.Length; i++)
				result[i] = i+1;

			return result;
		}

		private static int count(double[] arr, double num)
		{
			int result = 0;
			foreach(double e in arr)
				if(e == num) result++;
			
			return result;
		}

		/// <summary>Calculates the accuracy of a confusion matrix.</summary>
		/// <param name="matrix">The confusion matrix.</param>
		/// <returns>The accuracy of the confusion matrix.</returns>
		public static double confusionAccuracy(int[,] matrix)
		{
			int sum;
			double accuracy = 0;
			for(int i=0; i<matrix.GetLength(0); i++){
				sum = 0;
				for(int j=0; j<matrix.GetLength(1); j++)
					sum += matrix[i,j];
				accuracy += (double)matrix[i,i] / (double)sum;
			}

			accuracy /= matrix.GetLength(0);
			return accuracy;
		}
	}
}
