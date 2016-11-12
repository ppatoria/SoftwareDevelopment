@echo off
:loopstart echo %time% >> ping.txt
ping 59.144.127.16  >>ping.txt
sleep -m 1
goto loopstart
