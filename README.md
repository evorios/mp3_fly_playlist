# mp3_fly_playlist
The simple utility for creation and manage playlists on the Fly mobile phone (not smartphone).

There are schema for binary data in playlist:
```
01
MMIMP3_LIST_VER.01.01.00
FF 00 00 00
37 01 00 00 // number of songs
37 01 00 00 // number of songs

foreach {
00 00 00 00
78 ED A5 40 // ?
C6 97 52 00 // filesize in bytes
3C 00 // length of a path to the file in symbols
510 байт // path to the file encoded in utf-16, i.e. unicode
}

00 00 00 00

foreach {
00 00 00 00 // numbering of songs (zero-based)
}

MMIMP3_LIST_VER.01.01.00
BD 81 02 00 // filesize of a playlist in bytes
37 01 00 00 // number of songs
37 01 00 00 // number of songs
```

You can found playlists in folder ```E:\System\Mp3_res\```.
