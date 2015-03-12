using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    class LMS : NeuralNetwork
    {
        public LMS(DataSetReader dataSet, double[] target, double eta, double bias)
			: base(dataSet, target, eta, bias)
		{
            this.data=VectorTools.normalize(dataSet);
        }
        public LMS(DataSetReader dataSet, double[] target, double eta, double bias, double[] featureMask, double[] classMask)
			: base(dataSet, target, eta, bias, featureMask, classMask)
		{
            this.data = VectorTools.normalize(dataSet);
        }
        public LMS(DataSetReader dataSet, double[] target, double[] weight, double eta, double bias)
			: base(dataSet, target, weight, eta, bias)
		{
            this.data = VectorTools.normalize(dataSet);
        }
        public override void train(int trainCount)
        {
            int epochs = 0;
            bool moreError = true;
			const int MAX_EPOCHS = 1000;	//Limiting the number of iterations in the process.
            double minError = 1E-2;
            double[][] error=new double[this.classMask.Length][];
            double[] mse = new double[MAX_EPOCHS];
			bool weightChanged = true;
			int classIndex;
			double[] lineData;
			
			/*REAL WORK*/
            while (weightChanged && epochs < MAX_EPOCHS && moreError)
			{
				weightChanged = false;
				for(int i=0; i<this.classMask.Length; i++) //Class index.
				{
                    error[i] = new double[trainCount];
					classIndex = (int)classMask[i] - 1;
					for(int j=0; j<trainCount; j++) //Data index.
					{
						lineData = VectorTools.trim(this.data[classIndex][j], this.featureMask);
						lineData = VectorTools.prepend(lineData, this.bias); //Prepend the bias.

						double net = VectorTools.multiply(this.weight, lineData);
                        net = getvalue(net);

                        if (net != this.target[i])
						{
							weightChanged = true;
							lineData = VectorTools.trim(this.data[classIndex][j], this.featureMask);
							lineData = VectorTools.prepend(lineData, this.bias);

                            error[i][j] = this.target[i] - net;
							double[] mulOut = VectorTools.multiply(lineData, error[i][j] * this.eta);
                            error[i][j] = 0.5 * error[i][j] * error[i][j];
							this.weight = VectorTools.sum(this.weight, mulOut);
						}
					}
				} //End of inner for.
                double [] temp=VectorTools.get1D(error);
                mse[epochs] = VectorTools.mean(temp);
                if (mse[epochs] < minError)
                    moreError = false;
				epochs++;
			} //End of outer while.
		}

        private double getvalue(double net)
        {
            if (net >= 0)
                net = 1;
            else
                net = -1;
            return net;
        }
        

        public override int[,] test(int testCount)
        {
            int[,] confMatrix = new int[this.classMask.Length, this.classMask.Length];

            int startIndex = this.samples - testCount - 1,
                success = 0,
                classIndex,
                resultIndex;
            double classOut;
            double[] lineData;

            for (int i = 0; i < this.classMask.Length; i++)
            {
                classIndex = (int)this.classMask[i] - 1;
                for (int j = 0; j < testCount; j++)
                {
                    lineData = VectorTools.trim(this.data[classIndex][startIndex + j], this.featureMask);
                    classOut = classify(lineData);
                    classOut = getvalue(classOut);
                    if (classOut == this.target[i])
                        success++;

                    resultIndex = Array.IndexOf(this.target, (int)classOut);
                    confMatrix[i, resultIndex]++;
                }
            }

            return confMatrix;
        }

        public override double classify(double[] input)
        {
            if (input.Length > this.featureMask.Length)
                throw new ArgumentOutOfRangeException("Input features is bigger than features in feature mask");

            input = VectorTools.prepend(input, this.bias); //Add the bias.
            double net = VectorTools.multiply(this.weight, input);

            return net;
        }
    }
}
