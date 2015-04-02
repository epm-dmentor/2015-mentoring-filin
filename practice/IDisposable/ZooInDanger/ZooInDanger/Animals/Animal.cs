﻿#region

using System;
using System.Threading;

#endregion

namespace Epam.NetMentoring.Zoo.Animals
{
    public class Animal : IAnimal, ITickListener
    {
        //statuses

        //live intervals
        private const int eatInterval = 1;
        private const int hungerDeathInterval = 2;
        private const int infectionDeathInterval = 3;
        private const int lifeInterval = 3; //in years
        private const int YearInterval = 100;

        private const int infectionResistance = 70;

        private readonly int _id;
        private readonly IAnimalStatusTracker _statusTracker;
        private int _inHungerSinceLastEat;
        private bool _isAlive = true;
        private int _lastEat;
        private int _lastInfected = -1;
        private int _ticksAlive;

        public Animal(IAnimalStatusTracker statusTracker)
        {
            _id = AnimalIdGenerator.GetNewId();
            _statusTracker = statusTracker;
        }

        public virtual int LifeInterval
        {
            get { return lifeInterval; }
        }

        public virtual int InfectionResistance
        {
            get { return infectionResistance; }
        }

        public virtual int InfectionDeathInterval
        {
            get { return infectionDeathInterval; }
        }

        public virtual int HungerDeathInterval
        {
            get { return hungerDeathInterval; }
        }

        public virtual int EatInterval
        {
            get { return eatInterval; }
        }


        public virtual void Eat(string eatName)
        {
            if (_isAlive)
            {
                Interlocked.Exchange(ref _inHungerSinceLastEat, -1);
                Interlocked.Exchange(ref _lastEat, 0);
            }
        }

        public virtual void Infect()
        {
            _lastInfected = 0;
        }


        public virtual int Age
        {
            get { return _ticksAlive/YearInterval; }
        }

        public virtual bool IsAlive
        {
            get { return _isAlive; }
        }

        public void Kill()
        {
            Logger.Log("Class: {2}. Animal #{0} has been killed in age of {1}", _id, Age, GetType().Name);
            Die();
        }

        public void OnTick()
        {
            Interlocked.Increment(ref _ticksAlive);
            Interlocked.Increment(ref _lastEat);

            if (_lastInfected >= 0)
                Interlocked.Increment(ref _lastInfected);

            if (_inHungerSinceLastEat >= 0)
                Interlocked.Increment(ref _inHungerSinceLastEat);

            if (_lastInfected > InfectionDeathInterval)
                OnInfection();

            if (_lastEat > EatInterval)
                OnHunger();

            if (_inHungerSinceLastEat > HungerDeathInterval)
                OnHungerDeath();

            if (Age > LifeInterval)
                OnAged();
        }

        private void OnAged()
        {
            if (Age > LifeInterval)
            {
                Logger.Log("Animal #{0} died in age of {1}, because of age", _id, Age);
                Die();
            }
        }


        private void OnHungerDeath()
        {
            if (_isAlive)
            {
                Logger.Log("Animal #{0} died in age of {1}, because of hunger, Interval {2}", _id, Age,
                    HungerDeathInterval);
                Die();
            }
        }

        private void OnHunger()
        {
            if (_isAlive)
            {
                _statusTracker.IsInHunger(this);

                if (_inHungerSinceLastEat < 0)
                    Interlocked.Exchange(ref _inHungerSinceLastEat, 0);
            }
        }

        private void OnInfection()
        {
            _lastInfected = -1;
            if (_isAlive)
            {
                //Logger.Log("Animal #{0} infected", _id);
                var rnd = new Random();
                var probability = rnd.Next(0, 100);
                if (probability > InfectionResistance)
                {
                    Logger.Log("Animal #{0} died in age of {1}. because of infection", _id, Age);
                    Die();
                }
            }
        }

        private void Die()
        {
            _isAlive = false;
            _statusTracker.Died(this);
            EarthLiveTicker.LiveTicker.Unsubscribe(this);
        }

        ~Animal()
        {
            //BK: What is your fix for? Why do you think it was fixed?
            while (Zoo.Troops > 200)
            {
                _isAlive = false;
                Logger.Log("Ruining animal: {0}, ID = {1}", GetType().Name, _id);
                Interlocked.Decrement(ref Zoo.Troops);
            }

            Logger.LogYellow("Ruining animal: {0} finished, ID= {1}", GetType().Name, _id);
        }
    }
}