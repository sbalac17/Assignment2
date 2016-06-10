using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /**
     * This is the driver class
     * 
     * @class Program
     * */
    class Program
    {
        static void Main(string[] args)
        {
            SuperHero Markiplier = new SuperHero("Markiplier");
            Markiplier.Show();
            Markiplier.ShowPowers();
            Markiplier.Fight();
        }

    }
    /**
     * This class describes a SuperHero
     * 
     * @class Superhero
     * */
    class SuperHero : Hero
    {
        private string[] _superPowers;
        /**
         * This is an array of powers that the superhero has
         * 
         * @method SuperPowers
         * */
        public string[] SuperPowers
        {
            get
            {
                return _superPowers;
            }
        }
       
        /**
       * This is the construsctor for a super hero
       * 
       * @method SuperHero
       * @param {string} name
       * */
        public SuperHero(string name) : base(name)
        {
            _generateRandomPowers();

        }
        /**
       * This generates random powers for the superhero
       * 
       * @method _generateRandomPowers
       * */

        private void _generateRandomPowers()
        {
            Random generator = new Random();
            string[] possiblePowers = { "Super Speed", "Super Strength", "Body Armour", "Flight", "Fire Generation", "Weather Control" };
            _superPowers = new string[3];
            for (int power = 0; power <_superPowers.Length; power++)
            {
                string randomPower;

                do
                {
                    int randomNumber = generator.Next(possiblePowers.Length);
                    randomPower = possiblePowers[randomNumber];
                } while (_superPowers.Contains(randomPower));
                _superPowers[power] = randomPower;
            }
        }
        /**
       * This method prints the power 
       * 
       * @method ShowPowers
       * */
        public void ShowPowers()
        {
            Console.WriteLine("Super Powers");
            Console.WriteLine("-------------");
            foreach (string power in _superPowers)
            {
                Console.WriteLine(power);
            }
        }


    }


    /**
    * This class describes a hero
    * 
    * @class Hero
    * */
    class Hero
    {
        private static Random _rng = new Random();

        private int _strength;
        private int _speed;
        private int _health;
        private string _name;
        /**
       * this gets the heros name
       * 
       * @method Name
       * */
        // this is how you make it a property 
        public string Name
        {
            get { return _name; }
        }
        /**
       * constructs a hero 
       * 
       * @method Hero
       * */
        // this is the constructor
        public Hero(string name)
        {
            _name = name;
            _generateAbilties();
        }
        /**
       * this picks random attributes for the hero
       * 
       * @method _generateAbilties
       * */
        private void _generateAbilties()
        {
            _strength = _rng.Next(1, 100);
            _speed = _rng.Next(1, 100);
            _health = _rng.Next(1, 100);
        }
        /**
       * this calculates whether to hit or not
       * 
       * @method _hitAttempt
       * */
        private bool _hitAttempt()
        {
            int roll = _rng.Next(1, 100);
            return roll <= 20;
        }
        /**
       * this calculates the damage done when hitting
       * 
       * @method _hitDamage
       * */

        private int _hitDamage()
        {
            int roll = _rng.Next(1, 6);
            return roll * _strength;
        }
        /**
       * this attempts to make a hit and displays the results 
       * 
       * @method Fight
       * */
        public void Fight()
        {
            if (_hitAttempt())
            {
                int damage = _hitDamage();
                Console.WriteLine("{0}", damage);
            }
            else
            {
                Console.WriteLine("missed big boy");
            }

        }
        /**
       * this shows the heros information 
       * 
       * @method Show
       * */

        public void Show()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Health:   {0}", _health);
            Console.WriteLine("Speed:    {0}", _speed);
            Console.WriteLine("Strength: {0}", _strength);
        }
    }

}
