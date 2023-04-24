using System;
using System.Linq;

namespace Oppgave_Bossfight
{
    public class GameCharacter
    {
        private readonly string _name;
        private int _health;
        private readonly int[] _strength;
        private readonly int _stamina;
        private int _currentStamina;

        public GameCharacter(string name, int health, int[] strength, int stamina)
        {
            _name = name;
            _health = health;
            _strength = strength;
            _stamina = stamina;
            _currentStamina = stamina;
        }
        public static bool CheckAliveOrDead(GameCharacter hero, GameCharacter boss)
        {
            return hero._health > 0 && boss._health > 0;
        }

        public static void DeclareWinner(GameCharacter hero, GameCharacter boss)
        {
            if (hero._health != 0 && boss._health <= 0)
            {
                Console.WriteLine(hero._name + " has defeated " + boss._name);
            }
            else if (boss._health != 0 && hero._health <= 0)
            {
                Console.WriteLine(boss._name + " has defeated " + hero._name);
            }
            else
            {
                Console.WriteLine("What is this?! " + hero._name + " and " + boss._name + " has killed each other at the same time.");
            }
        }

        public void Fight(GameCharacter enemy)
        {
            Console.WriteLine("Stamina is: " + _stamina + ". Max stamina is: " + _currentStamina);

            if (_currentStamina >= 10)
            {
                if (_strength.Length > 1)
                {
                    var rng = new Random();
                    var randomDamage = rng.Next(_strength.First(), _strength.Last());
                    enemy._health -= randomDamage;
                    _currentStamina -= 10;
                    Console.WriteLine(_name + " attacked " + enemy._name + " for " + randomDamage + " damage! " + enemy._name + " now has " + enemy._health + "HP left.");
                }
                else
                {
                    enemy._health -= _strength.First();
                    _currentStamina -= 10;
                    Console.WriteLine(_name + " attacked " + enemy._name + " for " + _strength.First() + " damage! " + enemy._name + " now has " + enemy._health + "HP left.");
                }
            }
            else
            {
                Recharge();
                Console.WriteLine(_name + " has run out of energy and is catching their breath for a turn.");
            }
        }

        public void Recharge()
        {
            _currentStamina += _stamina;
        }
    }
}