using System;
using System.Diagnostics;
using System.Text;
using static Lab_1_6zavd_Latysh_1.Program;

namespace Lab_1_6zavd_Latysh_1
{
    class Program
    {
        const double con = 1000000;
        static int[] CreateRandomArray()
        {
            Random rnd = new Random();
            int[] arr = new int[rnd.Next(50, 100)];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
            return arr;
        }
        static bool IsArrayEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        static void CopyArray(int[] arr, ref int[] arr1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr1[i] = arr[i];
            }
        }
        public delegate int[] MySelectionDel(int[] array, int currInd = 0);
        public delegate int[] MyShakerDel(int[] array);
        static void Main()
        {
            sol sol1 = new sol();

            int[] arr = CreateRandomArray();
            int[] arrCopy = new int[arr.Length];
            CopyArray(arr, ref arr);
            MySelectionDel etaDel = new MySelectionDel(sol1.EtallonSelectionSort); // 1
            //MySelectionDel studDel = new MySelectionDel(sol1.CorrectSelectionSort); // 1
            MySelectionDel studDel = new MySelectionDel(sol1.WrongSelectionSort); // 1
            //MyShakerDel etaDel = new MyShakerDel(sol1.EtalonShakerSort);         // 2
            //MyShakerDel studDel = new MyShakerDel(sol1.CorrectShakerSort);       // 2
            //MyShakerDel studDel = new MyShakerDel(sol1.WrongShakerSort);         // 2

            Console.WriteLine("Оригінальний масив: {0}", string.Join(", ", arr));


            // Починаємо вимірювати час перед викликом сортування
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int[] etaSort = etaDel(arr);
            //int[] etaSort = sol1.EtalonShakerSort(arr);
            Console.WriteLine("Впорядкований  масив(еталон): {0}", string.Join(", ", sol1.EtalonShakerSort(arr)));
            // Зупиняємо вимірювання часу після сортування
            timer.Stop();

            TimeSpan time = timer.Elapsed;
            string etaTime = time.ToString();
            etaTime = etaTime.Substring(6);
            double etaTimeMil = time.TotalMinutes * 60 * con;
            Console.WriteLine("Час в секундах: " + etaTime);
            Console.WriteLine("Час в мілісекундах: " + etaTimeMil);

            timer.Reset();
            timer.Start();

            int[] studSort = sol1.CorrectSelectionSort(arr);
            //int[] studSort = sol1.CorrectShakerSort(arr1);
            //int[] studSort = sol1.WrongShakerSort(arr1);
            //int[] studSort = sol1.WrongSelectionSort(arr);
            Console.WriteLine("Впорядкований  масив(студент): {0}", string.Join(", ", studSort));

            timer.Stop();

            time = timer.Elapsed;
            string studTime = time.ToString();
            studTime = studTime.Substring(6);
            double studTimeMil = time.TotalMinutes * 60 * con;
            Console.WriteLine("Час в секундах: " + studTime);
            Console.WriteLine("Час в мілісекундах: " + studTimeMil);

            if ((studTimeMil >= Math.Max(0,(etaTimeMil) / 5.0 + 200)) && studTimeMil <= 5 * etaTimeMil - 200)
                //if (Math.Abs(studTimeMil - etaTimeMil) <= 0.002)
                Console.WriteLine("Час роботи збігається");
            else Console.WriteLine("Час роботи не збігається");
            if (IsArrayEqual(etaSort, studSort))
                Console.WriteLine("Сортування правильне");
            else Console.WriteLine("Сортування неправильне");
        }
    }
}
// P.S. з делегатами код працює швидше, але він не реагує на штучні затримки потоку і працює по-різному: то швидше еталонного набагато, то повільніше.