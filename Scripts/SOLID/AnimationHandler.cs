using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;

    public List<AnimationParameters> parameters;

    [System.Serializable]
    public struct AnimationParameters
    {
        public string name;
        public string type;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
}
