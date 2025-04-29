using System.Globalization;
using GradientDescent;
public class GeneticAlgorithm{



private int populationSize;
private double[] population;
private double mutationRate;
private Random randall = new Random();
private GradientDescent.GradientDescent.OptimizationFunction fitnessFunction;

public GeneticAlgorithm(int populationSize, double mutationRate, GradientDescent.GradientDescent.OptimizationFunction fitnessFunction)
{
    this.populationSize = populationSize;
    this.mutationRate = mutationRate;
    this.fitnessFunction = fitnessFunction;
    InitializePopulation();
}
private void InitializePopulation(){
    double minRange = -10.0;
    double maxRange = 10.0;
    population = new double[populationSize];
    for (int i = 0; i < populationSize; i++){
        population[i] = randall.NextDouble() * (maxRange -minRange);
    }
}

public void Evolve(){
    //fitness function, a higher value = better candidate
    double[] fitness = CalculateFitness(population, populationSize, fitnessFunction);
    //Selection
    
    int selectedCount = (int)Math.Ceiling(population.Length/2.0);
    List<double> selectedParents = new();
    for(int i = 0; i < selectedCount; i++){
        double parent = RouletteSelection(population, fitness);
        selectedParents.Add(parent);
    }
    //Crossover

    double[] newPopulation = Crossover(selectedParents);
    //Mutation and Replacement

    population = Mutation(newPopulation, mutationRate);
}
private double[] CalculateFitness(double[] population, int populationSize, GradientDescent.GradientDescent.OptimizationFunction fitnessFunction){
    double[] fitness = new double[populationSize];
    for(int i = 0; i < populationSize; i++){
        fitness[i] = fitnessFunction(population[i]);
    }
    return fitness;
}
private double RouletteSelection(double[] population, double[] fitnesses)
{
    double totalFitness = 0.0;
    foreach (var fitness in fitnesses)
        totalFitness += fitness;

    double r = randall.NextDouble() * totalFitness;
    double cumulative = 0.0;

    for (int i = 0; i < population.Length; i++)
    {
        cumulative += fitnesses[i];
        if (r <= cumulative)
            return population[i];
    }

    return population[population.Length - 1]; // fallback
}

//Combine 2 parent values into a new child value
//either average crossover, or random weighted crossover (child = (1-a) * p[1] + a x p[2])
private double[] Crossover(List<double> parents){
    List<double> newPopulation = new();
    for(int i = 0; i < parents.Count; i+=2){
        double parent1 = parents[i];
        double parent2 = parents[(i+1) % parents.Count]; //Wrapping in case of out of bounds
        for(int j = 0; j <4; j++){
            double alpha = randall.NextDouble();
            double child = ((1-alpha) * parent1) + alpha*parent2;
            newPopulation.Add(child);
        }
    }
    
    return newPopulation.ToArray();
}
private double[] Mutation(double[] population, double mutationRate){        
        for(int i = 0; i < population.Length; i++){
            if(randall.NextDouble() < mutationRate){
                double epsilon = (randall.NextDouble()*1.0)-0.5; //Should now be a random value between -0.5 and 0.5
                population[i] += epsilon;
        }
    }
    return population;
}


}