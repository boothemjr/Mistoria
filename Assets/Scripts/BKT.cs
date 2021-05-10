// equations refer to this page: https://en.wikipedia.org/wiki/Bayesian_Knowledge_Tracing

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BKT
{
    // DEFAULT BKT PARAMETERS
    // the probability of the student knowing the skill beforehand, only for default constructor
    private static float pInit = 0.5f; 
    // the probability of the student demonstrating knowledge of the skill after an opportunity to apply it
    private float pTransit = 0.1f; 
    // the probability the student makes a mistake when applying a known skill
    private float pSlip = 0.1f;
    //the probability that the student correctly applies an unknown skill (has a lucky guess)
    private float pGuess = 0.25f;
    
    //the changing + current probability of mastery
    private float pMastery;

    // todo - not yet used for anything
    // container to hold history of past probabilities
    private List<float> pHistory = new List<float>();

    // default constructor
    public BKT()
    {
        this.pMastery = pInit; // set pMastery to static pInit
        pHistory.Add(this.pMastery);
    }
    
    // todo - check implementation, not currently used
    // constructor if pMastery is set 
    public BKT(float currPMastery)
    {
        this.pMastery = currPMastery; // set pMastery to parameter currMastery
        pHistory.Add(this.pMastery);
    }
    
    // calculates and sets the new pMastery using BKT given whether or not it was correct
    public void CalculateNewBKT(bool isCorrect)
    {
        float temp = 0;
        
        // the probability that the student answered correctly,
        // given they know it, guessed it, or accidentally picked right (equation b)
        if (isCorrect) 
        {
            temp = (pMastery * (1 - pSlip)) / (pMastery * (1 - pSlip) + (1 - pMastery) * pGuess);
        }
        
        // the probability that the student answered INCORRECTLY,
        // given they didn't know it know it, guessed it, or accidentally picked wrong (equation b)
        else
        {
            temp = (pMastery * pSlip) / (pMastery * pSlip + (1 - pMastery) * (1 - pGuess));
        }
        
        // probability that they learned it after this observation (equation d)
        pMastery = temp + (1 - temp) * pTransit;
        pHistory.Add(pMastery);
        
    }

    // get the current bkt value
    public float getPMastery()
    {
        return pMastery;
    }


}
