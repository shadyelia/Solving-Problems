using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Animal
    {
        public int Id;
        public bool isDog;
    }

    public class Shelter
    {
        LinkedList<Animal> _animals;

        public Shelter()
        {
            _animals = new LinkedList<Animal>();
        }

        public void Enqueue(Animal animal)
        {
            _animals.AddFirst(animal);
        }

        public Animal DequeueAny()
        {
            Animal animal = _animals.First();
            _animals.RemoveFirst();
            return animal;
        }

        public Animal DequeueDog()
        {
            foreach (Animal ani in _animals)
            {
                if (ani.isDog)
                {
                    _animals.Remove(ani);
                    return ani;
                }
            }
            return null;
        }

        public Animal DequeueCat()
        {
            foreach (Animal ani in _animals)
            {
                if (!ani.isDog)
                {
                    _animals.Remove(ani);
                    return ani;
                }
            }
            return null;
        }
    }

    class Program
    {
        static void Main()
        {
            Shelter _shelter = new Shelter();
            Animal newAnimal = new Animal()
            {
                Id = 1,
                isDog = false
            };
            _shelter.Enqueue(newAnimal);

            Animal animalToDisplay = _shelter.DequeueCat();
            if (animalToDisplay == null) 
                Console.WriteLine("There are no dogs here");
            else
                Console.WriteLine("Anmial number " + animalToDisplay.Id);
        }

    }
}
