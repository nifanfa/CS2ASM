[BITS 32]
[global _start]
[ORG 0x100000]
;If using '-f bin' we need to specify the
;origin point for our code with ORG directive
;multiboot loaders load us at physical 
;address 0x100000

MULTIBOOT_AOUT_KLUDGE    equ  1 << 16
;FLAGS[16] indicates to GRUB we are not
;an ELF executable and the fields
;header address, load address, load end address;
;bss end address and entry address will be available
;in Multiboot header
MULTIBOOT_ALIGN          equ  1<<0   
; align loaded modules on page boundaries
MULTIBOOT_MEMINFO        equ  1<<1   
; provide memory map

MULTIBOOT_HEADER_MAGIC   equ  0x1BADB002
;magic number GRUB searches for in the first 8k
;of the kernel file GRUB is told to load

MULTIBOOT_HEADER_FLAGS   equ  MULTIBOOT_AOUT_KLUDGE|MULTIBOOT_ALIGN|MULTIBOOT_MEMINFO
CHECKSUM                 equ  -(MULTIBOOT_HEADER_MAGIC + MULTIBOOT_HEADER_FLAGS)

KERNEL_STACK             equ  0x00200000  
;Stack starts at the 2mb address & grows down

_start:
        xor    eax, eax                ;Clear eax and ebx in the event
        xor    ebx, ebx                ;we are not loaded by GRUB.
        jmp    multiboot_entry         ;Jump over the multiboot header
        align  4                       ;Multiboot header must be 32
                                       ;bits aligned to avoid error 13
multiboot_header:
        dd   MULTIBOOT_HEADER_MAGIC    ;magic number
        dd   MULTIBOOT_HEADER_FLAGS    ;flags
        dd   CHECKSUM                  ;checksum
        dd   multiboot_header          ;header address
        dd   _start                    ;load address of code entry point
                                       ;in our case _start
        dd   00                        ;load end address : not necessary
        dd   00                        ;bss end address : not necessary
        dd   multiboot_entry           ;entry address GRUB will start at

multiboot_entry:
        mov    esp, KERNEL_STACK       ;Setup the stack
        push   0                       ;Reset EFLAGS
        popf

        push   eax                     ;2nd argument is magic number
        push   ebx                     ;1st argument multiboot info pointer
        call   LongMode                ;Call _Main 
        add    esp, 8                  ;Cleanup 8 bytes pushed as arguments

        cli
endloop:
        hlt
        jmp   endloop

%include "LongMode.asm"