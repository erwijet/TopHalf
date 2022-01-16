call "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\Common7\Tools\VsDevCmd.bat"
@echo OFF

mkdir   bin
cd      bin
cl      ../src/main.cpp
move    main.exe tophalf.exe
copy    .\tophalf.exe ..\tophalf.exe
cls
echo    "Build Finished!"
