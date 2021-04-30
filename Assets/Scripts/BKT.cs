// equations refer to this page: https://en.wikipedia.org/wiki/Bayesian_Knowledge_Tracing

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BKT
{
    // todo: temp variables for testing, will need to come up with the numbers elsewhere
    // the probability of the student knowing the skill beforehand
    private static float pInit = 0.5f; 
    // the probability of the student demonstrating knowledge of the skill after an opportunity to apply it
    private static float pTransit = 0.1f; 
    // the probability the student makes a mistake when applying a known skill
    private static float pSlip = 0.8f;
    //the probability that the student correctly applies an unknown skill (has a lucky guess)
    private static float pGuess = 0.5f;
    
    // container to hold history of past probabilities
    //private List<float> pHistory = new List<float>();

    public static float CalculateBKT(bool isCorrect)
    {
        float temp = 0;
        
        // the probability that the student answered correctly,
        // given they know it, guessed it, or accidentally picked right (equation b)
        if (isCorrect) 
        {
            temp = (pInit * (1 - pSlip)) / (pInit * (1 - pSlip) + (1 - pInit) * pGuess);
        }
        
        // the probability that the student answered INCORRECTLY,
        // given they didn't know it know it, guessed it, or accidentally picked wrong (equation b)
        else
        {
            temp = (pInit * pSlip) / (pInit * pSlip + (1 - pInit) * (1 - pGuess));
        }
        
        // probability that they learned it after this observation (equation d)
        temp = temp + (1 - temp) * pTransit;


        return temp;
    }


}
