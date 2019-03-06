using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entities;
/*
 * 
 * TODO
 * ------
 * 
 * CREATE A SYSTEM TO STORE SEED, LOCATION, PLAYER STATS, INVENTORY
 * AND ALSO ENEMY LOCATIONS
 * 
 * 
 */
namespace TextGame {
    public class SaveTest {
        public SaveTest(string seed, string[] playerSave) {
            string path = @"D:\SCHOOL SHIT\TextGame\save\test.txt";
            if (!File.Exists(path)) {
                using (StreamWriter sw  = File.CreateText(path)) {
                    /**
                    sw.WriteLine(playerSave[0]);
                    sw.WriteLine(playerSave[1]);
                    sw.WriteLine(seed);
                    **/
                    for (int i = 0; i < playerSave.Length; i++) {
                        sw.WriteLine(playerSave[i]);
                    }
                }
            }else {
                using(StreamWriter sw = new StreamWriter(path)) {
                    /**
                    sw.WriteLine(playerSave[0]);
                    sw.WriteLine(playerSave[1]);
                    sw.WriteLine(seed);
                    **/
                    for(int i = 0; i < playerSave.Length; i++) {
                        sw.WriteLine(playerSave[i]);
                    }
                }
            }

            using (StreamReader sr = File.OpenText(path)) {
                string s;
                int i = 0;
                while((s = sr.ReadLine())!= null) {
                    Console.WriteLine(s);
                }
                
            }
        }



    }
}
