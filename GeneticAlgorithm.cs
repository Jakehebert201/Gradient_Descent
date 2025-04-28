using GradientDescent;
public class GeneticAlgorithm{



private int populationSize;
private double[] population;
private double mutationRate;
private Random randall = new Random();
private GradientDescent.GradientDescent.OptimizationFunction fitnessFunction;

public GeneticAlgorithm(int populationSize, double[] population, double mutationRate, GradientDescent.GradientDescent.OptimizationFunction func)
{
    this.populationSize = populationSize;
    this.population = population;
    this.mutationRate = mutationRate;
    this.fitnessFunction = fitnessFunction;
}

public static double Genetic(List<double> population, GradientDescent.GradientDescent.OptimizationFunction func){
    return 0;
}



}