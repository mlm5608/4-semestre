int[] num = [2,3,5,6,8,7,9,22,4,1];
var a = 0;

foreach (var i in num)
{
   if(i % 2 == 0) {
    a += i ;
    
   }
}


Console.WriteLine($"{a}");