using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    public class Crossover
    {
        // The class the resopnsible to manage the Chromosome from each parent to new individuals
        // by chossing a single point the divide the gene to two divided parts, then fill the 2 parts with the evolutionary Chromosomes 
        public Individual[] CrossOver(Individual Parent1, Individual Parent2)
        {
            Individual[] Child = new Individual[2];
            Random rnd = new Random();
            Child[0] = new Individual();
            Child[1] = new Individual();

            int rnd_number = rnd.Next(Individual.SIZE);

            for (int i = 0; i < rnd_number; i++)
            {
                Child[0].SetGene(i, Parent1.GetGene(i));
                Child[1].SetGene(i, Parent2.GetGene(i));
            }

            for (int i = 0; i < rnd_number; i++)
            {
                Child[0].SetGene(i, Parent2.GetGene(i));
                Child[1].SetGene(i, Parent1.GetGene(i));
            }
            return Child;
        }
    }
}
