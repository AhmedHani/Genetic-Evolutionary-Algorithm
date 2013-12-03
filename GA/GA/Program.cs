using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    // Refernces 
    //http://geneticalgorithms.ai-depot.com/Tutorial/Overview.html
    // http://en.wikipedia.org/wiki/Population_genetics
    // http://www.researchgate.net/post/Why_is_the_mutation_rate_in_genetic_algorithms_very_small
    // http://www.heatonresearch.com/articles/8/page3.html

    public class Program
    {
        public const double EVOLUTION_RATE = 0.1; 
        // it is better to set the evloution rate with low value to search for best solutions, to clarify that .. 
        // suppose we are in a state that considered to be a one of good solution, and we want to find a better,
        // to find it we need to search in a nearly space to this state
        public const double CROSSOVER_RATE = 0.65;
        // it is usually between 0.6 -> 0.7

        static void Main(string[] args)
        {
            /*
             * 1) Selection
             * 2) Crossover
             * 3) Evolution
             */

            Individual[] new_Population = new Individual[Population.POPULATION];
            Individual[] child = new Individual[2];
            Population population = new Population();
            Crossover crs = new Crossover();
            Random rnd = new Random();
            int Chosen, iterations;
            double tmp = population.FindBest().GetFitness();
            Console.WriteLine("Total Fitness : " + population.fitness_total + "\nBest Fitness : " + population.FindBest().GetFitness());
            Console.WriteLine("Enter number of iterations  ");
            iterations = Convert.ToInt32(Console.ReadLine()); // should be high ( > 3000 ), the more of iterations the more of evolution

            for (int i = 0; i < iterations; i++)
            {
                Chosen = 0; 

                for (int j = 0; j < Population.CHOOSEN; j++)
                {
                    new_Population[Chosen++] = population.FindBest();
                }

                for ( ; Chosen < Population.POPULATION;  )
                {
                    child[0] = population.SelectionPhase();
                    child[1] = population.SelectionPhase();

                    if (rnd.NextDouble() < CROSSOVER_RATE)
                    {
                        child = crs.CrossOver(child[0], child[1]);
                    }

                    if (rnd.NextDouble() < EVOLUTION_RATE)
                    {
                        child[0].evolve();
                    }

                    if (rnd.NextDouble() < EVOLUTION_RATE)
                    {
                        child[1].evolve();
                    }

                    new_Population[Chosen] = child[0];
                    new_Population[Chosen + 1] = child[1];
                    Chosen += 5;
                }
                population.SetNewPopulation(new_Population);
                population.Evaluate();
                Console.WriteLine("Total Fitness = " + population.fitness_total + "\nBest Fitness = " + population.FindBest().GetFitness());
            }
            Individual Best = population.FindBest();
            Console.WriteLine(Best.fitness == tmp ? "NO" : ("YES " + Best.fitness));
        }
    }
}
