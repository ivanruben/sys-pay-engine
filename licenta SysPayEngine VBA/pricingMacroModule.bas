Sub pricing()

    'identifica ultimul rand din sheet
 lastTxnRow = Sheets("txn").Range("A" & Rows.Count).End(xlUp).Row

    'Lisat merchantilor
 merchantList = Sheets("txn").Range("A4:A10000")
    'Lisat EVENT_ID-urilor
 eventList = Sheets("txn").Range("B4:B10000")
 
    'Copiaza lista merchantilor  - column A
 Sheets("pricing").Range("A4:A10000") = merchantList
     'Identifica ultimul rand din work shetul pricing
 lastPricingRow = Sheets("pricing").Range("A" & Rows.Count).End(xlUp).Row
    'Copiaza lista eventurilor  - column B
 Sheets("pricing").Range("B4:B10000") = eventList


 Set IndexRgn = Sheets("psegm").Range("B:B")
 Set MatchRgn = Sheets("psegm").Range("A:A")
 
 'Loop care sa populeze toate valorile din pricing worksheet
 For i = 4 To lastPricingRow
    On Error Resume Next
    'Index Match function in order to populate: Scheme, CaptureMethode, jurisdiction and transaction Type - column C,F,G,I
    Sheets("pricing").Range("C" & i).Value = Application.WorksheetFunction.Index(IndexRgn, Application.WorksheetFunction.Match(Sheets("txn").Range("F" & i).Value, MatchRgn, 0))
    Sheets("pricing").Range("I" & i).Value = Application.WorksheetFunction.Index(Sheets("dataref").Range("H:H"), Application.WorksheetFunction.Match(Sheets("txn").Range("D" & i).Value, Sheets("dataref").Range("I:I"), 0))
    Sheets("pricing").Range("G" & i).Value = Application.WorksheetFunction.Index(Sheets("dataref").Range("K:K"), Application.WorksheetFunction.Match(Sheets("txn").Range("I" & i).Value, Sheets("dataref").Range("L:L"), 0))
    Sheets("pricing").Range("F" & i).Value = Application.WorksheetFunction.Index(Sheets("dataref").Range("E:E"), Application.WorksheetFunction.Match(Sheets("txn").Range("H" & i).Value, Sheets("dataref").Range("F:F"), 0))
    
    'Populate Aquired/Processed, Auth/NotAUTH columns - column D,E
    If Sheets("txn").Range("E" & i).Value = "N" Then
       Sheets("pricing").Range("D" & i).Value = "Processed"
    Else: Sheets("pricing").Range("D" & i).Value = "Acquired"
    End If
    If Sheets("txn").Range("G" & i).Value = "Y" Then
       Sheets("pricing").Range("E" & i).Value = "Authorised"
    Else: Sheets("pricing").Range("E" & i).Value = "Not Authorised"
    'Populate Amount column with the correct sign - column H
    End If
    If Sheets("txn").Range("D" & i).Value = "0" Or Sheets("txn").Range("D" & i).Value = "1" Or Sheets("txn").Range("D" & i).Value = "2" Then
       Sheets("pricing").Range("H" & i).Value = Sheets("txn").Range("C" & i).Value
    Else: Sheets("pricing").Range("H" & i).Value = -Sheets("txn").Range("C" & i).Value
    End If
     'Creaza abrevieri pt schema
     Sheets("pricing").Range("AT" & i).Value = Application.WorksheetFunction.Index(Sheets("psegm").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("C" & i).Value, Sheets("psegm").Range("B:B"), 0))
     Sheets("pricing").Range("AU" & i).Value = Application.WorksheetFunction.Index(Sheets("psegm").Range("D:D"), Application.WorksheetFunction.Match(Sheets("txn").Range("F" & i).Value, Sheets("psegm").Range("A:A"), 0))
     Sheets("pricing").Range("AV" & i).Value = Application.WorksheetFunction.Index(Sheets("dataref").Range("F:F"), Application.WorksheetFunction.Match(Sheets("txn").Range("H" & i).Value, Sheets("dataref").Range("F:F"), 0))
    
    'Calculeaza FXINCOME - column K
    Sheets("pricing").Range("K" & i).Value = Round((Sheets("txn").Range("M" & i).Value - Sheets("txn").Range("N" & i).Value) * Sheets("txn").Range("C" & i).Value, 4)
    
    'Create Base Charge codes - column M
    If (Sheets("txn").Range("E" & i).Value <> "Y") And (Sheets("txn").Range("F" & i).Value <> "AMEX") And (Sheets("txn").Range("F" & i).Value <> "DCD") Then
       Sheets("pricing").Range("M" & i).Value = ""
       ElseIf (Sheets("txn").Range("E" & i).Value = "Y") And (Sheets("txn").Range("D" & i).Value = 10) Or (Sheets("txn").Range("D" & i).Value = 12) Then
       Sheets("pricing").Range("M" & i).Value = "ARF" & Sheets("txn").Range("F" & i).Value
       ElseIf (Sheets("txn").Range("E" & i).Value = "Y") And (Sheets("txn").Range("D" & i).Value = 11) Then
       Sheets("pricing").Range("M" & i).Value = "AOC" & Sheets("txn").Range("F" & i).Value
       ElseIf (Sheets("txn").Range("E" & i).Value = "Y") And (Sheets("txn").Range("D" & i).Value = 0) Then
       Sheets("pricing").Range("M" & i).Value = "APU" & Sheets("txn").Range("F" & i).Value
       ElseIf (Sheets("txn").Range("E" & i).Value = "Y") And (Sheets("txn").Range("D" & i).Value = 1) Then
       Sheets("pricing").Range("M" & i).Value = "ACA" & Sheets("txn").Range("F" & i).Value
       ElseIf (Sheets("txn").Range("E" & i).Value = "Y") And (Sheets("txn").Range("D" & i).Value = 2) Then
       Sheets("pricing").Range("M" & i).Value = "APC" & Sheets("txn").Range("F" & i).Value
    End If
    
    'Assigne PPI and PPC for every  - column N,O
    If Left(Sheets("pricing").Range("M" & i).Value, 1) = "A" Then
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("N" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("M" & i).Value, Sheets("contract").Range("A:A"), 0))
        Sheets("pricing").Range("O" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("M" & i).Value, Sheets("contract").Range("A:A"), 0)) * 100 & "%"
    ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("N" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("M" & i).Value, Sheets("contract").Range("F:F"), 0))
        Sheets("pricing").Range("O" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("H:H"), Application.WorksheetFunction.Match(Sheets("pricing").Range("M" & i).Value, Sheets("contract").Range("F:F"), 0)) * 100 & "%"
    Else
        Sheets("pricing").Range("N" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
        Sheets("pricing").Range("O" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
    End If
    
    'Calculate PPC*FUND and PPC*FUND+PPI for Base Charge - column P,Q
    If Sheets("pricing").Range("O" & i).Value <> "" Then
        Sheets("pricing").Range("P" & i).Value = Round(Abs(Sheets("pricing").Range("O" & i).Value * Sheets("pricing").Range("H" & i).Value), 6)
    Else: Sheets("pricing").Range("P" & i).Value = ""
    End If
    If Sheets("pricing").Range("O" & i).Value <> "" Then
        Sheets("pricing").Range("Q" & i).Value = Abs(Sheets("pricing").Range("P" & i).Value + Sheets("pricing").Range("N" & i).Value)
    Else: Sheets("pricing").Range("Q" & i).Value = ""
    End If
    End If
    
    
    'Create Premium CaptureMethode codes - column S
    If (Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("AV" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "") Then
        If ((Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("AV" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "")) Then
           Sheets("pricing").Range("S" & i).Value = "P" & Application.WorksheetFunction.Index(Sheets("dataref").Range("J:J"), Application.WorksheetFunction.Match(Sheets("txn").Range("D" & i).Value, Sheets("dataref").Range("I:I"), 0)) & Sheets("pricing").Range("AU" & i).Value & "C0" & Sheets("pricing").Range("AV" & i).Value
        Else: Sheets("pricing").Range("S" & i).Value = ""
        End If
        'Assigne PPI and PPC for every  - column T,U
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("T" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("S" & i).Value, Sheets("contract").Range("A:A"), 0))
        Sheets("pricing").Range("U" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("S" & i).Value, Sheets("contract").Range("A:A"), 0)) * 100 & "%"
    ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("T" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("S" & i).Value, Sheets("contract").Range("F:F"), 0))
        Sheets("pricing").Range("U" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("H:H"), Application.WorksheetFunction.Match(Sheets("pricing").Range("S" & i).Value, Sheets("contract").Range("F:F"), 0)) * 100 & "%"
    Else
        Sheets("pricing").Range("N" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
        Sheets("pricing").Range("O" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
    End If
    
    'Calculate PPC*FUND and PPC*FUND+PPI for Base Charge - column v,W
    If Sheets("pricing").Range("U" & i).Value <> "" Then
        Sheets("pricing").Range("V" & i).Value = Round(Abs(Sheets("pricing").Range("U" & i).Value * Sheets("pricing").Range("H" & i).Value), 6)
    Else: Sheets("pricing").Range("U" & i).Value = ""
    End If
    If Sheets("pricing").Range("T" & i).Value <> "" Then
        Sheets("pricing").Range("W" & i).Value = Abs(Sheets("pricing").Range("V" & i).Value + Sheets("pricing").Range("T" & i).Value)
    Else: Sheets("pricing").Range("W" & i).Value = ""
    End If
        End If
   
   
   'Create Premium Authorisation codes - column Y
    If (Sheets("txn").Range("G" & i).Value = "N") And (Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "") And ((Sheets("pricing").Range("F" & i).Value <> "Contactless") Or (Sheets("pricing").Range("F" & i).Value <> "OfflinePin")) Then
        If (Sheets("txn").Range("G" & i).Value = "N") And (Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "") And (Sheets("pricing").Range("F" & i).Value <> "Contactless") Or (Sheets("pricing").Range("F" & i).Value <> "OfflinePin") Then
           Sheets("pricing").Range("Y" & i).Value = "P" & Application.WorksheetFunction.Index(Sheets("dataref").Range("J:J"), Application.WorksheetFunction.Match(Sheets("txn").Range("D" & i).Value, Sheets("dataref").Range("I:I"), 0)) & Sheets("pricing").Range("AU" & i).Value & "A01"
        Else: Sheets("pricing").Range("Y" & i).Value = ""
        End If
        'Assigne PPI and PPC for every  - column Z,AA
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("Z" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("Y" & i).Value, Sheets("contract").Range("A:A"), 0))
        Sheets("pricing").Range("AA" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("Y" & i).Value, Sheets("contract").Range("A:A"), 0)) * 100 & "%"
    ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("Z" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("Y" & i).Value, Sheets("contract").Range("F:F"), 0))
        Sheets("pricing").Range("AA" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("H:H"), Application.WorksheetFunction.Match(Sheets("pricing").Range("Y" & i).Value, Sheets("contract").Range("F:F"), 0)) * 100 & "%"
    Else
        Sheets("pricing").Range("N" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
        Sheets("pricing").Range("O" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
    End If
    
    'Calculate PPC*FUND and PPC*FUND+PPI for Authorisation Charge - column AB,AC
    If Sheets("pricing").Range("AA" & i).Value <> "" Then
        Sheets("pricing").Range("AB" & i).Value = Round(Abs(Sheets("pricing").Range("AA" & i).Value * Sheets("pricing").Range("H" & i).Value), 6)
    Else: Sheets("pricing").Range("AA" & i).Value = ""
    End If
    If Sheets("pricing").Range("Z" & i).Value <> "" Then
        Sheets("pricing").Range("AC" & i).Value = Abs(Sheets("pricing").Range("AB" & i).Value + Sheets("pricing").Range("N" & i).Value)
    Else: Sheets("pricing").Range("AC" & i).Value = ""
    End If
        End If
 
 'Create Premium LOCALITY codes - column AE
   If (Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "") And (Sheets("txn").Range("D" & i).Value <> 12) Then
   If (Sheets("pricing").Range("AU" & i).Value <> "") And (Sheets("pricing").Range("M" & i).Value <> "") And (Sheets("txn").Range("D" & i).Value <> 12) Then
           Sheets("pricing").Range("AE" & i).Value = "P" & Application.WorksheetFunction.Index(Sheets("dataref").Range("J:J"), Application.WorksheetFunction.Match(Sheets("txn").Range("D" & i).Value, Sheets("dataref").Range("I:I"), 0)) & Sheets("pricing").Range("AU" & i).Value & "L" & Sheets("txn").Range("I" & i).Value
        Else:
        Sheets("pricing").Range("AE" & i).Value = ""
        End If
        'Assigne PPI and PPC for every  - column AF,AG
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("AF" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AE" & i).Value, Sheets("contract").Range("A:A"), 0))
        Sheets("pricing").Range("AG" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AE" & i).Value, Sheets("contract").Range("A:A"), 0)) * 100 & "%"
    ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("AF" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AE" & i).Value, Sheets("contract").Range("F:F"), 0))
        Sheets("pricing").Range("AG" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("H:H"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AE" & i).Value, Sheets("contract").Range("F:F"), 0)) * 100 & "%"
    Else
        Sheets("pricing").Range("N" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
        Sheets("pricing").Range("O" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
    End If
    
    'Calculate PPC*FUND and PPC*FUND+PPI for LOCALITY Charge - column AH,AI
    If Sheets("pricing").Range("AG" & i).Value <> "" Then
        Sheets("pricing").Range("AH" & i).Value = Round(Abs(Sheets("pricing").Range("AG" & i).Value * Sheets("pricing").Range("H" & i).Value), 6)
    Else: Sheets("pricing").Range("AG" & i).Value = ""
    End If
    If Sheets("pricing").Range("AF" & i).Value <> "" Then
        Sheets("pricing").Range("AI" & i).Value = Abs(Sheets("pricing").Range("AH" & i).Value + Sheets("pricing").Range("N" & i).Value)
    Else: Sheets("pricing").Range("AI" & i).Value = ""
    End If
    End If
    
    'CARD PROCESSED
    'Create Card Processed codes - column AK
   If (Sheets("txn").Range("E" & i).Value = "N") Then
    If (Sheets("txn").Range("E" & i).Value = "N") Then
        Sheets("pricing").Range("AK" & i).Value = "CPA" & Application.WorksheetFunction.Index(Sheets("dataref").Range("J:J"), Application.WorksheetFunction.Match(Sheets("txn").Range("D" & i).Value, Sheets("dataref").Range("I:I"), 0)) & Sheets("txn").Range("F" & i).Value
    Else: Sheets("pricing").Range("AK" & i).Value = ""
    End If
    
     'Assigne PPI and PPC for every CardProcessed code - column AL,AM
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("AL" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AK" & i).Value, Sheets("contract").Range("A:A"), 0))
        Sheets("pricing").Range("AM" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("C:C"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AK" & i).Value, Sheets("contract").Range("A:A"), 0)) * 100 & "%"
    ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("AL" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AK" & i).Value, Sheets("contract").Range("F:F"), 0))
        Sheets("pricing").Range("AM" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("H:H"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AK" & i).Value, Sheets("contract").Range("F:F"), 0)) * 100 & "%"
    Else
        Sheets("pricing").Range("N" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
        Sheets("pricing").Range("O" & i).Value = "No contract found for:" & Sheets("pricing").Range("A" & i).Value
    End If
    
    'Calculate PPC*FUND and PPC*FUND+PPI for CARD PROCESSED Charge - column AN,AO
    If Sheets("pricing").Range("AM" & i).Value <> "" Then
        Sheets("pricing").Range("AN" & i).Value = Round(Abs(Sheets("pricing").Range("AM" & i).Value * Sheets("pricing").Range("H" & i).Value), 6)
    Else: Sheets("pricing").Range("AM" & i).Value = ""
    End If
    If Sheets("pricing").Range("AL" & i).Value <> "" Then
        Sheets("pricing").Range("AO" & i).Value = Abs(Sheets("pricing").Range("AN" & i).Value + Sheets("pricing").Range("AL" & i).Value)
    Else: Sheets("pricing").Range("AO" & i).Value = ""
    End If
    End If
 
 'MISCELLANEOUS
 'Create Miscelaneus for AUTH codes - column AQ
    If (Sheets("txn").Range("K" & i).Value = "ELECTRONIC") Then
        If (Sheets("txn").Range("K" & i).Value = "ELECTRONIC") Then
            Sheets("pricing").Range("AQ" & i).Value = "MIS" & Sheets("txn").Range("J" & i).Value
        Else: Sheets("pricing").Range("AQ" & i).Value = ""
        End If
   'Assigne PPI and PPC for every CardProcessed code - column AL,AM
    If Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("D4").Value Then
        Sheets("pricing").Range("AR" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("B:B"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AQ" & i).Value, Sheets("contract").Range("A:A"), 0))
     ElseIf Sheets("pricing").Range("A" & i).Value = Sheets("contract").Range("I4").Value Then
        Sheets("pricing").Range("AR" & i).Value = Application.WorksheetFunction.Index(Sheets("contract").Range("G:G"), Application.WorksheetFunction.Match(Sheets("pricing").Range("AQ" & i).Value, Sheets("contract").Range("F:F"), 0))
    End If
    End If
        
 'Formateaza coloanele
    Sheets("pricing").Range("J" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("L" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("R" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("X" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("AD" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("AJ" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("AP" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("AS" & i).Interior.ColorIndex = 1
    Sheets("pricing").Range("AW" & i).Interior.ColorIndex = 1

 Next i
 
     'Calculeaza toate pricing events create
     'Base Charge events
    Sheets("pricing").Range("K3").Value = Application.Sum(Sheets("pricing").Range("K4:K1000").Value)
    Sheets("pricing").Range("M3").Value = Application.CountA(Sheets("pricing").Range("M4:M" & i).Value)
    

 'MsgBox "Calculation completed"


End Sub

