#include <intrin.h>

void CPPTest() 
{
	unsigned char* p = (unsigned char*)0xb8090;
	*p = 'S';
	__nop();
}