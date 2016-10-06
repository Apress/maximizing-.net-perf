using System;
using System.Text;
using System.IO;

public class DataLoss {
  public static void FinalizerCausingLoss(){
    ASCIIEncoding ae = new ASCIIEncoding();
    FileStream fs = new FileStream("MyFile.txt", FileMode.Create);
    BufferedStream bs = new BufferedStream(fs);
    byte[] data = ae.GetBytes("I should have gone out to file");
    
    //bytes written to BufferedStream buffer, but never flushed to disk
    bs.Write(data, 0, data.Length);

    //force full clean-up
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
  }
}
