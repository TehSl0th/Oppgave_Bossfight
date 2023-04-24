using System;

namespace Oppgave_Bossfight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hero = new GameCharacter("The Valiant Hero",100, new[] { 20 }, 40);
            var boss = new GameCharacter("The BBEG",400, new []{0,30},10);
            bool turnSwitch = true;

            while (GameCharacter.CheckAliveOrDead(hero,boss))
            {
                hero.Fight(boss);
                boss.Fight(hero);

            }
            GameCharacter.DeclareWinner(hero,boss);
            Console.ReadLine();
        }
    }
}
