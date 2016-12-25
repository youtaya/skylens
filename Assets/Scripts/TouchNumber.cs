using System;

public class TouchNumber
{
	public int number;
	public int belongPad;
	public int index;

	public TouchNumber (int v1, int v2)
	{
		number = v1;
		belongPad = v2;
	}

	public TouchNumber (int v1, int v2, int v3)
	{
		number = v1;
		belongPad = v2;
		index = v3;
	}
}


