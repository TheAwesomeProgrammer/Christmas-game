using UnityEngine;
using System.Collections;

public enum animationEnum
{
    firstAnimation,
    secoundAnimation,
    noAnimation
}


public class AnimationPlayer : MonoBehaviour
{

    public Material normalAnimation;
    public Material hitAnimationOnePlayer;
    public Material hitAnimationTwoPlayer;


    public float howLongShouldAnimateLight;
    public float howLongShouldAnimateHeavy;

    public bool mIsAnimating { get; set; }

    public animationEnum shouldAnimate { get; set; }

    private animationEnum m_animation = animationEnum.noAnimation;

    private float whenToStopAnimating = float.MaxValue;

    private int randomNumber;
    


	// Use this for initialization
	void Start ()
	{
        
	    shouldAnimate = animationEnum.noAnimation;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if(whenToStopAnimating < Time.time)
        {
            mIsAnimating = false;
            whenToStopAnimating = float.MaxValue;
            renderer.material = normalAnimation;
        }
      
         if(shouldAnimate == animationEnum.secoundAnimation)
        {
            mIsAnimating = true;
            whenToStopAnimating = howLongShouldAnimateHeavy + Time.time;
            shouldAnimate = animationEnum.noAnimation;
            renderer.material = hitAnimationTwoPlayer;
        }

        if (shouldAnimate == animationEnum.firstAnimation)
        {
            mIsAnimating = true;
            whenToStopAnimating = howLongShouldAnimateLight + Time.time;
            shouldAnimate = animationEnum.noAnimation;
            renderer.material = hitAnimationOnePlayer;
        }
	   
	}
}
