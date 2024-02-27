using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_6zavd_Latysh_1
{
    public class sol
    {
        int IndexOfMin(int[] array, int n)
        {
            int result = n;
            for (var i = n; i < array.Length; ++i)
            {
                if (array[i] < array[result])
                {
                    result = i;
                }
            }

            return result;
        }

        //метод для обміну елементів
        void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //сортування вибором
        public int[] EtallonSelectionSort(int[] array, int currentIndex = 0)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);
            if (index != currentIndex)
            {
                Swap(ref array[index], ref array[currentIndex]);
            }

            return EtallonSelectionSort(array, currentIndex + 1);
        }
        public int[] CorrectSelectionSort(int[] arr, int currInd = 0)
        {
            if (currInd == arr.Length)
                return arr;

            var index = IndexOfMin(arr, currInd);
            if (index != currInd)
            {
                Swap(ref arr[index], ref arr[currInd]);
            }

            return CorrectSelectionSort(arr, currInd + 1);
        }
        public int[] WrongSelectionSort(int[] arr, int currInd = 0)
        {
            if (currInd == arr.Length)
                return arr;

            var index = IndexOfMin(arr, currInd);
            if (index != currInd)
            {
                Swap(ref arr[index], ref arr[currInd]);
            }
            System.Threading.Thread.Sleep(1000);
            return WrongSelectionSort(arr, currInd + 1);
        }
        public int[] EtalonShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //прохід зліва направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                //прохід справа наліво
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                //якщо обмінів не було
                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
        public int[] CorrectShakerSort(int[] arr)
        {
            for (var i = 0; i < arr.Length / 2; i++)
            {
                var flag = false;
                //прохід зліва направо
                for (var j = i; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        flag = true;
                    }
                }

                //прохід справа наліво
                for (var j = arr.Length - 2 - i; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        flag = true;
                    }
                }

                //якщо обмінів не було
                if (!flag)
                {
                    break;
                }
            }

            return arr;
        }
        public int[] WrongShakerSort(int[] arr)
        {
            for (var i = 0; i < arr.Length / 2; i++)
            {
                var flag = false;
                //прохід зліва направо
                for (var j = i; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        flag = true;
                    }
                }

                //прохід справа наліво
                for (var j = arr.Length - 2 - i; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        flag = true;
                    }
                }
                System.Threading.Thread.Sleep(10);
                //якщо обмінів не було
                if (!flag)
                {
                    break;
                }
            }

            return arr;
        }
    }
}
