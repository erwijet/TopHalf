# TopHalf

## Um, what is it?? 😵
`TopHalf` is a free, open-sourced binary written in C# in the .NET framework for windows. Have you ever needed to snap one window on the top half of your screen, and another window on the bottom? `TopHalf` let's you select a window name, and either up or down and auto-magically rearranges your windows for you. This is especially helpful for users with rotated, vertical monitors.

## But is it safe? How are you moving windows?? 😨👾
`User32.dll` contains functionality to arranges windows that are interoperable especially with .NET. No malware or third-party software. Simply calls to `user32.dll`, and more pointer head scratching than I'd care to admit.

## Alright, Im hooked. But how do I add this to my workflow? 💻🕶☕
`TopHalf.exe` is available as a standalone binary exe file. Simply download it from the releases tab, or under the dist/ folder. The first time you run `TopHalf`, it will go ahead and create a desktop shortcut that sets up a keyboard shortcut. By default, the shortcut is `Ctrl + Alt + U` but can be changed by editing the properties of the desktop shortcut. It is also worth noting that the shortcut will target the executing binary in its current location. This means that if you move `TopHalf.exe`, the shortcut will no longer work. To put you at peace of mind, it doesn't copy itself to a System-Wide program folder, or a user-scoped program folder either. 

## This is awesome; thank you so much, Tyler!!
Hehe, you're very welcome 😊
