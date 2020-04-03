Sub generateInvoice()
 
 'Identifica ultimul rand din work shetul pricing
 lastInvauxRow = Sheets("invaux").Range("A" & Rows.Count).End(xlUp).Row
 spatiuLiber = 3
 initial = 15
'Identifica numarul maxim al event_id-urilor ale sectiunile de pe Invoice
 maxCA = Sheets("invaux").Range("R2") + initial
 countCA = Sheets("invaux").Range("R2")
 maxCP = maxCA + spatiuLiber
 countCP = Application.WorksheetFunction.CountA(Sheets("invaux").Range("BX4:BX10000"))
 maxP = (maxCP + spatiuLiber)
 countP = (Application.WorksheetFunction.CountA(Sheets("invaux").Range("AF4:AF10000")) + Application.WorksheetFunction.CountA(Sheets("invaux").Range("AT4:AT10000")) + Application.WorksheetFunction.CountA(Sheets("invaux").Range("BH4:BH10000")))
 countM = Application.WorksheetFunction.CountA(Sheets("invaux").Range("CG4:CG10000"))
 
 Sheets("GeneratedInvoice").Range("H1").Value = maxCA
 Sheets("GeneratedInvoice").Range("H2").Value = countCA
 Sheets("GeneratedInvoice").Range("H3").Value = maxCP
 Sheets("GeneratedInvoice").Range("H4").Value = countCP
 Sheets("GeneratedInvoice").Range("H5").Value = maxP
 Sheets("GeneratedInvoice").Range("H6").Value = countP
 Sheets("GeneratedInvoice").Range("H7").Value = spatiuLiber
 Sheets("GeneratedInvoice").Range("H8").Value = initial
 Sheets("GeneratedInvoice").Range("H9").Value = initial + countCA + spatiuLiber * 3 + countCP + countP + countM
 
 'Creeaza Invoice Card Acquiring Event_id
For i = initial + 1 To maxCA
On Error Resume Next
Sheets("GeneratedInvoice").Range("A" & i).Value = i - initial
    If i = maxCA Then
    Sheets("GeneratedInvoice").Range("B" & i + 1).Value = "Total Cards Acquired"
    Sheets("GeneratedInvoice").Range("A" & i + 2).Value = " "
    End If
    If i = maxCA Then
    Sheets("GeneratedInvoice").Range("B" & i + 3).Value = "Card Processed"
    End If
Next i

 'Creeaza Invoice Card Processing Event_id
For i = (maxCP + 1) To (maxCP + countCP)
On Error Resume Next
Sheets("GeneratedInvoice").Range("A" & i).Value = i - (initial + spatiuLiber)
    If i = (maxCP + countCP) Then
    Sheets("GeneratedInvoice").Range("B" & i + 1).Value = "Total Cards Processed"
    Sheets("GeneratedInvoice").Range("A" & i + 2).Value = " "
    End If
    If i = (maxCP + countCP) Then
    Sheets("GeneratedInvoice").Range("B" & i + 3).Value = "Premium"
    End If
Next i

'Creeaza Invoice Premium Event_id
For i = (initial + countCA + spatiuLiber * 2 + countCP + 1) To ((initial + countCA + spatiuLiber * 2 + countCP) + countP)
On Error Resume Next
Sheets("GeneratedInvoice").Range("A" & i).Value = i - (initial - (-spatiuLiber * 2))
If i = (initial + countCA + spatiuLiber * 2 + countCP + countP) Then
    Sheets("GeneratedInvoice").Range("B" & i + 1).Value = "Total Premium"
    Sheets("GeneratedInvoice").Range("A" & i + 2).Value = " "
    End If
    If i = (initial + countCA + spatiuLiber * 2 + countCP + countP) Then
    Sheets("GeneratedInvoice").Range("B" & i + 3).Value = "Misscellaneous"
    End If
Next i

'Creeaza Invoice Misscellaneous Event_id
For i = (initial + countCA + spatiuLiber * 3 + countCP + countP + 1) To (initial + countCA + spatiuLiber * 3 + countCP + countP + countM)
On Error Resume Next
Sheets("GeneratedInvoice").Range("A" & i).Value = i - (initial - (-spatiuLiber * 3))
If i = (initial + countCA + spatiuLiber * 3 + countCP + countP + countM) Then
    Sheets("GeneratedInvoice").Range("B" & i + 1).Value = "Total Misscellaneous"
    End If
Next i

'Populeaza Detaliile de pe invoice
For i = (initial) To (initial + countCA + spatiuLiber * 3 + countCP + countP + countM)
On Error Resume Next
'populeaza Detalii invoice pt Scheme si Transaction Type
'=IFNA(INDEX(invaux!K$4:K1000,MATCH(GeneratedInvoice!A16,invaux!R$4:R1000,0)),IFNA(INDEX(invaux!Z$4:Z1000,MATCH(GeneratedInvoice!A16,invaux!AF$4:AF1000,0)),IFNA(INDEX(invaux!AN$4:AN1000,MATCH(GeneratedInvoice!A16,invaux!AT$4:AT1000,0)),IFNA(INDEX(invaux!BB$4:BB1000,MATCH(GeneratedInvoice!A16,invaux!BH$4:BH1000,0)),IFNA(INDEX(invaux!BQ$4:BQ1000,MATCH(GeneratedInvoice!A16,invaux!BX$4:BX1000,0)),INDEX(invaux!CC$4:CC1000,MATCH(GeneratedInvoice!A16,invaux!CG$4:CG1000,0)))))))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("K4:K10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BQ4:BQ10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("Z4:Z10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AN4:AN10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BB4:BB10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0))
Sheets("GeneratedInvoice").Range("B" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("CC4:CC10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("CG4:CG10000"), 0))
'populeaza Detalii invoice pt Transaction Type
Sheets("GeneratedInvoice").Range("C" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("L4:L10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("C" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BR4:BR10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
'populeaza Detalii invoice pt NR. Tranzactii
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("M4:M10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BS4:BS10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AA4:AA10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0))
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AO4:AO10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0))
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BC4:BC10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0))
Sheets("GeneratedInvoice").Range("D" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("CE4:CE10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("CG4:CG10000"), 0))
'populeaza Detalii invoice pt PPI
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("N4:N10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BT4:BT10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AB4:AB10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0))
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AP4:AP10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0))
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BD4:BD10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0))
Sheets("GeneratedInvoice").Range("E" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("CD4:CD10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("CG4:CG10000"), 0))
'populeaza Detalii invoice pt Valoare Tranzactii
Sheets("GeneratedInvoice").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("O4:O10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BU4:BU10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
Sheets("GeneratedInvoice").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AC4:AC10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0))
Sheets("GeneratedInvoice").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AQ4:AQ10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0))
Sheets("GeneratedInvoice").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BE4:BE10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0))
'populeaza Detalii invoice pt PPC
Sheets("GeneratedInvoice").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("P4:P10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0)) * 100 & "%"
Sheets("GeneratedInvoice").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BV4:BV10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0)) * 100 & "%"
Sheets("GeneratedInvoice").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AD4:AD10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0)) * 100 & "%"
Sheets("GeneratedInvoice").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AR4:AR10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0)) * 100 & "%"
Sheets("GeneratedInvoice").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BF4:BF10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0)) * 100 & "%"
'populeaza Detalii invoice pt Cost Tranzactii(totoal charge)
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("Q4:Q10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("R4:R10000"), 0))
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BW4:BW10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BX4:BX10000"), 0))
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AE4:AE10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AF4:AF10000"), 0))
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("AS4:AS10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("AT4:AT10000"), 0))
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("BG4:BG10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("BH4:BH10000"), 0))
Sheets("GeneratedInvoice").Range("H" & i).Value = Application.WorksheetFunction.Index(Sheets("invaux").Range("CF4:CF10000"), Application.WorksheetFunction.Match(Sheets("GeneratedInvoice").Range("A" & i).Value, Sheets("invaux").Range("CG4:CG10000"), 0))


Next i


End Sub


