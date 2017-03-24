@echo off

set VAR1=0
set VAR2=defaultValue

set VAR_NAME=UNKNOWN
:parse_param
if "%1"=="" goto done
set PARAM=%1
if "%PARAM%"=="-FLAG" (
    set VAR1=1
    set VAR_NAME=UNKNOWN
) else if "%PARAM:~0,1%"=="-" (
    set VAR_NAME=%PARAM:~1,250%
) else (
    set "%VAR_NAME%=%PARAM%"
    set VAR_NAME=UNKNOWN
)
shift
goto parse_param
:done

echo VAR1=%VAR1%
echo VAR2=%VAR2%
