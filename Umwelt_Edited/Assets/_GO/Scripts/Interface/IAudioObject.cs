using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAudioObject
{
    FrequencyType Type { get; set; } 
    RawImage Image { get; set; }
}
