#if UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_0_1
#define UNITY_AUDIO_FEATURES_4_0
#else
#define UNITY_AUDIO_FEATURES_4_1
#endif

using UnityEngine;
using System.Collections.Generic;

#pragma warning disable 1591 // undocumented XML code warning

#if UNITY_FLASH
#error Building for Flash is only supported by the full version of the Audio Toolkit
#endif

public class AudioToolkitDemo : MonoBehaviour
{
    public AudioClip customAudioClip;

    float musicVolume = 1;
    float ambienceVolume = 1;
    bool musicPaused = false;
    Vector2 playlistScrollPos = Vector2.zero;


    AudioObject introLoopOutroAudio;

    void OnGUI()
    {
        DrawGuiLeftSide();
        DrawGuiRightSide();
        DrawGuiBottom();
    }

    void DrawGuiLeftSide()
    {
        GUI.skin.label.richText = true;

        var headerStyle = new GUIStyle( GUI.skin.label );
        headerStyle.normal.textColor = new UnityEngine.Color( 1, 1, 0.5f );
        GUI.Label( new Rect( 22, 10, 300, 22 ), "<size=14>ClockStone Audio Toolkit Free Version - Demo</size>", headerStyle );

        int ypos = 10;
        int yposOff = 35;
        int buttonWidth = 200;
        int scrollbarWidth = 130;

        ypos += 50;

        GUI.Label( new Rect( 250, ypos, buttonWidth, 30 ), "Global Volume" );

        AudioController.SetGlobalVolume( GUI.HorizontalSlider( new Rect( 250, ypos + 20, scrollbarWidth, 30 ), AudioController.GetGlobalVolume(), 0, 1 ) );


        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Cross-fade to music track 1" ) )
        {
            AudioController.PlayMusic( "MusicTrack1" );
        }

        ypos += yposOff;

        GUI.Label( new Rect( 250, ypos +10, buttonWidth, 30 ), "Music Volume" );

        float musicVolumeNew = GUI.HorizontalSlider( new Rect( 250, ypos + 30, scrollbarWidth, 30 ), musicVolume, 0, 1 );

        if ( musicVolumeNew != musicVolume )
        {
            musicVolume = musicVolumeNew;
            AudioController.SetCategoryVolume( "Music", musicVolume );
        }

        GUI.Label( new Rect( 250 + scrollbarWidth + 30, ypos + 10, buttonWidth, 30 ), "Ambience Volume" );

        float ambienceVolumeNew = GUI.HorizontalSlider( new Rect( 250 + scrollbarWidth + 30, ypos + 30 , scrollbarWidth, 30 ), ambienceVolume, 0, 1 );

        if ( ambienceVolumeNew != ambienceVolume )
        {
            ambienceVolume = ambienceVolumeNew;
            AudioController.SetCategoryVolume( "Ambience", ambienceVolume );
        }

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Cross-fade to music track 2" ) )
        {
            AudioController.PlayMusic( "MusicTrack2" );
        }

        ypos += yposOff;

        if( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Fade out music category" ) )
        {
            AudioController.FadeOutCategory( "Music", 2 );
        }

        ypos += yposOff;

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Fade in music category" ) )
        {
            AudioController.FadeInCategory( "Music", 2 );
        }

        ypos += yposOff;

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Stop Music" ) )
        {
            AudioController.StopMusic( 0.3f );
        }

        //if ( GUI.Button( new Rect( 250, ypos, buttonWidth, 30 ), "Stop Ambience" ) )
        //{
        //    AudioController.StopAmbienceSound( 0.5f );
        //}

        ypos += yposOff;

        bool musicPausedNew = GUI.Toggle( new Rect( 20, ypos, buttonWidth, 30 ), musicPaused, "Pause Music" );

        if ( musicPausedNew != musicPaused )
        {
            musicPaused = musicPausedNew;

            if ( musicPaused )
            {
                AudioController.PauseMusic();
            }
            else
                AudioController.UnpauseMusic();
        }


        ypos += yposOff;
        ypos += yposOff;

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Play Sound with random pitch" ) )
        {
            AudioController.Play( "RandomPitchSound" );
        }
        ypos += yposOff;

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Play Sound with alternatives" ) )
        {
            AudioObject soundObj = AudioController.Play( "AlternativeSound" );
            if ( soundObj != null ) soundObj.completelyPlayedDelegate = OnAudioCompleteleyPlayed;
        }
        ypos += yposOff;

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Play Both" ) )
        {
            AudioObject soundObj = AudioController.Play( "RandomAndAlternativeSound" );
            if ( soundObj != null ) soundObj.completelyPlayedDelegate = OnAudioCompleteleyPlayed;
        }
        ypos += yposOff;

        ypos += yposOff;

        GUI.Label( new Rect( 20, ypos, 100, 20 ), "Playlists: " );

        ypos += 20;

        playlistScrollPos = GUI.BeginScrollView(new Rect(20, ypos, buttonWidth, 100), playlistScrollPos,
            new Rect(0, 0, buttonWidth, 33f*AudioController.Instance.musicPlaylists.Length));

        for ( int i = 0; i < AudioController.Instance.musicPlaylists.Length; ++i )
        {
            if ( GUI.Button( new Rect( 20, i * 33f, buttonWidth - 20, 30f ), AudioController.Instance.musicPlaylists[ i ].name ) )
            {
                AudioController.SetCurrentMusicPlaylist( AudioController.Instance.musicPlaylists[ i ].name );
            }
        }

        ypos += 105;
        
        GUI.EndScrollView();

        if ( GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Play Music Playlist" ) )
        {
            AudioController.PlayMusicPlaylist();
        }

        ypos += yposOff;

        if ( AudioController.IsPlaylistPlaying() && GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Next Track on Playlist" ) )
        {
            AudioController.PlayNextMusicOnPlaylist();
        }

        ypos += 32;

        if ( AudioController.IsPlaylistPlaying() && GUI.Button( new Rect( 20, ypos, buttonWidth, 30 ), "Previous Track on Playlist" ) )
        {
            AudioController.PlayPreviousMusicOnPlaylist();
        }

        ypos += yposOff;
        AudioController.Instance.loopPlaylist = GUI.Toggle( new Rect( 20, ypos, buttonWidth, 30 ), AudioController.Instance.loopPlaylist, "Loop Playlist" );
        ypos += yposOff;
        AudioController.Instance.shufflePlaylist = GUI.Toggle( new Rect( 20, ypos, buttonWidth, 30 ), AudioController.Instance.shufflePlaylist, "Shuffle Playlist " );

    }

    bool wasClipAdded = false;
    bool wasCategoryAdded = false;

    void DrawGuiRightSide()
    {
        int ypos = 10;
        int yposOff = 35;
        int buttonWidth = 300;

        if ( !wasCategoryAdded )
        {
            if ( customAudioClip != null && GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Create new category with custom AudioClip" ) )
            {
                var category = AudioController.NewCategory( "Custom Category" );
                AudioController.AddToCategory( category, customAudioClip, "CustomAudioItem" );
                wasClipAdded = true;
                wasCategoryAdded = true;
            }
            ypos += yposOff;
        }
        else
        {
            if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Play custom AudioClip" ) )
            {
                AudioController.Play( "CustomAudioItem" );
            }

            ypos += yposOff;

            if ( wasClipAdded )
            {


                if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Remove custom AudioClip" ) )
                {
                    if ( AudioController.RemoveAudioItem( "CustomAudioItem" ) )
                    {
                        wasClipAdded = false;
                    }
                }
            }
        }

        ypos += yposOff;

#if !UNITY_AUDIO_FEATURES_4_1
        BeginDisabledGroup( true );
#endif

        if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Play gapless audio loop" ) )
        {
            AudioController.Play( "GaplessLoopTest" ).Stop( 1, 4 );
        }
        ypos += yposOff;

        if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Play random loop sequence" ) )
        {
            AudioController.Play( "RandomLoopSequence" );
        }
        ypos += yposOff;

        if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 50 ), "Play intro-loop-outro sequence\ngatling gun" ) )
        {
            introLoopOutroAudio = AudioController.Play( "IntroLoopOutro_Gun" );
        }

        ypos += 20;
        ypos += yposOff;

        BeginDisabledGroup( introLoopOutroAudio == null  );

        if ( GUI.Button( new Rect( Screen.width - ( buttonWidth + 20 ), ypos, buttonWidth, 30 ), "Finish gatling gun sequence" ) )
        {
            introLoopOutroAudio.FinishSequence();
        }

        EndDisabledGroup();
        ypos += yposOff;

#if !UNITY_AUDIO_FEATURES_4_1
       EndDisabledGroup();
#endif

        ypos += 10;

        const float textWidth = 500;

        GUI.skin.box.alignment = TextAnchor.UpperLeft;
        GUI.skin.box.wordWrap = true;
        GUI.skin.box.richText = true;

        const string infoText =
            "<size=18><color=orange>Welcome to Audio Toolkit!\n</color></size>" +
            "<size=14>The number one audio management solution for Unity used in AAA titles!\n\n" +
            "What does the toolkit do? In a nutshell:\n" + 
            "1) It separates scripting from managing audio:\n" +
            " Let your audio artist define complex behaviours of what 'MySoundID' will sound like. All within the Unity inspector.\n" +
            "2) Trigger audio without any scripting knowledge using the example behaviours like <color=lightblue>PlayAudio</color> or by script with\n" +
            " a simple function call, e.g. <color=lightblue>AudioController.Play( \"MySoundID\" );</color>\n"+ 
            "3) It makes life much easier in many ways: control volume by categories, play random effects, chain sequences of sound files, define sound alternatives, manage playlists, ...\n" +
            "\n<color=cyan>Select the AudioController game object to see how to configure audio in the inspector!</color>" + 
            "</size>";

        GUI.Box( new Rect( Screen.width - textWidth, ypos, textWidth - 10 , Screen.height - ypos - 60 ), infoText );

    }

    void DrawGuiBottom()
    {
        if ( GUI.Button( new Rect( Screen.width / 2 - 150, Screen.height - 40, 300, 30 ), "Video tutorial & more info..." ) )
        {
            Application.OpenURL( "http://unity.clockstone.com" );
        }
    }
    void OnAudioCompleteleyPlayed( AudioObject audioObj )
    {
        Debug.Log( "Finished playing " + audioObj.audioID + " with clip " + audioObj.GetComponent<AudioSource>().clip.name );
    }

    List<bool> disableGUILevels = new List<bool>();

    void BeginDisabledGroup( bool condition )
    {
        disableGUILevels.Add( condition );
        GUI.enabled = !IsGUIDisabled();
    }

    void EndDisabledGroup()
    {
        var count = disableGUILevels.Count;
        if ( count > 0 )
        {
            disableGUILevels.RemoveAt( count - 1 );
            GUI.enabled = !IsGUIDisabled();
        }
        else
            Debug.LogWarning( "misplaced EndDisabledGroup" );
    }

    bool IsGUIDisabled()
    {
        foreach ( var b in disableGUILevels )
        {
            if ( b ) return true;
        }
        return false;
    }
}
