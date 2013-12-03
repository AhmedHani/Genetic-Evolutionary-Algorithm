using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Individual
    {
        // This class represents the attrbuits of the individuals of the population
        public const int SIZE = 700; // Size of Genome Array that contains the genes of child
        public int[] Genes = new int[SIZE];
        public int fitness;

        public Individual()
        {
        }

        public void SetFitness(int fitness)
        {
            this.fitness = fitness;
        }

        public int GetFitness()
        {
            return fitness;
        }

        public void SetGene(int index, int new_gene)
        {
            this.Genes[index] = new_gene;
        }

        public int GetGene(int index)
        {
            return Genes[index];
        }

        public int Evaluate() // Evaluate the total fitness of the new gene of individual
        {
            int fit = 0;
            for (int i = 0; i < SIZE; i++)
            {
                fit += this.GetGene(i);
            }
            this.SetFitness(fit);

            return fit;
        }

        public void GenesRandom() // generate random genes between 0 -> 2
        {
            Random rnd = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                this.SetGene(i, rnd.Next(2));
            }
        }

        public void evolve() // Change the alleles to ensure that it is evolved
        {
            Random rnd = new Random();
            int index = rnd.Next(SIZE);
            this.SetGene(index, 2 - this.GetGene(index));
        }
    }
}
