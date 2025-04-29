using System.Runtime.CompilerServices;
using GradientDescent;
using static GradientDescent.GradientDescent;
class Program{
static void Main(String[] args){

    OptimizationFunction func = x => (System.Math.Sin(x)) + (0.1 * x);
     GeneticAlgorithm ga = new GeneticAlgorithm(
            populationSize: 50,
            mutationRate: 0.05,
            fitnessFunction: func,
            minimize: true
        );
    Console.WriteLine(ga.ToString());
    for(int i = 0; i < 1000; i++){
    ga.Evolve();
    }
    System.Console.WriteLine("Evolved 1000 times, results:");
    Console.WriteLine(ga.ToString());

    Console.WriteLine("Gradient Descent: "+GradientDescent.GradientDescent.Optimize(func));




    }
}
