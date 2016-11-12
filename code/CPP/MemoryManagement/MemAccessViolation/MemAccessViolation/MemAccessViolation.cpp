// MemAccessViolation.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

void function (char **strArray)
{
	while (strArray != NULL)
	{
		printf ("%s\n", *strArray);
		strArray++;
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	char **strArray;
	strArray = (char**) malloc (6 * sizeof(char*));
	for (int i = 0; i < 5; i++)
	{
		*strArray = (char*) malloc (5 * sizeof (char));
		strArray++;
	}
	strArray[5]=NULL;
	function(strArray);
	return 0;
}

