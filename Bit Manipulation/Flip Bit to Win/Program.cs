
using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(FlipBit(13));
        Console.WriteLine(FlipBit(1775));
        Console.WriteLine(FlipBit(15));
	}
	public static int FlipBit(int number)
	{
		string numberInBinary = Convert.ToString(number,2);
		Console.WriteLine(numberInBinary);
		int maxResult = 0 , currentResult = 0,prevZero =0;
		bool firstZero = false;
		
		for(int i = 0;i<numberInBinary.Length;i++)
		{
			if(numberInBinary[i] == '0'){
				if(firstZero){
					firstZero = false;
					if(currentResult > maxResult) maxResult = currentResult;
					currentResult = i-prevZero;
				}
				else if (!firstZero){
					firstZero = true;
					prevZero = i;
					currentResult++;
				}
			}
			else if(numberInBinary[i] == '1'){
				currentResult++;
			}
			if(i == numberInBinary.Length-1 && currentResult > maxResult){
				maxResult = currentResult;
			}		
		}
		
		return maxResult;
	}
	
	
}

