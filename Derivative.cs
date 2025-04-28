namespace GradientDescent{
using System;
using static GradientDescent;
public static class Derivative{

public static double  CalculateDerivative(OptimizationFunction func, double x){
    double h = 1e-5;
    return (func(x+h) - func(x))/h;
}

}
}