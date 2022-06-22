using System;

namespace Simple_Nural_Net // Note: actual namespace depends on the project name.
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            var curNeuralNetwork = new NeuralNetWork(1, 3);

            Console.WriteLine("Synaptic weights before training:");
            Matrix.Print(curNeuralNetwork.SynapsesMatrix);

            var trainingInputs = new double[,]
            {
                { 0, 0, 1 },
                { 1, 1, 1 },
                { 1, 0, 1 },
                { 0, 1, 1 },
            };

            var trainingOutputs = Matrix.Transpose(new double[,]
            {
                { 0, 1, 1, 0 } 
            });

            curNeuralNetwork.Train(trainingInputs, trainingOutputs, 10_000);

            Console.WriteLine("\nSynaptic weights after training:");
            Matrix.Print(curNeuralNetwork.SynapsesMatrix);

            // Testing neural networks against a new problme
            var output = curNeuralNetwork.Think(new double[,]
            {
                { 1, 0, 0 },
            });
            Console.WriteLine("\nConsidering new problem [1, 0, 0] => :");
            Matrix.Print(output);

            // Testing neural networks against a new problme
            var output2 = curNeuralNetwork.Think(new double[,]
            {
                { 1, 1, 0 },
            });
            Console.WriteLine("\nConsidering new problem [1, 1, 0] => :");
            Matrix.Print(output2);

            // Testing neural networks against a new problme
            var output3 = curNeuralNetwork.Think(new double[,]
            {
                { 0, 1, 0 },
            });
            Console.WriteLine("\nConsidering new problem [0, 1, 0] => :");
            Matrix.Print(output3);
            Console.Read();
        }
    }
}