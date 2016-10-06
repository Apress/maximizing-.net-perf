using System;
using System.Threading;

public class CollectorPattern {
  private static readonly float GROWTH_RATE = .1F;
  private static int _maxCount = 1000;
  private static int _count = 0;

  public static void IncrementCount(){
    Interlocked.Increment(ref _count);
    if (_count > _maxCount){
      lock(typeof(CollectorPattern)){
        _maxCount = (int)(_maxCount + (float)_maxCount * GROWTH_RATE);
      }
      GC.Collect();
    }
  }

  public static void DecrementCount(){
    Interlocked.Decrement(ref _count);
  }
}

public class GenericResource: IDisposable{
  public GenericResource(){
    CollectorPattern.IncrementCount();
  }
  ~GenericResource(){
    Dispose();
  }

  public void Dispose() {
    CollectorPattern.DecrementCount();
    GC.SuppressFinalize(this);
    //free unmanaged resource
  }
}

