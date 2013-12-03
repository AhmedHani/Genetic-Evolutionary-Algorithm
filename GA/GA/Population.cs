using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Population
    {
        public const int POPULATION = 500 + 5; // Population sample space 
        public const int CHOOSEN = 10; // Chosen Ones

        public Individual[] Population_arr; // Contains the population of genes
        public double fitness_total; // represents the fitness or the stability of individuals

        public Population() // contructor
        {
            Population_arr = new Individual[POPULATION + CHOOSEN];

            for (int i = 0; i < POPULATION; i++)
            {
                Population_arr[i] = new Individual();
            }

            for (int i = 0; i < POPULATION; i++)
            {
                Population_arr[i].GenesRandom();
            }
            this.Evaluate();
        }

        // Evaluate the total fitness of evaluated genes

        public double Evaluate()
        {
            this.fitness_total = 0.00;
            for (int i = 0; i < POPULATION; i++)
            {
                this.fitness_total += Population_arr[i].Evaluate();
            }

            return this.fitness_total;
        }

        // Copying the new population to the original population

        public void SetNewPopulation(Individual[] new_Population)
        {
            new_Population = new Individual[Population_arr.Length];
            for (int i = 0; i < Population_arr.Length; i++)
            {
                new_Population[i] = Population_arr[i];
            }
        }

        // Selection Phase: in this phase we are chossing randomly the Elitism..
        // i used roulette wheel selection alogrithm ..

        public Individual SelectionPhase() // roulete Wheel selection algorihm
        {
            Random rnd = new Random();
            double rnd_number = Math.Abs(rnd.NextDouble() * this.fitness_total);
            int i;
            for (i = 0; i < POPULATION && rnd_number > 0; i++)
            {
                rnd_number -= Math.Abs(Population_arr[i].GetFitness());
            }
            return Population_arr[i - 1];
        }

        // Finding the best individual of population

        public Individual FindBest() // Find the Best individual
        {
            int indexMin = 0, indexMax = 0;
            double Min = 100000.00;
            double Max = -100000.00;
            double valueCurrent = 0.00;

            for (int i = 0; i < POPULATION; i++)
            {
                valueCurrent = Population_arr[i].GetFitness(); 

                if (Max < Min)
                {
                    Max = Min = valueCurrent;
                    indexMax = indexMin = i;
                }

                if (valueCurrent > Max)
                {
                    Max = valueCurrent;
                    indexMax = i;
                }

                if (valueCurrent < Min)
                {
                    Min = valueCurrent;
                    indexMin = i;
                }
            }

            return Population_arr[indexMax]; // you can change it to Population_arr[indexMin] of you waant the worst
        }
    }
}
