using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiDev.Models{
    public class Utils{

        public const int MAX_CHARS = 1999;

        public List<string> GetSharedStrings(List<List<string>> listsToCompare) {
            List<string> smallestList = GetSmallestList(listsToCompare);
            return CompareSmallestListToAllLists(listsToCompare, smallestList);
        }

        private List<string> GetSmallestList(List<List<string>> listsToCompare) {
            List<string> smallestList = new List<string>();
            long smallest = 999999999999999999;

            foreach(var list in listsToCompare){
                if(list.Count() < smallest){
                    smallest = list.Count();
                    smallestList = list;
                }
            }
            return smallestList;
        }

        private List<string> CompareSmallestListToAllLists(List<List<string>> listsToCompare, List<string>smallestList) {
            List<string> sharedStrings = new List<string>();
            foreach (string str in smallestList){
                bool includeInFinal = true;
                foreach (dynamic list in listsToCompare){
                    if (!list.Contains(str))
                        includeInFinal = false;
                }
                if (includeInFinal)
                    sharedStrings.Add(str);
            }
            return sharedStrings;
        }

        public bool isNumeric(string str)
        {
            long result = 0;
            return long.TryParse(str, out result);
        }

        public List<string> ConvertToMaxCharSafeMessages(List<string> strings){
            List<string> messageList = new List<string>();
            string message = "";

            foreach (string game in strings){
                if (message.Length + game.Length < MAX_CHARS){
                    message += game + "\n";
                }
                else{
                    messageList.Add(message);
                    message = "";
                    message += game + "\n";
                }
            }
            messageList.Add(message);
            return messageList;
        }
    }
}
