void Hello() 
{
	unsigned char* c = 0xb8060;
	*c = 'C';
	c += 2;
	*c = '+';
	c += 2;
	*c = '+';
}