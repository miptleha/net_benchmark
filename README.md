The purpose of this application is to measure the performance of an arbitrary function in dll.

## Sample
Download source code
```
git clone https://github.com/miptleha/net_benchmark.git
```

Open both solution (Benchmark.sln, BenchmarkCore.sln) in Visual Studio and build

To test .NET 4 Framework dll, go to `Test\bin\Debug\` and run `Benchmark.exe Test.dll` to see results:
```
Benchmarking type Class1
  SortQuick            00:00:00.4069558
  SortLong             00:00:00.3061403
```

To test .NET 5 Core dll, go to `TestCore\bin\Debug\net5.0\` and run `BenchmarkCore.exe TestCore.dll` to obtain results:
```
Benchmarking type Class1
  SortQuick            00:00:00.2526824
  SortLong             00:00:00.2514391
```

As we see, Classic .NET slower than .NET Core (in sorting).  
SortLong quicker because array in it has less elements.

## How it works
Benchmark is simple console application that loads provided dll.  
In the library, the method to be measured is marked with the `[Benchmark]` attribute:
```
[Benchmark]
public static void SortLong()
{
  BubbleSort(_arr2);
}
```

## Copyright
Thanks to Jon Skeet, idea and code was taken from his [site](https://jonskeet.uk/csharp/benchmark.html)
