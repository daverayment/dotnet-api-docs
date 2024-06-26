﻿// <Snippet1>
using System;

public class ByteConversion
{
   public static void Main()
   {
      string[] byteStrings = { null, string.Empty, "1024",
                               "100.1", "100", "+100", "-100",
                               "000000000000000100", "00,100",
                               "   20   ", "FF", "0x1F" };

      foreach (var byteString in byteStrings)
      {
          CallTryParse(byteString);
      }
   }

   private static void CallTryParse(string stringToConvert)
   {
      byte byteValue;
      bool success = Byte.TryParse(stringToConvert, out byteValue);
      if (success)
      {
         Console.WriteLine("Converted '{0}' to {1}",
                        stringToConvert, byteValue);
      }
      else
      {
         Console.WriteLine("Attempted conversion of '{0}' failed.",
                           stringToConvert);
      }
   }
}
// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Attempted conversion of '' failed.
//       Attempted conversion of '1024' failed.
//       Attempted conversion of '100.1' failed.
//       Converted '100' to 100
//       Converted '+100' to 100
//       Attempted conversion of '-100' failed.
//       Converted '000000000000000100' to 100
//       Attempted conversion of '00,100' failed.
//       Converted '   20   ' to 20
//       Attempted conversion of 'FF' failed.
//       Attempted conversion of '0x1F' failed.
// </Snippet1>
