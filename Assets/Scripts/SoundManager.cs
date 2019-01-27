using DarkTonic.MasterAudio;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SoundGroup] public string Move;
    [SoundGroup] public string GameEnd;
    [SoundGroup] public string LevelEnd;
    [SoundGroup] public string Music1;
    [SoundGroup] public string Music2;
    [SoundGroup] public string MusicOcean;
//    [SoundGroup] public string ;
}