using System.Collections.Generic;

namespace prj_05
{
    public static class ListExtension
    {
        public static List<BigInteger> GetNeighbours(this List<BigInteger> list, int indexOfCurrentElement, int countOfNeighbours)
        {
            List<BigInteger> resultList = new List<BigInteger>();
            int startIndex = indexOfCurrentElement - countOfNeighbours;
            if (startIndex < 0)
                startIndex = 0;
            for (int i = startIndex; i < indexOfCurrentElement; i++)
            {
                resultList.Add(list[i]);
            }
            int finishIndex = indexOfCurrentElement + countOfNeighbours;
            if (finishIndex > list.Count)
                finishIndex = list.Count - 1;
            for (int i = indexOfCurrentElement + 1; i < finishIndex; i++)
            {
                resultList.Add(list[i]);
            }
            return resultList;
        }
        
    }
}
