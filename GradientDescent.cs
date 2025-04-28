using System.Xml.Serialization;
using System;
public class GradientDescent{

    delegate double OptimizationFunction(double x);
    static Random randall = new Random();
    static double currentX = randall.Next();
    static double currentY = func(currentX);
    static OptimizationFunction func = x => (System.Math.Sin(x)) + (0.1*x);
    //OptimizationFunction func = x => (x - 3) * (x - 3);


}