using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAndBlow : MonoBehaviour
{
    // Start is called before the first frame update

    public int correctanswer = 1234;
    public int _input = 9999;
    //    int wrong_count = 0;

    void Start()
    {
        //correctanswer = GenerateNumberCard();
        correctanswer = GenerateNumberCard2();
        print( correctanswer );
        print( FeedBack(_input) );
       // print("HIT " +   CountHit(correctanswer_arr, input_arr) + " ‚Å‚·");
       // print("WRONG " + CountBlow(correctanswer_arr, input_arr) + " ‚Å‚·");
      
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    int GenerateNumberCard()
    {
        int[]n = { 0,1,2,3,4,5,6,7,8,9};
        int randomized = 0;
        for(int i = 0; i < 1;i++)
        {
            int a = Random.Range(0,10) * 1000;
            int b = Random.Range(0,10) * 100;
            int c = Random.Range(0,10) * 10;
            int d = Random.Range(0,10) * 1;
            randomized = a+b+c+d;
        }
        return randomized;
    }

    int GenerateNumberCard2()
    {
       for(int i = 0; i < 10000; i++)
        {
            int n = Random.Range(0,10000);
            if(ValidateNumber(n)  )
            {
                return n;
            }
            print("Loop number : " + i + " Same digit detected : "+n);
        }

       return 9999;
    }
    bool ValidateNumber(int number)
    {
        int[] n = SplitToDigits(number);
        for(int i = 0;i < 4;i++)
        {
            for (int j = i+1; j < 4; j++)
            { 
                if (n[i] == n[j])
                {
                return false;
                }
            }
        }

        return true;
    }

    //int CountHitBlow()
    //{
    //    int[] correctanswer_arr = SplitToDigits(correctanswer);
    //    int[] input_arr = SplitToDigits(_input);

    //    int correct_count = 0;

    //    for (int i = 0; i < 4; i++)
    //    {

    //        for (int j = 0; j < 4; j++)
    //        {
    //            if (input_arr[i] != correctanswer_arr[j] && input_arr[i] == correctanswer_arr[j])
    //            {
    //            correct_count++;
    //            }
    //        }

    //    }
    //    return correct_count;

    //}

    int CountHit(in int input)
    {
        int correct_count = 0;
        int[] correctanswer_arr = SplitToDigits(correctanswer);
        int[] input_arr = SplitToDigits(_input);

        for (int i = 0; i < 4;i++)
        {

        if(input_arr[i] == correctanswer_arr[i])
        {
               correct_count++;
        }
        else
        {
                //wrong_count++;
        }

        }

        return correct_count;
    }

    int CountBlow(in int guess)
    {
        int wrong_count = 0;
        int[] correctanswer_arr = SplitToDigits(correctanswer);
        int[] input_arr = SplitToDigits(_input);

        //int[] correctanswer_arr = SplitToDigits(correctanswer);
        //int[] input_arr = SplitToDigits(input);

        for (int i = 0; i < 4; i++)
        {

            if (input_arr[i] != correctanswer_arr[i])
            {
                wrong_count++;
            }

        }

        return wrong_count;
    }


    int[] SplitToDigits(in int number)
    {
        int[] digits_arr = new int[4];

        digits_arr[0] = number / 1000;
        digits_arr[1] = number % 1000 / 100;
        digits_arr[2] = number % 100 / 10;
        digits_arr[3] = number % 10;

        return digits_arr;
    }

    string FeedBack(in int guess)
    {
        int[] correctanswer_arr = SplitToDigits(correctanswer);
        int[] input_arr = SplitToDigits(guess);
        int hit =  CountHit(guess);
        int blow = CountBlow(guess);
        if(hit  == 4)
        {
            return "³‰ð‚Å‚·I";
        }

        return guess.ToString() + " ‚Í HIT " + hit + " ‚Å‚·" + "WRONG " + blow + " ‚Å‚·";
    }
}
