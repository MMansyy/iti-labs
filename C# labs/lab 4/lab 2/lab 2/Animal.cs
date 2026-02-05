using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal abstract class Animal
    {
        public abstract void makeSound();
        public abstract void Move();

        public virtual void Sleeping()
        {
            Console.WriteLine("zzzzzzzzzzzzzz!!!!!!");
        }
    }


    internal class Dog : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
        public override void Move()
        {
            Console.WriteLine("Running on four legs!");
        }
    }

    internal class Bird : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("kokokokokokokokokokoooooooooooooooooo");
        }
        public override void Move()
        {
            Console.WriteLine("Flying wooooooooooooooooo!");
        }
    }
}
