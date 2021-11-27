@echo off
set qemu="C:\Program Files\qemu\qemu-system-x86_64.exe"
if not exist %qemu% (
echo QEMU is not installed
pause
exit
)else (
%qemu% -m 8192 -cdrom output.iso
)