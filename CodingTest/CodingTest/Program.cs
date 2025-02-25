using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 점찍기 실행
            //Console.WriteLine(solution(2, 4));

            // 디스크 컨트롤러 실행
            //Console.WriteLine(DiscControler(new int[,] { { 0, 3 }, { 1, 9 }, { 3, 5 } }));

            // 문자열 정수로 바꾸기 실행
            Console.WriteLine(StrConvertInt("-1234"));

            //testSort();
        }

        public static void testSort()
        {
            int[] arr = new int[] { 2, 3, 1, 5, 4 };
            Array.Sort(arr, (a, b) => a.CompareTo(b));

            foreach(int i in arr)
                Console.WriteLine(i);
        }

        // 점찍기
        public static long solution(int k, int d)
        {

            long count = 0;
            long dSquared = (long)d * d;

            // x 좌표를 a * k 형태로 순회
            for (int x = 0; x <= d; x += k)
            {
                // 해당 x 좌표에서 가능한 최대 y 값을 구함
                long maxYSquared = dSquared - (long)x * x;

                // y 좌표를 b * k 형태로 구함
                long maxY = (long)Math.Sqrt(maxYSquared);

                // 가능한 y 좌표의 개수는 (maxY / k) + 1
                count += (maxY / k) + 1;
            }

            return count;
        }

        // 디스크 컨트롤러
        public static int DiscControler(int[,] jobs)
        {
            int count = jobs.GetLength(0);
            int[][] jobsArray = new int[count][];

            // 2차원 배열을 배열의 배열로 변환
            for (int i = 0; i < count; i++)
            {
                jobsArray[i] = new int[] { jobs[i, 0], jobs[i, 1] };
            }

            // 요청 시각 순으로 정렬
            Array.Sort(jobsArray, (a, b) => a[0].CompareTo(b[0]));

            int time = 0; // 현재 시간
            int index = 0; // jobs 배열 인덱스
            int totalTurnaround = 0; // 총 반환 시간

            // 우선순위 큐 대체 (SortedSet 사용)
            var comparer = Comparer<int[]>.Create((a, b) =>
            {
                int cmp = a[1].CompareTo(b[1]); // 소요시간 기준
                if (cmp == 0) cmp = a[0].CompareTo(b[0]); // 요청시간 기준
                return cmp;
            });

            var pq = new SortedSet<int[]>(comparer);

            while (index < count || pq.Count > 0)
            {
                // 현재 시간까지 들어온 작업을 큐에 추가
                while (index < count && jobsArray[index][0] <= time)
                {
                    pq.Add(jobsArray[index]);
                    index++;
                }

                if (pq.Count > 0)
                {
                    var job = pq.Min;
                    pq.Remove(job);
                    time += job[1]; // 작업 소요시간만큼 진행
                    totalTurnaround += time - job[0]; // 반환 시간 계산
                }
                else
                {
                    // 큐가 비어있다면 다음 작업이 들어오는 시점으로 이동
                    time = jobsArray[index][0];
                }
            }

            return totalTurnaround / count;
        }

        //문자열을 정수로 바꾸기
        public static int StrConvertInt(string s)
        {
            int answer = 0;

            // 문자열을 char형태 배열로 분리
            char[] a = s.ToCharArray();
            
            if (a[0] == '-')
            {
                answer = int.Parse(s.Substring(1, s.Length - 1)) * -1;
            }
            else
            {
                answer = int.Parse(s);
            }

            return answer;
        }

        // 약수의 합
        public static int SumAliquot(int n)
        {
            int answer = 0;

            // 나머지를 통해 약수 여부를 확인하고 더하기
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    answer += i;
            }

            return answer;
        }
    }
}
