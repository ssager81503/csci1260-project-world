# CSCI 1260 Project 1: Build Your Own World

Name: Seth Sager
Section: CSCI 1260-002
Language: C#

My World

My world is a dungeon where a randomly chosen hero (a Warrior or a Mage) fights two monsters and a boss on autoplay, and each run is recorded in a Hall of Fame.

How to Run

From the repository root, run:

    dotnet run --project csci1260-project-world

The program runs from start to finish without any keyboard input. It writes its output to the console and to Combat.txt

Question 1.

My Dungeon to Combatant relationship is an aggregation, shown with a hollow diamond. Program creates the monsters and passes them into the dungeon, so Dungeon only holds them. If Dungeon is removed, the monsters still exist. To make this a composition, Dungeon would need to create the monsters itself inside a method that calls the monsters to be made

My Hero to Skill relationship is a composition, shown with a filled diamond. Hero creates its own skills inside the LearnSkill using the new skill If the hero is removed, its skills are removed with it. To make this an aggregation, my main program would need to create the skills and pass them into the hero.

Question 2. 

Ispellcaster is used because it is a can do by both the boss class and mage class.  since the warrior class does not use spells it cant be directly inside of the combatant class or hero class.  

Question 3.

To add any new classes you would just need to create a class for that such as a Priest class and edit the program.cs to build it and add it to the possible lineup of heroes.  everything else doesnt need to be changed its all open for additions but closed for modifications

Recording


Not Finished
Recording needs to be uploaded
