Sub stock()
    ' --------------------------------------------
    ' LOOP THROUGH ALL SHEETS
    ' --------------------------------------------
For each ws in worksheets

    ws.Range("I1").Value = "Ticker"
    ws.Range("J1").Value = "Yearly Change"
    ws.Range("K1").Value = "Percentage Change"
    ws.Range("L1").Value = "Total Stock Volume"

    ws.Range("O2").Value = "Greatest % increase"
    ws.Range("O3").Value = "Greatest % Decrease"
    ws.Range("O4").Value = "Greatest total volume"

    ws.Range("P1").Value = "Ticker"
    ws.Range("Q1").Value = "Value"

    lastrow = ws.Cells(Rows.Count, 1).End(xlUp).Row

    total_Vol = 0
    summary_table_row = 2
    open_price_row = 2

    For i = 2 To lastrow
        If ws.Cells(i + 1, 1).Value <> ws.Cells(i, 1).Value Then
            'Ticker name captured
            ws.Cells(summary_table_row, "I").Value = ws.Cells(i, 1).value
            'Total vol captured
            ws.Cells(summary_table_row, "L").Value = total_Vol + ws.Cells(i,7).Value

            'Yearly open price
            Open_price = ws.Cells(open_price_row,3).Value 
            'Yearly close price
            close_price = ws.Cells(i,6).Value 
            'Change and input to summary table
            yearly_change = close_price - open_price
            ws.Cells(summary_table_row,"J").Value = yearly_change

                'Format cell fill-colors per change value (+/-)
                If yearly_change > 0 Then
                    ws.Cells(summary_table_row,"J").Interior.ColorIndex = 4
                Else
                    ws.Cells(summary_table_row,"J").Interior.ColorIndex = 3
                End if 
            
                'Calculate % change and output to summary table
                If open_price >0 Then
                    per_change = yearly_change/open_price
                Else 
                    per_change = 0
                End if 

                ws.Cells(summary_table_row,"K").Value = per_change
            
            'Reset the stock volume total
            total_Vol = 0

            'Increase 1 row for next summary item position
            summary_table_row = summary_table_row + 1

            'Open price position for next ticker in summary table
            open_price_row = i+1
    
        Else
            total_Vol = total_Vol + ws.Cells(i + 1, 7).Value
        End If

    Next i

    'format Cells
    ws.Range("J2:J" & summary_table_row).NumberFormat = "0.00000000"
    ws.Range("K2:K" & summary_table_row).NumberFormat = "0.00%"


    minlr = ws.Cells(Rows.Count, "I").End(xlUp).Row    
    Dim per_rng as Range
    'Set Range from which to determine MIN/MAX change value
    Set per_rng = ws.Range("K1:K" & minlr)    
    'Worksheet function MIN returns the smallest value in a Range 
    per_Min = Application.WorksheetFunction.Min(per_rng)    
    'Fill MIN in the table
    ws.Range("Q3").Value = per_Min
    ws.Range("Q3").NumberFormat = "0.00%"    
    'Find extreme ticker row
    per_min_row = Application.Match(per_min, per_rng, 0)
    'Find ticker value
    pmin_ticker = ws.Cells(per_min_row, "I").Value    
    'Fill in ticker value
    ws.Range("P3").Value = pmin_ticker



    'Worksheet function MAX returns the biggest value in a Range 
    per_Max = Application.WorksheetFunction.Max(per_rng)    
    'Fill MAX in the table
    ws.Range("Q2").Value = per_Max
    ws.Range("Q2").NumberFormat = "0.00%"
    'Find extreme ticker row
    per_max_row = Application.Match(per_max, per_rng, 0)    
    'Find ticker value
    pmax_ticker = ws.Cells(per_max_row, "I").Value
    'Fill in ticker value
    ws.Range("P2").Value = pmax_ticker



    Dim vol_rng as Range
    vlr = ws.Cells(Rows.Count, "I").End(xlUp).Row 
    'Set Range from which to determine max value
    Set vol_rng = ws.Range("L1:L" & vlr)
    'Worksheet function MAX returns the biggest value in a Range 
    totalvol_max = Application.WorksheetFunction.Max(vol_rng)
    'Fill in the table
    ws.Range("Q4").Value = totalvol_max
    'Find extreme ticker row
    totalvol_max_row = Application.Match(totalvol_max, vol_rng, 0)
    'Find ticker value
    vmax_ticker = ws.Cells(totalvol_max_row, "I").Value
    ws.Range("P4").Value = vmax_ticker

Next ws 

MsgBox ("Analysis Complete")

End Sub

