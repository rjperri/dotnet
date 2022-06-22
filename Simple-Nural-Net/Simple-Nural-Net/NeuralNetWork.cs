using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Nural_Net
{
    internal class NeuralNetWork
    {
        private Random _radomObj;
        public int SynapseMatrixColumns { get; }
        public int SynapseMatrixLines { get; }
        public double[,] SynapsesMatrix { get; private set; }

        public NeuralNetWork(int synapseMatrixColumns, int synapseMatrixLines)
        {
            SynapseMatrixColumns = synapseMatrixColumns;
            SynapseMatrixLines = synapseMatrixLines;

            _Init();
        }

        public double[,] Think(double[,] inputMatrix)
        {
            var productOfTheInputsAndWeights = Matrix.DotProduct(inputMatrix, SynapsesMatrix);
            return _CalculateSigmoid(productOfTheInputsAndWeights);
        }

        public void Train(double[,] trainInputMatrix, double[,] trainOutputMatrix, int interactions)
        {
            // Loop through all interactions
            for (int i = 0; i < interactions; i++)
            {
                Console.WriteLine($"Run{i}");
                // Calculate the output
                var output = Think(trainInputMatrix);
                Console.WriteLine("Output:");
                Matrix.Print(output);

                // Calculate the error
                var error = Matrix.Subtract(trainOutputMatrix, output);
                var curSigmoidDerivative = _CalculateSigmoidDerivative(output);
                var error_SigmoidDerivative = Matrix.Product(error, curSigmoidDerivative);

                Console.WriteLine("Error:");
                Matrix.Print(error);

                // calculate the adjustment :) 
                var adjustment = Matrix.DotProduct(Matrix.Transpose(trainInputMatrix), error_SigmoidDerivative);

                SynapsesMatrix = Matrix.Sum(SynapsesMatrix, adjustment);

                Console.WriteLine("New Weights:");
                Matrix.Print(SynapsesMatrix);

                Console.WriteLine("---------------------------------");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Initialize the ramdom object and the matrix of ramdon weights
        /// </summary>
        private void _Init()
        {
            // make sure that for every instance of the neural network we are geting the same random values
            _radomObj = new Random(1);
            _GenerateSynapsesMatrix();
        }

        /// <summary>
        /// Generate our matrix with the weight of the synapses
        /// </summary>
        private void _GenerateSynapsesMatrix()
        {
            SynapsesMatrix = new double[SynapseMatrixLines, SynapseMatrixColumns];
            for (int i = 0; i < SynapseMatrixLines; i++)
            {
                for(int j = 0; j < SynapseMatrixColumns; j++)
                {
                    SynapsesMatrix[i, j] = (2 * _radomObj.NextDouble()) - 1;
                }
            }
        }
        
        private double[,] _CalculateSigmoid(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = 1 / (1 + Math.Exp(value * -1));
                }
            }
            return matrix;
        }

        private double[,] _CalculateSigmoidDerivative(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = value * (1 - value);
                }
            }
            return matrix;
        }

    }
}
