# TopHalf

## Um, what is it?? 😵
`TopHalf` is a free, open-sourced binary built in C++ on top of the Windows API. Have you ever needed to snap one window on the top half of your screen, and another window on the bottom? `TopHalf` let's you do just that.

## But is it safe? How are you moving windows?? 😨👾
`User32.dll` contains functionality to interact with the windows on Windows. TopHalf simply sets up keyboard listeners and invokes commands from the native `user32.dll` library to move around the windows on your screen.

## Alright, Im hooked. But how do I add this to my workflow? 💻🕶☕
`TopHalf.exe` is available as a standalone binary exe file. Simply download it from the releases tab. After running, you will be prompted with a terminal window that says "TopHalf is ready!". At this point, `TopHalf` has registered 4 global hotkeys:

|hotkey|description|
|---|---|
|`Alt`+`u`|Snap the current window to the top half of your screen|
|`Alt`+`d`|Snap the current window to the bottom half of your screen|
|`Alt`+`q`|Unregister all hotkeys and exit `tophalf` gracefully|
|`Alt`+`h`|Toggle the visibility of the `tophalf.exe` window|

## Building from Source 🔨

Are you a fan of being extra? Are you overly worried about security? Well then guess what, building from source is for you! I am kidding, but not really.
Obviously, since `tophalf` is targeting the `user32.dll` library, it is only avalible on Windows. To build from source, make sure you have the `Developer Command Prompt for VS 2017` installed. You can use any year, really, but the build script is targeting 2017. The build script uses microsoft's [cl.exe](https://docs.microsoft.com/en-us/cpp/build/reference/compiler-options?view=msvc-170) to build/link the source files.

Clone the repo:
```
C:\users\Bob> git clone https://github.com/erwijet/tophalf.git
```

then run the `bulid.bat` script.
```
C:\users\Bob> cd tophalf
C:\users\Bob\tophalf> .\build.bat
```

and yes, please make sure you are in the root folder of tophalf before running `build.bat`.
After the script runs, you should see a `tophalf.exe` in the root folder, as well as a new `bin/` folder containing... guess what... *binaries!!* (wow, who'da thought?)

Tada 🎉

## Disclaimer 😰
Okay so honesty time... this is my first project in C++. Like, ever. So if I messed up the code styling, please feel free to (a) send me an email roasting me and then (b) submit a PR to fix it and put your money where your mouth is 🤍. 

## Demo 🎯

<p align="center">
  <img src="https://i.imgur.com/uwSm71o.gif">
</p>

## This is awesome; thank you so much, Tyler!!
Hehe, you're very welcome 😊
If you would like to help support me and my projects, feel free to [buy me a coffee](https://ko-fi.com/erwijet). I am a wee broke college student and it would make me very happy.
