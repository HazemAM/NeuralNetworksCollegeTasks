﻿using System;

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
		public static double[] trim(double[] arr, int length)
		{
			if(arr.Length == length)
				return arr;
			else if(length > arr.Length)
				throw new ArgumentOutOfRangeException("Trimming length is bigger than the vector length");
			
			double[] newArr = new double[length];
			Array.Copy(arr, newArr, length);

			return newArr;
		}
	}
}
