﻿// <Snippet1>
open System

let computeStatistics (pitchers: Tuple<string, decimal, int, int>[]) =
    [| for pitcher in pitchers do
        // Decimal portion of innings pitched represents 1/3 of an inning
        let innings =  truncate (double pitcher.Item2) |> double
        let innings = innings + (double pitcher.Item2 - innings) * 0.33
        
        let ERA = double pitcher.Item4 / innings * 9.
        let hitsPerInning = double pitcher.Item3 / innings
        let EI = (ERA * 2. + hitsPerInning * 9.) / 3.
        Tuple<string, double, double, double>(pitcher.Item1, ERA, hitsPerInning, EI)|]

let pitchers  =  
    [| Tuple.Create("McHale, Joe", 240.1m, 221, 96)
       Tuple.Create("Paul, Dave", 233.1m, 231, 84)
       Tuple.Create("Williams, Mike", 193.2m, 183, 86)
       Tuple.Create("Blair, Jack", 168.1m, 146, 65) 
       Tuple.Create("Henry, Walt", 140.1m, 96, 30)
       Tuple.Create("Lee, Adam", 137.2m, 109, 45)
       Tuple.Create("Rohr, Don", 101.0m, 110, 42) |]

let results = computeStatistics pitchers

// Display the results.
printfn "%-20s %9s %11s %15s\n" "Pitcher" "ERA" "Hits/Inn." "Effectiveness"
for result in results do
    printfn $"{result.Item1,-20} {result.Item2,9:F2} {result.Item3,11:F2} {result.Item4,15:F2}"

// The example displays the following output
//       Pitcher                    ERA   Hits/Inn.   Effectiveness
//       
//       McHale, Joe               3.60        0.92            5.16
//       Paul, Dave                3.24        0.99            5.14
//       Williams, Mike            4.01        0.95            5.52
//       Blair, Jack               3.48        0.87            4.93
//       Henry, Walt               1.93        0.69            3.34
//       Lee, Adam                 2.95        0.80            4.36
//       Rohr, Don                 3.74        1.09            5.76
// </Snippet1>