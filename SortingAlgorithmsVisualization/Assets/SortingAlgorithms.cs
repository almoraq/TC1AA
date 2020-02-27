using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System;
using UnityEngine;
using Random = System.Random;
using Debug = System.Diagnostics.Debug;

public class SortingAlgorithms : MonoBehaviour
{
    int[] generateRandomNumArr(int arrSize, int min, int max)
    {
        Random randNum = new Random();
        int[] resultArr = Enumerable
            .Repeat(0, arrSize)
            .Select(i => randNum.Next(min, max))
            .ToArray();
        return resultArr;
    }

    long BubbleSort(int[] testArr)
    {
        int temp;
        long duration = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int j = 0; j <= testArr.Length - 2; j++)
        {
            for (int i = 0; i <= testArr.Length - 2; i++)
            {
                if (testArr[i] > testArr[i + 1])
                {
                    temp = testArr[i + 1];
                    testArr[i + 1] = testArr[i];
                    testArr[i] = temp;
                }
            }
        }

        stopwatch.Stop();
        duration = stopwatch.ElapsedMilliseconds;

        return duration;
    }

    long InsertionSort(int[] testArr)
    {
        int j, temp;
        long duration = 0;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 1; i <= testArr.Length - 1; i++)
        {
            temp = testArr[i];
            j = i - 1;
            while (j >= 0 && testArr[j] > temp)
            {
                testArr[j + 1] = testArr[j];
                j--;
            }
            testArr[j + 1] = temp;
        }
        stopwatch.Stop();
        duration = stopwatch.ElapsedMilliseconds;

        return duration;
    }

    void testAlgorithms(int numOfTests, int arraySizeIncrements, int maxNumber)
    {
        int arraySize = 5;
        for(int i=0; i<numOfTests; i++)
        {
            int[] testArray = generateRandomNumArr(arraySize, 0, maxNumber);

            long bubbleDuration = BubbleSort(testArray);
            Debug.Write("Bubble Sort duration: " + bubbleDuration);
            long insertDuration = InsertionSort(testArray);
            Debug.Write("Insertion Sort duration: " + insertDuration);

            arraySize += arraySizeIncrements;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int tests = 20;
        int sizeInc = 50;
        int maxNum = 1000;
        testAlgorithms(tests, sizeInc, maxNum);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
