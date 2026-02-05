using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    internal interface IMovable
    {
        void move();
        void stop();
        int GetSpeed();

    }

    internal interface IChargeable
    {
        void charge();
        void outOfBattery();
    }

    internal class car : IMovable
    {
        int speed;
        public void move()
        {
            speed = 60;
        }

        public void stop()
        {
            speed = 0;
        }

        public int GetSpeed()
        {
            return this.speed;
        }
    }

    internal class Robot : IMovable, IChargeable
    {
        int speed;
        int capacity;

        public void move()
        {
            speed = 10;
        }

        public void stop()
        {
            speed = 0;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public void charge()
        {
            capacity = 100;
        }

        public void outOfBattery()
        {
            capacity = 0;
        }

        public int getBattery()
        {
            return capacity;
        }

    }
}
