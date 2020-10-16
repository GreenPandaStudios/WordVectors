using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordVectors
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //make sure the path is valid, or the program will crash. The txt file should be in the zip
            VectorDictionary vectorDictionary =
                new VectorDictionary("E:\\Green Panda Studios\\TMMO\\glove.6B.300d.txt",300);
            
            //input the list of "valid" commands here
            string[] names =
            {
                "go north",
                "go east",
                "go west",
                "go south",
                "inspect",
                "inspect mouse",
                "take",
                "get",
                "stop",
                "smell",
                "drink",
                "eat",
                "cut",
                "attack",
                "shout",
                "pray",
                "listen",
                "study",
                "examine",
                "open",
                "close",
                "jump",
                "climb",
                "look"
            };
            DimVector[] validCommands = new DimVector[names.Length];
            for (int i = 0; i < names.Length; i++) validCommands[i] = vectorDictionary.SentenceVector(names[i].Split(' '));
            string input;
            while ((input = Console.ReadLine())!=null){
               
                double min_dist = -double.MaxValue;
                int command = 0;
               for (int i = 0; i < validCommands.Length; i++)
               {
                    double new_dist = DimVector.CSim(vectorDictionary.SentenceVector(input.ToLower().Split(' '))
                        , validCommands[i]);

                    if (min_dist < new_dist){
                        command = i;
                        min_dist = new_dist;
                    }
               }
                Console.WriteLine("Best Guess: " + names[command]+"\n("+(min_dist*100)+"%)\n");
            }
        
        
        }
        
    }
}
